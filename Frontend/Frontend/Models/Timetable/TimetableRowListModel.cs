using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class TimetableRowListModel
    {
        
        /// <summary>
        /// Model <c>TimetableRowListModel</c> that holds all Rows as 
        /// Objects so that they can be displayed in wpf xaml
        /// </summary>
        public TimetableRowListModel()
        {
            int rowAmount = (int)Globals.GetDuration() / Globals.Subdivisions;
            TimeSpan time = Globals.StartTime;
            
            bool odd = true;
            for (int i = 0; i < rowAmount; i++)
            {
                AddRow(new RowModel()
                {
                    Time = string.Format("{0:hh\\:mm}", time),
                    Color = odd ? Globals.RowColors[0] : Globals.RowColors[1],
                    RowIndex = i
                });
                time += Globals.TimeSubdivision;
                odd = !odd;
            }
        }

        private List<RowModel> _rowList = new List<RowModel>();

        public void AddRow(RowModel r)
        {
            _rowList.Add(r);
        }

        public void RemoveRow(RowModel r)
        {
            _rowList.Remove(r);
        }

        /// <summary>
        /// List that contains all Rows as <c>RowModel</c>. RowModels contain:
        /// <list type="RowModel">
        /// <item><description>Time</description></item>
        /// <item><description>BackgroundColor</description></item>
        /// </list>
        /// </summary>
        public List<RowModel> RowList { get { return _rowList; } }

    }



    /// <summary>
    /// RowModel that contains the Time for the row and the background color
    /// </summary>
    public class RowModel
    {
        public int RowIndex { get; set; }
        public string Time { get; set; }
        public string Color { get; set; }
    }
}
