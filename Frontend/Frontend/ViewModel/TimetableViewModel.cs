using System.Collections.Generic;
using Frontend.Models;
using HttpUtils;
using Newtonsoft.Json;
using Timetable;

namespace Frontend.Helpers
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
        private List<Group> GroupList { get; set; }
        MockupModels mm;

        //Konstruktor
        public TimetableViewModel()
        {
            this.GroupList = new List<Group>();
            mm = new MockupModels();
        }

        /**
        * <summary>
        * Fragt Stundenplan per HttpRequest an entsprechender REST-Schnittstelle vom Server ab
        * </summary>
        */
        public void RequestTimetableFromServer()
        {
            string restUri = @"http://localhost:8080/" + mm.ActiveStudent.EnrolementNumber + "/timetable";
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
            GroupList = JsonConvert.DeserializeObject<List<Group>>(json);
        }
    }
}
