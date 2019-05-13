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

        
        public PlayerAction GetBestAction() {
            Node targetNode = FindBestPath(CurrentNode);
            while(!ReferenceEquals(CurrentNode, targetNode)) {
                targetNode = targetNode.Parent;
            }

            CurrentNode = targetNode;
            return targetNode.GetAction();
        }

        private Node FindBestPath(Node parentNode) {
            if(parentNode.Children.Count != 0) {
                Node result = null;
                for(int i = 0; i < parentNode.Children.Count; i++) {
                    Node tmp = FindBestPath(parentNode.Children[i]);
                    if(i == 0 || result.ExpectedValue < tmp.ExpectedValue) {
                        result = tmp;
                    } 
                }
                return result;
            }
            return parentNode;
        }






    }
}
