using System;
using System.Windows.Forms;

namespace Poker_Game
{
    public partial class SettingsForm : Form
    {
        private bool nameChanged = false;
        private bool valueJustChanged = false;

        public SettingsForm()
        {
            InitializeComponent();
            checkBoxRoundBased.Checked = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            if (textboxName.Text != "" && textboxName.Text != "Enter Name")
            {
                this.Hide();
                GameForm formGame = new GameForm(textboxName.Text, potSizeTrackBar.Value, blindSizeTrackBar.Value );
                formGame.ShowDialog();
                this.Close();
            }
            else
            {
                nameErrorLabel.Visible = true;
            }
        }

        private void blindSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;
                blindSizeTrackBar.Value = (int)blindSizeNumericUpDown.Value;
            }
        }

        private void blindSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;

                if (blindSizeTrackBar.Value % 10 != 0)
                {
                    valueJustChanged = true;
                    blindSizeTrackBar.Value = blindSizeTrackBar.Value - (blindSizeTrackBar.Value % 10);
                }
                blindSizeNumericUpDown.Value = blindSizeTrackBar.Value;
            }
        }

        private void potSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                if (potSizeTrackBar.Value % 100 != 0)
                {
                    valueJustChanged = true;
                    potSizeTrackBar.Value = potSizeTrackBar.Value - (potSizeTrackBar.Value % 100);
                }
                valueJustChanged = true;

                potSizeNumericUpDown.Value = potSizeTrackBar.Value;
            }
        }

        private void potSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;
                potSizeTrackBar.Value = (int)potSizeNumericUpDown.Value;
            }
        }

        private void numberOfPlayersTrackBar_ValueChanged(object sender, EventArgs e)
        {
            numberOfPlayersNumericUpDown.Value = numberOfPlayersTrackBar.Value;
        }

        private void numberOfPlayersNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            numberOfPlayersTrackBar.Value = (int)numberOfPlayersNumericUpDown.Value;
        }

        private void textboxName_Leave(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                nameChanged = false;
            }
        }

        private void textboxName_Enter(object sender, EventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text == "Enter Name" && !nameChanged) {
                txtbox.Text = "";
            }
        }

        private void textbox_CheckChange(object sender, KeyPressEventArgs e) {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text != "" || txtbox.Text != "Enter Name") {
                nameChanged = true;
            }
        }

        private void timeBasedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(timeBasedCheckBox.Checked == true)
            {
                checkBoxRoundBased.Checked = false;

                blindIncreaseTrackBar.Visible = true;
                blindIncreaseNumericUpDown.Visible = true;

                blindIncreaseNumericUpDown.Value = 20;

                blindIncreaseNumericUpDown.Maximum = 60;
                blindIncreaseNumericUpDown.Increment = 5;

                blindIncreaseTrackBar.Maximum = 60;
            }
            else if (timeBasedCheckBox.Checked == false && checkBoxRoundBased.Checked == false)
            {
                blindIncreaseTrackBar.Visible = false;
                blindIncreaseNumericUpDown.Visible = false;
            }
        }

        private void roundBasedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRoundBased.Checked == true)
            {
                timeBasedCheckBox.Checked = false;

                blindIncreaseTrackBar.Visible = true;
                blindIncreaseNumericUpDown.Visible = true;

                blindIncreaseNumericUpDown.Value = 5;

                blindIncreaseNumericUpDown.Maximum = 20;
                blindIncreaseNumericUpDown.Increment = 1;

                blindIncreaseTrackBar.Maximum = 20;
            }
            else if (timeBasedCheckBox.Checked == false && checkBoxRoundBased.Checked == false)
            {
                blindIncreaseTrackBar.Visible = false;
                blindIncreaseNumericUpDown.Visible = false;
            }
        }

        private void blindIncreaseTrackBar_ValueChanged(object sender, EventArgs e)
        {
            blindIncreaseNumericUpDown.Value = blindIncreaseTrackBar.Value;
        }

        private void blindIncreaseNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            blindIncreaseTrackBar.Value = (int)blindIncreaseNumericUpDown.Value;
        }
    }
}
