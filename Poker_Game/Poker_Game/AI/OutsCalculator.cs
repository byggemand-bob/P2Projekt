﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    public class OutsCalculator {
        public int CompareOuts(List<Card> street, List<Card> cardHand /* params missing*/) {

            //Flush hands

            var cardDiff = GetRankDifference(cardHand);

            if (HasFlushChance(cardHand)) {
                if (OpenStraightAndFlushDraw(street, cardHand)) {
                    return 15;
                }

                else if (InsideStraightAndFlushDraw(street, cardHand)) {
                    return 12;
                }

                else if (IsPocketFlushDraw(cardHand, street)) {
                    return 9;
                }
            }
            else if (IsTableFlushDraw(cardHand, street)) {
                return 9;
            }

            //Straight hands

            else if (cardDiff >= 1 && cardDiff <= 4)
            {
                if (IsOpenEndedStraightDraw(street, cardHand))
                {
                    return 8;
                }

                else if (InsideStraightAndTwoOverCards(street, cardHand)) {
                    return 10;
                }

                else if (IsInsideStraightDraw(street, cardHand)) {
                    return 4;
                }
            }

            //Multiple

            else if (cardDiff == 0) {

                if (ThreeOAKToFullHouseOr4OAK(cardHand)) {
                    return 7;
                }

                if (PocketPairToSet(cardHand)) {
                    return 2;
                }

                else if (OnePairToTwoPair(street, cardHand)) {
                    return 5;
                }

                if (OneOverCard(cardHand, street)) {
                    return 3;
                }

                if (TwoOverCardsToOverPair(street, cardHand)) {
                    return 6;
                }

                if (TwoPairToFullHouse(street, cardHand)) {
                    return 4;
                }

                if (OnePairToSet(street, cardHand)) {
                    return 5;
                }

                if (NoPairToPair(street, cardHand)) {
                    return 6;
                }
            }

            return 0;
            

        }

        #region StraightOuts

        public int GetStraightOuts(List<Card> cardHand, List<Card> street) {
            //Checks for cards that are in range of a straight compared to the players hand

            List<Card> straightCards = new List<Card> {cardHand[0], cardHand[1]};
            int numberOfOuts = 0;
            var count = 0;
            int cardRange = GetRankDifference(cardHand);

            if(cardRange < 1 || cardRange > 4) {
                return 0;
            }

            List<Card> allStraightCards = street
                .Where(s => s.Rank >= cardHand[0].Rank - (cardRange - 4) && s.Rank <= cardHand[1].Rank + (4 - cardRange)).ToList();
            allStraightCards.Add(cardHand[0]);
            allStraightCards.Add(cardHand[1]);
            
            if (allStraightCards.Count == 4 ) {

                straightCards.Sort();

                for (int i = 0; i < allStraightCards.Count; i++) {
                    if (allStraightCards[i].Rank == allStraightCards[i + 1].Rank + 1) {
                        count++;
                    }
                }

                if (count == 4) {
                    return numberOfOuts += 8;
                }
                
                return numberOfOuts += 4;
               
            }

            return numberOfOuts += 0;
        }

        public List<Card> findMissingCardsForStraight(List<Card> listOfPossibleStraightCards, List<Card> straightCards) {

            WinConditions wc = new WinConditions();
            List<Card> allStraightCards = new List<Card>();


            wc.RemoveDublicateRank(listOfPossibleStraightCards, 0);

            var MinVal = listOfPossibleStraightCards.Min();
            var MaxVal = listOfPossibleStraightCards.Max();
            for (int i = 0; i < (MaxVal.Rank - MinVal.Rank); i++) {
                allStraightCards.Add(new Card(Suit.Hearts, listOfPossibleStraightCards[0].Rank + i));
            }

            List<Card> missingCardsStraight = new List<Card>(allStraightCards.Except(listOfPossibleStraightCards));

            return missingCardsStraight;
        }

    
        #endregion

        #region FlushOuts

        private int GetFlushOuts(List<Card> cardHand, List<Card> street) {
            var flushCards = street
                .Where(x => x.Suit == cardHand[0].Suit)
                .OrderBy(x => x.Rank);

            return 13 /*Cards in a suit*/ - (flushCards.Count() + cardHand.Count);
        }

        #endregion
        
        #region MultipleCardOuts

        private int FindStreetCardsEqualToCardHand(List<Card> cardHand, List<Card> street) {
            
            List<Card> StreetCardsEqualToHand = new List<Card>();
           // Tjekker om kort på streeten er magen til dem spilleren har på hånden

            foreach (var element in street) {
               if (element.Rank.Equals(cardHand[0].Rank)) {
                   StreetCardsEqualToHand.Add(element);
               }
            }
            return StreetCardsEqualToHand.Count;
        }

        private int FindMultipleCardsOnStreet(List<Card> cardHand, List<Card> street) {
            // Tjekker om kortene på streeten er ens
            List<Card> MultipleCardsOnStreet = new List<Card>();
            WinConditions wc = new WinConditions();

            for (int i = 0; i < street.Count; i++) {
                for (int j = 0; j < street.Count; j++) {
                    if (street[i].Rank == street[j].Rank) {
                        MultipleCardsOnStreet.Add(street[j]);
                    }
                }
            }
            return wc.RemoveDublicateRank(MultipleCardsOnStreet, 0).Count;
        }

        private bool OpenStraightAndFlushDraw(List<Card> cardHand, List<Card> street)
        {
            if (GetFlushOuts(cardHand, street) == 8 && IsOpenEndedStraightDraw(street, cardHand)){
                return true;
            }

            return false;
        }

        private bool IsPocketFlushDraw(List<Card> cardHand, List<Card> street) {
            var count = 0;
            if (HasFlushChance(cardHand) && !IsOpenEndedStraightDraw(street, cardHand) && !IsInsideStraightDraw(street, cardHand)) {
                foreach (var element in street) {
                    if (element.Suit == cardHand[0].Suit) {
                        count++;
                    }
                }

                return true;
            }
            return false;
        }

        private bool IsTableFlushDraw(List<Card> cardHand, List<Card> street) {
            int countFirst = 0, countSecond = 0;
                if(!HasFlushChance(cardHand))
                {
                    foreach (var element in street) {
                        if (element.Suit == cardHand[0].Suit) {
                            countFirst++;
                        }
                        else if (element.Suit == cardHand[1].Suit) {
                            countSecond++;
                        }
                    }

                    if (countFirst == 4 || countSecond == 4) {
                        return true;
                    }
                }

                return false;
        }

        private bool InsideStraightAndFlushDraw(List<Card> cardHand, List<Card> street)
        {
            if (GetFlushOuts(cardHand, street) == 4 && GetFlushOuts(cardHand, street) >= 4)
            {
                return true;
            }

            return false;
        }

        private bool InsideStraightAndTwoOverCards(List<Card> cardHand, List<Card> street)
        {
            if (GetFlushOuts(cardHand, street) == 8 && TwoOverCardsToOverPair(street, cardHand))
            {
                return true;
            }

            return false;
        }

        private bool IsOpenEndedStraightDraw(List<Card> street, List<Card> cardHand)
        { // Outs 8
            if (GetStraightOuts(street, cardHand) == 8)
            {
                return true;
            }

            return false;
        }

        private bool IsInsideStraightDraw(List<Card> street, List<Card> cardHand) {
            if (GetStraightOuts(street, cardHand) == 4)
            {
                return true;
            }

            return false;
        }

        private bool ThreeOAKToFullHouseOr4OAK(List<Card> cardHand)
        { // Outs 7
            WinConditions wc = new WinConditions();

            if (wc.HasThreeOfAKind(cardHand))
            {
                return true;
            }

            return false;
        }

        private bool TwoPairToFullHouse(List<Card> street, List<Card> cardHand)
        {

            var Multiples = FindMultipleCardsOnStreet(cardHand, street);

            if (FindStreetCardsEqualToCardHand(cardHand, street) == 1 && Multiples == 1)
            { // 4 outs
                return true;
            }

            if (HasPair(cardHand) && Multiples == 1)
            {
                return true;
            }

            return false;
        }

        private bool TwoOverCardsToOverPair(List<Card> street, List<Card> cardHand)
        { // Outs 6
            var count = 0;
            for (int i = 0; i < street.Count; i++) {
                if (street[i].Rank < cardHand[0].Rank && street[i].Rank < cardHand[1].Rank) {
                    count++;
                }
            }

            if (count == street.Count) {
                    return true;
                }
                return false;
            }

        private bool PocketPairToSet(List<Card> cardHand)
        { // 2 outs
            if (HasPair(cardHand))
            {
                return true;
            }

            return false;

        }

        private bool OnePairToSet(List<Card> street, List<Card> cardHand){ // 5 outs

            if (!HasPair(cardHand) && FindStreetCardsEqualToCardHand(cardHand, street) == 1) {
                return true;
            }
            return false;
        }

        private bool OnePairToTwoPair(List<Card> street, List<Card> cardHand)
        { // 5 outs

            var Multiples = FindMultipleCardsOnStreet(cardHand, street);
            if (HasPair(cardHand) && Multiples == 0)
            {
                return true;
            }

            if (!HasPair(cardHand) && Multiples == 1)
            {
                return true;
            }

            return false;
        }

        private bool OneOverCard(List<Card> street, List<Card> cardHand) { // 3 outs
            
            if (!HasPair(cardHand)) {
                foreach (var element in street) {
                    if (cardHand[0].Rank > element.Rank && cardHand[1].Rank > element.Rank) {
                        return true;
                    }

                    if (cardHand[0].Rank < element.Rank && cardHand[1].Rank > element.Rank) {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool NoPairToPair(List<Card> street, List<Card> cardHand) { // Outs 6
            if (!HasPair(cardHand)) {
                return true;
            }

            return false;
        }

        #endregion

        #region Utility
        private int GetRankDifference(List<Card> cardHand) {
            return Math.Abs(cardHand[0].Rank - cardHand[1].Rank);
        }

        private bool HasFlushChance(List<Card> cardHand) {
            return cardHand[0].Suit == cardHand[1].Suit;
        }

        private bool HasStraightChance(List<Card> cardHand) {
            return Math.Abs(cardHand[1].Rank - cardHand[0].Rank) <= 4;
        }

        private bool HasPair(List<Card> cardHand) {
            return cardHand[0].Rank == cardHand[1].Rank;
        }

        #endregion

        #region OutsInProcentagesCalc

        public double OutsInProcentages(List<Card> street, List<Card> cardHand)
        {
            int outs = CompareOuts(street, cardHand), streetSize = street.Count();
            double result;

            if(streetSize == 4)
            {
                result = 1 - ((46 - outs) / 46);
            }
            else if(streetSize == 3)
            {
                result = (47 - outs) / 47;
                result *= (46 - outs) / 46;
                result = 1 - result;
            }
            else
            {
                throw new Exception("street count has to be either 3 or 4");
            }

            return result;
        }

        #endregion
    }
}