using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsNotes
{
    public partial class WinFormsStillGood : Form
    {
        BindingList<string> lstMovies = new BindingList<string>()
        {
            "50 First Dates", "Grown Ups", "Happy Gilmore", "Little Nicky", "Billy Madison", "WaterBoy"
        };
        public WinFormsStillGood()
        {
            InitializeComponent();
        }

        private void WinFormsStillGood_Load(object sender, EventArgs e)
        {
            Button btnGoodbye = new Button();
            btnGoodbye.Location = new Point(30, 30);
            btnGoodbye.Text = "Goodbye";
            btnGoodbye.Size = new Size(200, 100);
            Controls.Add(btnGoodbye);
            btnGoodbye.Click += new System.EventHandler(this.btnGoodbye_Click);

            //lb.Items.Add("Dumb and Dumber");

            lb.DataSource = lstMovies;
            lstMovies.Add("Click");
        }

        private void btnGoodbye_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            btnSender.Size = new Size(btnSender.Size.Width + 10, btnSender.Size.Height + 10);
            lblInfo.Text = btnSender.Text;
        }

        private void btnHello_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lb.SelectedIndex.ToString());
            //MessageBox.Show(lb.SelectedItem.ToString());
            ListBox listBox = (ListBox)sender;
            lblInfo.Text = listBox.SelectedItem.ToString();
        }
    }
}
