using System.Windows;
using System.Windows.Controls;

namespace Container
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void LoadUnityUserControl(object sender, RoutedEventArgs e)
        {
            Page3_UnityFrame.Content = UnityWindowViewModel.Instance.myUserControl;
            Page3_UnityFrame.NavigationService.Refresh();
        }
    }
}