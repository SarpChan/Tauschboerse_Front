using System;
using System.Windows.Input;
using Frontend.Helpers;
using System.Windows.Controls;
using Frontend.View;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable;
using System.Threading;

namespace Frontend
{
    /**
     * <summary>
     * </summary>
     */

    class RootPageViewModel : ViewModelBase
    {
        #region properties
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
        #endregion

        public RootPageViewModel()
        {
            ActivePage = new HomePage();
            IsLoading = false;
        }

        #region commands
        private ICommand _SwitchToHomePageCommand;
        public ICommand SwitchToHomePageCommand
        {
            get
            {
                if (_SwitchToHomePageCommand == null)
                {
                    _SwitchToHomePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new HomePage()));
                }
                return _SwitchToHomePageCommand;
            }
        }

        private ICommand _SwitchToTimetablePageCommand;
        public ICommand SwitchToTimetablePageCommand
        {
            get
            {
                if (_SwitchToTimetablePageCommand == null)
                {
                    _SwitchToTimetablePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new TimetablePage()));
                }
                return _SwitchToTimetablePageCommand;
            }
        }

        private ICommand _SwitchToSharingServicePageCommand;
        public ICommand SwitchToSharingServicePage
        {
            get
            {
                if (_SwitchToSharingServicePageCommand == null)
                {
                    _SwitchToSharingServicePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new SharingServicePage()));
                }
                return _SwitchToSharingServicePageCommand;
            }
        }

        private ICommand _SwitchToPersonalDataPageCommand;
        public ICommand SwitchToPersonalDataPageCommand
        {
            get
            {
                if (_SwitchToPersonalDataPageCommand == null)
                {
                    _SwitchToPersonalDataPageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new PersonalDataPage()));
                }
                return _SwitchToPersonalDataPageCommand;
            }
        }

        private ICommand _SwitchToAdminPageCommand;
        public ICommand SwitchToAdminPageCommand
        {
            get
            {
                if (_SwitchToAdminPageCommand == null)
                {
                    _SwitchToAdminPageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new AdminPage()));
                }
                return _SwitchToAdminPageCommand;
            }
        }

        private ICommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (_LogoutCommand == null)
                {
                    _LogoutCommand = new ActionCommand(dummy => this.SwitchActivePageAsync(new HomePage()));
                }
                return _LogoutCommand;
            }
        }
        #endregion

        #region methods
        private async void SwitchActivePageAsync(Page newActivePage)
        {
            if (newActivePage.GetType().Equals(typeof(HomePage)))
            {
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(TimetablePage)))
            {
                SwitchIsLoading();
                await RequestTimetableFromServerAsync();
                SwitchIsLoading();
            }
            else if (newActivePage.GetType().Equals(typeof(SharingServicePage)))
            {
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(PersonalDataPage)))
            {
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(AdminPage)))
            {
                IsLoading = true;
            }
            else
            {
                return;
            }
            ActivePage = newActivePage;
        }

        private void SwitchIsLoading()
        {
            IsLoading = !IsLoading;
        }


        public async Task RequestTimetableFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/module/read", Method.GET); //REST Path
            //var request = new RestRequest("rest/timetable", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            //request.AddParameter("studentID", ActiveStudent.EnrolemenNumber);
            request.AddParameter("moduleID", "1001337"); //Adds "?moduleID=1001337" to Path
            var body = new
            {
                Id = "",
                Slots = "",
                Day = "",
                Term = "",
                CourseComponent = "",
                Lecture = "",
                Room = "",
                Students = ""
            };
            request.AddJsonBody(body);
            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            Console.WriteLine(response.Content);
            cancellationTokenSource.Dispose();
        }
    
        #endregion
    }
}
