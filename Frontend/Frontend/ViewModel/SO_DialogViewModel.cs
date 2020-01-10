using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
    class SO_DialogViewModel
    {
        private ICommand _DialogClose_ButtonCommand;
        public ICommand DialogCloseCommand
        {
            get
            {
                return _DialogClose_ButtonCommand;
            }
            set { _DialogClose_ButtonCommand = value; }
        }
    }
}
