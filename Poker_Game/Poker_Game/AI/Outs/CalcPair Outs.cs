using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class CalcPairOuts {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand playerCardsInHand { get; set; }
        public int numberOfOuts { get; set; }
        public WinConditions WinConditions { get; set; }


        public CalcPairOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhand, List<Turn> turns,
            WinConditions winconditions) {
            Player = player;
            Street = street;
            playerCardsInHand = cardsinhand;
            WinConditions = winconditions;

        }

        public int PlayerPairOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhand) {


            int countOfAKind = 0, equalsInStreet = 0, multiplePairCount = 0;

            List<Card> equalsToCardInHand = new List<Card>();
            List<Card> equalCardsOnTable = new List<Card>();
            List<Card> pairCards = new List<Card>();

            foreach (var element in street) {
                if (element.Rank == player.Cards[0].Rank) {
                    countOfAKind++;
                    equalsToCardInHand.Add(element);
                }
            }

            // Skal kunne tage forbehold for flere forskellige par på streeten

            for (int i = 0; i < Street.Count; i++) {
                for (int j = 0; j < Street.Count; j++) {
                    if (street[i].Rank == street[j].Rank) {
                        equalCardsOnTable.Add(street[i]);
                    }
                }
            }

            pairCards.AddRange(equalsToCardInHand);
            pairCards.AddRange(equalCardsOnTable);

            //Tjekker om kortene er ens
            for (int k = 0; k < pairCards.Count; k++) {
                for (int l = 1; l < pairCards.Count; l++) {
                    if (pairCards[k].Rank != (pairCards[l].Rank)) {
                        multiplePairCount++;
                    }
                }
            }


            if (countOfAKind == 0 && equalsInStreet == 0) {
                // 1 par - hvor mange odds har man her? Vel ligeså meget de 3 kort på floppet, da hver kan rammes 2x mere for et fuldt hus? Men måske det er for langt at se frem?
                return numberOfOuts += 2;
            }

            else if (countOfAKind == 1 && equalsInStreet == 0) {
                // Tre ens
                return numberOfOuts += 7;
            }

            else if (countOfAKind == 0 && equalsInStreet == 1) {
                // To par
                return numberOfOuts += 4;
            }

            else if (countOfAKind == 1 && equalsInStreet == 1) {
                // Full house

            }

            else if (countOfAKind == 2 && equalsInStreet == 1) {
                // Fire ens
                // Fuld ild!!
            }

            else if (countOfAKind == 1 && equalsInStreet > 2) {
                // 3 ens, 2 par på streeten
                // Call / Raise
            }

            else if (countOfAKind == 0 && equalsInStreet == 3 && multiplePairCount > 1) {
                foreach (var element in equalCardsOnTable) {

                    if (player.Cards[0].Rank < element.Rank) {
                        //Pairs on table are higher than hours, so we can only get split pot, or loose to a better pair
                        // Check / Fold
                    }
                }
            }

            return 0;

        }
    }
}