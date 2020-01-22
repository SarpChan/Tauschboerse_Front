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



        private List<SwapOfferFrontendModel> TestListOwn = new List<SwapOfferFrontendModel>();
        private List<SwapOfferFrontendModel> TestListPublic = new List<SwapOfferFrontendModel>();

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

            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 0,
                FromGroupChar = 'A',
                ToGroupChar = 'B',
                CourseName = "Programmieren 3",
                CourseType = "Praktikum",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });

            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 1,
                FromGroupChar = 'C',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 2,
                FromGroupChar = 'A',
                ToGroupChar = 'D',
                CourseName = "EIBO",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 3,
                FromGroupChar = 'B',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 4,
                FromGroupChar = 'A',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 5,
                FromGroupChar = 'A',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 6,
                FromGroupChar = 'C',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });
            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 7,
                FromGroupChar = 'C',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });

            TestListPublic.Add(new SwapOfferFrontendModel
            {
                Id = 8,
                FromGroupChar = 'A',
                ToGroupChar = 'B',
                CourseName = "EIBO",
                CourseType = "Übung",
                ToStartTime = new TimeSpan(10, 0, 0),
                ToEndTime = new TimeSpan(11, 30, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY,
            });

            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[0]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[1]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[2]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[3]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[4]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[5]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[6]));
            SwapListPublic.Add(new SharingPageViewModelSwapOffer(TestListPublic[0]));

            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden exmatrikuliert.",
                timestamp = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Stundent dekradiert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 21,8, 15, 0)).ToUnixTimeSeconds()
            });
            NewsList.Add(new NewsModel
            {
                Message = "Sie wurden zum Admin befördert.",
                timestamp = ((DateTimeOffset)new DateTime(2020, 1, 20,8,15,0)).ToUnixTimeSeconds()
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

        private void DeleteTradeOffer(object id)
        {
            //ID = System.Int64
            Console.WriteLine("Deleting " + id + "...");
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

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {


            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnModuleAdd(sender, e);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnModuleRemove(sender, e);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    OnModuleClear(sender, e);
                    break;
                default:
                    throw new ArgumentException("Unbehandelter TupelHaufen-Change " + e.Action.ToString());
            }
        }

        #endregion methods

        #region CollectionChangeActions

        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e)
        {

            foreach (SwapOfferFrontendModel t in e.NewItems)
            {
                SharingPageViewModelSwapOffer add = new SharingPageViewModelSwapOffer(t);
                this.SwapListOwn.Add(add);
            }
        }
        private void OnModuleRemove(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (SwapOfferFrontendModel t in e.NewItems)
            {
                SharingPageViewModelSwapOffer foundSPVMSO = FindSharingPageViewModelSwapOfferWithId(t.Id, this.SwapListOwn);
                this.SwapListOwn.Remove(foundSPVMSO);
            }
        }
        private void OnModuleClear(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.SwapListOwn.Clear();
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
                return SwapOffer.CourseType;
            }
            set
            {
                SwapOffer.CourseType = (string)value;
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
            string tanslateDay = sofm.FromDay.ToString();
            sb.Append(tanslateDay.First().ToString().ToUpper()).Append(tanslateDay.Substring(1).ToLower()).Append(" ");
            sb.Append(sofm.FromStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.FromEndTime.ToString(@"hh\:mm")).Append(")");
            this.Has = sb.ToString();
            sb.Clear();
            sb.Append("Gruppe ").Append(sofm.ToGroupChar).Append(" (");
            tanslateDay = sofm.ToDay.ToString();
            sb.Append(tanslateDay.First().ToString().ToUpper()).Append(tanslateDay.Substring(1).ToLower()).Append(" ");
            sb.Append(sofm.ToStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.ToEndTime.ToString(@"hh\:mm")).Append(")");
            this.Wants = sb.ToString();
            this.Id = sofm.Id;
        }
    }

    public class SwapOfferFrontendModel
    {
        public long Id { get; set; }
        public char FromGroupChar { get; set; }
        public char ToGroupChar { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public TimeSpan ToStartTime { get; set; }
        public TimeSpan ToEndTime { get; set; }
        public TimeSpan FromStartTime { get; set; }
        public TimeSpan FromEndTime { get; set; }
        public Models.DayOfWeek FromDay { get; set; }
        public Models.DayOfWeek ToDay { get; set; }
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
                DateTime conv = new DateTime(timestamp);
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
