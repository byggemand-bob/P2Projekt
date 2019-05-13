using System;
using System.Text;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree
{
    public class PathGenerator {

        Player Player { get; set; }
    

        public PathGenerator(Player player) {
            Player = player;
        } 
        
        private readonly StringBuilder _allActions = new StringBuilder();


        private string[] previousPlayerAction(Player player) {
            if (player.IsSmallBlind) {
                string[] possibleActions = { "R-RE-C", "R-RE-F", "R-C", "R-F", "Ch-R-RE-C", "Ch-R-RE-F", "Ch-R-C", "Ch-R-F", "Ch-Ch"};
                return possibleActions;
            }

            else if (player.IsBigBlind /* && previousPlayerAction == call */) {
                string[] possibleActions = { "R-RE-C", "R-RE-F", "R-C", "R-F", "Ch" };
                return possibleActions;
            }

            else if (player.IsBigBlind /* && previousPlayerAction == raise*/) {
                string[] possibleActions = { "RE-C", "RE-F", "R-C", "R-F", "F" };
                return possibleActions;
            }
        }
        private string MakePath(Player player) {

            var possibleActions = previousPlayerAction(player);

            for(int i = 0; i < possibleActions.Length; i++) {
                for(int j = 0; j < possibleActions.Length; j++) {
                    for(int k = 0; k < possibleActions.Length; k++) {
                        if(possibleActions[i].Contains("F")) {
                            _allActions.Append(possibleActions[i] + "-")
                                       .Append("\n");
                            i++;
                        } else if(possibleActions[j].Contains("F")) {
                            _allActions.Append(possibleActions[i] + "-")
                                       .Append(possibleActions[j])
                                       .Append("\n");
                            j++;
                        } else {
                            _allActions.Append(possibleActions[i] + "-")
                                       .Append(possibleActions[j] + "-")
                                       .Append(possibleActions[k])
                                       .Append("\n");
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

