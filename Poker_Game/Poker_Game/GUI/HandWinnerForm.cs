using System;
using System.Windows.Forms;
using Poker_Game.Game;

// Kan det laves bedre? Det kan det sikkert...

namespace Poker_Game
{
    partial class HandWinnerForm : Form
    {
        public HandWinnerForm(string winners, int potsizeWon, string score)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FindWinnerName(winners);
            UpdatePotSizeLabel(potsizeWon);
            UpdateWincondition(score);
        }

        private void FindWinnerName(string winners) 
        {
            labelWinningPlayerName.Text = "Playername: " + winners;
        }

        private void UpdatePotSizeLabel(int potSize)
        {
            labelPotSizeWon.Text = "Pot Size Won: $" + potSize;
        }

        private void UpdateWincondition(String score)
        {
            // Do this mehtod when winconditions are okay
            labelWincondition.Text = "Wincondition: " + score;
        }
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
