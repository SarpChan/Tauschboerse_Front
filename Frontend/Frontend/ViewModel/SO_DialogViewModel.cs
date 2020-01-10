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
        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand { get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }
     
}
