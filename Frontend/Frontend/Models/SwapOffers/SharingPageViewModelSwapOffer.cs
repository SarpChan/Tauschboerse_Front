using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Dictionary<String, String> WeekdayTranslate = new Dictionary<string, string>() {
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
            {"test", "Übung"},
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

}
