using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace Frontend.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        private int thisID;
        private Dictionary<string, string> userPass = new Dictionary<string, string>();

        private static LoginPageViewModel _instance;
        public static LoginPageViewModel Instance { get { return _instance; } } 

        public LoginPageViewModel()
        {
            IsLoggedIn = false;
            Username = "Nutzername";
            Password = "Passwort";
            userPass.Add("user", SHA256Gen.ComputeSha256Hash("login"));
            thisID = (int)(new Random().NextDouble() * 9999 ) + 1;
            Console.WriteLine("\"new LoginPageViewModel()\" InstanceID: " + thisID);
            _instance = this; //TODO ViewModel.LPVM: Klaeren wie das sonst gedacht ist. Ohne gleiche Instance geht das halt nicht mit login/logout etc...
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
                    MainViewModel.Instance.personalData.LoginUser(Username, SHA256Gen.ComputeSha256Hash(Password),"Dude");
                    MainViewModel.Instance.IsLoggedIn = true; //TODO ViewModel.LPVM: Herausfinden wie man von VM zu VM binded! Oder wie man das richtig macht! will ich ein new MainViewModel?
                    IsLoggedIn = true;
                    App.notifier.ShowSuccess("Einloggen erfolgreich");
                } 
                else
                {
                    App.notifier.ShowError("Falsches Passwort");
                }
            }
            else
            {
                App.notifier.ShowWarning("Unbekannter Benutzername");
            }
        }
        #endregion
    }
}
