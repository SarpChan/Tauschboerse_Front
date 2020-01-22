using Frontend.Helpers.Generators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class NewsListModel
    {
        private ObservableCollection<News> _newsList = new ObservableCollection<News>();
        public ObservableCollection<News> NewsList { get { return _newsList; } }

        private static NewsListModel _instance;
        public static NewsListModel Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new NewsListModel();
                }
            }
        }

        private NewsListModel()
        {
            _instance = this;
        }

        private void AddNews(News n)
        {
            _newsList.Add(n);
        }

        private void RemoveNews(News n)
        {
            _newsList.Remove(n);
        }

        public void SetNewsList(ObservableCollection<News> newsList)
        {
            _newsList = newsList;
        }

        public void RemoveById(long id)
        {
            News rm = FindNewsByID(id);
            RemoveNews(rm);
        }

        public void AddById(long id)
        {
            News add = FindNewsByID(id);
            AddNews(add);
        }

        private News FindNewsByID(long id)
        {
            foreach (var so in NewsList)
            {
                if (so.id == id) { return so; };
            }
            return null;
        }

    }
}