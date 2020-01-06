using System;
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
            ActiveUser = new User();
            ActiveUser.Roles.Add(new Student());
            foreach (Role role in ActiveUser.Roles) {
                if (role.GetType().Equals(typeof(Student))){
                    ((Student)role).EnrollmentNumber = 313373;
                    break;
                }
            }
            _instance = this;
        }

        public void LogoutUser()
        {
            ActiveUser = new User();
        }

        public void LoginUser(string loginname, string password, string firstname)
        {
            ActiveUser.Loginname = loginname;
            ActiveUser.Password = password;
            ActiveUser.Firstname = firstname;
            //Console.WriteLine("loginname=" + loginname + "\npassword=" + password + "\nfirstname=" + firstname + "\nid=" + ActiveUser.Id);
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
