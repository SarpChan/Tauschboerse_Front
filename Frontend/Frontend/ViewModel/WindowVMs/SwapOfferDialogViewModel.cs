using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        private ObservableCollection<SwapOfferCourse> _GroupList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> GroupList
        {
            get { return _GroupList; }
        }

        private Dictionary<long, List<SwapOfferCourse>> courseDict = new Dictionary<long, List<SwapOfferCourse>>();

        private List<SwapOfferCourse> allSwapOfferCourses = new List<SwapOfferCourse>();

        public SwapOfferDialogViewModel()
        {
            //FillLists();
            FillDummy();
        }

        private void CourseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwapOfferGroup selectedItem = (e.AddedItems[0] as ComboBoxItem).Content as SwapOfferGroup;
            Console.WriteLine(selectedItem.Id);
        }
        //DropDownClosed 

        public void FillDummy()
        {
            CourseList.Add(new SwapOfferCourse
            {
                courseComponentId = 0,
                courseId = 1,
                courseName = "Prog 3",
                courseType = "Praktikum",
                groupChar = 'A',
                groups = new List<SwapOfferGroup>
                {
                    new SwapOfferGroup
                    {
                        Char = 'A',
                        Id = 17
                    }, new SwapOfferGroup
                    {
                        Char = 'B',
                        Id = 18
                    }
                }
            });
            CourseList.Add(new SwapOfferCourse
            {
                courseComponentId = 1,
                courseId = 1,
                courseName = "Prog 3",
                courseType = "Übung",
                groupChar = 'B',
                groups = new List<SwapOfferGroup>
                {
                    new SwapOfferGroup
                    {
                        Char = 'A',
                        Id = 19
                    }, new SwapOfferGroup
                    {
                        Char = 'B',
                        Id = 20
                    }
                }
            });
        }

        public async void FillLists()
        {
            APIClient api = APIClient.Instance;
            var response = await api.NewGETRequest("/rest/lists/availableSwaps");
            this.allSwapOfferCourses = JsonConvert.DeserializeObject<List<SwapOfferCourse>>(response.Content);
            foreach(SwapOfferCourse swapOfferCourse in this.allSwapOfferCourses)
            {
                List<SwapOfferCourse> fill;
                this.courseDict.TryGetValue(swapOfferCourse.courseId, out fill);
                fill.Add(swapOfferCourse);
                CourseList.Add(swapOfferCourse);
            }
        }
        
    }
}
