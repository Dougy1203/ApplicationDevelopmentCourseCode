using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuesser
{
    public partial class NumberGuess : Form
    {

        Random rnd = new Random();
        List<Label> lblResults = new List<Label>();
        List<PictureBox> picResults = new List<PictureBox>();

        int answer = 0;
        int numGuess = 0;
        int randomMax = 0;

        private void InitializeGame()
        {
            lblResults.Add(label1);
            lblResults.Add(label2);
            lblResults.Add(label3);
            lblResults.Add(label4);
            lblResults.Add(label5);

            picResults.Add(pictureBox1);
            picResults.Add(pictureBox2);
            picResults.Add(pictureBox3);
            picResults.Add(pictureBox4);
            picResults.Add(pictureBox5);
        }

        private void ResetGame() 
        {
            foreach(Label label in lblResults)
            {
                label.Text = "";
            }

            foreach(PictureBox pic in picResults)
            {
                pic.Image = null;
            }

            txtGuess.Enabled = false;
            btnStart.Enabled = true;
            btnStart.Text = "Start";

            numGuess = 0;
        }

        private void StartGame() 
        {
            answer = rnd.Next(1, randomMax + 1);
            txtGuess.Enabled = true;
            btnStart.Text = "Reset";
        }

        private void GameWon()
        {
            txtGuess.Enabled = false;
        }

        private void GameLost()
        {
            txtGuess.Enabled = false;
        }



        public NumberGuess()
        {
            InitializeComponent();
            InitializeGame();
            ResetGame();
        }

        private void NumberGuess_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text.Equals("Start"))
            {
                StartGame();
            }
            else
            {
                ResetGame();
            }
        }

        private void btnEasy_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 10;
            }
        }

        private void btnMedium_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 50;
            }
        }

        private void btnHard_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 100;
            }
        }

        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuess_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string HighLow = "";
                string text = txtGuess.Text;
                int guess = int.Parse(text);
                if(guess == answer)
                {
                    lblResults[numGuess].Text = answer + " Correct!";
                    lblResults[numGuess].ForeColor = Color.Green;
                    picResults[numGuess].Image = Properties.Resources.correct_icon;
                    GameWon();
                }
                else if(guess > answer)
                {
                    HighLow = "Too High!";
                    lblResults[numGuess].Text = HighLow;
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.incorrect_icon;

                }
                else if (guess < answer)
                {
                    HighLow = "Too Low!";
                    lblResults[numGuess].Text = HighLow;
                    lblResults[numGuess].ForeColor = Color.Red;
                    picResults[numGuess].Image = Properties.Resources.incorrect_icon;

                }
                numGuess++;
                if(numGuess == 5)
                {
                    GameLost();
                }
            }
        }
    }
}
