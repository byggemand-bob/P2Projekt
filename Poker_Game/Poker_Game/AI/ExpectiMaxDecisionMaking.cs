using System;
using System.Linq;
using Poker_Game.AI.GameTree;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class ExpectiMaxDecisionMaking {
        private readonly OpponentData _data;
        private Node _currentNode;
        private Node _treeRoot;
        private Node _currentTarget;
        private PlayerAction _expectedAction; // For checking if the human player follows the calculated path.


        public ExpectiMaxDecisionMaking(OpponentData data) {
            _data = data;
        }

        public void CreateNewTree(PokerGame game) {
            TreeConstructor tc = new TreeConstructor(game, _data);
            _treeRoot = tc.CreateTree(game.CurrentRoundNumber());
            _currentNode = _treeRoot;
            _currentTarget = null;
            _expectedAction = PlayerAction.None;

        }

        public PlayerAction GetNextAction() {
            if(_expectedAction == PlayerAction.None || _expectedAction != _currentNode.GetAction()) {
                _currentTarget = FindOptimalPath(_currentNode);
            }

            Node result = _currentTarget;

            while(!ReferenceEquals(_currentNode, result.Parent)) {
                _expectedAction = result.GetAction();
                result = result.Parent;
            }

            _currentNode = result;
            return result.GetAction();
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
