using System;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private static readonly Lazy<HomePage> lazyHomePageSingleton =
            new Lazy<HomePage>(() => new HomePage());

        public static HomePage Instance { get { return lazyHomePageSingleton.Value; } }

        public HomePage()
        {
            Console.WriteLine("Homepage Constructor");
            InitializeComponent();
        }
    }
}
