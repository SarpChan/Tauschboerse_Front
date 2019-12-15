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
        /*TODO: TTP Singleton sinnvoll??
        private static readonly Lazy<TimetablePage> lazyTimetablePageSingleton =
            new Lazy<TimetablePage>(() => new TimetablePage());

        public static TimetablePage Instance { get { return lazyTimetablePageSingleton.Value; } }
        */
        public TimetablePage()
        {
            InitializeComponent();
        }
    }
}
