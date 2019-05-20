using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent {
    class DecideOpponentRange {

        private Player Player { get; set; }
        private Settings Settings { get; set; }

        List<List<Card>> cardsHeRaises = new List<List<Card>>();
        List<List<Card>> cardsHeCalls = new List<List<Card>>();
        List<List<Card>> cardsHeFolds = new List<List<Card>>();
        List<List<List<Card>>> OpponentReactionToHand = new List<List<List<Card>>>();


        public List<List<List<Card>>> splitRanges(string path, List<List<Card>> playerOutsRange, List<Card> street) {

            EVCalculator ev = new EVCalculator(Player, Settings);

            double EvOpponentCards = 0;

            foreach (var element in playerOutsRange) {
                
                EvOpponentCards = ev.CalculateEv(path, element, street);
                if (EvOpponentCards >= 2) {
                    cardsHeRaises.Add(element);
                }

                if (EvOpponentCards <= 0) {
                    cardsHeFolds.Add(element);
                }

                if (EvOpponentCards > 0 && EvOpponentCards < 2) {
                    cardsHeCalls.Add(element);
                }
            }

            OpponentReactionToHand.Add(cardsHeRaises);
            OpponentReactionToHand.Add(cardsHeCalls);
            OpponentReactionToHand.Add(cardsHeFolds);

            return OpponentReactionToHand;

        }

    }
}



