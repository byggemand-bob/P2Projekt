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
using System.IO;

namespace Poker_Game
{
    public partial class UserTestForm : Form
    {
        FastWinCalc winCalc = new FastWinCalc();
        List<Card> Player1Cards = new List<Card>(), Player2Cards = new List<Card>(), Street = new List<Card>(), CardsInPlay = new List<Card>();
        Card NewCard;
        int UserResult, AiResult, testNumber = 37;
        bool RandomPlayerCards = true, GenerateTests = true;
        List<string> PrintFile = new List<string>();

        public UserTestForm()
        {
            InitializeComponent();

            if (GenerateTests)
            {
                SaveTestsButton.Visible = true;
            }
            else
            {
                SaveTestsButton.Visible = false;
            }

            if (!RandomPlayerCards)
            {
                RandomOrStaticButton.Text = "Switch to Random cards";
            }
            else
            { 
                RandomOrStaticButton.Text = "Switch to Static cards";
            }

            NewCards();
        }

        private void Player2GuessButton_Click(object sender, EventArgs e)
        {
            UserResult = 1;

            if (UserResult == AiResult)
            {
                if (GenerateTests)
                {
                    GenerateTest();
                }
                
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
                if (GenerateTests)
                {
                    GenerateTest();
                }

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

        private void SaveTestsButton_Click(object sender, EventArgs e)
        {
            SaveGeneratedTests();
        }

        private void Player1GuessButton_Click(object sender, EventArgs e)
        {
            UserResult = -1;

            if(UserResult == AiResult)
            {
                if (GenerateTests)
                {
                    GenerateTest();
                }

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

        private void GenerateTest()
        {
            if(PrintFile.Count() > 1000)
            {
                TestNumnerWarningLabel.Visible = true;
            }
            else if(PrintFile.Count() > 1200)
            {
                PrintFile.Clear();
                TestNumnerWarningLabel.Visible = false;
            }

            PrintFile.Add("[TestMethod]");
            PrintFile.Add("public void FastWinCalcTest" + testNumber + "()");
            PrintFile.Add("{");
            PrintFile.Add("");
            PrintFile.Add("    // Arrange");
            PrintFile.Add("    List<Card> Player1Cards = new List<Card>();");
            PrintFile.Add("    List<Card> Player2Cards = new List<Card>();");
            PrintFile.Add("");
            PrintFile.Add("    Card tableCard1 = new Card((Suit)" + (int)Street[0].Suit + ", (Rank)" + (int)Street[0].Rank + ");");
            PrintFile.Add("    Card tableCard2 = new Card((Suit)" + (int)Street[1].Suit + ", (Rank)" + (int)Street[1].Rank + ");");
            PrintFile.Add("    Card tableCard3 = new Card((Suit)" + (int)Street[2].Suit + ", (Rank)" + (int)Street[2].Rank + ");");
            PrintFile.Add("    Card tableCard4 = new Card((Suit)" + (int)Street[3].Suit + ", (Rank)" + (int)Street[3].Rank + ");");
            PrintFile.Add("    Card tableCard5 = new Card((Suit)" + (int)Street[4].Suit + ", (Rank)" + (int)Street[4].Rank + ");");
            PrintFile.Add("");
            PrintFile.Add("    Player1Cards.Add(new Card((Suit)" + (int)Player1Cards[0].Suit + ", (Rank)" + (int)Player1Cards[0].Rank + "));");
            PrintFile.Add("    Player1Cards.Add(new Card((Suit)" + (int)Player1Cards[1].Suit + ", (Rank)" + (int)Player1Cards[1].Rank + "));");
            PrintFile.Add("    Player1Cards.Add(tableCard1);");
            PrintFile.Add("    Player1Cards.Add(tableCard2);");
            PrintFile.Add("    Player1Cards.Add(tableCard3);");
            PrintFile.Add("    Player1Cards.Add(tableCard4);");
            PrintFile.Add("    Player1Cards.Add(tableCard5);");
            PrintFile.Add("");
            PrintFile.Add("    Player2Cards.Add(new Card((Suit)" + (int)Player2Cards[0].Suit + ", (Rank)" + (int)Player2Cards[0].Rank + "));");
            PrintFile.Add("    Player2Cards.Add(new Card((Suit)" + (int)Player2Cards[1].Suit + ", (Rank)" + (int)Player2Cards[1].Rank + "));");
            PrintFile.Add("    Player2Cards.Add(tableCard1);");
            PrintFile.Add("    Player2Cards.Add(tableCard2);");
            PrintFile.Add("    Player2Cards.Add(tableCard3);");
            PrintFile.Add("    Player2Cards.Add(tableCard4);");
            PrintFile.Add("    Player2Cards.Add(tableCard5);");
            PrintFile.Add("");
            PrintFile.Add("    //Act");
            PrintFile.Add("    int actual = winCalc.WhoWins(Player1Cards, Player2Cards);");
            PrintFile.Add("");
            PrintFile.Add("    //Assert");
            PrintFile.Add("    Assert.AreEqual(" + UserResult + ", actual);");
            PrintFile.Add("}");
            PrintFile.Add("");

            testNumber++;
        }

        private void SaveGeneratedTests()
        {
            string path = System.Windows.Forms.Application.StartupPath + "GeneratedUnitTests.txt";
            File.WriteAllLines(path, PrintFile);
        }
    }
}
