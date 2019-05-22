using System;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    class PathConstructor {
        private readonly OpponentData _data;
        private int _currentRound;

        private bool _isSmallBlind;
        private int[] _roundEndIndex;


        public PathConstructor(OpponentData data, bool isSmallBlind) {
            _data = data;
            _currentRound = 0;
            _isSmallBlind = isSmallBlind;
            _roundEndIndex = new int[4];
        }


        public void ConstructPath(Node parent, string path, double expectedValue) {
            string[] separatedPath = SeparatePath(path);
            Node startNode = parent,
                 prevNode = startNode;
            UpdateRoundIndexes(separatedPath);

            for(int i = 0; i < separatedPath.Length; i++) {
                _currentRound = GetCurrentRound(i);
                bool isAiNode = IsAiNode(i);

                if(i == separatedPath.Length - 1) {
                    prevNode.Children.Add(NewLeafNode(prevNode, separatedPath[i], expectedValue, isAiNode));
                } else {
                    if(NodeExists(ref prevNode, separatedPath[i])) { continue; }

                    Node tempNode = NewNode(prevNode, separatedPath[i], isAiNode);
                    prevNode.Children.Add(tempNode);
                    prevNode = tempNode;
                }
            }
        }

        private bool IsAiNode(int index) {
            int roundStartIndex = 0;
            for(int i = 0; i < _roundEndIndex.Length; i++) {
                if(index >= roundStartIndex && index < _roundEndIndex[i]) {
                    if(!_isSmallBlind) {
                        roundStartIndex++;
                    }

                    if((index - roundStartIndex) % 2 == 0) {
                        return true;
                    }
                }

                roundStartIndex = _roundEndIndex[i]++;
            }

            return false;
        }

        private Node NewLeafNode(Node parent, string action, double value, bool isAiNode) {
            if(isAiNode) {
                return new Node(parent, action, value);
            }

            return NewOpponentNode(parent, action, _currentRound);
        }

        private int GetCurrentRound(int index) {
            for(int i = 0; i < _roundEndIndex.Length; i++) {
                if(_roundEndIndex[i] > index) {
                    return i;
                }
            }

            return _currentRound;
        }

        private void UpdateRoundIndexes(string[] actions) {
            int roundNumber = 0;
            for(int i = 0; i < actions.Length; i++) {
                if(actions[i] == "C") {
                    _roundEndIndex[roundNumber] = i;
                    roundNumber++;
                } else if(actions[i] == "Ch" && actions[i + 1] == "Ch") {
                    _roundEndIndex[roundNumber] = i;
                    roundNumber++;
                    i++;
                }
            }
        }


        private Node NewOpponentNode(Node parent, string action, int roundNumber) {
            HandData data = _isSmallBlind ? _data.BigBlindHands : _data.SmallBlindHands;
            return new Node(parent, action, GetChance(action, roundNumber, data));
        }

        private double GetChance(string action, int roundNumber, HandData data) {
            if(action == "R") {
                return (double) data.Raises[roundNumber] / data.Hands;
            }
            if(action == "RE") {
                return (double)data.ReRaises[roundNumber] / data.Hands;
            }
            if(action == "C") {
                return (double)data.Calls[roundNumber] / data.Hands;
            }
            if(action == "Ch") {
                return (double)data.Checks[roundNumber] / data.Hands;
            }
            if(action == "F") {
                return (double)data.Folds[roundNumber] / data.Hands;
            }

            throw new Exception("Unknown action recieved.");
        }

        private Node NewNode(Node parent, string action, bool isAiNode) {
            if(isAiNode) {
                return new Node(parent, action);
            }

            return NewOpponentNode(parent, action, _currentRound);
        }

        private bool NodeExists(ref Node parent, string action) {
            foreach(Node child in parent.Children) {
                if(child.Action == action) {
                    parent = child;
                    return true;
                }
            }
            return false;
        }
        
        private string[] SeparatePath(string path) {
            return path.Split('-');
        }
    }
}
