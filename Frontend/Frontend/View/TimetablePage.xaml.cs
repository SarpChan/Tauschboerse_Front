using System;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /// <summary>
    /// Interaktionslogik für TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {

        private static readonly Lazy<TimetablePage> lazyTimetablePageSingleton =
            new Lazy<TimetablePage>(() => new TimetablePage());

        public static TimetablePage Instance { get { return lazyTimetablePageSingleton.Value; } }

        private TimetablePage()
        {
            InitializeComponent();
        }
    }
}
