using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Poker_Game {
    public partial class GameForm : Form {

        private Settings Setting;
        private Game Game;

        public GameForm(String inputPlayerName, int inputStackSize, int inputBlindSize, int blindIncrease, bool blindIsRoundBased) { //Think about making Settings in settingsform and has it as a parameter. 
            InitializeComponent();
            playerName.Text = inputPlayerName;

            // Constuctor called
            CreateGameSettings(inputPlayerName, inputStackSize, inputBlindSize, blindIncrease, blindIsRoundBased);

            // Creates the game so to say...
            Game = new Game(Setting);
            labelPlayerStack.Text = Convert.ToString(Game.Players[0].Stack);
            ShowPlayerHand(Game.Players[0].Cards);
            ShowOpponentHand(Game.Players[1].Cards);
            UpdatePlayerStack(Game.Players[0], Game.Players[1]);
            
        }

        private void Form1_Load(object sender, EventArgs e) // Events when the form loads
        {
            //Set the window form.
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture.
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        } 

        private void CreateGameSettings(string playerName, int stackSize, int blindSize, int blindIncrease, bool blindIsRoundBased)
        {
            Setting = new Settings(2, stackSize, blindSize, blindIsRoundBased, blindIncrease, playerName);
        }

        private void buttonQuitToMenu_Click(object sender, EventArgs e)
        {
            QuitConfirmationForm formConfirmationQuit = new QuitConfirmationForm(this);
            formConfirmationQuit.ShowDialog();
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            // Call
            Game.Call();
            UpdatePlayerStack(Game.Players[0], Game.Players[1]);
            UpdatePotSize(Game.Hands[Game.Hands.Count - 1]);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            // Check
            Game.Check();
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            // Raise
            Game.Raise();
            UpdatePlayerStack(Game.Players[0], Game.Players[1]);
            UpdatePotSize(Game.Hands[Game.Hands.Count - 1]);
        }

        private void ShowPlayerHand(List<Card> cards) // Takes card list from player hand
        {
            picturePlayerCard1.Image = cards[0].Image;
            picturePlayerCard2.Image = cards[1].Image;
        }

        private void ShowOpponentHand(List<Card> cards) // Takes card list from opponent's (AI) hand
        {
            pictureAICard1.Image = cards[0].Image;
            pictureAICard2.Image = cards[1].Image;
        }

        private void ShowFlopCards(List<Card> cards) // Changes picture of the flop cards.
        {
            pictureTableCard1.Image = cards[2].Image;
            pictureTableCard2.Image = cards[3].Image;
            pictureTableCard3.Image = cards[4].Image;
        }

        private void ShowTurnCard(List<Card> cards)
        {
            pictureTableCard4.Image = cards[5].Image;
        }

        private void ShowRiverCard(List<Card> cards)
        {
            pictureTableCard5.Image = cards[6].Image;
        }

        private void UpdatePlayerStack(Player player, Player AI)
        {
            labelPlayerStack.Text = "Your Stack:" + Environment.NewLine + player.Stack;
            labelAIStack.Text = "AI" + Environment.NewLine + "Stack:" + Environment.NewLine + AI.Stack;
        }

        private void UpdatePotSize(Hand hand)
        {
            labelTablePot.Text = "Pot:   $" + Convert.ToString(hand.Pot);
        }

        private void UpdatePlayerBlind(Player player)
        {
            if (player.IsBigBlind)
            {
                labelAIBlind.Text = "Small blind";
                labelPlayerBlind.Text = "Big blind";
            }
            else
            {
                labelPlayerBlind.Text = "Small blind";
                labelAIBlind.Text = "Big blind";
            }
        }
    }
}