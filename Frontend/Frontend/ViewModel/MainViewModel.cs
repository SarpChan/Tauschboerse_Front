using System.Windows.Input;
using Frontend.Helpers;
using System.Windows.Controls;
using Frontend.View;
using RestSharp;
using System.Threading.Tasks;
using System.Threading;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.ViewModel
{
    /**
     * <summary>
     * RootPage ViewModel. Hat alle Properties, ICommands und Methoden fuer die View RootPage. Benennung historisch bedingt.
     * TODO: Refactor to 'RootPageViewModel'
     * </summary>
     */

    class MainViewModel : ViewModelBase
    {
        public PersonalData personalData;
        public TimetableData timetableData;

        public MainViewModel()
        {
            ActivePage = new HomePage();
            IsLoading = false;
            personalData = new PersonalData();
            timetableData = new TimetableData();
            
        }

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
                }
            }
        }

        //Aktuell angezeigte Page. Frame hat Binding darauf um zu switchen
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
                }
            }
        }
        #endregion

        #region commands
        /*
         * Alle ICommands für die Button-Funktionen
         */
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
        /*
         * Handled das Page-Switchen inkl. asynchroner Anfrage an den Server und anzeigen des Loading Screens
         */
        private async void SwitchActivePageAsync(Page newActivePage)
        {
            if (newActivePage.GetType().Equals(typeof(HomePage)))
            {
                SwitchIsLoading();
                await RequestNewsFromServerAsync();
                SwitchIsLoading();
            }
            else if (newActivePage.GetType().Equals(typeof(TimetablePage)))
            {
                SwitchIsLoading();
                await RequestTimetableFromServerAsync();
                SwitchIsLoading();
            }
            else if (newActivePage.GetType().Equals(typeof(SharingServicePage)))
            {
                SwitchIsLoading();
                await RequestSharingDataFromServerAsync();
                SwitchIsLoading();
            }
            else if (newActivePage.GetType().Equals(typeof(PersonalDataPage)))
            {
                SwitchIsLoading();
                await RequestPersonalDataFromServerAsync();
                SwitchIsLoading();
            }
            else if (newActivePage.GetType().Equals(typeof(AdminPage)))
            {
                SwitchIsLoading();
                await RequestAdminDataFromServerAsync();
                SwitchIsLoading();
            }
            else
            {
                return;
            }
            ActivePage = newActivePage;
        }

        /*
         * Simple Methode zum ändern des IsLoading-Zustands
         */
        private void SwitchIsLoading()
        {
            IsLoading = !IsLoading;
        }

        /*
         * Request an REST-Schnittstelle des Servers fuer Stundenplan senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        public async Task RequestTimetableFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/lists/timetable", Method.GET); //REST Path
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("studentID", personalData.ActiveStudent.EnrolementNumber); //Adds "?studentID='EnrolementNumber'" to Path

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            timetableData.CurrentCurriulum = JsonConvert.DeserializeObject<Curriculum>(response.Content.ToString());

            /*Zum Testen
            string jsonFileString;
            StreamReader streamReader = File.OpenText("..\\..\\Models\\GroupListFromServer.json");
            jsonFileString = streamReader.ReadToEnd();
            Zum Testen*/

            cancellationTokenSource.Dispose();
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestNewsFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/lists/news", Method.GET); //REST Path
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("studentID", personalData.ActiveStudent.EnrolementNumber); //Adds "?studentID='EnrolementNumber'" to Path

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            //TODO: NEWS VOM SERVER JSON-SERIALISIEREN

            cancellationTokenSource.Dispose();
        }


        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestSharingDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/lists/sharingData", Method.GET); //REST Path
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("studentID", personalData.ActiveStudent.EnrolementNumber); //Adds "?studentID='EnrolementNumber'" to Path

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            //TODO: SHARINGDATA VOM SERVER JSON-SERIALISIEREN (response.Content)

            cancellationTokenSource.Dispose();
        }


        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestPersonalDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/lists/personalData", Method.GET); //REST Path
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("studentID", personalData.ActiveStudent.EnrolementNumber); //Adds "?studentID='EnrolementNumber'" to Path

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            //TODO: PERSONAL_DATA VOM SERVER JSON-SERIALISIEREN (response.Content)

            cancellationTokenSource.Dispose();
        }


        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestAdminDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/"); //Base-URL
            var request = new RestRequest("/rest/lists/adminData", Method.GET); //REST Path
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("studentID", personalData.ActiveStudent.EnrolementNumber); //Adds "?studentID='EnrolementNumber'" to Path

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            //TODO: ADMIN_DATA VOM SERVER JSON-SERIALISIEREN (response.Content)

            cancellationTokenSource.Dispose();
        }
        #endregion
    }
}
