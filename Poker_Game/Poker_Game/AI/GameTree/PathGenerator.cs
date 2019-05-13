using System;
using System.Text;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree
{
    public class PathGenerator {

        private readonly string[] _possibleActions = { "R-RE-C", "R-RE-F", "R-C", "R-F", "Ch-R-RE-C", "Ch-R-RE-F", "Ch-R-C", "Ch-R-F", "Ch-Ch" };
        private readonly StringBuilder _allActions = new StringBuilder();

        private string MakePath(int currentRoundNumber) {

            if (currentRoundNumber == 2) {
                for (int i = 0; i < _possibleActions.Length; i++) {
                    for (int j = 0; j < _possibleActions.Length; j++) {
                        for (int k = 0; k < _possibleActions.Length; k++) {
                            if (_possibleActions[i].Contains("F")) {
                                _allActions.Append(_possibleActions[i])
                                    .Append("\n");
                                i++;
                            }
                            else if (_possibleActions[j].Contains("F")) {
                                _allActions.Append(_possibleActions[i] + "-")
                                    .Append(_possibleActions[j])
                                    .Append("\n");
                                j++;
                            }
                            else {
                                _allActions.Append(_possibleActions[i] + "-")
                                    .Append(_possibleActions[j] + "-")
                                    .Append(_possibleActions[k])
                                    .Append("\n");
                            }
                        }
                    }
                }
                return Convert.ToString(_allActions);
            }

            if (currentRoundNumber == 3) {
                for(int i = 0; i < _possibleActions.Length; i++) {
                    for(int j = 0; j < _possibleActions.Length; j++) {
                        if(_possibleActions[i].Contains("F")) {
                            _allActions.Append(_possibleActions[i])
                                       .Append("\n");
                            i++;
                        }
                        else if (_possibleActions[j].Contains("F")) {
                            _allActions.Append(_possibleActions[i] + "-")
                                .Append(_possibleActions[j])
                                .Append("\n");
                            j++;
                        }
                    }
                }

                return Convert.ToString(_allActions);
            }

            if (currentRoundNumber == 4) {
                for (int i = 0; i < _possibleActions.Length; i++) {
                    if (_possibleActions[i].Contains("F")) {
                        _allActions.Append(_possibleActions[i])
                            .Append("\n");
                        i++;
                    }
                }
                return Convert.ToString(_allActions);
            }

            return "";
        }

        public string[] GeneratePaths(int CurrentRoundNumber) {
            string[] temp = MakePath(CurrentRoundNumber).Split('\n');
            string[] result = new string[temp.Length - 1];
            Array.Copy(temp, result, temp.Length - 1);

            return result;
        
        }
    }
}
