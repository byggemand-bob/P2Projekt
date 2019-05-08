using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class CalcStraightOuts
    {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand playerCardsInHand { get; set; }
        public int numberOfOuts { get; set; }
        public WinConditions WinConditions { get; set; }


        public CalcStraightOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhand, List<Turn> turns, WinConditions winconditions)
        {
            Player = player;
            Street = street;
            playerCardsInHand = cardsinhand;
            WinConditions = winconditions;

        }

        public int calcStraightOuts(Player player, List<Card> Street, PlayerCardsInHand cardsinhands, List<Turn> turns, WinConditions winconditions)
        {
            //Checks for cards that are in range of a straight compared to the players hand

            if (cardsinhands.IsStraightChance(player) == true) {

                List<Card> straightCards = new List<Card> {player.Cards[0], player.Cards[1]};

                int cardRange = player.Cards[0].Rank - player.Cards[1].Rank;

                // Inside straight chance

                if (Math.Abs(cardRange) == 4) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) && (element.Rank <= Street.Max(s => s.Rank))) {
                            straightCards.Add(element);
                        }

                    }
                }

                if (Math.Abs(cardRange) == 3) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) && element.Rank <= Street.Max(s => s.Rank) ||
                            element.Rank >= Street.Min(s => s.Rank - 1) ||
                            element.Rank <= Street.Max(s => s.Rank + 1)) {
                            straightCards.Add(element);
                        }
                    }
                }

                
                if (Math.Abs(cardRange) == 2) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) &&
                            element.Rank <= Street.Max(s => s.Rank) ||
                            element.Rank >= Street.Min(s => s.Rank - 2) ||
                            element.Rank <= Street.Max(s => s.Rank + 2)) {
                            straightCards.Add(element);
                        }
                    }
                }

                // Open ended connector
                if (Math.Abs(cardRange) == 1) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) &&
                            element.Rank <= Street.Max(s => s.Rank) ||
                            element.Rank >= Street.Min(s => s.Rank - 3) ||
                            element.Rank <= Street.Max(s => s.Rank + 3)) {
                            straightCards.Add(element);
                        }

                    }
                }

                winconditions.RemoveDublicateRank(straightCards, 0);

                return numberOfOuts += 5 - straightCards.Count;
            }

            return 0;

        }
    }
}