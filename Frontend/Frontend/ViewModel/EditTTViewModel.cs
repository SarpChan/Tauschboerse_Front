﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModel
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

        public ICommand TT_TimeButtonCommand
        {
            get { return m_ButtonCommand; }
            set { m_ButtonCommand = value; }
        }
        public ICommand TT_DetailButtonCommand
        {
            get { return m_ButtonCommand; }
            set { m_ButtonCommand = value; }
        }

        public ICommand TT_ComponentButtonCommand
        {
            get { return m_ButtonCommand; }
            set { m_ButtonCommand = value; }
        }
        public ICommand TT_DeleteButtonCommand
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
