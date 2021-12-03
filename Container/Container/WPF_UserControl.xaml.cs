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
    /// Interaction logic for WPF_UserControl.xaml
    /// </summary>
    public partial class WPF_UserControl : UserControl
    {
        public bool Already_Loaded = false;

        public WPF_UserControl()
        {
            InitializeComponent();

            Init();

        }

        private void On_Load(object sender, RoutedEventArgs e)
        {
            //Init();

        }

        private void Init()
        {
            if (!Already_Loaded)
            {
                // Create the interop host control.
                var host =
                    new WindowsFormsHost();

                // Embed the Winforms Control
                host.Child = new LVD_Steelplying_Embed_Unity_Exe_Winforms_Control();

                Grid.SetRow(host, 1);

          

                // Add the interop host control to the Grid
                // control's collection of child controls.
                Grid_To_Embed_Winforms_Control_In.Children.Add(host);
                Already_Loaded = true;
            }
        }



    }
}
