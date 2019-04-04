using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game
{
    public partial class SettingsForm : Form
    {
        private bool nameChanged = false;

        public SettingsForm()
        {
            InitializeComponent();



        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm formGame = new GameForm();
            formGame.ShowDialog();
            this.Close();
        }

        private void blindSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            blindSizeTrackBar.Value = (int) blindSizeNumericUpDown.Value;
        }

        private void blindSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            blindSizeNumericUpDown.Value = blindSizeTrackBar.Value;
        }

        private void potSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            potSizeNumericUpDown.Value = potSizeTrackBar.Value;
        }

        private void potSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            potSizeTrackBar.Value = (int) potSizeNumericUpDown.Value;
        }

        private void numberOfPlayersTrackBar_ValueChanged(object sender, EventArgs e)
        {
            numberOfPlayersNumericUpDown.Value = numberOfPlayersTrackBar.Value;
        }

        private void numberOfPlayersNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberOfPlayersTrackBar.Value = (int)numberOfPlayersNumericUpDown.Value;

        private void textboxName_Leave(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                nameChanged = false;
            }
        }

        private void textboxName_Enter(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "Enter Name" && !nameChanged) {
                txtbox.Text = "";
            }
        }

        private void textbox_CheckChange(object sender, KeyPressEventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text != "" || txtbox.Text != "Enter Name") {
                nameChanged = true;
            }
        }
    }
}
