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
using System.Windows.Shapes;

namespace SysTray
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();

            SettingsStartup();
        }

        private void SettingsStartup()
        {
            if (Properties.Settings.Default.IconCPU)
                chkCPU.IsChecked = true;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //private void chkboxTransparentBackground_Checked(object sender, RoutedEventArgs e)
        //{
        //    Properties.Settings.Default.IconTransparent = true;
        //    Properties.Settings.Default.icon = System.Drawing.Color.Transparent;
        //    Properties.Settings.Default.Save();
        //    Console.WriteLine(Properties.Settings.Default.IconTransparent.ToString());
        //}

        //private void chkboxTransparentBackground_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    Properties.Settings.Default.IconTransparent = false;
        //    Properties.Settings.Default.IconBackground = System.Drawing.Color.Black;
        //    Properties.Settings.Default.Save();
        //    Console.WriteLine(Properties.Settings.Default.IconTransparent.ToString());
        //}

        private void HeaderBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
