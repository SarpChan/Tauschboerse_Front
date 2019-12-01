using System.ComponentModel;
using System.Windows;

namespace Frontend.Models
{
    class MockupData : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _text;
        public string Text {
            get { return _text; }
            set
            {
                
            } 
        }

        public MockupData(string text)
        {
            this.Text = text;
        }
    }
}
