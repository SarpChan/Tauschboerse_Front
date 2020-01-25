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

namespace Frontend.ViewModel
{
    /// <summary>
    /// ViewModel für die Sharing-Page
    /// </summary>
    class SharingPageViewModel
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

        private ObservableCollection<NewsModel> _NewsList = new ObservableCollection<NewsModel>();
        /// <summary>
        /// Eine Liste mit allen News des aktuellen Nutzers
        /// </summary>
        public ObservableCollection<NewsModel> NewsList
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

        public SharingPageViewModel()
        {

            SwapOfferListModel swapOfferListModel = SwapOfferListModel.Instance;
            foreach(SwapOfferFrontendModel swapOffer in swapOfferListModel.SwapOfferListPublic)
            {
                _SwapListPublic.Add(new SharingPageViewModelSwapOffer(swapOffer));
            }
            foreach (SwapOfferFrontendModel swapOffer in swapOfferListModel.SwapOfferListPersonal)
            {
                _SwapListOwn.Add(new SharingPageViewModelSwapOffer(swapOffer));
            }

            swapOfferListModel.SwapOfferListPublic.CollectionChanged += OnPublicCollectionChange;
            swapOfferListModel.SwapOfferListPersonal.CollectionChanged += OnPersonalCollectionChange;

            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden exmatrikuliert.",
                timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Stundent dekradiert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 22,8, 15, 0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Admin befördert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 21,8,15,0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden exmatrikuliert.",
                timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Stundent dekradiert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 22, 8, 15, 0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Admin befördert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 21, 8, 15, 0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden exmatrikuliert.",
                timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Stundent dekradiert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 22, 8, 15, 0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Admin befördert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 21, 8, 15, 0)).ToUnixTimeSeconds()
            });
            CreateAutocompletes();

        }

        #region methods
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
                //Ging
            }
        }

        private void EditTradeOffer(object id)
        {
            Console.WriteLine("Editing " + id + "...");
        }

        private async void RequestTradeOffer(object id)
        {
            APIClient api = APIClient.Instance;
            foreach (SharingPageViewModelSwapOffer swapOffer in this.SwapListPublic)
            {
                if (swapOffer.Id == (long)id)
                {
                    Console.WriteLine("Trading " + id + "...");
                    await api.NewPOSTRequest("/tradeOffer/request", swapOffer);
                }
            }
        }

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
                    throw new ArgumentException("Unbehandelter TupelHaufen-Change " + e.Action.ToString());
            }
        }

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
                    throw new ArgumentException("Unbehandelter TupelHaufen-Change " + e.Action.ToString());
            }
        }

        #endregion methods

        #region CollectionChangeActions

        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {

            foreach (SwapOfferFrontendModel t in e.NewItems)
            {
                SharingPageViewModelSwapOffer add = new SharingPageViewModelSwapOffer(t);
                if (own)
                {
                    this.SwapListOwn.Add(add);
                } else
                {
                    this.SwapListPublic.Add(add);
                }
                
            }
        }
        private void OnModuleRemove(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {
            foreach (SwapOfferFrontendModel t in e.NewItems)
            {
                if (own)
                {
                    SharingPageViewModelSwapOffer foundSPVMSO = FindSharingPageViewModelSwapOfferWithId(t.Id, this.SwapListOwn);
                    this.SwapListOwn.Remove(foundSPVMSO);
                }
                else
                {
                    SharingPageViewModelSwapOffer foundSPVMSO = FindSharingPageViewModelSwapOfferWithId(t.Id, this.SwapListPublic);
                    this.SwapListPublic.Remove(foundSPVMSO);
                }
            }
        }
        private void OnModuleClear(object sender, NotifyCollectionChangedEventArgs e, bool own)
        {
            if (own)
            {
                this.SwapListOwn.Clear();
            }
            else
            {
                this.SwapListPublic.Clear();
            }
        }

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

        private ICommand _EditCommand;

        /// <summary>
        /// Command der an den Edit Button in jeder Zeile gebinded wird
        /// </summary>
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new ActionCommand(id => EditTradeOffer(id));
                }

                return _EditCommand;
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


namespace Frontend.Models
{
    //SPVMSO

