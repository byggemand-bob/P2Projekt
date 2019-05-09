using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game.AI;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game {
    public partial class GameForm : Form {
        private readonly Settings _settings;
        private readonly PokerGame _game;
        private readonly List<Button> _actionButtons = new List<Button>();
        private readonly List<PictureBox> _pictureBoxes = new List<PictureBox>();
        private readonly PokerAI _ai;
        private const bool DiagnosticsMode = true;
        
        #region Initialization

        public GameForm(Settings settings) { // Think about making Settings in settingsForm and has it as a parameter. 
            InitializeComponent();
            _settings = settings;
            // Initialization of List for more readable and homogeneous code
            CreateButtonList();
            CreatePictureBoxList();

            // Diagnostics window for (bad) debugging
            panel1.Visible = DiagnosticsMode;

            // Creates the game with user settings
            _game = new PokerGame(_settings);
            _game.Players[0].Name = _settings.PlayerName;
            _game.Players[1].Name = "Deep Peer";

            // AI
            _ai = new PokerAI(_game);

            labelPlayerStack.Text = Convert.ToString(_game.Players[0].Stack); // Why only index 0? 
            labelTablePot.Text = Convert.ToString("Pot:   $" + 0);
            labelPlayerName.Text = _settings.PlayerName;

            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, _game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, _game.Players[0].Cards[1]);
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
            _actionButtons.Add(buttonCall);
            _actionButtons.Add(buttonCheck);
            _actionButtons.Add(buttonRaise);
            _actionButtons.Add(buttonFold);
        }

        private void CreatePictureBoxList() // Adds all pictureBoxes from winform into a list. 
        {
            _pictureBoxes.Add(pictureAICard1);
            _pictureBoxes.Add(pictureAICard2);
            _pictureBoxes.Add(pictureTableCard1);
            _pictureBoxes.Add(pictureTableCard2);
            _pictureBoxes.Add(pictureTableCard3);
            _pictureBoxes.Add(pictureTableCard4);
            _pictureBoxes.Add(pictureTableCard5);
        }

        #endregion

        #region CardDrawing

        private void ShowCardImage(PictureBox obj, Card card) // Changes image of a tablecard. Both image and object are parameters
        {   
            card.LoadImage();
            obj.Image = card.Image;
        }

        private void ResetCards() { // Reset of tablecard images to default
            foreach (PictureBox pictureBox in _pictureBoxes) {
                pictureBox.Image = Properties.Resources.z_Back_of_card2;
            }
        }

        #endregion

        #region Updates

        private void UpdateAll() // Name-change? --- Makes sure the game progresses as it should. 
        {
            UpdateLabelCurrentBet(_game.Players);
            UpdateRoundName();
            UpdateCurrentPlayer();
            UpdatePlayerStack(_game.Players[0], _game.Players[1]);
            UpdatePotSize(_game.CurrentHand());
            UpdatePlayerBlindLabels(_game.Players[0]); // Malplaceret. 
            UpdateButtons();
            UpdateCards();
            CheckForPrematureShowdown(_game.Players);
            if (DiagnosticsMode) {UpdateTest();}
            CheckPlayerTurn(_game.CurrentPlayerIndex);// Disabled until AI has been implemented
        }

        private void UpdateCards() // Checks if a new tablecard should be 'revealed'
        { 
            if (_game.CurrentRoundNumber() == 2)
            {
                ShowCardImage(pictureTableCard1, _game.CurrentHand().Street[0]); // Shows image of the the first table card (flop)
                ShowCardImage(pictureTableCard2, _game.CurrentHand().Street[1]); // Shows image of the second table card (flop)
                ShowCardImage(pictureTableCard3, _game.CurrentHand().Street[2]); // Shows image of the third table card (flop)
            }
            else if (_game.CurrentRoundNumber() == 3)
            {
                ShowCardImage(pictureTableCard4, _game.CurrentHand().Street[3]); // Shows turn card
            }
            else if (_game.CurrentRoundNumber() == 4)
            {
                ShowCardImage(pictureTableCard5, _game.CurrentHand().Street[4]); // Shows river card
            }
            else if (_game.CurrentRoundNumber() == 5)
            {
                Showdown();
                EndOfHand();
            }
        }

        private void ShowAllCards()
        {
            _game.Hands[_game.CurrentHandNumber() - 1].DrawCards(5);
            Showdown();
            ShowCardImage(pictureTableCard1, _game.CurrentHand().Street[0]); // Shows image of the the first table card (flop)
            ShowCardImage(pictureTableCard2, _game.CurrentHand().Street[1]); // Shows image of the second table card (flop)
            ShowCardImage(pictureTableCard3, _game.CurrentHand().Street[2]); // Shows image of the third table card (flop)
            ShowCardImage(pictureTableCard4, _game.CurrentHand().Street[3]); // Shows turn card
            ShowCardImage(pictureTableCard5, _game.CurrentHand().Street[4]); // Shows river 
        }

        private void UpdateRoundName() 
        {
            if (_game.CurrentRoundNumber() == 1)
            {
                labelRoundName.Text = "Round: Preflop";
            }
            else if (_game.CurrentRoundNumber() == 2)
            {
                labelRoundName.Text = "Round: Flop";
            }
            else if (_game.CurrentRoundNumber() == 3)
            {
                labelRoundName.Text = "Round: Turn";
            }
            else if (_game.CurrentRoundNumber() == 4)
            {
                labelRoundName.Text = "Round: River";
            }
            else if (_game.CurrentRoundNumber() == 5)
            {
                labelRoundName.Text = "Round: Showdown";
            }

        }

        private void UpdateCurrentPlayer() // Highlights current player's name
        { 
            if (_game.CurrentPlayerIndex == 0)
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
            buttonCall.Enabled = _game.CanCall();
            buttonCheck.Enabled = _game.CanCheck();
            buttonRaise.Enabled = _game.CanRaise();

        }

        private void CheckPlayerTurn(int id)
        {
            ChangeActionButtonState(id == 0);
        }

        private void UpdateLabelCurrentBet(List<Player> players)
        {
            if (_game.CurrentRoundNumber() == 1)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + players[0].CurrentBet;
                labelAICurrentBet.Text = "Current betsize: $" + players[1].CurrentBet;
            }
            else if (_game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + players[0].CurrentBet;
            }
            else if (_game.CurrentPlayerIndex == 1)
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
            _game.Call();
            UpdateAll();
            AiTurn();
        }

        private void buttonCall_MouseEnter(object sender, EventArgs e)
        {
            if (_game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + GetCurrentTopBidderIndex().CurrentBet; 
            }
            else if (_game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + GetCurrentTopBidderIndex().CurrentBet;
            }
        }

        private void buttonCall_MouseLeave(object sender, EventArgs e)
        {
            if (_game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + _game.Players[0].CurrentBet;
            }
            else if (_game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + _game.Players[1].CurrentBet;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            _game.Check();
            UpdateAll();
            AiTurn();
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            _game.Raise();
            UpdateAll();
            AiTurn();
        }

        private void buttonRaise_MouseEnter(object sender, EventArgs e)
        {
            if (_game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + (GetCurrentTopBidderIndex().CurrentBet + 100);
            }
            else if (_game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + (GetCurrentTopBidderIndex().CurrentBet + 100);
            }
        }

        private void buttonRaise_MouseLeave(object sender, EventArgs e)
        {
            if (_game.CurrentPlayerIndex == 0)
            {
                labelPlayerCurrentBet.Text = "Current betsize: $" + _game.Players[0].CurrentBet;
            }
            else if (_game.CurrentPlayerIndex == 1)
            {
                labelAICurrentBet.Text = "Current betsize: $" + _game.Players[1].CurrentBet;
            }
        }

        private void buttonFold_Click(object sender, EventArgs e)
        {
            _game.Fold();
            ChangeActionButtonColor();
            UpdateAll();
            ChangeActionButtonState(false);
            EndOfHand();
        }

        #endregion  

        #region Utility

        private void ChangeActionButtonState(bool updatedState) // check if updatedState is the same as old?
        { 
            foreach(Button button in _actionButtons) {
                button.Enabled = updatedState;
            }
            ChangeActionButtonColor();
        }

        private void ChangeActionButtonColor() // Changes color depending if button is clickable or not
        {
            foreach(Button button in _actionButtons)
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


        private void CheckForPrematureShowdown(List<Player> players)
        {
            if (CheckPlayerStack(players) && (players[0].CurrentBet == players[1].CurrentBet))
            {
                ShowAllCards();
                EndOfHand();
            }
        }

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
                ShowCardImage(pictureAICard1, _game.Players[1].Cards[0]);
                ShowCardImage(pictureAICard2, _game.Players[1].Cards[1]);           
        }
        
        private void EndOfHand()
        {
            // Checks if the game is finished, and makes the buttons un-pressable.
            _game.UpdateState();
            ChangeActionButtonState(false);
            ShowEndOfHandWindow();
        }

        private void ShowEndOfHandWindow()
        {
            // Shows new window with information about who won, how much and how. (CheckPlayerStack, Playername, potsize and wincondition)
            HandWinnerForm handWinnerForm = new HandWinnerForm(CheckPlayerStack(_game.Players), GetWinnerPlayersName(), _game.CurrentHand().Pot, GetWinningPlayersScore(), checkboxEnableTimer.Checked); // More information from GameForm
            handWinnerForm.ShowDialog();
            if (!CheckPlayerStack(_game.Players))
            {
                ChangeActionButtonState(true);
                CreateNewHand();
            }
        }

        private string GetWinningPlayersScore()
        {
            if (_game.GetWinners(_game.CurrentHand()).Count == 1)
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
            else if (_game.GetWinners(_game.CurrentHand()).Count == 2)
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
            return Convert.ToString(_game.GetWinners(_game.CurrentHand())[index].Score);
        }

        private string GetWinnerPlayersName() // Gets the string of which player has won
        {
            List<Player> players = _game.GetWinners(_game.CurrentHand());
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
            _game.NewHand();
            _ai.PrepareNewHand(_game);
            ResetCards();
            UpdateAll();
            // Shows player new hand cards
            ShowCardImage(picturePlayerCard1, _game.Players[0].Cards[0]);
            ShowCardImage(picturePlayerCard2, _game.Players[0].Cards[1]);
        }

        private void UpdateTest() // Test labels - used for diagnostics
        {
            label2.Text = "DealerButtonPosition: " + _game.DealerButtonPosition;
            label3.Text = "HandNumber: " + _game.CurrentHandNumber();
            label4.Text = "RoundNumber: " + _game.CurrentRoundNumber();
            label5.Text = "HandInProgress: " + _game.HandInProgress;
            label6.Text = "RoundInProgress: " + _game.RoundInProgress;
            label7.Text = "AI Stack: " + _game.Players[1].Stack;
            label8.Text = "Player Stack: " + _game.Players[0].Stack;
            label9.Text = "CycleStep: " + _game.CurrentRound().CycleStep;
            label10.Text = "Bets: " + _game.CurrentRound().Bets;
            label11.Text = "CurrentPlayerIndex: " + _game.CurrentPlayerIndex;
            label12.Text = "TopBidderIndex: " + _game.CurrentRound().TopBidderIndex;
        }

        private Player GetCurrentTopBidderIndex()
        {
            return _game.Players[_game.Hands[_game.CurrentHandNumber() - 1].Rounds[_game.CurrentRoundNumber() - 1].TopBidderIndex];
        }
        #endregion

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e) {
            _ai.SaveData();
        }

        private void AiTurn() {
            _ai.MakeDecision();
            UpdateAll();
        }

    }
}