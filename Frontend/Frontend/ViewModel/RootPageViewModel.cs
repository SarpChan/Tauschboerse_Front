using System;
using System.Windows.Input;
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
        private bool _isLoading;
        public bool IsLoading {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                    Console.WriteLine("IS LOADING = " + IsLoading);
                }
            }
        }

        //TODO: RPVM Momentan aktive page die angezeigt wird (Idee: Frame.Source soll diese Variable benutzen)
        private Page _activePage;
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
                    Console.WriteLine(ActivePage.GetType().FullName);
                }
            }
        }

        public RootPageViewModel()
        {
            ActivePage = new HomePage();
            IsLoading = false;
        }

        //TODO: RPVM FRAGE: ICommand fuer den ButtonClick (!: Kann man einfach ein SwitchPage machen und irgendwie aus der GUI/View die geklickte page mitgeben?)
        private ICommand _SwitchToTimetablePageCommand; //Raffe gar nix grad
        public ICommand SwitchToTimetablePageCommand
        {
            get
            {
                if (_SwitchToTimetablePageCommand == null)
                {
                    _SwitchToTimetablePageCommand = new ActionCommand(dummy => this.SwitchActivePage(TimetablePage.Instance));
                }
                Console.WriteLine("TTP SWITCH");
                return _SwitchToTimetablePageCommand;
                
            }
        }

        private ICommand _SwitchToHomePageCommand;
        public ICommand SwitchToHomePageCommand
        {
            get
            {
                if (_SwitchToHomePageCommand == null)
                {
                    _SwitchToHomePageCommand = new ActionCommand(dummy => this.SwitchActivePage(HomePage.Instance)); 
                }
                Console.WriteLine("HP SWITCH");
                return _SwitchToHomePageCommand;

            }
        }

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

        private void SwitchActivePage(Page ap)
        {
            if(ap.GetType().Equals(typeof(TimetablePage)))
            {
                IsLoading = true;
            } else
            {
                IsLoading = false;
            }
            ActivePage = ap;
        }

        private void SwitchIsLoading()
        {
            IsLoading = !IsLoading;
        }

    }
}
