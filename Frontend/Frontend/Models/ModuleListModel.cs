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
                ID = "0",
                StartTime = "10:15",
                EndTime = "09:45",
                Day = "0",
                PersonName = "Nick",
                RoomNumber = "D14",
                CourseName = "Entwicklung Interaktiver Benutzeroberflächen",
                Color = "#FFF4A233"
            });
            AddModule(new ModuleDummy()
            {
                ID = "1",
                StartTime = "14:15",
                EndTime = "15:45",
                Day = "3",
                PersonName = "Olli",
                RoomNumber = "D17",
                CourseName = "Programmieren 3",
                Color = "#FFA8EEDD"
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

    public class ModuleDummy
    {
        public string ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RoomNumber { get; set; }
        public string PersonName { get; set; }
        public string CourseName { get; set; }
        public string Color { get; set; }
        public string Day { get; set; }
    }

}
