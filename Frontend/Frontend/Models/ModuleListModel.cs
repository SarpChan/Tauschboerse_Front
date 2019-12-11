using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    class ModuleListModel
    {
        //Hier eig liste mit Modulen reingereicht??
        public ModuleListModel()
        {
            AddModule(new ModuleDummy()
            {
                ID = "69",
                StartTime = "10:00",
                EndTime = "11:30",
                Day = "1",
                PersonName = "Lukas",
                RoomNumber = "D14",
                CourseName = "EIBO",
                Color = "#FFF4A233"
            });
            AddModule(new ModuleDummy()
            {
                ID = "69",
                StartTime = "10:00",
                EndTime = "11:30",
                Day = "1",
                PersonName = "Marc",
                RoomNumber = "D42",
                CourseName = "VS Code für anfänger",
                Color = "#FFF4A233"
            });
            AddModule(new ModuleDummy()
            {
                ID = "1",
                StartTime = "08:15",
                EndTime = "15:45",
                Day = "3",
                PersonName = "Olli",
                RoomNumber = "D17",
                CourseName = "Programmieren 3",
                Color = "#FFA8EEDD"
            });
            AddModule(new ModuleDummy()
            {
                ID = "1",
                StartTime = "08:15",
                EndTime = "09:45",
                Day = "0",
                PersonName = "Nicklas",
                RoomNumber = "D11",
                CourseName = "Programmieren 3",
                Color = "#FFA16C17"
            });
            AddModule(new ModuleDummy()
            {
                ID = "1",
                StartTime = "09:15",
                EndTime = "11:45",
                Day = "4",
                PersonName = "Sonntag",
                RoomNumber = "D8",
                CourseName = "Programmieren 4",
                Color = "#FFABCDEF"
            });
            AddModule(new ModuleDummy()
            {
                ID = "1",
                StartTime = "12:00",
                EndTime = "15:00",
                Day = "2",
                PersonName = "Sanja",
                RoomNumber = "D17",
                CourseName = "Programmieren 1",
                Color = "#FF99AA88"
            });
        }

        private List<ModuleDummy> _moduleList = new List<ModuleDummy>();

        public void AddModule(ModuleDummy m)
        {
            _moduleList.Add(m);
        }
        public void RemoveModule(ModuleDummy m)
        {
            _moduleList.Remove(m);
        }

        public List<ModuleDummy> ModuleList { get { return _moduleList; } }
    }

    /// <summary>
    /// Dummy Model für eine Module
    /// </summary>
    public class ModuleDummy
    {
        public enum ModuleType {Vorlesung,Übung,Praktikum,Tutorium};
        public string ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RoomNumber { get; set; }
        public string PersonName { get; set; }
        public string CourseName { get; set; }
        public string Color { get; set; }
        public string Day { get; set; }
        public ModuleType Type { get; set; }
    }

}
