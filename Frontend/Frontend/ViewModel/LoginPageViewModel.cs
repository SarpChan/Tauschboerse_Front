using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace Frontend.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        /*
         * Notifier fuer die Toast-Benachrichtigungen
         */
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: App.Current.MainWindow,
                corner: Corner.BottomCenter,
                offsetX: 10,
                offsetY: 10);
            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3), // Leben 3 Sekunden
                maximumNotificationCount: MaximumNotificationCount.FromCount(3)); // Maximal 3 auf einmal
            cfg.DisplayOptions.Width = 750;
            cfg.Dispatcher = App.Current.Dispatcher;
        });


        private Dictionary<string, string> userPass = new Dictionary<string, string>();

        private static LoginPageViewModel _instance;
        public static LoginPageViewModel Instance { get { return _instance; } } 

        Random generator = new Random();
        int myID;
        
        public LoginPageViewModel()
        {
            IsLoggedIn = false;
            Username = "Nutzername";
            Password = "Passwort";
            userPass.Add("Test", SHA256Gen.ComputeSha256Hash("Test"));
            myID = (int)(generator.NextDouble() * 9999 ) + 1;
            Console.WriteLine("NEW LOGINPAGEVIEWMODEL " + myID);
            _instance = this; //TODO: klaeren wie das sonst gedacht ist. ohne gleiche instance geht das halt nicht mit login/logout etc...
        }

        #region commands
        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new ActionCommand(dummy => this.ProcessLogin());
                }
                return _LoginCommand;
            }
        }
        #endregion

        #region properties
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged("IsLoggedIn");
                    Console.WriteLine("LOGGED IN == " + value);
                }
            }
        }
        #endregion

        #region methods
        private void ProcessLogin()
        {
           if(userPass.ContainsKey(Username))
            {
                if (userPass[Username].Equals(SHA256Gen.ComputeSha256Hash(Password)))
                {
                    MainViewModel.Instance.personalData.ActiveStudent = new Student();
                    MainViewModel.Instance.personalData.ActiveStudent.Firstname = "Dude";
                    MainViewModel.Instance.IsLoggedIn = true; //TODO -> Herausfinden wie man von VM zu VM binded! Oder wie man das richtig macht! will ich ein new MainViewModel?
                    IsLoggedIn = true;
                    notifier.ShowSuccess("Login succesful");
                } 
                else
                {
                    notifier.ShowError("Wrong password");
                }
            }
            else
            {
                notifier.ShowWarning("Wrong username");
            }
        }
        #endregion
    }
}
