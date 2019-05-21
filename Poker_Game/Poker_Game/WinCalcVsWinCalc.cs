﻿using System;
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
        List<Card> CardsInPlay, Street;
        Card NewCard;
        List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };

        private int CheckWinner() {
            int resultWinCalc1;
            int resultWinCalc2;
            Player resultWinCalc2Player;
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

                }
            }
        }
        private void PrintPlayers() {
            Console.WriteLine("player1 hand: " + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank + players[0].Cards[0].Suit + players[0].Cards[0].Rank);
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
                players[0].Cards.Add(NewCard);
            }

            for (int x = 0; x < 2; x++)
            {
                NewCard = new Card(CardsInPlay);
                CardsInPlay.Add(NewCard);
                players[2].Cards.Add(NewCard);
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
