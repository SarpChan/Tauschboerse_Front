using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using Frontend.Helpers;
using Frontend.Models;
using ToastNotifications.Messages;
using Frontend.Helpers.Converters;
using Frontend.View;
using Frontend.Helpers.Handlers;

namespace Frontend.ViewModel
{
    /// <summary>
    /// ViewModel für die Sharing-Page
    /// </summary>
    class SharingPageViewModel : NotifyPropertyValueChange
    {
        private ObservableCollection<SharingPageViewModelSwapOffer> _SwapListPublic = new ObservableCollection<SharingPageViewModelSwapOffer>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SharingPageViewModelSwapOffer> SwapListPublic
        {
            get { return _SwapListPublic; }
        }

        private ObservableCollection<SharingPageViewModelSwapOffer> _SwapListOwn = new ObservableCollection<SharingPageViewModelSwapOffer>();
        /// <summary>
        /// Eine Liste mit allen Tauschangeboten des aktuellen Nutzers
        /// </summary>
        public ObservableCollection<SharingPageViewModelSwapOffer> SwapListOwn
        {
            get { return _SwapListOwn; }
        }

        private ObservableCollection<News> _NewsList = new ObservableCollection<News>();
        /// <summary>
        /// Eine Liste mit allen News des aktuellen Nutzers
        /// </summary>
        public ObservableCollection<News> NewsList
        {
            get { return _NewsList; }
        }


        /// <summary>
        /// Eine Liste mit allen Möglichkeite der Suche
        /// Depricated
        /// </summary>
        public IEnumerable<String> AutocompleteOwn { get; set; }
        /// <summary>
        /// Eine Liste mit allen Möglichkeite der Suche
        /// Depricated
        /// </summary>
        public IEnumerable<String> AutocompletePublic { get; set; }

        /// <summary>
        /// Konstruktor
        /// 
        /// Gleicht die lokalen swapOffer Lists / News List mit der Model List ab. (Diese ist eine Instanz somit ist jede SharingPageViewModel instanz stehts gleich gefüllt).
        /// Zusätzlich meldet sich die Klasse auf jedrige Änderung der besagten Listen an um Änderungen zu synchronisieren.
        /// </summary>
        public SharingPageViewModel()
        {

            SwapOfferListModel swapOfferListModel = SwapOfferListModel.Instance;
            NewsListModel newsListModel = NewsListModel.Instance;
            foreach(SwapOfferFrontendModel swapOffer in swapOfferListModel.SwapOfferListPublic)
            {
                    _SwapListPublic.Add(new SharingPageViewModelSwapOffer(swapOffer));
            }
            foreach (SwapOfferFrontendModel swapOffer in swapOfferListModel.SwapOfferListPersonal)
            {
                    _SwapListOwn.Add(new SharingPageViewModelSwapOffer(swapOffer));
            }
            foreach(News news in newsListModel.NewsList)
            {
                    _NewsList.Add(news);
            }

            swapOfferListModel.SwapOfferListPublic.CollectionChanged += OnPublicCollectionChange;
            swapOfferListModel.SwapOfferListPersonal.CollectionChanged += OnPersonalCollectionChange;
            newsListModel.NewsList.CollectionChanged += OnNewsCollectionChange;
            
            CreateAutocompletes();
        }


        #region methods
        /// <summary>
        /// Creates Autocompletions for the search.
        /// </summary>
        private void CreateAutocompletes()
        {
            List<String> autoCompleteConvertList = new List<string>();
            foreach (SharingPageViewModelSwapOffer swapoffer in this.SwapListOwn)
            {
                    autoCompleteConvertList.Add(swapoffer.CourseName);
                    autoCompleteConvertList.Add(swapoffer.CourseType);
            }
            this.AutocompleteOwn = autoCompleteConvertList.Distinct().ToList(); ;
            foreach (string s in this.AutocompleteOwn) Console.WriteLine(s);
            List<String> autoCompleteConvertList2 = new List<string>();
            foreach (SharingPageViewModelSwapOffer swapoffer in this.SwapListPublic)
            {
                    autoCompleteConvertList2.Add(swapoffer.CourseName);
                    autoCompleteConvertList2.Add(swapoffer.CourseType);
            }
            this.AutocompletePublic = autoCompleteConvertList2.Distinct().ToList(); ;

        }

