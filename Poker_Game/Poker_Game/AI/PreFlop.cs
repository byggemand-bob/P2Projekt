using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class Preflop
        {
            public Player players { get; set; }

            public void CalcEv(Player player)
            {
                players = player;
            }

            public bool IsClubsFlush(Player player) {

                if (player.Cards[0].Suit == Suit.Clubs) { 

                    if (player.Cards[0].Suit == Suit.Clubs && player.Cards[1].Suit == Suit.Clubs) {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
                    return false;
            }

            public bool IsDiamondsFlush(Player player)
            {

                if (player.Cards[0].Suit == Suit.Diamonds) {

                    if (player.Cards[0].Suit == Suit.Diamonds && player.Cards[1].Suit == Suit.Diamonds) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                return false;
            }

            public bool IsHeartsFlush(Player player) {

                if (player.Cards[0].Suit == Suit.Hearts) {

                    if (player.Cards[0].Suit == Suit.Hearts && player.Cards[1].Suit == Suit.Hearts) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                return false;
            }

            public bool IsSpadesFlush(Player player) {

                if (player.Cards[0].Suit == Suit.Clubs) {

                    if (player.Cards[0].Suit == Suit.Spades && player.Cards[1].Suit == Suit.Spades) {
                        return true;
                    }
                    else {
                        return false;

                    }
                }

                return false;
            }

            public bool IsStraightChance(Player player) {

                var difference = player.Cards[1].Rank - player.Cards[0].Rank;

                if (Math.Abs(difference) <= 3) {
                    return true;
                }

                else {
                    return false;
                }
            }

            public bool isPair(Player player) {
                if (player.Cards[0].Rank == (player.Cards[1].Rank)) {
                    return true;
                }

                else {
                    return false;
                }
            }
        }
    }
