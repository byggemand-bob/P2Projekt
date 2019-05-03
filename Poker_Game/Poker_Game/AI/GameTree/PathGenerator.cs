using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    public class PathGenerator {
        private readonly string[] _possibleActions = new string[]
            {"Raise-ReRaise-Call", "Raise-ReRaise-Fold", "Raise-Call", "Raise-Fold", "Check-Raise-ReRasie-Call", "Check-Raise-ReRaise-Fold", "Check-Raise-Call", "Check-Raise-Fold", "Check-Check"};

        private readonly StringBuilder _allActions = new StringBuilder();

        private int count = 0;
        private string MakePath() {
            for(int i = 0; i < _possibleActions.Length; i++) {
                for(int j = 0; j < _possibleActions.Length; j++) {
                    foreach(string action in _possibleActions) {
                        if(_possibleActions[i].Contains('F')) {
                            _allActions.Append(_possibleActions[i] + "-").Append("\n");
                            i++;
                            count++;

                        } else if(_possibleActions[j].Contains('F')) {
                            _allActions.Append(_possibleActions[i] + "-").Append(_possibleActions[j]).Append("\n");
                            j++;
                            count++;
                        } else {
                            _allActions.Append(_possibleActions[i] + "-").Append(_possibleActions[j] + "-")
                                .Append(action + "")
                                .Append("\n");
                            count++;
                        }
                    }
                }
            }

            return Convert.ToString(_allActions);
        }


        public string[] GeneratePaths() {
            string[] temp = MakePath().Split('\n');
            string[] result = new string[temp.Length - 2];
            Array.Copy(temp, result, temp.Length - 2);
            return result;
        }
    }
}

