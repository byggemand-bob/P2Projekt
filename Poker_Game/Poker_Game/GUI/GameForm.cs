using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game {
    public partial class GameForm : Form {
        private Settings Settings;
        private readonly PokerGame Game;
        private readonly List<Button> Buttons = new List<Button>();
        private readonly List<PictureBox> PictureBoxes = new List<PictureBox>();
        private const bool DiagnosticsMode = true;

         // TODO: Make prettier and show who wins and how much at showdown
        

        #region Initialization

        public GameForm(string inputPlayerName, int inputStackSize, int inputBlindSize, int blindIncrease, bool blindIsRoundBased) { //Think about making Settings in settingsform and has it as a parameter. 
            InitializeComponent();
            CreateButtonList();
            CreatePictureBoxList();
            CreateGameSettings(inputPlayerName, inputStackSize, inputBlindSize, blindIncrease, blindIsRoundBased);
            labelPlayerName.Text = inputPlayerName;

            panel1.Visible = DiagnosticsMode;
            MessageBox.Show("WINNER" + Environment.NewLine +
                            "--------" + Environment.NewLine + 
                            "PlayerName" + Environment.NewLine + 
                            "PotSizeWon" + Environment.NewLine + 
                            "WinningCardCombinatio");
            // Creates the game so to say...
            Game = new PokerGame(Settings);
            labelPlayerStack.Text = Convert.ToString(Game.Players[0].Stack);
            labelTablePot.Text = Convert.ToString("Pot:   $" + 0);
            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, Game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, Game.Players[0].Cards[1]);
            UpdateAll();
        }

        private void CreateGameSettings(string playerName, int stackSize, int blindSize, int blindIncrease, bool blindIsRoundBased) {
            Settings =  new Settings(2, stackSize, blindSize, blindIsRoundBased, blindIncrease, playerName);
        }

        private void Form1_Load(object sender, EventArgs e) { // Events when the form loads
            //Set the window form
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CreateButtonList()
        {
            Buttons.Add(buttonCall);
            Buttons.Add(buttonCheck);
            Buttons.Add(buttonRaise);
            Buttons.Add(buttonFold);
        }

        private void CreatePictureBoxList()
        {
            PictureBoxes.Add(pictureAICard1);
            PictureBoxes.Add(pictureAICard2);
            PictureBoxes.Add(pictureTableCard1);
            PictureBoxes.Add(pictureTableCard2);
            PictureBoxes.Add(pictureTableCard3);
            PictureBoxes.Add(pictureTableCard4);
            PictureBoxes.Add(pictureTableCard5);
        }

        #endregion

        #region CardDrawing

        private void ShowCardImage(PictureBox obj, Card card)
        {
            obj.Image = card.Image;
        }

        private void ResetCards() {
            // Reset table and AI cards to be "invisible"
            foreach (PictureBox pictureBox in PictureBoxes)
            {
                pictureBox.Image = Properties.Resources.z_Back_of_card2;
            }
        }

        #endregion

        #region Updates

        private void UpdateAll() // Name-change?
        {
            UpdateRoundName();
            UpdateCurrentPlayer();
            UpdatePlayerStack(Game.Players[0], Game.Players[1]);
            UpdatePotSize(Game.CurrentHand());
            UpdatePlayerBlind(Game.Players[0]);
            UpdateButtons();
            UpdateCards();
            if (DiagnosticsMode) {UpdateTest();}
            // CheckPlayerTurn(Game.CurrentPlayerIndex); Disabled until AI has been implemented
        }

        private void UpdateCards() {
            if (Game.CurrentRoundNumber() == 2)
            {
                ShowCardImage(pictureTableCard1, Game.CurrentHand().Street[0]); // Shows image of the the first table card (flop)
                ShowCardImage(pictureTableCard2, Game.CurrentHand().Street[1]); // Shows image of the second table card (flop)
                ShowCardImage(pictureTableCard3, Game.CurrentHand().Street[2]); // Shows image of the third table card (flop)
            }
            else if (Game.CurrentRoundNumber() == 3)
            {
                ShowCardImage(pictureTableCard4, Game.CurrentHand().Street[3]); // Shows turn card
            }
            else if (Game.CurrentRoundNumber() == 4)
            {
                ShowCardImage(pictureTableCard5, Game.CurrentHand().Street[4]); // Shows river card
            }
            else if (Game.CurrentRoundNumber() == 5)
            {
                Showdown(false);
            }
        }

        private void UpdateRoundName()
        {
            if (Game.CurrentRoundNumber() == 1)
            {
                labelRoundName.Text = "Round: Preflop";
            }
            else if (Game.CurrentRoundNumber() == 2)
            {
                labelRoundName.Text = "Round: Flop";
            }
            else if (Game.CurrentRoundNumber() == 3)
            {
                labelRoundName.Text = "Round: Turn";
            }
            else if (Game.CurrentRoundNumber() == 4)
            {
                labelRoundName.Text = "Round: River";
            }
            else if (Game.CurrentRoundNumber() == 5)
            {
                labelRoundName.Text = "Round: Showdown";
            }

        }

        private void UpdateCurrentPlayer() { // Highlights current player's name
            if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerName.ForeColor = Color.Yellow;
                labelAIStack.ForeColor = Color.White;
                ChangeActionButtonState(true);
            }
            else
            {
                labelAIStack.ForeColor = Color.Yellow;
                labelPlayerName.ForeColor = Color.White;
                //Disabled untill AI has been implemented
                //ChangeActionButtonState(false);
            }
        }

        private void UpdatePlayerStack(Player player, Player AI) {
            labelPlayerStack.Text = "Your Stack:" + Environment.NewLine + player.Stack;
            labelAIStack.Text = "AI" + Environment.NewLine + "Stack:" + Environment.NewLine + AI.Stack;
        }

        private void UpdatePotSize(Hand hand) {
            labelTablePot.Text = "Pot:   $" + Convert.ToString(hand.Pot);
        }

        private void UpdatePlayerBlind(Player player) {
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

        private void UpdateButtons() {
           
            buttonCall.Enabled = Game.CanCall();
            buttonCheck.Enabled = Game.CanCheck();
            buttonRaise.Enabled = Game.CanRaise();

        }

        private void CheckPlayerTurn(int id) {
            ChangeActionButtonState(id == 0);
        }


        #endregion

        #region ButtonEvents

        // TODO: Fix Fold (Doesn't give the pot to the right player
        // TODO: Fix disables of buttons, so that you cant check when a player has raised

        private void buttonQuitToMenu_Click(object sender, EventArgs e) {
            QuitConfirmationForm formConfirmationQuit = new QuitConfirmationForm(this);
            formConfirmationQuit.ShowDialog();
        }

        private void buttonCall_Click(object sender, EventArgs e) {
            Game.Call();
            UpdateAll();
        }

        private void buttonCheck_Click(object sender, EventArgs e) {
            Game.Check();
            UpdateAll();
        }

        private void buttonRaise_Click(object sender, EventArgs e) {
            Game.Raise();
            UpdateAll();
        }

        private void buttonFold_Click(object sender, EventArgs e) {
            Game.Fold();
            Showdown(true);
            ChangeActionButtonColor();
            UpdateAll();
            ChangeActionButtonState(false);
        }

        private void buttonMakeNewHand_Click(object sender, EventArgs e) {
            ChangeActionButtonState(true);
            CreateNewHand();
            buttonMakeNewHand.Visible = false;
        }

        #endregion

        #region Utility

        private void ChangeActionButtonState(bool updatedState) { // check if updatedState is the same as old?
            foreach(Button button in Buttons) {
                button.Enabled = updatedState;
            }
            ChangeActionButtonColor();
        }

        private void ChangeActionButtonColor() {
            foreach(Button button in Buttons)
            {
                if (!button.Enabled)
                {
                    button.BackColor = Color.Gray;
                }
                else
                {
                    button.BackColor = Color.Red;
                }
            }
        }

        #endregion

        // Un-categorized for now
        #region Other

        private void Showdown(bool playerHasFolded) {
            if (!playerHasFolded)
            {
                // Shows AI's cards on hand if showdown has been reached
                ShowCardImage(pictureAICard1, Game.Players[1].Cards[0]);
                ShowCardImage(pictureAICard2, Game.Players[1].Cards[1]);
            }
            //TODO: Show winner and score
            Game.UpdateState();
            ChangeActionButtonState(false);
            if (Game.IsFinished())
            {
                MessageBox.Show("GAMEOVER SUCKERS!");
            }
            else
            {
                buttonMakeNewHand.Visible = true;
            }
        }

        private void CreateNewHand() {
            Game.NewHand();
            ResetCards();
            UpdateAll();
            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, Game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, Game.Players[0].Cards[1]);
        }

        private void UpdateTest() {
            label2.Text = "DealerButtonPosition: " + Game.DealerButtonPosition;
            label3.Text = "HandNumber: " + Game.CurrentHandNumber();
            label4.Text = "RoundNumber: " + Game.CurrentRoundNumber();
            label5.Text = "HandInProgress: " + Game.HandInProgress;
            label6.Text = "RoundInProgress: " + Game.RoundInProgress;
            label7.Text = "AI Stack: " + Game.Players[1].Stack;
            label8.Text = "Player Stack: " + Game.Players[0].Stack;
            label9.Text = "CycleStep: " + Game.CurrentRound().CycleStep;
        }

        #endregion
    }
}