using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game {
    partial class HandWinnerForm : Form {
        private int _timeLeft = 10;

        public HandWinnerForm(string winners, int potSizeWon, string score, bool timerEnabled) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            labelMessage.Text = GenerateMessage(winners, potSizeWon, score);
            if(timerEnabled) {
                timer1.Enabled = true;
                buttonContinue.Text = "Continue .. " + _timeLeft;
            } else {
                buttonContinue.Text = "Continue";
            }
        }

        private string GenerateMessage(string winners, int moneyWon, string score) {

            if (score.CompareTo("None") == 0)  {
                return winners + " won, because their opponent folded" +
                       Environment.NewLine + "They gained $" + moneyWon;
            }

            else if (!winners.Contains("&"))  {
                return winners + " won over their opponent with " +
                    Environment.NewLine + "a " + score + ". They gained $" + moneyWon;
            }

            else  {
                string[] winnersArray = winners.Split('&');
                return winnersArray[0] + " & " + winnersArray[1] + " tied with" + Environment.NewLine +
                       "a " + score + "They both get $" + moneyWon;
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e) {
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
