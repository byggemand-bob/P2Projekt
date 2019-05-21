using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game
{
    class WinCalcVsWinCalc
    {
        FastWinCalc WinCalc1 = new FastWinCalc();
        WinConditions winCalc2 = new WinConditions();
        List<Card> player1Cards, player2Cards, CardsInPlay, Street;
        Card NewCard;
        List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
        private int CheckWinner() {
            int resultWinCalc1;
            int resultWinCalc2;
            Player resultWinCalc2Player;
            players[0].Cards.Concat(player1Cards).ToList();
            players[1].Cards.Concat(player2Cards).ToList();
            players[0].Cards.Concat(Street).ToList();
            players[1].Cards.Concat(Street).ToList();
            players[0].Score = winCalc2.Evaluate(players[0].Cards);
            players[1].Score = winCalc2.Evaluate(players[1].Cards);
            if (players[0].Score > players[1].Score) {
                return players[0].Id;
            } else if (players[0].Score < players[1].Score) {
                return players[1].Id;
            }else {
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
                    PrintPlayers();
                    Console.ReadKey();
                    return 1;

                }
            }
        }
        private void PrintPlayers() {
            Console.WriteLine("player1 hand: " + player1Cards[0].Suit + player1Cards[0].Rank + " " + player1Cards[1].Suit + player1Cards[1].Rank);
            Console.WriteLine("player1 hand: " + player2Cards[0].Suit + player2Cards[0].Rank + " " + player2Cards[1].Suit + player2Cards[1].Rank);
        }
        private void NewCards()
        {
            players[0].Cards.Clear();
            players[1].Cards.Clear();
            Street.Clear();
            CardsInPlay.Clear();

            
            for (int x = 0; x < 2; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                player1Cards.Add(NewCard);
            }

            for (int x = 0; x < 2; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                player2Cards.Add(NewCard);
            }
            

            for (int x = 0; x < 5; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                Street.Add(NewCard);
            }
        }

    }
}
