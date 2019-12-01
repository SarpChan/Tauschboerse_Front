using System.Windows;

namespace Frontend.Models
{
    class MockupModels : DependencyObject
    { 

        public MockupModels()
        {
            MockModule = "EMPTY";
        }
 
        public string MockModule
        {
            get { return (string) GetValue(MockModuleProperty); }
            set { SetValue(MockModuleProperty, value); }
        }
        public static readonly DependencyProperty MockModuleProperty =
            DependencyProperty.Register("MockModule", typeof(string), typeof(MockupModels));
    }
}
