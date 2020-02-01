using System.Windows.Input;
using Frontend.Helpers;
using System.Windows.Controls;
using Frontend.View;
using System.Threading.Tasks;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ToastNotifications.Messages;
using Frontend.Helpers.Generators;
using System.Configuration;
using System.Collections.ObjectModel;

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
        public ModuleListModel ModuleList;
        string mode = ConfigurationManager.AppSettings.Get("login.mode");

        private int thisID;
        
        
        private static MainViewModel _instance;
        public static MainViewModel Instance { get { return _instance; } }

        SwapOfferMessageBroker so_mb;

        public MainViewModel()
        {
            ActivePage = "SharingServicePage.xaml";
            IsLoading = false;
            personalData = PersonalData.Instance;
            ModuleList = ModuleListModel.Instance;
            thisID = (int)(new Random().NextDouble() * 9999) + 1;
            so_mb = new SwapOfferMessageBroker();
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
        private string _activePage;
        public string ActivePage
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

        private ICommand pythonscriptUpload_ButtonCommand;

        public ICommand UploadPythonscriptCommand
        {
            get { return pythonscriptUpload_ButtonCommand; }
            set { pythonscriptUpload_ButtonCommand = value; }
        }

        private ICommand _SwitchToHomePageCommand;
        public ICommand SwitchToHomePageCommand
        {
            get
            {
                if (_SwitchToHomePageCommand == null)
                {
                    _SwitchToHomePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("HomePage.xaml"));
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
                    _SwitchToTimetablePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("TimetablePage.xaml"));
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
                    _SwitchToSharingServicePageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("SharingServicePage.xaml"));
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
                    _SwitchToPersonalDataPageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("StudentModulePage.xaml"));
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
                    _SwitchToAdminPageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("AdminPage.xaml"));
                }
                return _SwitchToAdminPageCommand;
            }
        }

        private ICommand _SwitchToPythonUploadPageCommand;
        public ICommand SwitchToPythonUploadPageCommand
        {
            get
            {
                if (_SwitchToPythonUploadPageCommand == null)
                {
                    _SwitchToPythonUploadPageCommand = new ActionCommand(dummy => this.SwitchActivePageAsync("PythonUpload.xaml"));
                }
                return _SwitchToPythonUploadPageCommand;
            }
        }

        private ICommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (_LogoutCommand == null)
                {
                    _LogoutCommand = new ActionCommand(dummy => this.Logout(200));
                }
                return _LogoutCommand;
            }
        }
        #endregion

        #region methods
        /*
         * Handled das Page-Switchen inkl. asynchroner Anfrage an den Server und anzeigen des Loading Screens
         */
        public async void SwitchActivePageAsync(string newActivePage)
        {
            if (newActivePage == "TimetablePage.xaml")
            {

                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        break;
                    case "normal":
                        await RequestTimetableFromServerAsync();
                        break;
                }
                IsLoading = false;
            }
            else if (newActivePage == "SharingServicePage.xaml")
            {
                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        break;
                    case "normal":
                        await RequestSharingDataFromServerAsync();
                        break;
                }
                IsLoading = false;
            }
            else if (newActivePage == "PersonalDataPage.xaml")
            {
                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        break;
                    case "normal":
                        await RequestPersonalDataFromServerAsync();
                        break;
                }
                IsLoading = false;

            }
            else if (newActivePage == "AdminPage.xaml")
            {
                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        break;
                    case "normal":
                        await RequestAdminDataFromServerAsync();
                        break;
                }
                IsLoading = false;
            }
            else if (newActivePage =="StudentModulePage.xaml")
            {
                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        RequestModuleDataDummy();
                        break;
                    case "normal":
                        await RequestModuleDataFromServerAsync();
                        break;
                }
                IsLoading = false;
            }

            else if (newActivePage == "PythonUpload.xaml")
            {
                IsLoading = true;
                switch (mode)
                {
                    case "debug":
                        break;
                    case "normal":
                        await RequestAdminDataFromServerAsync();
                        break;
                }
                IsLoading = false;
            }
            else
            {
                return;
            }
            ActivePage = newActivePage;
        }

        public void HandleHttpError(int HttpCode)
        {
            switch (HttpCode)
            {
                //Bad Request
                case (400):
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        App.notifier.ShowWarning(HttpCode + ": Fehlerhafter Request an Server");
                        //Logout(HttpCode);
                        //APIClient.Instance.Logout();
                    }
                    break;
                //Unauthorized
                case (401):
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        Logout(HttpCode);
                        APIClient.Instance.Logout();
                    }
                    break;
                //Forbidden
                case (403):
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        App.notifier.ShowWarning(HttpCode + ": Keine Zugriffsberechtigung");
                        //Logout(HttpCode);
                        //APIClient.Instance.Logout();
                    }
                    break;
                //Not Found
                case (404):
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        App.notifier.ShowWarning(HttpCode + ": Resource nicht gefunden");
                        //Logout(HttpCode);
                        //APIClient.Instance.Logout();
                    }
                    break;
                //Method Not Allowed
                case (405):
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        App.notifier.ShowWarning(HttpCode + ": Anfrage-Methode nicht erlaubt");
                        //Logout(HttpCode);
                        //APIClient.Instance.Logout();
                    }
                    break;
                case (-1):
                    
                    App.notifier.ShowError("Server is offline");
                    //Logout(HttpCode);
                    //APIClient.Instance.Logout();
                    
                    break;
                default:
                    if (LoginPageViewModel.Instance.IsLoggedIn)
                    {
                        App.notifier.ShowWarning("HttpFehlerCode: " + HttpCode);
                        //Logout(HttpCode);
                        //APIClient.Instance.Logout();
                    }
                    break;
            }

        }

        

        /*
         * Logout types: 1=auf button geklickt, 2=token nicht mehr valide
         */
        public void Logout(int code)
        {
            this.SwitchActivePageAsync("SharingServicePage.xaml");
            personalData.LogoutUser();
            LoginPageViewModel.Instance.IsLoggedIn = false;
            if (code == 200)
            {
                App.notifier.ShowSuccess("Ausloggen erfolgreich");
            } else if (code >= 400)
            {
                App.notifier.ShowError("Der Authentifizierungstoken ist nicht mehr gueltig");
            }
            APIClient.Instance.Logout();
        }
       
        /*
         * Request an REST-Schnittstelle des Servers fuer Stundenplan senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        public async Task RequestTimetableFromServerAsync()
        {
            ObservableCollection<TimetableModule> tempTable = new ObservableCollection<TimetableModule>();
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("/rest/lists/student_timetable");
            if ((int)response.StatusCode >= 400) return;
            tempTable = JsonConvert.DeserializeObject<ObservableCollection<TimetableModule>>(response.Content.ToString());
            foreach (TimetableModule tm in tempTable) //TODO ViewModel.MVM: Sollte besser in einem JSON Converter passieren
            {
                tm.Day = Globals.dayValues[tm.Day];
            }

            ModuleList.SetList(tempTable);
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestNewsFromServerAsync()
        {
            
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/lists/news", new { id = 32 });
            if ((int)response.StatusCode >= 400) return;
            
            //tempTable = JsonConvert.DeserializeObject<List<string>>(response.Content.ToString());
            //newsList.SetList(tempTable);
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestSharingDataFromServerAsync()
        {
            ObservableCollection<SwapOfferFrontendModel> tempList = new ObservableCollection<SwapOfferFrontendModel>();
            APIClient apiClient = APIClient.Instance;
            if (!UserInformation.Instance.IsAdmin)
            {
                var responseMe = await apiClient.NewGETRequest("/rest/lists/swapOffer/me");
                Console.WriteLine(responseMe.Content);
                if ((int)responseMe.StatusCode >= 400) return;
                tempList = JsonConvert.DeserializeObject<ObservableCollection<SwapOfferFrontendModel>>(responseMe.Content.ToString());
                SwapOfferListModel.Instance.SetList(tempList, false);
            }
            
            var responseAll = await apiClient.NewGETRequest("/rest/lists/swapOffer/all");
            if ((int)responseAll.StatusCode >= 400) return;
            tempList = JsonConvert.DeserializeObject<ObservableCollection<SwapOfferFrontendModel>>(responseAll.Content.ToString());
            SwapOfferListModel.Instance.SetList(tempList, true);

        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestPersonalDataFromServerAsync()
        {
            List<string> tempTable = new List<string>();
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/lists/personaldata", new { id = 32 });
            if ((int)response.StatusCode >= 400) return;
            //tempTable = JsonConvert.DeserializeObject<List<string>>(response.Content.ToString());
            //personaldata.SetList(tempTable);
        }

        /*
         * Request an REST-Schnittstelle des Servers senden und erhaltenes JSON in Objekt parsen
         * verwendet RestSharp
         */
        private async Task RequestAdminDataFromServerAsync()
        {
           
            ObservableCollection<TimetableModule> tempTable = new ObservableCollection<TimetableModule>();
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("/rest/lists/date_timetable/1");
            if ((int)response.StatusCode >= 400) return;
            
            tempTable = JsonConvert.DeserializeObject<ObservableCollection<TimetableModule>>(response.Content.ToString());
            foreach (TimetableModule tm in tempTable)
            {
                tm.Day = Globals.dayValues[tm.Day];
                //tm.RoomNumber = ((int)(new Random().NextDouble() * 17) + 1).ToString(); //TODO: MUSS VOM SERVER KOMMEN
            }
            ModuleList.SetList(tempTable);
            
           ModuleList.SetList(tempTable);
        }

        private async Task RequestModuleDataFromServerAsync()
        {
            List<ModuleSelectionItem> tempTable = new List<ModuleSelectionItem>();
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("/rest/lists/module/prioritize");
            Console.WriteLine(response.Content);
            if ((int)response.StatusCode >= 400) return;
            tempTable = JsonConvert.DeserializeObject<List<ModuleSelectionItem>>(response.Content.ToString());

            ModuleList.SetModuleSelcionItemList(tempTable);
        }

        private async void RequestModuleDataDummy()
        {
            //await RequestModuleDataFromServerAsync();
            var v = new TimetableModule();
            v.Type = TimetableModule.ModuleType.LECTURE;
            var p = new TimetableModule();
            p.Type = TimetableModule.ModuleType.PRACTICE;
            var t = new TimetableModule();
            t.Type = TimetableModule.ModuleType.TUTORIAL;
            var u = new TimetableModule();
            u.Type = TimetableModule.ModuleType.TEST;
            ModuleList.ModuleList.Add(v);
            ModuleList.ModuleList.Add(t);
            ModuleSelectionItem moduleItem1 = new ModuleSelectionItem(1, "prog3", 5, 3, ModuleList.ModuleList);
            ModuleSelectionItem moduleItem2 = new ModuleSelectionItem(2, "prog17", 5, 1, ModuleList.ModuleList);
            ModuleList.ModuleItemList.Add(moduleItem1);
            ModuleList.ModuleItemList.Add(moduleItem2);
        }


        #endregion
    }
}
