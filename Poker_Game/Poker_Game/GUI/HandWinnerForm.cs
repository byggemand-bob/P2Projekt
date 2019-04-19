using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Game.Game;

// Kan det laves bedre? Det kan det sikkert...

namespace Poker_Game
{
    partial class HandWinnerForm : Form
    {
        private GameForm GameForm;
        private string Winners;

        public HandWinnerForm(GameForm gameForm)
        {
            GameForm = gameForm;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FindWinnerName(GameForm.Game.GetWinners(GameForm.Game.CurrentHand()), GameForm.Settings.PlayerName);
            UpdatePotSizeLabel(gameForm.Game.Hands[gameForm.Game.CurrentHandNumber() - 1].Pot);
        }

        private void FindWinnerName(List<Player> players, String playernames) // TODO: Make this shit work
        {
            foreach (Player player in players)
            {
                Winners += playernames;
            }
            labelWinningPlayerName.Text = "Playername: " + Winners;
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
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            GameForm.CreateNewHand();
            this.Close();
        }
    }
}
