using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game
{
    class UserTest
    {
        static void Main()
        {
            FastWinCalc winCalc = new FastWinCalc();
            List<Card> Player1Cards = new List<Card>(), Player2Cards = new List<Card>(), Street = new List<Card>(), CardsInPlay = new List<Card>();
            Card NewCard;
            int UserResult = 9, AiResult;

            while (UserResult != 0)
            {
                Player1Cards.Clear();
                Player2Cards.Clear();
                Street.Clear();
                CardsInPlay.Clear();

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

                for (int x = 0; x < 5; x++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    Street.Add(NewCard);
                }

                Console.WriteLine("Player1 hand:    {0} {1}, {2} {3}\n", 
                                Player1Cards[0].Suit.ToString(), Player1Cards[0].Rank.ToString(), 
                                Player1Cards[1].Suit.ToString(), Player1Cards[1].Rank.ToString());

                Console.WriteLine("Street:          {0} {1}, {2} {3}, {4} {5}, {6} {7}, {8} {9}\n",
                                Street[0].Suit.ToString(), Street[0].Rank.ToString(),
                                Street[1].Suit.ToString(), Street[1].Rank.ToString(),
                                Street[2].Suit.ToString(), Street[2].Rank.ToString(),
                                Street[3].Suit.ToString(), Street[3].Rank.ToString(),
                                Street[4].Suit.ToString(), Street[4].Rank.ToString());

                Console.WriteLine("Player2 hand:    {0} {1}, {2} {3}\n",
                                Player2Cards[0].Suit.ToString(), Player2Cards[0].Rank.ToString(),
                                Player2Cards[1].Suit.ToString(), Player2Cards[1].Rank.ToString());

                Console.WriteLine("(1) for player 1 wins, (2) for draw, (3) for player 2 wins               (0) exit");

                while (UserResult != 1 && UserResult != 2 && UserResult != 3 && UserResult != 0)
                {
                    UserResult = Convert.ToInt32(Console.ReadLine());
                }

                AiResult = winCalc.WhoWins(Player1Cards.Concat(Street).ToList(), Player2Cards.Concat(Street).ToList());

                if(UserResult != AiResult + 2)
                {
                    if(AiResult == -1)
                    {
                        Console.WriteLine("Ai believes that Player1 should win");
                    }
                    else if (AiResult == 0)
                    {
                        Console.WriteLine("Ai believes its a draw");
                    }
                    else if (AiResult == 1)
                    {
                        Console.WriteLine("Ai believes that Player2 should win");
                    }
                    Console.ReadKey();
                }

                UserResult = 9;

                Console.WriteLine("\n-----------------------------------------------------------------------\n\n");


            }
        }
        


    }
}
