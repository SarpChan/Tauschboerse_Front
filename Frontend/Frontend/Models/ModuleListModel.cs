using Frontend.Helpers.Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    
    class ModuleListModel
    {
        private ObservableCollection<TimetableModule> _moduleList = new ObservableCollection<TimetableModule>();
        public ObservableCollection<TimetableModule> ModuleList { get { return _moduleList; } }

        private static ModuleListModel _instance;

        public static ModuleListModel Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new ModuleListModel();
                }
            }
        }

        private ModuleListModel()
        {
            _instance = this;
        }

        public async void AddModule(TimetableModule m)
        {
            Task gameTask = Task.Factory.StartNew(() =>
            {
                _moduleList.Add(m);
            });
        }

        public void RemoveModule(TimetableModule m)
        {
            Task gameTask = Task.Factory.StartNew(() =>
            {
                _moduleList.Remove(m);
            });
        }

        public void SetList(ObservableCollection<TimetableModule> moduleList)
        {
            Task gameTask = Task.Factory.StartNew(() =>
            {
                _moduleList.Clear();
                foreach( var x in moduleList){
                    _moduleList.Add(x);
                }
            });
        }
    }
}

/**
 * 
 *             AddModule(new ModuleDummy()
            {
                ID = "69",
                StartTime = "10:00",
                EndTime = "12:30",
                Day = "1",
                PersonName = "Lukas",
                RoomNumber = "D14",
                CourseName = "EIBO",
                GroupChar = 'B',
                Color = "#FFF4A233"
            });
            AddModule(new ModuleDummy()
            {
                ID = "17",
                StartTime = "10:00",
                EndTime = "11:30",
                Day = "1",
                PersonName = "Marc",
                Type = ModuleDummy.ModuleType.Tutorium,
                RoomNumber = "D42",
                CourseName = "VS Code für anfänger",
                Color = "#FFF4A233"
            });

            AddModule(new ModuleDummy()
            {
                ID = "70",
                StartTime = "10:00",
                EndTime = "12:30",
                Day = "1",
                PersonName = "Dude",
                RoomNumber = "D21",
                CourseName = "EIBO 2",
                Type = ModuleDummy.ModuleType.Vorlesung,
                GroupChar = 'B',
                Color = "#FFF4A233"
            });

            AddModule(new ModuleDummy()
            {
                ID = "65",
                StartTime = "11:30",
                EndTime = "15:00",
                Day = "1",
                PersonName = "Marc",
                RoomNumber = "D42",
                CourseName = "Computergrafik",
                Type = ModuleDummy.ModuleType.Übung,
                Color = "#FFF4A233"
            });
            AddModule(new ModuleDummy()
            {
                ID = "7",
                StartTime = "08:15",
                EndTime = "09:45",
                Day = "0",
                PersonName = "Nicklas",
                RoomNumber = "D11",
                CourseName = "Programmieren 3",
                GroupChar = 'H',
                Color = "#FFA16C17"
            });
            AddModule(new ModuleDummy()
            {
                ID = "14",
                StartTime = "09:15",
                EndTime = "11:45",
                Day = "4",
                PersonName = "Sonntag",
                RoomNumber = "D8",
                CourseName = "Programmieren 4",
                GroupChar = 'A',
                Color = "#FFABCDEF"
            });
            AddModule(new ModuleDummy()
            {
                ID = "89",
                StartTime = "12:00",
                EndTime = "15:00",
                Day = "2",
                PersonName = "Sanja",
                RoomNumber = "D17",
                CourseName = "Programmieren 1",
                GroupChar = 'A',
                Color = "#FF99AA88"
            });
 */
