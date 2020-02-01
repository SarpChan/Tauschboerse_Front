using System.ComponentModel;

namespace Frontend.Models
{
    /**
     * Diese Klasse enthaelt alle ModelDaten betreffend der Eigenen Daten
     */
    class PersonalData : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private User _activeUser = new User();
        public User ActiveUser
        {
            get { return _activeUser; }
            set
            {
                if (value != _activeUser)
                {
                    _activeUser = value;
                    OnPropertyChanged("ActiveUser");
                }
            }
        }

        /*private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (value != _isLoggedIn)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged("IsLoggedIn");
                }
            }
        }*/

        private static PersonalData _instance;
        public static PersonalData Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new PersonalData();
                }
            }
        }

        private PersonalData()
        {
            _activeUser.Roles.Add(new Student());
            foreach (Role role in _activeUser.Roles) {
                if (role.GetType().Equals(typeof(Student))){
                    ((Student)role).EnrollmentNumber = 313373;
                    break;
                }
            }
            //_isLoggedIn = false;
            _instance = this;
        }

        public void LogoutUser()
        {
            _activeUser = new User();
        }

        public void LoginUser(string loginname, string password, string firstname) //TODO Model.PersonalData: mit daten fuellen die vom server kommen
        {
            _activeUser.Loginname = loginname;
            _activeUser.Password = password;
            _activeUser.Firstname = firstname;
        }

        public long getEnrollmentNumber() {
            foreach (Role role in ActiveUser.Roles) {
                if (role.GetType().Equals(typeof(Student))) {
                    return ((Student)role).EnrollmentNumber;
                }
            }
            return 0;
        }
    }

}
