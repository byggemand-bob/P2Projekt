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
            Icon = Properties.Resources.coins;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        // Makes sure you've entered a name before continueing
        {
            if (Testing || _nameChanged)
            {
                this.Hide();
                Settings settings = new Settings(2, trackBarPotSize.Value, trackBarBlindSize.Value, textboxName.Text, 1);
                GameForm formGame = new GameForm(settings);
                formGame.ShowDialog();
                this.Close();
            } else {
                nameErrorLabel.Visible = true;
            }
        }

        private void BlindSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void BlindSizeTrackBar_ValueChanged(object sender, EventArgs e)
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

        private void PotSizeTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the potsize trackbar with the potsize numeric up down
        {
            if (_valueJustChanged) {
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

        private void PotSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void NumberOfPlayersTrackBar_ValueChanged(object sender, EventArgs e)
        // Links the number of players trackbar with the number of players numeric up down
        {
            numericUpDownNumberOfPlayers.Value = trackBarNumberOfPlayers.Value;
        }

        private void NumberOfPlayersNumericUpDown_ValueChanged(object sender, EventArgs e)
        // Links the number of players numeric up down with the number of players trackbar
        {
            trackBarNumberOfPlayers.Value = (int)numericUpDownNumberOfPlayers.Value;
        }

        private void TextboxName_Leave(object sender, EventArgs e)
        // Checks if player has Entered a name
        {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "") {
                txtbox.Text = "Enter Name";
                _nameChanged = false;
            }
        }

        private void TextboxName_Enter(object sender, EventArgs e)
        // Removes the text "Enter Name" when clicked
        {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text == "Enter Name" && !_nameChanged) {
                txtbox.Text = "";
            }
        }

        private void Textbox_CheckChange(object sender, KeyPressEventArgs e)
        // Checks if the Entered name is a Valid option
        {
            TextBox txtbox = (TextBox)sender;
            if(txtbox.Text != "" || txtbox.Text != "Enter Name") {
                _nameChanged = true;
            }
        }

        private void TextboxName_KeyDown(object sender, KeyEventArgs e)
        //Enables the user to press "Enter" and start the game from the Player Name textbox.
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStartGame.PerformClick();
            }
        }

        private void TrackBarBlindSize_ValueChanged(object sender, EventArgs e) {
            numericUpDownBlindSize.Value = trackBarBlindSize.Value;
        }
    }
}
