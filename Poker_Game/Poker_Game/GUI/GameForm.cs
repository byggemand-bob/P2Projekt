using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game {
    public partial class GameForm : Form {
        /*
        list<Player> Players = new list<Player>();
        Settings GameSettings = New Settings();
        */
        
        public GameForm(String InputPlayerName, int InputPotSize, int InputBlindSize) {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            /*
            Players.add(new Player(1, InputPotSize, InputPlayerName)); PlayerName needs implimenting
            GameSettings.BlindSize = InputBlindSize;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set the window form.
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);

            //Load background picture.
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void buttonQuitToMenu_Click(object sender, EventArgs e)
        {
            QuitConfirmationForm formConfirmationQuit = new QuitConfirmationForm(this);
            formConfirmationQuit.ShowDialog();
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            // Call
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            // Check
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            // Raise
        }
    }
}
