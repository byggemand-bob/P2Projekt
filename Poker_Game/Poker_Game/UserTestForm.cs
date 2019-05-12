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

namespace Poker_Game
{
    public partial class UserTestForm : Form
    {
        FastWinCalc winCalc = new FastWinCalc();
        List<Card> Player1Cards = new List<Card>(), Player2Cards = new List<Card>(), Street = new List<Card>(), CardsInPlay = new List<Card>();
        Card NewCard;
        int UserResult, AiResult;
        bool RandomPlayerCards = false;

        private void Player2GuessButton_Click(object sender, EventArgs e)
        {
            UserResult = 1;

            if (UserResult == AiResult)
            {
                NewCards();
            }
            else
            {
                if(AiResult == -1)
                {
                    AiPlayer1GuessLabel.Visible = true;
                }
                else if(AiResult == 0)
                {
                    AiDrawGuessLabel.Visible = true;
                }
                else
                {
                    AiPlayer2GuessLabel.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RandomPlayerCards)
            {
                RandomPlayerCards = false;
                RandomOrStaticButton.Text = "Switch to Random cards";
            }
            else
            {
                RandomPlayerCards = true;
                RandomOrStaticButton.Text = "Switch to Static cards";
            }
        }

        private void DrawGuessButton_Click(object sender, EventArgs e)
        {
            UserResult = 0;

            if (UserResult == AiResult)
            {
                NewCards();
            }
            else
            {
                if (AiResult == -1)
                {
                    AiPlayer1GuessLabel.Visible = true;
                }
                else if (AiResult == 0)
                {
                    AiDrawGuessLabel.Visible = true;
                }
                else
                {
                    AiPlayer2GuessLabel.Visible = true;
                }
            }
        }

        private void Player1GuessButton_Click(object sender, EventArgs e)
        {
            UserResult = -1;

            if(UserResult == AiResult)
            {
                NewCards();
            }
            else
            {
                if (AiResult == -1)
                {
                    AiPlayer1GuessLabel.Visible = true;
                }
                else if (AiResult == 0)
                {
                    AiDrawGuessLabel.Visible = true;
                }
                else
                {
                    AiPlayer2GuessLabel.Visible = true;
                }
            }
        }

        public UserTestForm()
        {
            InitializeComponent();

            NewCards();
        }

        private void NewCards()
        {
            Player1Cards.Clear();
            Player2Cards.Clear();
            Street.Clear();
            CardsInPlay.Clear();

            AiDrawGuessLabel.Visible = false;
            AiPlayer1GuessLabel.Visible = false;
            AiPlayer2GuessLabel.Visible = false;

            if (RandomPlayerCards)
            {
                for (int x = 0; x < 2; x++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    Player1Cards.Add(NewCard);
                }

                for (int x = 0; x < 2; x++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    Player2Cards.Add(NewCard);
                }
            }
            else
            {
                Player1Cards.Add(new Card(Suit.Hearts, Rank.Ace));
                Player1Cards.Add(new Card(Suit.Spades, Rank.Ace));
                CardsInPlay.Add(Player1Cards[0]);
                CardsInPlay.Add(Player1Cards[1]);

                Player2Cards.Add(new Card(Suit.Diamonds, Rank.Ace));
                Player2Cards.Add(new Card(Suit.Diamonds, Rank.King));
                CardsInPlay.Add(Player2Cards[0]);
                CardsInPlay.Add(Player2Cards[1]);
            }

            for (int x = 0; x < 5; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                Street.Add(NewCard);
            }

            foreach (Card card in CardsInPlay)
            {
                card.LoadImage();
            }

            Player1pictureBox1.Image = Player1Cards[0].Image;
            Player1pictureBox2.Image = Player1Cards[1].Image;

            Player2pictureBox1.Image = Player2Cards[0].Image;
            Player2pictureBox2.Image = Player2Cards[1].Image;

            StreetCard1ImageBox.Image = Street[0].Image;
            StreetCard2ImageBox.Image = Street[1].Image;
            StreetCard3ImageBox.Image = Street[2].Image;
            StreetCard4ImageBox.Image = Street[3].Image;
            StreetCard5ImageBox.Image = Street[4].Image;

            AiResult = winCalc.WhoWins(Player1Cards.Concat(Street).ToList(), Player2Cards.Concat(Street).ToList());
        }
    }
}
