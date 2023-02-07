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

namespace Login
{
    /// <summary>
    /// Interaction logic for Ukraine.xaml
    /// </summary>
    public partial class Ukraine : Window
    {
        public Ukraine()
        {
            InitializeComponent();
            DataContext = this;

            Resources["loginStatus"] = "Welcome Home Comrade";
            Resources["Header"] = "Jokes Aside";
            Resources["Footer"] = "I Stand With Ukraine";
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            this.Close();
            window.Show();
            
        }
    }
}
