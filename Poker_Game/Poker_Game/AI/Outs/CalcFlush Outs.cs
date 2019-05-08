using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class CalcFlushOuts {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand PlayerCardsInHands { get; set; }
        public int numberOfOuts { get; set; }

        public CalcFlushOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhands) {
            Player = player;
            Street = street;
            PlayerCardsInHands = cardsinhands;
        }

        public int PlayerFlushOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhands) {

            int numberOfOuts = 0;

            if (cardsinhands.IsFlushChance(player) == true) {
                int cardsInASuit = 13, suitsInHand = player.Cards.Count;
                // finds each element in the street that matches the suit that the player holds in his hand

                var flushCards = Street
                    .Where(x => x.Suit == player.Cards[0].Suit)
                    .OrderBy(x => x.Rank);


                //Calculates the number of outs for a flush
                numberOfOuts += (cardsInASuit - (flushCards.Count() + player.Cards.Count));
            }

            return numberOfOuts;
        }
    }
}