    /// <summary>
    /// Für die SharingPageView vorbereitetes Model mit berechneten Daten.
    /// Enthält gleiche Id wie das SwapOfferFrontendModel was es repräsentiert
    /// 
    /// Kurz SPVMSO
    /// </summary>
    public class SharingPageViewModelSwapOffer
    {

        private Dictionary<String,String> WeekdayTranslate = new Dictionary<string, string>() {
            {"monday", "Montag"},
            {"tuesday", "Dienstag"},
            {"wednesday", "Mittwoch"},
            {"thursday", "Donnerstag"},
            {"friday", "Freitag"},
            {"satturday", "Samstag"},
            {"sunday", "Sonntag"},
        };

        private Dictionary<String, String> WeekdayTranslateRe = new Dictionary<string, string>() {
            {"montag", "monday"},
            {"dienstag", "tuesday"},
            {"mittwoch", "wednesday"},
            {"donnerstag", "thursday"},
            {"freitag", "friday"},
            {"samstag", "satturday"},
            {"sonntag", "sunday"},
        };

        private Dictionary<String, String> CourseTypeTranslate = new Dictionary<string, string>() {
            {"lecture", "Vorlesung"},
            {"practice", "Praktikum"},
            {"tutorial", "Tutorium"},
            {"test", "Test"},
        };

        private Dictionary<String, String> CourseTypeTranslateRe = new Dictionary<string, string>() {
            {"vorlesung", "lecture"},
            {"praktikum", "practice"},
            {"tutorium", "tutorial"},
            {"test", "test"},
        };

        public string CourseName
        {
            get
            {
                return SwapOffer.CourseName;
            }
            set
            {
                SwapOffer.CourseName = (string)value;
            }
        }
        public string CourseType
        {
            get
            {
                return CourseTypeTranslate[SwapOffer.CourseType.ToLower()];
            }
            set
            {
                SwapOffer.CourseType = CourseTypeTranslateRe[(string)value.ToLower()].ToUpper();
            }
        }
        //Könnte auch dann ein Bild sein.
        public string Has { get; set; }
        public string Wants { get; set; }
        public long Id { get; set; }

        public SwapOfferFrontendModel SwapOffer { get; set; }

        /// <summary>
        /// Konstruktor für ein SPVMSO
        /// </summary>
        /// <param name="sofm">Das zu repräsentierende SwapOfferFrontendModel</param>
        public SharingPageViewModelSwapOffer(SwapOfferFrontendModel sofm)
        {
            //Im getter durchreichen
            this.SwapOffer = sofm;
            StringBuilder sb = new StringBuilder();
            sb.Append("Gruppe ").Append(sofm.FromGroupChar).Append(" (");
            sb.Append(WeekdayTranslate[sofm.FromDay.ToString().ToLower()]).Append(" ");
            sb.Append(sofm.FromStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.FromEndTime.ToString(@"hh\:mm")).Append(")");
            this.Has = sb.ToString();
            sb.Clear();
            sb.Append("Gruppe ").Append(sofm.ToGroupChar).Append(" (");
            sb.Append(WeekdayTranslate[sofm.ToDay.ToString().ToLower()]).Append(" ");
            sb.Append(sofm.ToStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.ToEndTime.ToString(@"hh\:mm")).Append(")");
            this.Wants = sb.ToString();
            this.Id = sofm.Id;
        }
    }

    public class NewsModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("timestamp")]
        public long timestamp { get; set; }
        [JsonIgnore]
        public String Time
        {
            get
            {
                DateTime conv = TimestampToDatetimeConverter.convert(timestamp);
                DateTime today = DateTime.Now;
                StringBuilder sb = new StringBuilder();
                if (conv.Day == today.Day)
                {
                    sb.Append("Heute,");
                }
                else if (conv.Day == today.Day - 1)
                {
                    sb.Append("Gestern,");
                }
                else
                {
                    sb.Append(conv.ToShortDateString()).Append(",");
                }
                sb.Append(conv.ToShortTimeString()).Append("Uhr").Append(":");

                return sb.ToString();
            }
            set
            {
                Time = (string)value;
            }
        }
    }

}
