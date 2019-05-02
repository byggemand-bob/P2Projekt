using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game {
    public partial class GameForm : Form {
        private Settings Settings;
        private readonly PokerGame Game;
        private readonly List<Button> ActionButtons = new List<Button>();
        private readonly List<PictureBox> PictureBoxes = new List<PictureBox>();
        private const bool DiagnosticsMode = false;
        
        #region Initialization

        public GameForm(Settings settings) { // Think about making Settings in settingsform and has it as a parameter. 
            InitializeComponent();
            Settings = settings;
            // Initilization of List for more readable and homogeneous code
            CreateButtonList();
            CreatePictureBoxList();

            // Diagnostics window for (bad) debugging
            panel1.Visible = DiagnosticsMode;

            // Creates the game with usersettings
            Game = new PokerGame(Settings);
            Game.Players[0].Name = Settings.PlayerName;
            Game.Players[1].Name = "Deep Peer";
            
            labelPlayerStack.Text = Convert.ToString(Game.Players[0].Stack); // Why only index 0? 
            labelTablePot.Text = Convert.ToString("Pot:   $" + 0);
            labelPlayerName.Text = Settings.PlayerName;

            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, Game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, Game.Players[0].Cards[1]);
            UpdateAll();
        }

        private void Form1_Load(object sender, EventArgs e) { 
            this.MaximumSize = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterScreen;

            //Load background picture
            this.BackgroundImage = Properties.Resources.PokerBord;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CreateButtonList() // Adds all action-buttons to ButtonsList
        {
            ActionButtons.Add(buttonCall);
            ActionButtons.Add(buttonCheck);
            ActionButtons.Add(buttonRaise);
            ActionButtons.Add(buttonFold);
        }

        private void CreatePictureBoxList() // Adds all pictureBoxes from winform into a list. 
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

        private void ShowCardImage(PictureBox obj, Card card) // Changes image of a tablecard. Both image and object are parameters
        {   
            card.LoadImage();
            obj.Image = card.Image;
        }

        private void ResetCards() { // Reset of tablecard images to default
            foreach (PictureBox pictureBox in PictureBoxes) {
                pictureBox.Image = Properties.Resources.z_Back_of_card2;
            }
        }

        #endregion

        #region Updates

        private void UpdateAll() // Name-change? --- Makes sure the game progresses as it should. 
        {
            UpdateLabelCurrentBet(Game.Players);
            UpdateRoundName();
            UpdateCurrentPlayer();
            UpdatePlayerStack(Game.Players[0], Game.Players[1]);
            UpdatePotSize(Game.CurrentHand());
            UpdatePlayerBlindLabels(Game.Players[0]);
            UpdateButtons();
            UpdateCards();
            if (DiagnosticsMode) {UpdateTest();}
            // CheckPlayerTurn(Game.CurrentPlayerIndex); Disabled until AI has been implemented
        }

        private void UpdateCards() // Checks if a new tablecard should be 'revealed'
        { 
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
                Showdown();
                EndOfHand();
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

        private void UpdateCurrentPlayer() // Highlights current player's name
        { 
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
                //Disabled untill AI has been implemented ??? missing something
                //ChangeActionButtonState(false);
            }
        }

        private void UpdatePlayerStack(Player player, Player AI) // Updates the stack-label of all players
        {
            labelPlayerStack.Text = "Your Stack:" + Environment.NewLine + player.Stack;
            labelAIStack.Text = "Deep Peer" + Environment.NewLine + "Stack:" + Environment.NewLine + AI.Stack;
        }

        private void UpdatePotSize(Hand hand) // Updates the Pot size-label.
        {
            labelTablePot.Text = "Pot:   $" + Convert.ToString(hand.Pot);
        }

        private void UpdatePlayerBlindLabels(Player player) // Updates blind-labels for each player
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

        private void UpdateButtons() // Enables buttons only if the player can make such action
        {
            buttonCall.Enabled = Game.CanCall();
            buttonCheck.Enabled = Game.CanCheck();
            buttonRaise.Enabled = Game.CanRaise();

        }

        private void CheckPlayerTurn(int id)
        {
            ChangeActionButtonState(id == 0);
        }

        private void UpdateLabelCurrentBet(List<Player> players)
        {
            if (Game.CurrentRoundNumber() == 1)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + players[0].CurrentBet;
                labelAICurrentBet.Text = "Current betsize: $" + players[1].CurrentBet;
            }
            else if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + players[0].CurrentBet;
            }
            else if (Game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + players[1].CurrentBet;
            }
        }
 
        #endregion

        #region ButtonEvents

        private void buttonQuitToMenu_Click(object sender, EventArgs e)
        {
            QuitConfirmationForm formConfirmationQuit = new QuitConfirmationForm(this);
            formConfirmationQuit.ShowDialog();
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            Game.Call();
            UpdateAll();
        }

        private void buttonCall_MouseEnter(object sender, EventArgs e)
        {
            if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + GetCurrentTopBidderIndex().CurrentBet; 
            }
            else if (Game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + GetCurrentTopBidderIndex().CurrentBet;
            }
        }

        private void buttonCall_MouseLeave(object sender, EventArgs e)
        {
            if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + Game.Players[0].CurrentBet;
            }
            else if (Game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + Game.Players[1].CurrentBet;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Game.Check();
            UpdateAll();
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            Game.Raise();
            UpdateAll();

        }

        private void buttonRaise_MouseEnter(object sender, EventArgs e)
        {
            if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + (GetCurrentTopBidderIndex().CurrentBet + 100);
            }
            else if (Game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + (GetCurrentTopBidderIndex().CurrentBet + 100);
            }
        }

        private void buttonRaise_MouseLeave(object sender, EventArgs e)
        {
            if (Game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + Game.Players[0].CurrentBet;
            }
            else if (Game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + Game.Players[1].CurrentBet;
            }
        }

        private void buttonFold_Click(object sender, EventArgs e)
        {
            Game.Fold();
            ChangeActionButtonColor();
            UpdateAll();
            ChangeActionButtonState(false);
            EndOfHand();
        }

        #endregion  

        #region Utility

        private void ChangeActionButtonState(bool updatedState) // check if updatedState is the same as old?
        { 
            foreach(Button button in ActionButtons) {
                button.Enabled = updatedState;
            }
            ChangeActionButtonColor();
        }

        private void ChangeActionButtonColor() // Changes color depending if button is clickable or not
        {
            foreach(Button button in ActionButtons)
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

        private bool CheckPlayerStack(List<Player> players)
        {
            foreach (Player player in players)
            {
                if (player.Stack <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void Showdown() // TODO: Make less crowded - more methods!
        {
                // Shows AI's cards on hand if a player has not folded
                ShowCardImage(pictureAICard1, Game.Players[1].Cards[0]);
                ShowCardImage(pictureAICard2, Game.Players[1].Cards[1]);           
        }

        private void EndOfHand()
        {
            Game.UpdateState();
            ChangeActionButtonState(false);
            if (Game.IsFinished())
            {
                MessageBox.Show("GAMEOVER!");
            }
            else
            {
                ShowEndOfHandWindow();
            }
        }

        private void ShowEndOfHandWindow()
        {
            // Shows new window with information about who won, how much and how. (Playername, potsize and wincondition)
            HandWinnerForm handWinnerForm = new HandWinnerForm(GetWinnerPlayersName(), Game.CurrentHand().Pot, GetWinningPlayersScore(), checkboxEnableTimer.Checked); // More information from GameForm
            handWinnerForm.ShowDialog();
            ChangeActionButtonState(true);
            CreateNewHand();
        }

        private string GetWinningPlayersScore()
        {
            if (Game.GetWinners(Game.CurrentHand()).Count == 1)
            {
                if (Int32.TryParse(ConvertScoreToString(0), out int numericScore))
                {
                    if (numericScore > 10)
                    {
                        return GiveScoreName(numericScore);
                    }
                    return numericScore + " (Highest Card)";
                }
                return ConvertScoreToString(0);
            }
            else if (Game.GetWinners(Game.CurrentHand()).Count == 2)
            {
                return ConvertScoreToString(0);
            }
            return null; // TODO: error handling
        }

        private string GiveScoreName(int numericScore)
        {
            if (numericScore == 11)
            {
                return "Jack (Highest Card)";
            }
            else if (numericScore == 12)
            {
                return "Queen (Highest Card)";
            }
            else if (numericScore == 13)
            {
                return "King (Highest Card)";
            }
            else
            {
                return "Ace (Highest Card)";
            }
        }

        private string ConvertScoreToString(int index)
        {
            return Convert.ToString(Game.GetWinners(Game.CurrentHand())[index].Score);
        }

        private string GetWinnerPlayersName() // Gets the string of which player has won
        {
            List<Player> players = Game.GetWinners(Game.CurrentHand());
            string winners = null;
            foreach (Player player in players)
            {
                if (winners == null)
                {
                    winners += player.Name;
                }
                else
                {
                    winners += " & " + player.Name;
                }
            }
            return winners;
        }

        public void CreateNewHand() // Creates a new hand and calls methods for the new gamestate
        {
            Game.NewHand();
            ResetCards();
            UpdateAll();
            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, Game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, Game.Players[0].Cards[1]);
        }

        private void UpdateTest() // Test labels - used for diagnostics
        {
            label2.Text = "DealerButtonPosition: " + Game.DealerButtonPosition;
            label3.Text = "HandNumber: " + Game.CurrentHandNumber();
            label4.Text = "RoundNumber: " + Game.CurrentRoundNumber();
            label5.Text = "HandInProgress: " + Game.HandInProgress;
            label6.Text = "RoundInProgress: " + Game.RoundInProgress;
            label7.Text = "AI Stack: " + Game.Players[1].Stack;
            label8.Text = "Player Stack: " + Game.Players[0].Stack;
            label9.Text = "CycleStep: " + Game.CurrentRound().CycleStep;
            label10.Text = "Bets: " + Game.CurrentRound().Bets;
            label11.Text = "CurrentPlayerIndex: " + Game.CurrentPlayerIndex;
            label12.Text = "TopBidderIndex: " + Game.CurrentRound().TopBidderIndex;
        }

        private Player GetCurrentTopBidderIndex()
        {
            return Game.Players[Game.Hands[Game.CurrentHandNumber() - 1].Rounds[Game.CurrentRoundNumber() - 1].TopBidderIndex];
        }
        #endregion
    }
}