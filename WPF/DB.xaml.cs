using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using WPF.NamesDSTableAdapters;

namespace WPF
{
    /// <summary>
    /// Interaction logic for DB.xaml
    /// </summary>
    public partial class DB : Window
    {
        NamesTableAdapter ad = new NamesTableAdapter();
        NamesDS ds = new NamesDS();

        public DB()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;
            long lngReturn;

            ht.Clear();
            ht.Add("@Name", "Daniel");
            ht.Add("@Age", 18);
            ht.Add("@IsWeird", 0);
            ht.Add("@ID", 1);
            //Insert person
            //sql = "Insert into Names (Name,Age,IsWeird) Values(@Name, @Age, @IsWeird)";
            //Update Person
            //sql = "Update Names set Name=@Name, Age=@Age, IsWeird=@IsWeird where ID=@ID";
            //lngReturn = ExDB.ExecuteIt("AwesomeDB", sql, ht);
            //lblMsg.Content = lngReturn + " records updated";

            sql = "SELECT * from Names";
            dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            lblMsg.Content = dt.Rows.Count + " rows found";

            //DataRow dr;
            //dr = dt.Rows[0];
            //int intID;
            //intID = (int)dr["ID"];
            //lblMsg.Content = "ID=" + intID;

            //xsd file examples
            //ad.Insert("Tristyn", 33, Convert.ToDateTime("7/28/2000"), true);

            ad.Fill(ds.Names);
            var s = (from Names in ds.Names
                     where Names.ID == 3
                     select Names.Name);
            lblMsg.Content = s.First();

            dt = ad.GetData();
            var g = dt.Select("Name='Daniel' and ID=1");

            DataRow dr;
            dr = g[0];

            MessageBox.Show(dr["ID"].ToString());

            //Making a new row hard coding
            NamesDS.NamesRow row = (NamesDS.NamesRow)ds.Names.NewRow();
            row.Name = "Brad";
            row.Age = 22;
            ds.Names.AddNamesRow(row);
            ad.Update(ds); //Saves
            MessageBox.Show("Name " + row.Name + " was added", "Added");

            ht.Clear();
            ht.Add("@Name", "Henry");
            sql = "Select * From Names";
            dt = ExDB.GetDataTable("AwesomeDB", ht, sql);
            dg.ItemsSource = dt.DefaultView;
        }
    }
}
