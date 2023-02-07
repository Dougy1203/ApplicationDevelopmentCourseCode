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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bnSubmit_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "I just clicked my Button";
            MessageBox.Show("I Clicked the Button and I liked it", "Top of Box");
            this.Hide();
            Form2 SF = new Form2();
            SF.Show();
            //SF.ShowDialog();
        }

        private void txtInputTextChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }
    }
}
