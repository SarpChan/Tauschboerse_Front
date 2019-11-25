using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Specialized;
using Frontend.Models;
using HttpUtils;
using Newtonsoft.Json;
using Timetable;
using Frontend.Helpers;
using System.Windows.Controls;
using Frontend.View;

namespace Frontend
{
    /**
     * <summary>
     * </summary>
     */

    class RootPageViewModel : ViewModelBase
    {
        public bool IsLoading { get; set; }

        private Page _ActivePage = null;
        public Page ActivePage
        {
            get { return _ActivePage; }
            set
            {
                if (_ActivePage != value)
                {
                    _ActivePage = value;
                    OnPropertyChanged("ActivePage");
                }
            }
        }

        private ICommand _SwitchToTimetablePage; //Raffe gar nix grad
        public ICommand SwitchToTimetablePage
        {
            get
            {
                if (_SwitchToTimetablePage == null)
                {
                    _SwitchToTimetablePage = new ActionCommand(dummy => this.ActivePage = new TimetablePage());
                }
                return _SwitchToTimetablePage;
            }
        }


    }
}
