using System.Collections.Generic;
using HttpUtils;
using Newtonsoft.Json;
using Timetable;

namespace Frontend.ViewModel
{
    /**
     * <summary>
     * Verwaltet die "Verbindung" von der Stundenplan View (TimetablePage) und Model (.Models)
     * Fragt Server nach Stundenplan an und fuellt Model mit erhaltenen Daten
     * </summary>
     */

    class TimetableViewModel: ViewModelBase
    {
        //Liste der Gruppen = Stundenplan -> AUSLAGERN IN MODELS? Timetable.cs ?
        private List<Group> groupList { get; set; }
        //Angemeldeter Benutzer
        private Student activeStudent { get; set; }

        //Konstruktor
        public TimetableViewModel(Student activeStudent)
        {
            this.activeStudent = activeStudent;
            this.groupList = new List<Group>();
        }

        /**
        * <summary>
        * Fragt Stundenplan per HttpRequest an entsprechender REST-Schnittstelle vom Server ab
        * </summary>
        */
        public void RequestTimetableFromServer()
        {
            string restUri = @"http://localhost:8080/" + activeStudent.EnrolementNumber + "/timetable";
            var restClient = new RestClient(endpoint: restUri, method: HttpVerb.GET);
            var json = restClient.MakeRequest();
            LoadJsonIntoModel(json);
        }

        /**
        * <summary>
        * Laedt vom Server erhaltene JSON in Model
        * </summary>
        */
    public void LoadJsonIntoModel(string json)
        {
            groupList = JsonConvert.DeserializeObject<List<Group>>(json);
        }
    }
}
