using Frontend.Helpers;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using ToastNotifications.Messages;

namespace Frontend.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        private int thisID;
        private static LoginPageViewModel _instance;
        public static LoginPageViewModel Instance { get { return _instance; } }

        string mode = ConfigurationManager.AppSettings.Get("login.mode");

        public LoginPageViewModel()
        {
            switch(mode) {
                case "debug":
                    IsLoggedIn = true; //TODO ViewModel.LPVM: Besser in PersonalData?
                    break;

                case "normal":
                    IsLoggedIn = false; //TODO ViewModel.LPVM: Besser in PersonalData?
                    break;
            }
            Username = "Nutzername";
            Password = "Passwort";
            thisID = (int)(new Random().NextDouble() * 9999 ) + 1;
            _instance = this;
        }

        #region commands
        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new ActionCommand(pwBox => this.ProcessLogin());
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

        internal async void ProcessLogin()
        {
            APIClient apiClient = APIClient.Instance;
            IsLoggedIn = await apiClient.SendLogin(Username, Password);
            if (IsLoggedIn)
            {
                App.notifier.ShowSuccess("Einloggen erfolgreich");
                if(UserInformation.Instance.IsAdmin)
                {
                    MainViewModel.Instance.SwitchActivePageAsync("AdminPage.xaml");
                } else
                {
                    MainViewModel.Instance.SwitchActivePageAsync("SharingServicePage.xaml");
                }
                
            }
            
        }
        #endregion
    }
}
