using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class PlayerCardsInHand
        {
            public Player players { get; set; }

            public void CalcEv(Player player)
            {
                players = player;
            }

            public void InsertWhichPlayersCards(Player player) {
                List<Card> currentPlayerCards = new List<Card>();    
            }

            public bool IsFlushChance(Player player) {

                if (player.Cards[0].Suit == Suit.Clubs && player.Cards[1].Suit == Suit.Clubs) {
                    return true;
                }

                if (player.Cards[0].Suit == Suit.Diamonds && player.Cards[1].Suit == Suit.Diamonds)
                {
                    return true;
                }

                if (player.Cards[0].Suit == Suit.Hearts && player.Cards[1].Suit == Suit.Hearts)
                {
                    return true;
                }

                if (player.Cards[0].Suit == Suit.Spades && player.Cards[1].Suit == Suit.Spades)
                {
                    return true;
                }
            
                return false;
            }

            public bool IsStraightChance(Player player) {

                var difference = player.Cards[1].Rank - player.Cards[0].Rank;

                if (Math.Abs(difference) <= 3) {
                    return true;
                }
                return false;
            }

            public bool IsPair(Player player) {
                if (player.Cards[0].Rank == (player.Cards[1].Rank)) {
                    return true;
                }
                return false;
            }
        }
    }
