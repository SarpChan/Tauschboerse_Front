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
using System.Windows;

namespace Frontend
{
    /**
     * <summary>
     * </summary>
     */

    class RootPageViewModel : ViewModelBase
    {        
        //Loading Flag ob loading page angezeigt werden soll
        private bool _isLoading = false;
        public bool IsLoading {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }
        //TODO: RPVM Brauche ich die DependencyProperty fuer Variablen???
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(Page), typeof(RootPageViewModel), new UIPropertyMetadata(null));

        //TODO: RPVM Momentan aktive page die angezeigt wird (Idee: Frame.Source soll diese Variable benutzen)
        private Page _activePage = null;
        public Page ActivePage
        {
            get { return _activePage; }
            set
            {
                if (_activePage != value)
                {
                    _activePage = value;
                    OnPropertyChanged("ActivePage");
                    Console.WriteLine("ACTIVE PAGE = " + ActivePage);
                }
            }
        }
        public static readonly DependencyProperty ActivePageProperty =
            DependencyProperty.Register("ActivePage", typeof(Page), typeof(RootPageViewModel), new UIPropertyMetadata(null));


        //TODO: RPVM FRAGE: ICommand fuer den ButtonClick (!: Kann man einfach ein SwitchPage machen und irgendwie aus der GUI/View die geklickte page mitgeben?)
        private ICommand _SwitchToTimetablePageCommand; //Raffe gar nix grad
        public ICommand SwitchToTimetablePageCommand
        {
            get
            {
                if (_SwitchToTimetablePageCommand == null)
                {
                    _SwitchToTimetablePageCommand = new ActionCommand(dummy => this.ActivePage = TimetablePage.Instance);
                }
                Console.WriteLine("TT SWITCH");
                return _SwitchToTimetablePageCommand;
                
            }
        }
        public static readonly DependencyProperty SwitchToTimetablePageCommandProperty =
            DependencyProperty.Register("SwitchToTimetablePageCommand", typeof(ICommand), typeof(RootPageViewModel), new UIPropertyMetadata(null));

        //TODO: RPVM Waere das moeglich? Mache ich das "falsch rum"? also sollte die active page im view gesetzt werden?
        public void NavigateToPage(Page page)
         {
             ActivePage = page;
         }
         private ICommand _SwitchToActivePage;
         public ICommand SwitchToActivePage
         {
             get
             {
                 if (_SwitchToActivePage == null) //TODO: RPVM FRAGE: Kann man parameter in die commands geben? (TimetablePage). Wie kann man ueberhaupt auf irgendwas zugreifen? 
                 {
                     _SwitchToActivePage = new ActionCommand(page => NavigateToPage((Page)page));
                 }
                 return _SwitchToActivePage;
             }
         }
 
    }
}
