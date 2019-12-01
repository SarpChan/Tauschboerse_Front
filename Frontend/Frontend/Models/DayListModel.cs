using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class DayListModel
    {
        //Hier eig liste mit Modulen reingereicht??
        public DayListModel()
        {
            for(int i = 0; i < Globals.weekdays; i++)
            {
                AddModule(new DayModel()
                {
                    Name = Globals.Weekdays[i],
                    Abbreviation = Globals.WeekdaysAbbreviation[i],
                    Index = i,
                });
            }
        }

        private List<DayModel> _dayList = new List<DayModel>();

        public void AddModule(DayModel m)
        {
            _dayList.Add(m);
        }
        public void RemoveModule(DayModel m)
        {
            _dayList.Remove(m);
        }

        public List<DayModel> DayList { get { return _dayList; } }
    }

    public class DayModel
    {
        public String Name { get; set; }
        public String Abbreviation { get; set; }
        public int Index { get; set; }
    }

}
