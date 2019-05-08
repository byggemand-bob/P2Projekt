using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class CalcPairOuts
    {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand playerCardsInHand { get; set; }
        public int numberOfOuts { get; set; }
        public WinConditions WinConditions { get; set; }


        public void calcOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhand, List<Turn> turns, WinConditions winconditions)
        {
            Player = player;
            Street = street;
            playerCardsInHand = cardsinhand;
            WinConditions = winconditions;

        }

        public int PlayerPairOuts(Player player, List<Card> street, PlayerCardsInHand PlayerCardsInHands, List<Turn> turns)
        {


            List<Card> otherPairs = new List<Card>();
            if (PlayerCardsInHands.isPair(player))
            {
                int moreOfAKind = 0;

                foreach (var element in Street)
                {
                    if (element.Rank == player.Cards[0].Rank)
                    {
                        moreOfAKind++;
                    }
                }

                if (moreOfAKind == 2)
                {
                    //FOAK
                }

                else if (moreOfAKind == 1)
                {
                    foreach (var element in Street)
                    {
                        if (element.Rank != player.Cards[0].Rank)
                        {
                            otherPairs.Add(element);
                        }
                    }
                }

                foreach (var element in otherPairs)
                {

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