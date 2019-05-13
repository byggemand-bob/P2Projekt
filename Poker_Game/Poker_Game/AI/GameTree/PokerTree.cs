using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    class PokerTree {
        private readonly Node _rootNode;
        private Node _currentNode;

        public PokerTree(List<Card> street, Player player, Settings settings, PlayerAction opponentAction, int currentRoundNumber) {
            _rootNode = CreateTree(street, player, settings, currentRoundNumber);
            _currentNode = _rootNode;

            if(currentRoundNumber == 2 && player.IsBigBlind) {
                RegisterOpponentMove(opponentAction);
            }
        }

        private Node CreateTree(List<Card> street, Player player, Settings settings, int currentRoundNumber) {
            Node result = new Node(null, string.Empty);
            PathGenerator pg = new PathGenerator();
            PathConstructor ph = new PathConstructor();
            List<Card> cardHand = new List<Card>{player.Cards[0], player.Cards[1]};
            string[] paths = pg.GeneratePaths(currentRoundNumber);
            double[] expectedValues = GetEVs(paths, cardHand, street, player, settings);

            for(int i = 0; i < paths.Length; i++) {
                ph.ConstructPath(result, paths[i],expectedValues[i]);
            }

            return result;
        }

        private double[] GetEVs(string[] paths, List<Card> cardHand, List<Card> street, Player player, Settings settings) {
            EVCalculator evCalculator = new EVCalculator(player, settings);
            return evCalculator.CalculateAll(paths, cardHand, street);
        }

        
        public PlayerAction GetBestAction() {
            Node targetNode = FindBestPath(_currentNode);
            while(!ReferenceEquals(_currentNode, targetNode.Parent)) {
                targetNode = targetNode.Parent;
            }

            MessageBox.Show(targetNode.Parent.Action + ", " + targetNode.Action);
            _currentNode = targetNode;
            //MessageBox.Show(targetNode.GetAction().ToString() + ", " + targetNode.Action);
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

        public void RegisterOpponentMove(PlayerAction action) {
            _currentNode = GetOpponentMove(action);
        }

        private Node GetOpponentMove(PlayerAction action) {
            foreach(Node childNode in _currentNode.Children) {
                //MessageBox.Show(childNode.GetAction() + " == " + action);
                if(childNode.GetAction() == action) {
                    return childNode;
                }
            }
            throw new Exception("You done fucked up");
        }




    }
}
