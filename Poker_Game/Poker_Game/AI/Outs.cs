using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game;

namespace Poker_Game.AI {
    class Outs {

        enum Score {
            RSF, FourOfAKind, FullHouse, Flush, Straight, ThreeOfAKind, TwoPairs, None;
        }

        public Score FindOuts(List<Card> someMoreCards){
            List<Card> playerAccessibleCards = someMoreCards;
            playerAccessibleCards.Sort();

            if (IsFlushChance(playerAccessibleCards)){
                foreach (Card element in playerAccessibleCards){
                    if (Convert.ToInt32(element.Rank) > 10)
                    {
                        return Score.RSF;
                    }
                } return Score.Flush;
            }

            else if (IsThreeOfAKind(playerAccessibleCards)){
                if (IsFourOfAKind(playerAccessibleCards)){
                    return Score.FourOfAKind;
                }

                else if (IsFullHouse(playerAccessibleCards)){
                    return Score.FullHouse;
                }

                else if (IsTwoPair(playerAccessibleCards)){
                    return Score.TwoPairs;
                }return Score.ThreeOfAKind;
            }

            else if (IsStraightChance(playerAccessibleCards)){
                return Score.Straight;
            }

            else if (IsPair(playerAccessibleCards)){
                return Score.IsPair;
            }

            return Score.None;
        }

        private bool IsStraightChance(List<Card> playerAccessibleCards)
        {

            int numberOfCards = playerAccessibleCards.Count;

            int straightRange = (playerAccessibleCards[numberOfCards].Rank - playerAccessibleCards[0].Rank);

            if (straightRange >= 2 && straightRange <= 4)
            {
                return true;
            } return false;

            //Her skal laves en algoritme der kan udregne om man eksempelvis har 3 eller 4 ud af 5 kort i en straight
        }

        // Checks if there are cards in the AI's hand and on the street that are in range of a straight
        private bool IsStraightAceFive(List<Card> playerAccessibleCards) {

            List<Card> specialCase = new List<Card>();
            // Skal tilføjes en overload method som kan lave et kort kun med et parameter i MakeCards funktionen
            specialCase.Add(new Card((Rank) Ace));
            specialCase.Add(new Card((Rank) 5));
            specialCase.Add(new Card((Rank) 4));
            specialCase.Add(new Card((Rank) 3));
            specialCase.Add(new Card((Rank) 2));


            int numberOfCards = playerAccessibleCards.Count;

            int straightRange = (playerAccessibleCards[numberOfCards].Rank - playerAccessibleCards[0].Rank);


            if (playerAccessibleCards.Contains(List < Card > specialCase){
                if (straightRange >= 2 && straightRange <= 4) {
                    return true;
                } return false;
            }
        }

        // Checks if there are cards in the AI's hand and on the street that are in range of a flush
        private bool IsFlushChance(List<Card> playerAccessibleCards) {
            int C = 0, D = 0, H = 0, S = 0;
            foreach (Card element in playerAccessibleCards) {
                if (element.Suit == Suit.Clubs) {
                    C++;
                }
                else if (element.Suit == Suit.Diamond) {
                    D++;
                }
                else if (element.Suit == Suit.Hearts) {
                    H++;
                }
                else if (element.Suit == Suit.Spades) {
                    S++;
                }
            }

            // Skal ikke være Round.Turn, men jeg ved ikke hvad den skal hedde, så Round.Turn er lige en placeholder..
            if ((Round.Turn == 0) && (C > 1 || D > 1 || H > 1 || S > 1)){
                return true;
            }
            else if ((Round.Turn == 1) && (C > 2 || D > 2 || H > 2 || S > 2)){
                return true;
            }
            else if ((Round.Turn == 2) && (C > 3 || D > 3 || H > 3 || S > 3)){
                return true;
            }
            else if ((Round.Turn == 3) && (C > 4 || D > 4 || H > 4 || S > 4)){
                return true;
            }

            return false;
        }
    

        private bool RSF(List<Card> playerAccessibleCards) {
            if ((IsFlushChance(playerAccessibleCards) == true) && (IsStraightChance(playerAccessibleCards) == true)) {
                return true;
            } return false;
        }

        private bool IsThreeOfAKind(List<Card> playerAccessibleCards) {
            var duplicates = playerAccessibleCards
                .GroupBy(x => x)
                .Where(g => g.Skip(1).Any())
                .SelectMany(g => g);

            if (Convert.ToInt32(duplicates) > 2) {
                return true;
            } return false;
        }

        if(IsThreeOfAKind(playerAccessibleCards) == true) {
            //Her skal den tjekke for om de sidste 2 kort er ens også - måske .Where?
        }

        // No clue om den her metode virker
        private bool IsFourOfAKind(List<Card> playerAccessibleCards) {
            var duplicates = playerAccessibleCards
                .GroupBy(x => x)
                .Where(g => g.Skip(1).Any())
                .SelectMany(g => g);

            if (Convert.ToInt32(duplicates) > 3) {
                return true;
            } return false;
        }

        private bool IsTwoPair(List<Card> playerAccessibleCards) { }
        private bool IsPair(List<Card> playerAccessibleCards) { }

    }
}