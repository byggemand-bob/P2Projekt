using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    public class CalculateEv
    {
        private string[] _possibleActions = new string[] { "R-RE-C;", "R-RE-F;", "R-C;", "R-F;", "Ch-R-RE-C;", "Ch-R-RE-F;", "Ch-R-C;", "Ch-R-F;", "Ch-Ch;" };

        private StringBuilder _allActions = new StringBuilder();

        public string CalculatePaths() {

            int i = 0, j = 0, k = 0, count = 0;
            
            for (i = 0; i < _possibleActions.Length; i++)
            {
                for (j = 0; j < _possibleActions.Length; j++)
                {
                    for (k = 0; k < _possibleActions.Length; k++)
                    {
                        if (_possibleActions[i].Contains('F'))
                        {
                            _allActions.Append(_possibleActions[i]).Append("\n");
                            i++;
                            count++;

                        }

                        else if (_possibleActions[j].Contains('F'))
                        {
                            _allActions.Append(_possibleActions[i]).Append(_possibleActions[j]).Append("\n");
                            j++;
                            count++;
                        }

                        else
                        {
                            _allActions.Append(_possibleActions[i]).Append(_possibleActions[j]).Append(_possibleActions[k])
                                .Append("\n");
                            count++;
                        }
                    }
                }
            }
      
            return Convert.ToString(_allActions);
        }
    }
}
}
