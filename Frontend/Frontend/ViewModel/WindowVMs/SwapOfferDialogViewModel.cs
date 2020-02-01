using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToastNotifications.Messages;

namespace Frontend.ViewModel
{
    class SwapOfferDialogViewModel : ViewModelBase
    {
        private ObservableCollection<SwapOfferCourse> _CourseList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseList
        {
            get { return _CourseList; }
        }

        private List<SwapOfferCourse> DatabaseCourses = new List<SwapOfferCourse>();

        private ObservableCollection<SwapOfferGroup> _GroupList = new ObservableCollection<SwapOfferGroup>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferGroup> GroupList
        {
            get { return _GroupList; }
        }

        private ObservableCollection<SwapOfferCourse> _CourseTypeList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseTypeList
        {
            get { return _CourseTypeList; }
        }

        /// <summary>
        /// Dictonary welche alle Course mit der gleichen ID in einer Liste speichert und diese unter der ID abspeichert
        /// Key = CourseId
        /// Value = Liste mit Courses mit der CourseId
        /// </summary>
        private Dictionary<long, List<SwapOfferCourse>> courseDict = new Dictionary<long, List<SwapOfferCourse>>();

        /// <summary>
        /// Wird das Dialog Fenster geöffnet und somit diese Viewmodel instanziert werden die möglichen Tauschangebote vom Server gefetcht
        /// </summary>
        public SwapOfferDialogViewModel()
        {
            FetchFromDatabase();
            FromGroup = "";
        }

        private long FromGroupId = 0;
        private long ToGroupId = 0;


        /// <summary>
        /// Erstellt ein Tauschangebot mit den eingestellten Werten
        /// </summary>
        public async void CreateSwapOffer()
        {
            SwapOffer so = new SwapOffer(FromGroupId, ToGroupId);
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/swapoffer/insert", so);
            if ((int)response.StatusCode >= 400) return;
            App.notifier.ShowSuccess("Tauschangebot erstellt!");
        }


        #region UserInputChange

        /// <summary>
        /// Jedes mal wenn sich der ausgewählte Kurs sich ändert werden erst die folgenden Eingaben (Kurstyp und Gruppe) zurückgesetzt und dann die KursTypauswahl befüllt
        /// </summary>
        /// <param name="selectedItem"></param>
        public void CourseSelectionChanged(SwapOfferCourse selectedItem)
        {
            CourseTypeList.Clear();
            GroupList.Clear();
            FromGroup = "";
            ChangeLine = "";
            foreach (SwapOfferCourse courseType in courseDict[selectedItem.CourseId])
            {
                CourseTypeList.Add(courseType);
            }
        }

        /// <summary>
        /// Jedes mal wenn sich der ausgewählte Kurstyp sich ändert wird die ausgewählte Gruppe gelöscht und die Gruppenauswahl befüllt
        /// Des weiteren wird sich die aktuelle Gruppe des Studenten gemerkt, von welcher er weg wechseln möchte</summary>
        /// <param name="selectedItem"></param>
        public void CourseTypeSelectionChanged(SwapOfferCourse selectedItem)
        {
            FromGroup = "Gruppe " + selectedItem.GroupChar;
            GroupList.Clear();
            ChangeLine = "";
            FromGroupId = selectedItem.GroupId;
            foreach (SwapOfferGroup group in selectedItem.Groups)
            {
                GroupList.Add(group);
            }
        }

        /// <summary>
        /// Wenn der Nutzer die Zielgruppe wechselt wird passend zu den Eingaben ein Anzeige mit dem Statement gefüllt von wo nach wo der User wechselt wenn er das Tauschangebot erstellt.
        /// Zusätlich wird sich die Id der Zielgruppe gemerkt.
        /// </summary>
        /// <param name="group"></param>
        public void GroupSelect(SwapOfferGroup group)
        {
            ChangeLine = "Du wechselst von " + FromGroup + " zu Gruppe " + group.Char;
            ToGroupId = group.Id;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Anzeige String welche das Tauschangebot in Worte fasst.
        /// </summary>
        public string _ChangeLine;
        public string ChangeLine
        {
            get
            {
                return _ChangeLine;
            }
            set
            {
                _ChangeLine = value;
                OnPropertyChanged("ChangeLine");
            }
        }

        /// <summary>
        /// String der Gruppe aus der der Nutzer wechselt. Wird zur Anzeige in der View benutzt
        /// </summary>
        public string _FromGroup;
        public string FromGroup
        {
            get
            {
                return _FromGroup;
            }
            set
            {
                _FromGroup = value;
                OnPropertyChanged("FromGroup");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Füllt das CourseDict und die Liste für die erste ComboBox
        /// </summary>
        public void FillList()
        {
            foreach (SwapOfferCourse swapOfferCourse in this.DatabaseCourses)
            {
                List<SwapOfferCourse> fill = new List<SwapOfferCourse>();
                bool found = this.courseDict.TryGetValue(swapOfferCourse.CourseId, out fill);
                if (!found)
                {
                    this.courseDict[swapOfferCourse.CourseId] = new List<SwapOfferCourse>();
                    CourseList.Add(swapOfferCourse);
                }
                this.courseDict[swapOfferCourse.CourseId].Add(swapOfferCourse);
            }
        }

        /// <summary>
        /// Fragt eine Liste mit allen Kursen des Nutzers an. Füllt dann die benötigten Listen zur Darstellung
        /// </summary>
        public async void FetchFromDatabase()
        {
            APIClient api = APIClient.Instance;
            var response = await api.NewGETRequest("/rest/lists/availableSwaps");
            Console.WriteLine(response.Content);
            this.DatabaseCourses = JsonConvert.DeserializeObject<List<SwapOfferCourse>>(response.Content);
            FillList();
        }

        #endregion

    }
}
