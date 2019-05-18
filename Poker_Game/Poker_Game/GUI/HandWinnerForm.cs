using System;
using System.Windows.Forms;

namespace Poker_Game.GUI {
    partial class HandWinnerForm : Form {
        private int _timeLeft = 10;

        public HandWinnerForm(bool gameFinished, string winners, int potSizeWon, string score, bool timerEnabled) {
            InitializeComponent();
            Icon = Properties.Resources.coins;

            labelMessage.Text = GenerateMessage(gameFinished, winners, potSizeWon, score);
            if(timerEnabled) {
                timer1.Enabled = true;
                buttonContinue.Text = "Continue .. " + _timeLeft;
            } else {
                buttonContinue.Text = "Continue";
            }
        }

        private string GenerateMessage(bool gameFinished, string winners, int moneyWon, string score) {
            if (gameFinished) {
                return "Congratulations " + winners + "." +
                    Environment.NewLine + "You have won the game with a " + score;
            }
            if (score.CompareTo("None") == 0)  {
                return winners + " won, because their opponent folded." +
                       Environment.NewLine + winners + " gained $" + moneyWon;
            }
            if (!winners.Contains("&"))  {
                return winners + " won over their opponent with " +
                    Environment.NewLine + "a " + score + ". " + winners + " gained $" + moneyWon;
            }

            // 
            string[] winnersArray = winners.Split('&');
            return winnersArray[0] + "and" + winnersArray[1] + " tied with" + Environment.NewLine +
                   "a " + score + ". They split $" + moneyWon;

        }

        private void ButtonContinue_Click(object sender, EventArgs e) {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            buttonContinue.Text = "Continue .. " + --_timeLeft;
            if(_timeLeft == 0) {
                Close();
            }
        }
    }
}
