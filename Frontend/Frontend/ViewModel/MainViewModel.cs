using System.Windows.Input;
using Frontend.Helpers;
using System.Windows.Controls;
using Frontend.View;
using RestSharp;
using System.Threading.Tasks;
using System.Threading;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ToastNotifications.Messages;

namespace Frontend.ViewModel
{
    /**
     * <summary>
     * RootPage ViewModel. Hat alle Properties, ICommands und Methoden fuer die View RootPage. Benennung historisch bedingt.
     * </summary>
     */

    class MainViewModel : ViewModelBase
    {
        public PersonalData personalData;
        public TimetableData timetableData;

        private int thisID;

        private static MainViewModel _instance;
        public static MainViewModel Instance { get { return _instance; } }

        public MainViewModel()
        {
            ActivePage = new HomePage();
            IsLoading = false;
            IsLoggedIn = false;
            personalData = PersonalData.Instance;
            timetableData = new TimetableData();
            thisID = (int)(new Random().NextDouble() * 9999) + 1;
            Console.WriteLine("\"NEW MAIN_VIEWMODEL\" InstanceID: "  + thisID);
            _instance = this;
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

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged("IsLoggedIn");
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
        public ICommand SwitchToSharingServicePageCommand
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
                    _LogoutCommand = new ActionCommand(dummy => this.Logout());
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
                IsLoading = true;
                await RequestNewsFromServerAsync();
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(TimetablePage)))
            {
                IsLoading = true;
                await RequestTimetableFromServerAsync();
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(SharingServicePage)))
            {
                IsLoading = true;
                await RequestSharingDataFromServerAsync();
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(PersonalDataPage)))
            {
                IsLoading = true;
                await RequestPersonalDataFromServerAsync();
                IsLoading = false;
            }
            else if (newActivePage.GetType().Equals(typeof(AdminPage)))
            {
                IsLoading = true;
                await RequestAdminDataFromServerAsync();
                IsLoading = false;
            }
            else
            {
                return;
            }
            ActivePage = newActivePage;
        }

        private void Logout()
        {
            this.SwitchActivePageAsync(new HomePage());
            personalData.LogoutUser();
            this.IsLoggedIn = false; //TODO ViewModel.MVM: von VM zu VM binden? -> Besser: sowas im Model speichern
            LoginPageViewModel.Instance.IsLoggedIn = false;
            App.notifier.ShowSuccess("Ausloggen erfolgreich");
        }
       
        /*
         * Request an REST-Schnittstelle des Servers fuer Stundenplan senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        public async Task RequestTimetableFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/");
            var request = new RestRequest("/rest/lists/timetable", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { EnrollmentNumber = personalData.getEnrollmentNumber() });
            
            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);

            timetableData.Timetable = JsonConvert.DeserializeObject<List<Module>>(response.Content.ToString());

            /*Zum Testen
            string jsonFileString;
            StreamReader streamReader = File.OpenText("..\\..\\Models\\timetable_stupla.json");
            jsonFileString = streamReader.ReadToEnd();
            timetableData.Timetable = JsonConvert.DeserializeObject<List<Module>>(jsonFileString);
            Console.WriteLine("response from server: " + response.Content);
            //Zum Testen*/

            cancellationTokenSource.Dispose();
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestNewsFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/");
            var request = new RestRequest("/rest/lists/timetable", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { EnrollmentNumber = personalData.getEnrollmentNumber() });

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            //TODO ViewModel.MVM: NEWS vom Server in JSON Serialisieren

            cancellationTokenSource.Dispose();
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestSharingDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/");
            var request = new RestRequest("/rest/lists/timetable", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { EnrollmentNumber = personalData.getEnrollmentNumber() });

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            //TODO ViewModel.MVM: SHARING_DATA vom Server in JSON Serialisieren

            cancellationTokenSource.Dispose();
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestPersonalDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/");
            var request = new RestRequest("/rest/lists/timetable", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { EnrollmentNumber = personalData.getEnrollmentNumber() });

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            //TODO ViewModel.MVM: PERSONAL_DATA vom Server in JSON Serialisieren

            cancellationTokenSource.Dispose();
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestAdminDataFromServerAsync()
        {
            var client = new RestClient("http://localhost:8080/");
            var request = new RestRequest("/rest/lists/timetable", Method.POST);
            var cancellationTokenSource = new CancellationTokenSource();

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { EnrollmentNumber = personalData.getEnrollmentNumber() });

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            //TODO ViewModel.MVM: ADMIN_DATA vom Server in JSON Serialisieren

            cancellationTokenSource.Dispose();
        }
        #endregion
    }
}
