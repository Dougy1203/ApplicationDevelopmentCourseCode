using System;
using System.Collections;
using System.Data;
using System.Windows;
using CasinoSim;

namespace DungeonsAndDragons
{
    public partial class Saved : Window
    {
        private Random rand = new Random();
        public Saved()
        {
            InitializeComponent();
            Resources["Name"] = "";
            Resources["Age"] = "";
            Resources["Gender"] = "";
            Resources["Race"] = "";
            Resources["Class"] = "";
            Resources["Strength"] = "";
            Resources["Constitution"] = "";
            Resources["Dexterity"] = "";
            Resources["Charisma"] = "";
            Resources["Intelligence"] = "";
            Resources["Wisdom"] = "";
            Resources["d100"] = "";
            Resources["d20"] = "";
            Resources["d12"] = "";
            Resources["d10"] = "";
            Resources["d8"] = "";
            Resources["d6"] = "";
            Resources["d4"] = "";
        }

        private void SearchForCharacter_OnClick(object sender, RoutedEventArgs e)
        {
            
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;
            long lngreturn;
            
            sql = $"SELECT * FROM DnD WHERE Name = '{EnterName.Text}'";
            dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Enter an Existing Character Name");
            }
            else if (dt.Rows.Count > 1)
            {
                MessageBox.Show("Invalid Entry... Try Again.");
            }
            else if (dt.Rows.Count == 1)
            {
                Resources["Name"] = dt.Rows[0]["Name"].ToString();
                Resources["Age"] = dt.Rows[0]["Age"].ToString();
                Resources["Gender"] = dt.Rows[0]["Gender"].ToString();
                Resources["Race"] = dt.Rows[0]["Race"].ToString();
                Resources["Class"] = dt.Rows[0]["Class"].ToString();
                Resources["Strength"] = dt.Rows[0]["Strength"].ToString();
                Resources["Constitution"] = dt.Rows[0]["Constitution"].ToString();
                Resources["Dexterity"] = dt.Rows[0]["Dexterity"].ToString();
                Resources["Charisma"] = dt.Rows[0]["Charisma"].ToString();
                Resources["Intelligence"] = dt.Rows[0]["Intelligence"].ToString();
                Resources["Wisdom"] = dt.Rows[0]["Wisdom"].ToString();
                Resources["d100"] = "";
                Resources["d20"] = "";
                Resources["d12"] = "";
                Resources["d10"] = "";
                Resources["d8"] = "";
                Resources["d6"] = "";
                Resources["d4"] = "";
            }
            
            //MessageBox.Show(dt.Rows[0]["Gender"].ToString());
        }

        private void D20_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d20"] = rand.Next(1,21).ToString();
        }

        private void D100_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d100"] = rand.Next(1,101).ToString();
        }

        private void D12_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d12"] = rand.Next(1,13).ToString();
        }

        private void D10_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d10"] = rand.Next(1,11).ToString();
        }

        private void D8_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d8"] = rand.Next(1,9).ToString();
        }

        private void D6_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d6"] = rand.Next(1,7).ToString();
        }

        private void D4_OnClick(object sender, RoutedEventArgs e)
        {
            Resources["d4"] = rand.Next(1,5).ToString();
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NotEnough_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is more than most others that you've passed... why?!?");  
        }
    }
}