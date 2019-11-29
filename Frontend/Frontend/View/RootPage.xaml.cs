using System.Windows.Controls;

namespace Frontend.View
{
    /* <summary>
    * Interaktionslogik für RootPage.xaml
    * Verwaltet nur die Events der Button_Click's
    * </summary>
    */
    public partial class RootPage : Page
    {
        /*
        //TODO: TTP Singleton sinnvoll?? Wenn ja, wie? private Constructor wirft fehler
        private static readonly Lazy<RootPage> lazyRootPageSingleton =
            new Lazy<RootPage>(() => new RootPage());

        public static RootPage Instance { get { return lazyRootPageSingleton.Value; } }
        */

        /* <summary>
        * Konstruktor der RootPage : Page
        * </summary>
        */
        public RootPage()
        {
            InitializeComponent();
        }
    }
}
