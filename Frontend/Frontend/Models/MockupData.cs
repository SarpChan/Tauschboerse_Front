using System.ComponentModel;

namespace Frontend.Models
{
    class MockupData : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _text;
        public string Text {
            get { return _text; }
            set
            {
                if(value != _text)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            } 
        }

        public MockupData(string text)
        {
            this.Text = text;
        }
    }
}
