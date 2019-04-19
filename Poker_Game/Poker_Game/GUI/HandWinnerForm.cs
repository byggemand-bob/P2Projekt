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

        public HandWinnerForm(GameForm gameForm)
        {
            GameForm = gameForm;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            labelPotSizeWon.Text = "Pot Size Won: " + 100;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            GameForm.CreateNewHand();
            this.Close();
        }
    }
}
