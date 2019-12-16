using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Helpers;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Frontend.Models;

namespace Frontend.ViewModel
{
    class StudentModuleViewModel: Helpers.ViewModelBase
    {
        CurriculumDummy curriculum = new CurriculumDummy() {Terms = 7};

        

        private ObservableCollection<int> _numberOfSemesters = new ObservableCollection<int>();
        public ObservableCollection<int> numberOfSemesters
        {
            get { return _numberOfSemesters; }
        }

        private static ObservableCollection<Module> _modules = new ObservableCollection<Module>();
        public ObservableCollection<Module> modules
        {
            get { return _modules; }
        }

        static HttpClient client = new HttpClient();

        public StudentModuleViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:1818/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            for (int i = 1; i <= curriculum.Terms; i++)
            {
                _numberOfSemesters.Add(i);
                Console.WriteLine(numberOfSemesters);
            }
        }


        static async Task<ObservableCollection<Module>> GetProductAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                _modules = response.Content.ReadAsAsync<ObservableCollection<Module>>().Result;
            }
            return _modules;
        }



    }

    public class CurriculumDummy
    {
        public int Terms { get; set; }

    }

}
