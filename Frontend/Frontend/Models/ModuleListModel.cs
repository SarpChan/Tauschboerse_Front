using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    class ModuleListModel
    {
        //Hier eig liste mit Modulen reingereicht
        public ModuleListModel()
        {
            int i = 0;
            foreach (string module in new string[] { "Prog3", "EIBO" })
            {
                AddModule(new ModuleDummy() { ID = ""+(i++), Name = module });
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

    class ModuleDummy
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
