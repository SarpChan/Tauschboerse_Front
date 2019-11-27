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
            int i = 0;
            foreach (string module in new string[] { "Prog3", "EIBO" })
            {
                if(i == 0)
                {
                    AddModule(new ModuleDummy() { ID = "" + (i++), Name = module, StartTime = "0815", EndTime = "0945", Day = "0" });
                } else
                {
                    AddModule(new ModuleDummy() { ID = "" + (i++), Name = module, StartTime = "1000", EndTime = "1130", Day = "3" });
                }
                
            }
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
        public string Name { get; set; }
        public string ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string Day { get; set; }
    }

}
