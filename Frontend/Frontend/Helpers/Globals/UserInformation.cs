using Frontend.Helpers.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    class UserInformation : NotifyPropertyValueChange
    {
        private static UserInformation _Instance;

        public static UserInformation Instance
        {
            get
            {
                if (_Instance != null)
                {
                    return _Instance;
                }
                else
                {
                    _Instance = new UserInformation();
                    return _Instance;
                }
            }
        }

        private string _UserName = "Unkown";
        public string UserName { get { return _UserName; }
            set {
                var oldValue = _UserName;
                _UserName = value;
                NotifyPropertyChanged("UserName", oldValue, value);
            } 
        }

        private long _UserId = -1;
        public long UserId
        {
            get { return _UserId; }
            set
            {
                var oldValue = _UserId;
                _UserId = value;
                NotifyPropertyChanged("UserId", oldValue, value);
            }
        }

        private bool _IsAdmin = false;
        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                var oldValue = _IsAdmin;
                _IsAdmin = value;
                NotifyPropertyChanged("IsAdmin", oldValue, value);
            }
        }

    }
}
