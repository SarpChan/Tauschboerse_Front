using System.Collections.Generic;
using Frontend.Models;
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

        //Konstruktor
        public TimetableViewModel()
        {
        }

    }
}
