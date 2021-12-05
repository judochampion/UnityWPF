using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page1 page1;
        private Page2 page2;
        private Page3 page3;
        private Page4 page4;

        public MainWindow()
        {
            InitializeComponent();

            page1 = new Page1();
            page2 = new Page2();
            page3 = new Page3();
            page4 = new Page4();

            UnityFrame.Content = page1;
        }

        private void LoadPage1_Click(object sender, RoutedEventArgs e)
        {
            UnityFrame.Content = page1;
        }

        private void LoadPage2_Click(object sender, RoutedEventArgs e)
        {
            UnityFrame.Content = page2;
        }

        private void LoadPage3_Click(object sender, RoutedEventArgs e)
        {
            UnityFrame.Content = page3;
        }

        private void LoadPage4_Click(object sender, RoutedEventArgs e)
        {
            UnityFrame.Content = page4;
        }
    }
}