using System;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game {
    public partial class SettingsForm : Form {
        private const bool Testing = true;
        private bool _nameChanged = false;
        private bool _valueJustChanged = false;

        public SettingsForm() {
            InitializeComponent();
            checkBoxRoundBased.Checked = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        // Makes sure you've entered a name before continueing
        {
            if (Testing || _nameChanged)
            {
                this.Hide();
                Settings settings = new Settings(2, trackBarPotSize.Value, trackBarBlindSize.Value, checkBoxRoundBased.Checked, trackBarBlindIncrease.Value, textboxName.Text, 1);
                GameForm formGame = new GameForm(settings);
                formGame.ShowDialog();
                this.Close();
            } else {
                nameErrorLabel.Visible = true;
            }
        }

        private void blindSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the blind numeric up down with the blind trackbar
        {
            if (_valueJustChanged)
            {
                _valueJustChanged = false;
            } else {
                _valueJustChanged = true;
                trackBarBlindSize.Value = (int)numericUpDownBlindSize.Value;
            }
        }

        private void blindSizeTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the blind trackbar with the blind numeric up down
        {
            if (_valueJustChanged)
            {
                _valueJustChanged = false;
            } else {
                _valueJustChanged = true;

                if(trackBarBlindSize.Value % 10 != 0) {
                    _valueJustChanged = true;
                    trackBarBlindSize.Value = trackBarBlindSize.Value - (trackBarBlindSize.Value % 10);
                }
                numericUpDownBlindSize.Value = trackBarBlindSize.Value;
            }
        }

        private void potSizeTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the potsize trackbar with the potsize numeric up down
        {
            if (_valueJustChanged)
            {
                _valueJustChanged = false;
            } else {
                if(trackBarPotSize.Value % 100 != 0) {
                    _valueJustChanged = true;
                    trackBarPotSize.Value = trackBarPotSize.Value - (trackBarPotSize.Value % 100);
                }
                _valueJustChanged = true;

                numericUpDownPotSize.Value = trackBarPotSize.Value;
            }
        }

        private void potSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the potsize numeric up down with the potsize trackbar
        {
            if (_valueJustChanged)
            {
                _valueJustChanged = false;
            } else {
                _valueJustChanged = true;
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
            if(txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                _nameChanged = false;
            }
        }

        private void textboxName_Enter(object sender, EventArgs e)
        // Removes the text "Enter Name" when clicked
        {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "Enter Name" && !_nameChanged) {
                txtbox.Text = "";
            }
        }

        private void textbox_CheckChange(object sender, KeyPressEventArgs e)
        // Checks if the Entered name is a Valid option
        {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text != "" || txtbox.Text != "Enter Name") {
                _nameChanged = true;
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
            } else if(checkBoxTimeBased.Checked == false && checkBoxRoundBased.Checked == false) {
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
            } else if(checkBoxTimeBased.Checked == false && checkBoxRoundBased.Checked == false) {
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

        private void SettingsForm_Load(object sender, EventArgs e) {

        }

        private void textboxName_KeyDown(object sender, KeyEventArgs e)
        //Enables the user to press "Enter" and start the game from the Player Name textbox.
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStartGame.PerformClick();
            }
        }
    }
}
