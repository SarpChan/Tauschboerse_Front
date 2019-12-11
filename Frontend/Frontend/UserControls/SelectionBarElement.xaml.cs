using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SelectionBarElement : UserControl
    {
        public SelectionBarElement() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SelectionBarElementCommand
        {
            get { return (ICommand)GetValue(SelectionBarElementProperty); }
            set { SetValue(SelectionBarElementProperty, value); }
        }
        public static readonly DependencyProperty SelectionBarElementProperty =
            DependencyProperty.Register("SelectionBarElementCommand", typeof(ICommand), typeof(SelectionBarElement), new UIPropertyMetadata(null));

        public string SBE_Tag
        {
            get { return (string)GetValue(SBE_TagProperty); }
            set { SetValue(SBE_TagProperty, value); }
        }
        public static readonly DependencyProperty SBE_TagProperty =
            DependencyProperty.Register("SBE_Tag", typeof(string), typeof(SelectionBarElement), new UIPropertyMetadata(null));
    }
}
