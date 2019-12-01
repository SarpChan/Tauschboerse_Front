using System.Windows;

namespace Frontend.Models
{
    class MockModule : DependencyObject
    {
        public string Text { get; set; }
        public MockModule(string text)
        {
            this.Text = text;
        }
    }
}
