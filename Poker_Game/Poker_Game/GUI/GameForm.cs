using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game.AI;
using Poker_Game.Game;

namespace Poker_Game {
    public partial class GameForm : Form {
        private readonly Settings _settings;
        private readonly PokerGame _game;
        private readonly List<Button> _actionButtons = new List<Button>();
        private readonly List<PictureBox> _pictureBoxes = new List<PictureBox>();
        private readonly PokerAI _ai;
        private int _prevRound = 0; // Husk fix ai

        private const int AiSleepTime = 0;


        #region Initialization

        public GameForm(Settings settings) { // Think about making Settings in settingsForm and has it as a parameter. 
            InitializeComponent();
            _settings = settings;
            // Initialization of List for more readable and homogeneous code
            CreateButtonList();
            CreatePictureBoxList();

            // Creates the game with user settings
            _game = new PokerGame(_settings);
            _game.Players[0].Name = _settings.PlayerName;
            _game.Players[1].Name = "Deep Peer";

            labelPlayerStack.Text = Convert.ToString(_game.Players[0].Stack); // Why only index 0? 
            labelTablePot.Text = Convert.ToString("Pot:   $" + 0);
            labelPlayerName.Text = _settings.PlayerName;
            UpdatePlayerBlindLabels(_game.Players[0]);

            //AI
            _ai = new PokerAI(_game);

            MainUpdate();
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

        private void MainUpdate() {
            TurnUpdate();
            if(_prevRound < _game.CurrentRoundNumber()) { RoundUpdate(); }
        }

        private void TurnUpdate() {
            AiTurn();
            UpdateCurrentPlayer();
            UpdateButtons();
            UpdateLabelCurrentBet(_game.Players);
            UpdatePlayerStack(_game.Players[0], _game.Players[1]);
            UpdatePotSize(_game.CurrentHand());
            CheckForPrematureShowdown(_game.Players);
        }

        private void RoundUpdate() {
            _prevRound++;
            UpdateRoundName();
            UpdateCards();
            if(_prevRound == 5) { HandUpdate(); }
        }

        private void HandUpdate() {
            _prevRound = 0;
            EndOfHand();
            CreateNewHand();
            UpdatePlayerBlindLabels(_game.Players[0]);
        }

        #region Table Cards Visuals

        private void ShowCardImage(PictureBox obj, Card card) // Changes image of a tablecard. Both image and object are parameters
        {
            card.LoadImage();
            obj.Image = card.Image;
        }

        private void ResetCards()  // Reset of tablecard images to default
        {
            foreach(PictureBox pictureBox in _pictureBoxes) {
                pictureBox.Image = Properties.Resources.z_Back_of_card2;
            }
        }

        #endregion

        #region Updates

        private void UpdateCards() // Checks if a new tablecard should be 'revealed'
        {
            if(_game.CurrentRoundNumber() == 1) {
                ShowCardImage(picturePlayerCard1, _game.Players[0].Cards[0]);
                ShowCardImage(picturePlayerCard2, _game.Players[0].Cards[1]);
            } else if(_game.CurrentRoundNumber() == 2) {
                ShowCardImage(pictureTableCard1, _game.CurrentHand().Street[0]); // Shows image of the the first table card (flop)
                ShowCardImage(pictureTableCard2, _game.CurrentHand().Street[1]);
                ShowCardImage(pictureTableCard3, _game.CurrentHand().Street[2]);
            } else if(_game.CurrentRoundNumber() == 3) {
                ShowCardImage(pictureTableCard4, _game.CurrentHand().Street[3]); // Shows turn card
            } else if(_game.CurrentRoundNumber() == 4) {
                ShowCardImage(pictureTableCard5, _game.CurrentHand().Street[4]); // Shows river card
            } else if(_game.CurrentRoundNumber() == 5) {
                ShowOpponentsHand();
            }
        }

        private void UpdateButtons() {
            buttonCall.Enabled = _game.CanCall();
            buttonCheck.Enabled = _game.CanCheck();
            buttonRaise.Enabled = _game.CanRaise();
        }

        #endregion

        #region Visual Updates

        private void ShowAllCards() // only called if a player is all in, and the street has to be drawn
        {
            _game.Hands[_game.CurrentHandNumber() - 1].DrawCards(5); // Draws all cards for the street without going through all the List<Round> in hands. 
            ShowOpponentsHand();
            ShowCardImage(pictureTableCard1, _game.CurrentHand().Street[0]); // Shows image of the the first table card (flop)
            ShowCardImage(pictureTableCard2, _game.CurrentHand().Street[1]); // Shows image of the second table card (flop)
            ShowCardImage(pictureTableCard3, _game.CurrentHand().Street[2]); // Shows image of the third table card (flop)
            ShowCardImage(pictureTableCard4, _game.CurrentHand().Street[3]); // Shows turn card
            ShowCardImage(pictureTableCard5, _game.CurrentHand().Street[4]); // Shows river card
        }

        private void UpdateRoundName() // Updates the labelRoundName to show player. 
        {
            if(_game.CurrentRoundNumber() == 1) {
                labelRoundName.Text = "Round: Preflop";
            } else if(_game.CurrentRoundNumber() == 2) {
                labelRoundName.Text = "Round: Flop";
            } else if(_game.CurrentRoundNumber() == 3) {
                labelRoundName.Text = "Round: Turn";
            } else if(_game.CurrentRoundNumber() == 4) {
                labelRoundName.Text = "Round: River";
            } else if(_game.CurrentRoundNumber() == 5) {
                labelRoundName.Text = "Round: Showdown";
            }

        }

        private void UpdateCurrentPlayer() // Highlights current player's name with a yellew color
        {
            if(_game.CurrentPlayerIndex == 0) // Player has turn
            {
                labelPlayerName.ForeColor = Color.Yellow;
                labelAIStack.ForeColor = Color.White;
                ChangeActionButtonState(true);
            } else // AI has turn
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

        private void UpdatePlayerBlindLabels(Player player) // Updates blind-labels for both players
        {
            if(player.IsBigBlind) {
                labelAIBlind.Text = "Small blind";
                labelPlayerBlind.Text = "Big blind";
            } else {
                labelPlayerBlind.Text = "Small blind";
                labelAIBlind.Text = "Big blind";
            }
        }

        private void UpdateLabelCurrentBet(List<Player> players) {
            labelPlayerCurrentBet.Text = "Current betsize: $" + players[0].CurrentBet;
            labelAICurrentBet.Text = "Current betsize: $" + players[1].CurrentBet;
        }

        private void ChangeActionButtonState(bool updatedState) // check if updatedState is the same as old?
        {
            foreach(Button button in _actionButtons) {
                button.Enabled = updatedState;
            }
            ChangeActionButtonColor();
        }

        private void ChangeActionButtonColor() // Changes color depending if button is clickable or not
        {
            foreach(Button button in _actionButtons) {
                if(!button.Enabled) {
                    button.BackColor = Color.Gray;
                } else {
                    button.BackColor = Color.Red;
                }
            }
        }

        #endregion

        #region ButtonEvents

        private void ButtonQuitToMenu_Click(object sender, EventArgs e) // Exits gameForm
        {
            QuitConfirmationForm formConfirmationQuit = new QuitConfirmationForm(this);
            formConfirmationQuit.ShowDialog();
        }

        private void ButtonCall_Click(object sender, EventArgs e) {
            _game.Call();
            MainUpdate();
        }

        private void ButtonCall_MouseEnter(object sender, EventArgs e) {
            if(_game.CurrentPlayerIndex == 0) {
                labelPlayerCurrentBet.Text = "Current betsize: $" + _game.Players[1].CurrentBet;
            }
        }

        private void ButtonCall_MouseLeave(object sender, EventArgs e) {
            if(_game.CurrentPlayerIndex == 0) {
                labelPlayerCurrentBet.Text = "Current betsize: $" + _game.Players[0].CurrentBet;
            }
        }

        private void ButtonCheck_Click(object sender, EventArgs e) {
            _game.Check();
            MainUpdate();
        }

        private void ButtonRaise_Click(object sender, EventArgs e) {
            _game.Raise();
            MainUpdate();
        }

        private void ButtonRaise_MouseEnter(object sender, EventArgs e) {
            if(_game.CurrentPlayerIndex == 0) {
                labelPlayerCurrentBet.Text = "Current betsize: $" + (_game.Players[1].CurrentBet + 2 * _settings.BlindSize);
            }
        }

        private void ButtonRaise_MouseLeave(object sender, EventArgs e) {
            if(_game.CurrentPlayerIndex == 0) {
                labelPlayerCurrentBet.Text = "Current betsize: $" + _game.Players[0].CurrentBet;
            }
        }

        private void ButtonFold_Click(object sender, EventArgs e) {
            _game.Fold();
            ChangeActionButtonColor();
            MainUpdate();
            ChangeActionButtonState(false);
            EndOfHand();
        }

        #endregion  

        #region End Of Hand Methods


        private void CheckForPrematureShowdown(List<Player> players) // Calls metods for showdown when a player has $0 in stack and both have same currentBet. 
        {
            if(CheckPlayerStackForDepletion(players) && (players[0].CurrentBet == players[1].CurrentBet)) {
                ShowAllCards();
                EndOfHand();
            }
        }

        private bool CheckPlayerStackForDepletion(List<Player> players) // Checks for players having less of equal to $0 in stack. 
        {
            foreach(Player player in players) {
                if(player.Stack <= 0) {
                    return true;
                }
            }
            return false;
        }

        private void ShowOpponentsHand() // Shows AI's hand in showdown
        {
            ShowCardImage(pictureAICard1, _game.Players[1].Cards[0]);
            ShowCardImage(pictureAICard2, _game.Players[1].Cards[1]);
        }

        private void EndOfHand() {
            // Checks if the game is finished, and makes the buttons un-pressable.
            ChangeActionButtonState(false);
            _ai.PrepareNewHand();
            ShowEndOfHandWindow();
        }

        private void ShowEndOfHandWindow() {
            // Shows new window with information about who won, how much and how. (CheckPlayerStack, Playername, potsize and wincondition)
            HandWinnerForm handWinnerForm = new HandWinnerForm(CheckPlayerStackForDepletion(_game.Players), GetWinnerPlayersName(), _game.CurrentHand().Pot, GetWinningPlayersScore(), checkboxEnableTimer.Checked);
            handWinnerForm.ShowDialog();

            if(!CheckPlayerStackForDepletion(_game.Players)) // Both players still have money in stack = make new hand
            {
                ChangeActionButtonState(true);
            } else {
                // Game has ended
                MessageBox.Show("Game has ended");
                this.Close();
            }
        }

        private string GetWinningPlayersScore() // Collects information about winner(s) and converts into a string for easy parameter. 
        {
            if(_game.GetWinners(_game.CurrentHand()).Count == 1) {
                if(Int32.TryParse(ConvertScoreToString(0), out int numericScore)) {
                    if(numericScore > 10) {
                        return GiveNumericScoreName(numericScore);
                    }
                    return numericScore + " (Highest Card)";
                }
                return ConvertScoreToString(0);
            } else if(_game.GetWinners(_game.CurrentHand()).Count == 2) {
                return ConvertScoreToString(0);
            }
            return null; // TODO: error handling
        }

        private string GiveNumericScoreName(int numericScore) {
            if(numericScore == 11) {
                return "Jack (Highest Card)";
            } else if(numericScore == 12) {
                return "Queen (Highest Card)";
            } else if(numericScore == 13) {
                return "King (Highest Card)";
            } else {
                return "Ace (Highest Card)";
            }
        }

        private string ConvertScoreToString(int index) {
            return Convert.ToString(_game.GetWinners(_game.CurrentHand())[index].Score);
        }

        private string GetWinnerPlayersName() // Gets the string of which player has won
        {
            List<Player> players = _game.GetWinners(_game.CurrentHand());
            string winners = null;
            foreach(Player player in players) {
                if(winners == null) {
                    winners += player.Name;
                } else {
                    winners += " & " + player.Name;
                }
            }
            return winners;
        }

        // Creates a new hand and calls methods for the new gamestate
        private void CreateNewHand() 
        {
            _game.UpdateState();
            _game.NewHand();
            ResetCards();
            //MainUpdate();
        }

        #endregion

        #region AI

        private void AiTurn() {
            if(_game.Players[0].Action != PlayerAction.Fold) {
                if(_prevRound > 2) { _ai.PrepareNewTree(); }
                if(_game.CurrentPlayerIndex == 1) {
                    System.Threading.Thread.Sleep(AiSleepTime);
                    _ai.MakeDecision();
                    MainUpdate();
                }
            }
        }

        #endregion

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e) {
            _ai.SaveData();
        }
    }
}