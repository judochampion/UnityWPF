using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Container
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void LoadUnityUserControl(object sender, RoutedEventArgs e)
        {
            Page2_UnityFrame.Content = UnityWindowViewModel.Instance.myUserControl;
            Page2_UnityFrame.NavigationService.Refresh();
        }
    }
}