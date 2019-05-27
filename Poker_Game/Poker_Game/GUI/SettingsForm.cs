using System;
using System.Windows.Forms;
using Poker_Game.AI;
using Poker_Game.Properties;
using Settings = Poker_Game.Game.Settings;

namespace Poker_Game.GUI {
    public partial class SettingsForm : Form {
        private bool _nameChanged;
        private bool _valueJustChanged;

        public SettingsForm() {
            InitializeComponent();
            Icon = Resources.coins;
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Makes sure you've entered a name before continueing
        private void ButtonStartGame_Click(object sender, EventArgs e) {
            if(_nameChanged) {
                Hide();
                Settings settings = new Settings(2, trackBarPotSize.Value, trackBarBlindSize.Value, textboxName.Text, 1,
                    radioButtonMonteCarlo.Checked ? AiMode.MonteCarlo : AiMode.ExpectiMax);

                GameForm formGame = new GameForm(settings);
                formGame.ShowDialog();
                Close();
            } else {
                nameErrorLabel.Visible = true;
            }
        }

        // Links the blind numeric up down with the blind trackbar
        private void BlindSizeNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if(_valueJustChanged) {
                _valueJustChanged = false;
            } else {
                _valueJustChanged = true;
                trackBarBlindSize.Value = (int) numericUpDownBlindSize.Value;
            }
        }

        // Links the potsize trackbar with the potsize numeric up down
        private void PotSizeTrackBar_ValueChanged(object sender, EventArgs e) {
            if(_valueJustChanged) {
                _valueJustChanged = false;
            } else {
                if(trackBarPotSize.Value % 100 != 0) {
                    _valueJustChanged = true;
                    trackBarPotSize.Value = trackBarPotSize.Value - trackBarPotSize.Value % 100;
                }

                _valueJustChanged = true;

                numericUpDownPotSize.Value = trackBarPotSize.Value;
            }
        }

        // Links the potsize numeric up down with the potsize trackbar
        private void PotSizeNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if(_valueJustChanged) {
                _valueJustChanged = false;
            } else {
                _valueJustChanged = true;
                trackBarPotSize.Value = (int) numericUpDownPotSize.Value;
            }
        }

        // Links the number of players trackbar with the number of players numeric up down
        private void NumberOfPlayersTrackBar_ValueChanged(object sender, EventArgs e) {
            numericUpDownNumberOfPlayers.Value = trackBarNumberOfPlayers.Value;
        }

        // Links the number of players numeric up down with the number of players trackbar
        private void NumberOfPlayersNumericUpDown_ValueChanged(object sender, EventArgs e) {
            trackBarNumberOfPlayers.Value = (int) numericUpDownNumberOfPlayers.Value;
        }

        private void TextboxName_Leave(object sender, EventArgs e)
            // Checks if player has Entered a name
        {
            TextBox txtbox = (TextBox) sender;
            if(txtbox.Text == "") {
                txtbox.Text = @"Enter Name";
                _nameChanged = false;
            }
        }

        // Removes the text "Enter Name" when clicked
        private void TextboxName_Enter(object sender, EventArgs e) {
            TextBox txtbox = (TextBox) sender;
            if(txtbox.Text == @"Enter Name" && !_nameChanged) txtbox.Text = "";
        }

        // Checks if the Entered name is a Valid option
        private void Textbox_CheckChange(object sender, KeyPressEventArgs e) {
            TextBox txtbox = (TextBox) sender;
            if(txtbox.Text != "" || txtbox.Text != @"Enter Name") _nameChanged = true;
        }

        //Enables the user to press "Enter" and start the game from the Player Name textbox.
        private void TextboxName_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) buttonStartGame.PerformClick();
        }

        private void TrackBarBlindSize_ValueChanged(object sender, EventArgs e) {
            numericUpDownBlindSize.Value = trackBarBlindSize.Value;
        }
    }
}