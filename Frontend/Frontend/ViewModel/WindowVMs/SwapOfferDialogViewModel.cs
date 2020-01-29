using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel.WindowVMs
{
    class SwapOfferDialogViewModel
    {
        private ObservableCollection<SwapOfferCourse> _CourseList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseList
        {
            get { return _CourseList; }
        }

        private ObservableCollection<SwapOfferCourse> _CourseTypeList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseTypeList
        {
            get { return _CourseTypeList; }
        }

        private ObservableCollection<SwapOfferCourse> _GroupList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> GroupList
        {
            get { return _GroupList; }
        }


        
    }
}
