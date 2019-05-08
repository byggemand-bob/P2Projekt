using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class CalcOuts
    {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public int Pot { get; set; }
        public Preflop Preflop { get; set; }
        public int numberOfOuts { get; set; }
        
        public List<Turn> Turns { get; set;}

        public WinConditions WinConditions { get; set; }


        public void calcOuts(Player player, List<Card> street, Preflop preflops, List<Turn> turns, WinConditions winconditions)
        {
            Player = player;
            Street = street;
            Preflop = preflops;
            Turns = turns;
            WinConditions = winconditions;

        }

        public int PlayerFlushOuts(Player player, List<Card> street, Preflop preflops, List<Turn> turns,
            WinConditions winconditions) {

            int numberOfOuts = 0;

            if (preflops.IsClubsFlush(player) == true) {
                int cardsInASuit = 13, suitsInHand = player.Cards.Count;
                // finds each element in the street that matches the suit that the player holds in his hand

                var flushClubs = Street
                    .Where(x => x.Suit == Suit.Clubs)
                    .OrderBy(x => x.Rank);


                //Calculates the number of outs for a flush
                numberOfOuts += (cardsInASuit - (flushClubs.Count() + player.Cards.Count));
            }

            if (preflops.IsDiamondsFlush(player) == true) {
                int cardsInASuit = 13, suitsInHand = player.Cards.Count;
                // finds each element in the street that matches the suit that the player holds in his hand

                var flushDiamonds = Street
                    .Where(x => x.Suit == Suit.Diamonds)
                    .OrderBy(x => x.Rank);


                //Calculates the number of outs for a flush
                numberOfOuts += (cardsInASuit - (flushDiamonds.Count() + player.Cards.Count));
            }

            if (preflops.IsHeartsFlush(player) == true) {
                int cardsInASuit = 13, suitsInHand = player.Cards.Count;
                // finds each element in the street that matches the suit that the player holds in his hand

                var flushHearts = Street
                    .Where(x => x.Suit == Suit.Clubs)
                    .OrderBy(x => x.Rank);


                //Calculates the number of outs for a flush
                numberOfOuts += (cardsInASuit - (flushHearts.Count() + player.Cards.Count));
            }

            if (preflops.IsSpadesFlush(player) == true) {
                int cardsInASuit = 13, suitsInHand = player.Cards.Count;
                // finds each element in the street that matches the suit that the player holds in his hand

                var flushSpades = Street
                    .Where(x => x.Suit == Suit.Spades)
                    .OrderBy(x => x.Rank);


                //Calculates the number of outs for a flush
                numberOfOuts += (cardsInASuit - (flushSpades.Count() + player.Cards.Count));
            }

            return numberOfOuts;
        }



        public int calcStraightOuts(Player player, List<Card> street, Preflop preflops, List<Turn> turns, WinConditions winconditions) { 


        //Checks for cards that are in range of a straight compared to the players hand

            if (preflops.IsStraightChance(player) == true) {

                List<Card> straightCards = new List<Card>();
               
                int cardRange = player.Cards[0].Rank - player.Cards[1].Rank;

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
                            element.Rank >= Street.Max(s => s.Rank + 1)) {
                            straightCards.Add(element);
                            
                        }
                    }
                }


                if (Math.Abs(cardRange) == 2) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) &&
                            element.Rank <= Street.Max(s => s.Rank) ||
                            element.Rank >= Street.Min(s => s.Rank - 2) ||
                            element.Rank >= Street.Max(s => s.Rank + 2)) {
                            straightCards.Add(element);
                        }

                    }

                }

                if (Math.Abs(cardRange) == 1) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank) &&
                            element.Rank <= Street.Max(s => s.Rank) ||
                            element.Rank >= Street.Min(s => s.Rank - 3) ||
                            element.Rank >= Street.Max(s => s.Rank + 3)) {
                            straightCards.Add(element);
                        }

                    }
                }

                if (Math.Abs(cardRange) == 0) {
                    foreach (var element in Street) {
                        if (element.Rank >= Street.Min(s => s.Rank - 3) ||
                            element.Rank >= Street.Max(s => s.Rank + 3)) {
                            straightCards.Add(element);
                        }
                    }
                }

                straightCards.Add(player.Cards[0]);
                straightCards.Add(player.Cards[1]);

                


                var lowestValue = Convert.ToInt32(straightCards.First().Rank);
                var highestValue = Convert.ToInt32(straightCards.Last().Rank);

                List<Card> allCardsNeeded = new List<Card>();

                for (int i = lowestValue, j = 0; i <= highestValue; i++) {
                    if (Convert.ToInt32(straightCards[j].Rank) != i) {
                        //Det her passer ikke, men hvilken værdi skal vi have for at få det pågældende kort??
                        // allCardsNeeded.Add(new Card(i));
                    }
                }

                // Both or?
                numberOfOuts += (5 - allCardsNeeded.Count);
            }

            return numberOfOuts;
        }

       public int PlayerPairOuts(Player player, List<Card> street, Preflop preflops, List<Turn> turns) {


            List<Card> otherPairs = new List<Card>();
            if(preflops.isPair(player)) {
                int moreOfAKind = 0;

                foreach (var element in Street) {
                    if (element.Rank == player.Cards[0].Rank) {
                        moreOfAKind++;
                    }
                }

                if (moreOfAKind == 2) {
                    //FOAK
                }

                else if (moreOfAKind == 1) {
                    foreach (var element in Street) {
                        if (element.Rank != player.Cards[0].Rank) {
                            otherPairs.Add(element);
                        }
                    }
                }

                foreach (var element in otherPairs) {
                       
                    }
                }

            for (int i = 0; i < otherPairs.Count - 1; i++)
            {
                if (otherPairs[i].Rank == otherPairs[i + 1].Rank)
                {
                    // Two pairs
                }

            }
           
            
            return 0;

       }


    }


}