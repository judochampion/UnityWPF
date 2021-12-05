using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Container
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void LoadUnityUserControl(object sender, RoutedEventArgs e)
        {
            Page4_UnityFrame.Content = UnityWindowViewModel.Instance.myUserControl;
            Page4_UnityFrame.NavigationService.Refresh();
        }
    }
}