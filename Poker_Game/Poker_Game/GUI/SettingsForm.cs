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
        // Makes sure you've entered a name before continueing
        {
            if (nameChanged)
            {
                this.Hide();
                GameForm formGame = new GameForm(textboxName.Text, trackBarPotSize.Value, trackBarBlindSize.Value, trackBarBlindIncrease.Value, checkBoxRoundBased.Checked);
                formGame.ShowDialog();
                this.Close();
            }
            else
            {
                nameErrorLabel.Visible = true;
            }
        }

        private void blindSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the blind numeric up down with the blind trackbar
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;
                trackBarBlindSize.Value = (int)numericUpDownBlindSize.Value;
            }
        }

        private void blindSizeTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the blind trackbar with the blind numeric up down
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;

                if (trackBarBlindSize.Value % 10 != 0)
                {
                    valueJustChanged = true;
                    trackBarBlindSize.Value = trackBarBlindSize.Value - (trackBarBlindSize.Value % 10);
                }
                numericUpDownBlindSize.Value = trackBarBlindSize.Value;
            }
        }

        private void potSizeTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the potsize trackbar with the potsize numeric up down
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                if (trackBarPotSize.Value % 100 != 0)
                {
                    valueJustChanged = true;
                    trackBarPotSize.Value = trackBarPotSize.Value - (trackBarPotSize.Value % 100);
                }
                valueJustChanged = true;

                numericUpDownPotSize.Value = trackBarPotSize.Value;
            }
        }

        private void potSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the potsize numeric up down with the potsize trackbar
        {
            if (valueJustChanged)
            {
                valueJustChanged = false;
            }
            else
            {
                valueJustChanged = true;
                trackBarPotSize.Value = (int)numericUpDownPotSize.Value;
            }
        }

        private void numberOfPlayersTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the number of players trackbar with the number of players numeric up down
        {
            numericUpDownNumberOfPlayers.Value = trackBarNumberOfPlayers.Value;
        }

        private void numberOfPlayersNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the number of players numeric up down with the number of players trackbar
        {
            trackBarNumberOfPlayers.Value = (int)numericUpDownNumberOfPlayers.Value;
        }

        private void textboxName_Leave(object sender, EventArgs e)
        // Checks if player has Entered a name
        {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                nameChanged = false;
            }
        }

        private void textboxName_Enter(object sender, EventArgs e)
        // Removes the text "Enter Name" when clicked
        {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text == "Enter Name" && !nameChanged) {
                txtbox.Text = "";
            }
        }

        private void textbox_CheckChange(object sender, KeyPressEventArgs e)
        // Checks if the Entered name is a Valid option
        {
            TextBox txtbox = (TextBox)sender;
            if (txtbox.Text != "" || txtbox.Text != "Enter Name") {
                nameChanged = true;
            }
        }

        private void timeBasedCheckBox_CheckedChanged(object sender, EventArgs e)
        // reveals or hides Blind Increase trackbar and numeric up down and adjusts its values to fit time based blind increase
        {
            if(checkBoxTimeBased.Checked == true)
            {
                checkBoxRoundBased.Checked = false;

                trackBarBlindIncrease.Visible = true;
                numericUpDownBlindIncrease.Visible = true;

                numericUpDownBlindIncrease.Value = 20;

                numericUpDownBlindIncrease.Maximum = 60;
                numericUpDownBlindIncrease.Increment = 5;

                trackBarBlindIncrease.Maximum = 60;
            }
            else if (checkBoxTimeBased.Checked == false && checkBoxRoundBased.Checked == false)
            {
                trackBarBlindIncrease.Visible = false;
                numericUpDownBlindIncrease.Visible = false;
            }
        }

        private void roundBasedCheckBox_CheckedChanged(object sender, EventArgs e)
        // reveals or hides Blind Increase trackbar and numeric up down and adjusts its values to fit round based blind increase
        {
            if (checkBoxRoundBased.Checked == true)
            {
                checkBoxTimeBased.Checked = false;

                trackBarBlindIncrease.Visible = true;
                numericUpDownBlindIncrease.Visible = true;

                numericUpDownBlindIncrease.Value = 5;

                numericUpDownBlindIncrease.Maximum = 20;
                numericUpDownBlindIncrease.Increment = 1;

                trackBarBlindIncrease.Maximum = 20;
            }
            else if (checkBoxTimeBased.Checked == false && checkBoxRoundBased.Checked == false)
            {
                trackBarBlindIncrease.Visible = false;
                numericUpDownBlindIncrease.Visible = false;
            }
        }

        private void blindIncreaseTrackBar_ValueChanged(object sender, EventArgs e)
        // links blind increase trackbar with blind increase numeric up down
        {
            numericUpDownBlindIncrease.Value = trackBarBlindIncrease.Value;
        }

        private void blindIncreaseNumericUpDown_ValueChanged(object sender, EventArgs e)
        // links blind increase numeric up down with blind increase trackbar
        {
            trackBarBlindIncrease.Value = (int)numericUpDownBlindIncrease.Value;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
