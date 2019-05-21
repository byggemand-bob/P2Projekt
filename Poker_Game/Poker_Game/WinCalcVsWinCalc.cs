using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game {
    class WinCalcVsWinCalc {
        static void Main() {
            FastWinCalc WinCalc1 = new FastWinCalc();
            WinConditions winCalc2 = new WinConditions();
            List<Card> player1Cards = new List<Card>(), player2Cards = new List<Card>(), Street = new List<Card>(), CardsInPlay = new List<Card>();
            Card NewCard;
            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
            WinCalcVsWinCalc functions = new WinCalcVsWinCalc();

            int resultWinCalc1;
            int resultWinCalc2;
            int counter = 0;

            while (true) {
                counter++;
                if (counter % 1000 == 0) {
                    Console.WriteLine("Counter: " + counter);
                }
                //if (players[0].Cards.Count < 7 && players[1].Cards.Count < 7 && player1Cards.Count < 7 &&) {
                //    Console.WriteLine("FEJL");
                //    Console.ReadKey();
                //}
                players[0].Cards.Clear();
                players[1].Cards.Clear();
                player1Cards.Clear();
                player2Cards.Clear();
                Street.Clear();
                CardsInPlay.Clear();


                for (int x = 0; x < 2; x++) {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    player1Cards.Add(NewCard);
                }

                for (int x = 0; x < 2; x++) {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    player2Cards.Add(NewCard);
                }


                for (int x = 0; x < 5; x++) {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    Street.Add(NewCard);
                }

                Player resultWinCalc2Player;
                players[0].Cards = new List<Card>(player1Cards.Concat(Street).ToList());
                players[1].Cards = new List<Card>(player2Cards.Concat(Street).ToList());
                players[0].Cards.Sort();
                players[1].Cards.Sort();
                players[0].Score = winCalc2.Evaluate(players[0].Cards);
                players[1].Score = winCalc2.Evaluate(players[1].Cards);

                if (players[0].Score == players[1].Score) {
                    resultWinCalc1 = WinCalc1.WhoWins(players[0].Cards, players[1].Cards);
                    resultWinCalc2Player = winCalc2.SameScore(players[0], players[1]);
                    if (resultWinCalc2Player == null) {
                        resultWinCalc2 = 0;
                    } else if (resultWinCalc2Player.Id == 0) {
                        resultWinCalc2 = -1;
                    } else {
                        resultWinCalc2 = 1;
                    }
                    if (resultWinCalc1 != resultWinCalc2) {
                        Console.WriteLine("player1 hand: " + player1Cards[0].Suit + player1Cards[0].Rank + " " + player1Cards[1].Suit + player1Cards[1].Rank);
                        Console.WriteLine("Street  hand: " + Street[0].Suit + Street[0].Rank + " " + Street[1].Suit + Street[1].Rank + " " + Street[2].Suit + Street[2].Rank + " " + Street[3].Suit + Street[3].Rank + " " + Street[4].Suit + Street[4].Rank);
                        Console.WriteLine("player2 hand: " + player2Cards[0].Suit + player2Cards[0].Rank + " " + player2Cards[1].Suit + player2Cards[1].Rank);
                        Console.WriteLine("\nWinCon1: " + resultWinCalc1);
                        Console.WriteLine("WinCon2: " + resultWinCalc2);
                        Console.WriteLine("\nScore: " + players[0].Score);
                        Console.ReadKey();
                    }

                }
            }
        }
    }
}
