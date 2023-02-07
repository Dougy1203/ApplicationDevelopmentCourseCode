using System;
using System.Collections;
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
using System.Data;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Resources["Header"] = "USSR";
            Resources["Footer"] = "Property of the USSR, Illegal use will result in Termination; of Program and of Self. Tread Carefully Comrade.";
            Resources["createStatus"] = "";
            Resources["loginStatus"] = "";
        }

        private void createAccount_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;
            long lngReturn;

            if (createName.Text.Equals("") || createUsername.Text.Equals("") || createEmail.Text.Equals("") || createPass.Text.Equals(""))
            {
                MessageBox.Show("Must Fill All Information Comrade. \n Wouldn't Want to Misidentify the Means of Production");
            }
            else
            {
                ht.Clear();
                sql = $"SELECT UserName FROM Users WHERE UserName='{createUsername.Text}'";
                dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("UserName already Exists");
                }
                else if(dt.Rows.Count == 0)
                {
                    ht.Add("@Name", createName.Text);
                    ht.Add("@UserName", createUsername.Text);
                    ht.Add("@Email", createEmail.Text);
                    ht.Add("@Password", createPass.Text);
                    sql = "INSERT INTO Users (Name,UserName,Email,Password) VALUES(@Name,@UserName,@Email,@Password)";
                    lngReturn = ExDB.ExecuteIt("AwesomeDB", sql, ht);
                    Resources["createStatus"] = "WE are happy to have US";
                }
            }
        }

        private void loginAccount_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;
            long lngReturn;

            sql = $"SELECT * FROM Users WHERE UserName = '{loginName.Text}' and Password = '{loginPass.Text}'";
            dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
            if(dt.Rows.Count == 1)
            {
                Window window = new Ukraine();
                window.Show();
                this.Close();
            }
            else
            {
                Resources["loginStatus"] = "Zat Vas Not Ze Right Answer!";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
