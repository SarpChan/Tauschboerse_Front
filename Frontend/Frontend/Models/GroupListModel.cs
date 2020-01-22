using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class GroupListModel
    {
        private ObservableCollection<Group> _groupList = new ObservableCollection<TimetableModule>();
        public ObservableCollection<Group> ModuleList { get { return _groupList; } }

        private static GroupListModel _instance;

        public static GroupListModel Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new GroupListModel();
                }
            }
        }

        private GroupListModel()
        {
            _instance = this;
        }

        public void SetList(ObservableCollection<Group> GroupList)
        {
            _groupList.Clear();
            foreach (var x in GroupList)
            {
                _groupList.Add(x);
            }
        }

    }
}
