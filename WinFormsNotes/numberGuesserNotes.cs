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
    public partial class numberGuesserNotes : Form
    {
        public numberGuesserNotes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 11);
            MessageBox.Show(r.ToString());
            //if (panel1.Contains(checkBox2))
            //{
            //    MessageBox.Show("inside");
            //}
            //else
            //{
            //    MessageBox.Show("outside");
            //}
        }
    }
}
