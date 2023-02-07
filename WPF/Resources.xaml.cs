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

namespace WPF
{
    /// <summary>
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        public Resources()
        {
            InitializeComponent();
            //btnResourceStatic.Content = FindResource("CompanyName");
            //btnResourceStatic.Content = Properties.Resources.String1;
            btnResourceStatic.Content = Properties.Settings.Default.Setting1;

            Resources["Boogers"] = "boogers";
            btnResourceDynamic.Content = FindResource("Boogers");
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            //Only Dynamic will change by chaining resource like binding
            Resources["CompanyColor"] = new SolidColorBrush(Colors.Blue);

            //static will chang if you explicitly updat the .Content of the button
            Resources["CompanyName"] = "Dynamic Company";
            btnResourceStatic.Content = FindResource("CompanyName");
        }
    }
}
