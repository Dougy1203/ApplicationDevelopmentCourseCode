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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool mult = false;
        public bool div = false;
        public bool add = false;
        public bool sub = false;
        public bool mod = false;
        public bool dot = false;
        public string entry = "";
        public float entry1;
        public float entry2;
        public float answer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            entry += "0";
            lblEntry.Content = entry;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            entry += "1";
            lblEntry.Content = entry;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            entry += "2";
            lblEntry.Content = entry;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            entry += "3";
            lblEntry.Content = entry;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            entry += "4";
            lblEntry.Content = entry;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            entry += "5";
            lblEntry.Content = entry;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            entry += "6";
            lblEntry.Content = entry;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            entry += "7";
            lblEntry.Content = entry;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            entry += "8";
            lblEntry.Content = entry;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            entry += "9";
            lblEntry.Content = entry;
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if(!dot)
            {
                entry += ".";
                lblEntry.Content = entry;
                dot = true;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            entry = "";
            lblEntry.Content = entry;
            mult = false;
            div = false;
            sub = false;
            add = false;
            mod = false;
            dot = false;
            entry = "";
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            div = true;
            float.TryParse(entry, out entry1);
            entry = "";
            lblEntry.Content = entry;
            dot = false;
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            mult = true;
            float.TryParse(entry, out entry1);
            entry = "";
            lblEntry.Content = entry;
            dot = false;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            sub = true;
            float.TryParse(entry, out entry1);
            entry = "";
            lblEntry.Content = entry;
            dot = false;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            add = true;
            float.TryParse(entry, out entry1);
            entry = "";
            lblEntry.Content = entry;
            dot = false;
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            mod = true;
            float.TryParse(entry, out entry1);
            entry = "";
            lblEntry.Content = entry;
            dot = false;
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            float.TryParse(entry, out entry2);
            if(mult)
            {
                answer = entry1 * entry2;
                lblEntry.Content = answer;
            }
            else if (div)
            {
                answer = entry1 / entry2;
                lblEntry.Content = answer;
            }
            else if (add)
            {
                answer = entry1 + entry2;
                lblEntry.Content = answer;
            }
            else if (sub)
            {
                answer = entry1 - entry2;
                lblEntry.Content = answer;
            }
            else if (mod)
            {
                answer = entry1 % entry2;
                lblEntry.Content = answer;
            }
            mult = false;
            div = false;
            sub = false;
            add = false;
            mod = false;
            dot = false;
            entry = "";
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            float temp;
            float.TryParse(entry, out temp);
            entry1 = 0 - temp;
            entry = entry1.ToString();
            lblEntry.Content = entry;
        }
    }
}
