using System;
using System.Collections.Generic;
using System.Linq;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    class PokerTree {
        private Node RootNode { get; }
        private Node _currentNode;
        private readonly PokerGame _pokerGame;
        private readonly OpponentData _data;
        private readonly bool _isSmallBlind;

        public PokerTree(PokerGame game, List<Card> street, Player player, Settings settings, int currentRoundNumber, OpponentData data) {
            RootNode = CreateTree(street, player, settings, currentRoundNumber);
            _currentNode = RootNode;
            _data = data;
            _isSmallBlind = player.IsSmallBlind;
            _pokerGame = game;

        }

        private Node CreateTree(List<Card> street, Player player, Settings settings, int currentRoundNumber) {
            Node result = new Node(null, string.Empty);
            PathGenerator pg = new PathGenerator();
            PathConstructor ph = new PathConstructor(_data, _isSmallBlind);
            List<Card> cardHand = new List<Card>{player.Cards[0], player.Cards[1]};
            string[] paths = pg.GeneratePaths(currentRoundNumber);
            double[] expectedValues = GetEVs(paths, cardHand, street, player, settings);

            for(int i = 0; i < paths.Length; i++) {
                ph.ConstructPath(result, paths[i],expectedValues[i]);
            }

            return result;
        }

        private double[] GetEVs(string[] paths, List<Card> cardHand, List<Card> street, Player player, Settings settings) {
            EVCalculator evCalculator = new EVCalculator(_pokerGame, settings);
            return evCalculator.CalculateAll(paths, cardHand, street, player);
        }

        public PlayerAction GetBestAction() {
            Node targetNode = FindBestPath(_currentNode);

            while(!ReferenceEquals(_currentNode, targetNode.Parent)) {
                targetNode = targetNode.Parent;
            }

            _currentNode = targetNode;
            return targetNode.GetAction();
        }

        private Node FindBestPath(Node parentNode) {
            if(parentNode.Children.Count == 0) { return parentNode; }
            Node result = null;
            for(int i = 0; i < parentNode.Children.Count; i++) {
                Node tmp = FindBestPath(parentNode.Children[i]);
                if(i == 0 || result.Value < tmp.Value) {
                    result = tmp;
                } 
            }
            return result;
        }

        private Node FindOptimalPath(Node position) {
            if(position.Children.Count == 0) { return position; }

            Node bestNode = null;
            foreach(Node child in position.Children) {
                if(position.GetType() == typeof(OpponentNode)) {
                    Node tmp = FindOptimalPath(child);
                    if(child == position.Children.First() || bestNode.Value < tmp.Value) {
                        bestNode = tmp;
                    }
                } else {
                    OpponentNode bestProb = null;
                    foreach(OpponentNode probChild in child.Children) {
                        if(probChild == child.Children.First() ||
                           probChild.DecisionProbability < bestProb.DecisionProbability) {
                            bestProb = probChild;
                        }
                    }

                    bestNode = FindOptimalPath(bestProb);
                }
            }

            return bestNode;
        }


        public void RegisterOpponentMove(PlayerAction action) {
            _currentNode = GetOpponentMove(action);
        }

        private Node GetOpponentMove(PlayerAction action) {
            foreach(Node childNode in _currentNode.Children) {
                if(childNode.GetAction() == action) {
                    return childNode;
                }
            }
            throw new Exception("Action does not match any possible node.");
        }
    }
}