        /// <summary>
        /// Sendet eine Delete-Request an den Server um das Tauschangebot mir der übergebenen Id zu löschen
        /// </summary>
        /// <param name="id">des Tauschangebots was gelöscht werden soll</param>
        private async void DeleteTradeOffer(object id)
        {
            //ID = System.Int64
            APIClient api = APIClient.Instance;
            string requestUrl = "/rest/swapOffer/delete/" + id;
            Console.WriteLine(requestUrl);
            var response = await api.NewDELETERequest(requestUrl);
            if ((int)response.StatusCode >= 400)
            {
                App.notifier.ShowError((int)response.StatusCode+": Beim Löschen des Tauschangebots ist ein Fehler aufgetreten");
            } else
            {
                App.notifier.ShowSuccess("Tausch gelöscht");
            }
        }

        /// <summary>
        /// Sendet eine Anfrage an den Server um eins der öffentlichen angezeigten Tauschangebote anzunehmen
        /// </summary>
        /// <param name="id">des Tauschangebots was angefragt wird.</param>
        private async void RequestTradeOffer(object id)
        {
            APIClient api = APIClient.Instance;
            foreach (SharingPageViewModelSwapOffer swapOffer in this.SwapListPublic)
            {
                if (swapOffer.Id == (long)id)
                {
                    Console.WriteLine("Trading " + id + "...");
                    var response = await api.NewPOSTRequest("/tradeOffer/request", swapOffer);
                    if ((int)response.StatusCode >= 400)
                    {
                        App.notifier.ShowError((int)response.StatusCode + ": Beim Anfragen des Tauschanbots ist ein Fehler aufgetreten");
                    }
                    else
                    {
                        App.notifier.ShowSuccess("Tausch angenommen!");
                    }
                }
            }
        }

