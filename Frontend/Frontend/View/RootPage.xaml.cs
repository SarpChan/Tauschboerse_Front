using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Frontend.View
{
    /* <summary>
    * Interaktionslogik für RootPage.xaml
    * Verwaltet nur die Events der Button_Click's
    * </summary>
    */
    public partial class RootPage : Page
    {
        /* <summary>
        * Konstruktor der RootPage : Page
        * </summary>
        */
        public RootPage()
        {
            InitializeComponent();
        }
        
        #region MainFrame DataContext to Pages
        
         /* 
          * Benoetigt um DataContext an Pages in Frame weiter zu geben.
         */

        private void FrameDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateFrameDataContext(sender, e);
        }
        private void FrameLoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e);
        }
        private void UpdateFrameDataContext(object sender, NavigationEventArgs e)
        {
            var content = MainFrame.Content as FrameworkElement;
            if (content == null)
                return;
            content.DataContext = MainFrame.DataContext;
        }
        private void UpdateFrameDataContext(object sender, DependencyPropertyChangedEventArgs e)
        {
            var content = MainFrame.Content as FrameworkElement;
            if (content == null)
                return;
            content.DataContext = MainFrame.DataContext;
        }
        #endregion
    }
}
