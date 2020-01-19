using Frontend.Helpers.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Frontend.Models
{
    public class TimetableViewModelModule : NotifyPropertyValueChange
    {
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;
        private string _Color;
        private TimetableModule _Module;


        public double X
        {
            get { return _X; }
            set
            {
                var oldValue = _X;
                _X = value;
                NotifyPropertyChanged("X", oldValue, value);
            }
        }

        public double Y
        {
            get { return _Y; }
            set
            {
                var oldValue = _Y;
                _Y = value;
                NotifyPropertyChanged("Y", oldValue, value);
            }
        }
        public double Width
        {
            get { return _Width; }
            set
            {
                var oldValue = _Width;
                _Width = value;
                NotifyPropertyChanged("Width", oldValue, value);
            }
        }

        public double Height
        {
            get { return _Height; }
            set
            {
                var oldValue = _Height;
                _Height = value;
                NotifyPropertyChanged("Height", oldValue, value);
            }
        }

        public string Color
        {
            get { return _Color; }
            set
            {
                var oldValue = _Color;
                _Color = value;
                NotifyPropertyChanged("Color", oldValue, value);
            }
        }
        public TimetableModule Module
        {
            get { return _Module; }
            set
            {
                var oldValue = _Module;
                _Module = value;
                NotifyPropertyChanged("Module", oldValue, value);
            }
        }

    }
}