        /// <summary>
        /// Jedes mal wenn sich die Liste der persönlichen Tauschangebote im Model verändert wird zieht das Viewmodel nach indem es das betreffende Tauschangebot löscht bzw ein neues hinzufügt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPersonalCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnModuleAdd(sender, e, true);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnModuleRemove(sender, e, true);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    OnModuleClear(sender, e, true);
                    break;
                default:
                    throw new ArgumentException("Error while adding to personal sharing list " + e.Action.ToString());
            }
        }

        /// <summary>
        /// Äquivalent zu OnPersonalCollectionChange wird auch hier die Änderung abgeglichen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPublicCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {


            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnModuleAdd(sender, e, false);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnModuleRemove(sender, e, false);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    OnModuleClear(sender, e, false);
                    break;
                default:
                    throw new ArgumentException("Error while adding to public sharing list " + e.Action.ToString());
            }
        }

        /// <summary>
        /// Äquivalent zu OnPersonalCollectionChange wird auch hier die Änderung abgeglichen jedoch hier für die News
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnNewsCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnNewsAdd(sender, e);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnNewsRemove(sender, e);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    OnNewsClear(sender, e);
                    break;
                default:
                    throw new ArgumentException("Error while adding to news list " + e.Action.ToString());
            }
        }

        #endregion methods

        #region CollectionChangeActions

        /// <summary>
        /// Wenn ein neues Module im Model hinzugefügt wird wird dieses auch hier in der ViewModel Liste hinzugefügt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="own">Ob es sich um die Öffentliche oder Private Tauschangebotliste handelt. True wenn es die Persönliche ist</param>
        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {

            foreach (SwapOfferFrontendModel t in e.NewItems)
            {
                SharingPageViewModelSwapOffer add = new SharingPageViewModelSwapOffer(t);
                if (own)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        this.SwapListOwn.Add(add);
                    });
                } else
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        this.SwapListPublic.Add(add);
                    });
                }
                
            }
        }

        /// <summary>
        /// Wenn ein neues Module im Model gelöscht wird wird dieses auch hier in der ViewModel Liste gelöscht
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="own">Ob es sich um die Öffentliche oder Private Tauschangebotliste handelt. True wenn es die Persönliche ist</param>
        private void OnModuleRemove(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {
            foreach (SwapOfferFrontendModel t in e.OldItems)
            {
                if (own)
                {
                    SharingPageViewModelSwapOffer foundSPVMSO = FindSharingPageViewModelSwapOfferWithId(t.Id, this.SwapListOwn);
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        this.SwapListOwn.Remove(foundSPVMSO);
                    });
                }
                else
                {
                    SharingPageViewModelSwapOffer foundSPVMSO = FindSharingPageViewModelSwapOfferWithId(t.Id, this.SwapListPublic);
                    App.Current.Dispatcher.Invoke((Action)delegate 
                    {
                        this.SwapListPublic.Remove(foundSPVMSO);
                    });
                    
                }
            }
        }

        /// <summary>
        /// Wenn ein die ModuleList im Model geleert wird wird auch hier in der ViewModel die Liste geleert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="own">Ob es sich um die Öffentliche oder Private Tauschangebotliste handelt. True wenn es die Persönliche ist</param>
        private void OnModuleClear(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {
            if (own)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    this.SwapListOwn.Clear();
                });
            }
            else
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    this.SwapListPublic.Clear();
                });
            }
        }

        /// <summary>
        /// Äquivalent zu OnModuleAdd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNewsAdd(object sender, NotifyCollectionChangedEventArgs e)
        {

            foreach (News t in e.NewItems)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    this.NewsList.Add(t);
                });
            }
        }
        /// <summary>
        /// Äquivalent zu OnModuleRemove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNewsRemove(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (News t in e.NewItems)
            {
                News foundNews = FindNewsWithId(t.id, this.NewsList);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    this.NewsList.Remove(foundNews);
                });
            }
        }

        /// <summary>
        /// Äquivalent zu OnModuleClear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNewsClear(object sender, NotifyCollectionChangedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                this.NewsList.Clear();
            });
        }

        /// <summary>
        /// Findet das passende SharingPageViewModelSwapOffer in der übergebenen Liste mit der übergebenen Id
        /// </summary>
        /// <param name="id">des gesuchten Tauschangebots</param>
        /// <param name="swapOffers">Liste mit allen Tauschangeboten</param>
        /// <returns></returns>
        private SharingPageViewModelSwapOffer FindSharingPageViewModelSwapOfferWithId(long id, IList<SharingPageViewModelSwapOffer> swapOffers)
        {
            foreach (SharingPageViewModelSwapOffer spvmso in swapOffers)
            {
                if (spvmso.Id == id)
                {
                    return spvmso;
                }
            }
            return null;
        }
        /// <summary>
        /// Äquivalent zu der Suche nach Tauschangeboten
        /// </summary>
        /// <param name="id">der gesuchten News</param>
        /// <param name="newsList">Liste mit allen News</param>
        /// <returns></returns>
        private News FindNewsWithId(long id, IList<News> newsList)
        {
            foreach (News news in newsList)
            {
                if (news.id == id)
                {
                    return news;
                }
            }
            return null;
        }

        #endregion

        #region Commands


        private ICommand _DeleteCommand;
        /// <summary>
        /// Command der an den Löschen Button in jeder Zeile gebinded wird
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new ActionCommand(id => DeleteTradeOffer(id));
                }

                return _DeleteCommand;
            }
            set { }
        }

        private ICommand _RequestCommand;

        /// <summary>
        /// Command der an den Request Button in jeder Zeile gebinded wird
        /// </summary>
        public ICommand RequestCommand
        {
            get
            {
                if (_RequestCommand == null)
                {
                    _RequestCommand = new ActionCommand(id => RequestTradeOffer(id));
                }

                return _RequestCommand;
            }
            set { }
        }




        #endregion
    }
}


