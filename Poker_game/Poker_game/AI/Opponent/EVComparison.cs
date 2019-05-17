using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent
{
    class EVComparison {

        /*public Player Player { get; set; }
        public Settings Settings { get; set; }

        public EVComparison(Player player, Settings settings) {
            Player = player;
            Settings = settings;
        }

        public double EVCompare(Player player, Settings settings, List<Card> playerCardHands, List<Card> AICardHands) { 

            EVCalculator ec = new EVCalculator(player, settings);

            var playerEv = ec.CalculateEv(List<Card> playerCardHands);
            var AIev = ec.CalculateEv(List<Card> AICardHands);

            if (playerEv < AIev) {
                player.Action = PlayerAction.Fold;
            }

            else if (playerEv > AIev) {
                if (playerEv > 1) {
                    player.Action = PlayerAction.Raise;
                }

                if (playerEv > 0 && playerEv < 1) {
                    player.Action = PlayerAction.Call;
                }
            }
        }
        */
    }
}
