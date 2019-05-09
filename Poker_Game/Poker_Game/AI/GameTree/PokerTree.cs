using System;
using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    class PokerTree {
        public Node RootNode { get; private set; }
        public Node CurrentNode { get; private set; }

        public PokerTree(List<Card> cardHand, List<Card> street) {
            RootNode = CreateTree(cardHand, street);
        }

        private Node CreateTree(List<Card> cardHand, List<Card> street) {
            Node result = new Node(null, string.Empty);
            CurrentNode = RootNode;
            PathGenerator pg = new PathGenerator();
            PathConstructor ph = new PathConstructor();
            string[] paths = pg.GeneratePaths();
            double[] expectedValues = GetEVs(paths, cardHand, street);

            for(int i = 0; i < paths.Length; i++) {
                ph.ConstructPath(result, paths[i],expectedValues[i]);
            }

            return result;
        }

        private double[] GetEVs(string[] paths, List<Card> cardHand, List<Card> street) {
            EVCalculator evCalculator = new EVCalculator();
            return evCalculator.CalculateAll(paths, cardHand, street);
        }

        // MinMax
        public PlayerAction ChoosePath(List<Card> cardHand, List<Card> street) {
            throw  new NotImplementedException();

        }


    }
}
