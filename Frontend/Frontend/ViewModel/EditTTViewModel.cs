using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.TT
{
    public class EditTTViewModel
    {
        public EditTTViewModel()
        {
            //TT_SaveButtonCommand = new ICommand(new Action<object>(ShowMessage));
        }

        private ICommand m_ButtonCommand;

        public ICommand TT_SaveButtonCommand
        {
            get { return m_ButtonCommand; }
            set { m_ButtonCommand = value; }
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show("Test");
        }
    }
}
