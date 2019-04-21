﻿using System;
using System.Windows.Forms;

// Kan det laves bedre? Det kan det sikkert...

namespace Poker_Game
{
    partial class HandWinnerForm : Form
    {
        public HandWinnerForm(string winners, int potsizeWon)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FindWinnerName(winners);
            UpdatePotSizeLabel(potsizeWon);
        }

        private void FindWinnerName(string winners) 
        {
            labelWinningPlayerName.Text = "Playername: " + winners;
        }

        private void UpdatePotSizeLabel(int potSize)
        {
            labelPotSizeWon.Text = "Pot Size Won: " + potSize;
        }

        private void UpdateWincondition()
        {
            // Do this mehtod when vindonditions are okay
            labelWincondition.Text = "2 pairs";
        }
        private void buttonContinue_Click(object sender, EventArgs e) // How can this method be called without having gameForm as parameter and mehtod non-static?
        {
            this.Close();
        }
    }
}
