using Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class TimetabeItem : ViewModelBase
    {
        private ICommand _DialogOpen_ButtonCommand;
        public ICommand DialogOpenCommand
        {
            get
            {
                return _DialogOpen_ButtonCommand;
            }
            set { _DialogOpen_ButtonCommand = value; }
        }
    }
}
