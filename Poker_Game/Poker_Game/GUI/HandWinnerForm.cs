using System;
using System.Windows.Forms;
using Poker_Game.Properties;

namespace Poker_Game.GUI {
    internal partial class HandWinnerForm : Form {
        private int _timeLeft = 10;

        public HandWinnerForm(string winners, int potSizeWon, string score, bool timerEnabled) {
            InitializeComponent();
            Icon = Resources.coins;

            labelMessage.Text = GenerateMessage(winners, potSizeWon, score);
            if(timerEnabled) {
                timer1.Enabled = true;
                buttonContinue.Text = "Continue .. " + _timeLeft;
            } else {
                buttonContinue.Text = "Continue";
            }
        }

        private string GenerateMessage(string winners, int moneyWon, string score) {
            if(score.Equals("None"))
                return winners + " won, because their opponent folded." +
                       Environment.NewLine + winners + " gained $" + moneyWon;
            if(!winners.Contains("&"))
                return winners + " won over their opponent with " +
                       Environment.NewLine + "a " + score + ". " + winners + " gained $" + moneyWon;

            string[] winnersArray = winners.Split('&');
            return winnersArray[0] + "and" + winnersArray[1] + " tied with" + Environment.NewLine +
                   "a " + score + ". They split $" + moneyWon;
        }

        private void ButtonContinue_Click(object sender, EventArgs e) {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            buttonContinue.Text = "Continue .. " + --_timeLeft;
            if(_timeLeft == 0) Close();
        }
    }
}