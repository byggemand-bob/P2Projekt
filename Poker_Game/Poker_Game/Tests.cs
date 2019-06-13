using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;
using Poker_Game.AI;

namespace Poker_Game {
    class Tests {

        private const int goal = 10;


        public static void Main() {
            Settings settings = new Settings(2, 1000000, 1, "player1", 1, AiMode.MonteCarlo);
            PokerGame game = new PokerGame(settings);
            PokerAi ai1 = new PokerAi(game, game.Players[0]);
            PokerAi ai2 = new PokerAi(game, game.Players[1]);


            int current = 0, prevRound = 0, ai1Win;
            while(current < goal) {
                if(prevRound < game.CurrentRoundNumber()) {
                    prevRound++;
                }
                if(prevRound == 5) {
                    prevRound = 0;
                    current++;
                    game.RewardWinners();
                    if(current >= goal) {
                        break;
                    }
                    game.NewHand();
                }

                if(game.CurrentPlayerIndex == 0) {
                    ai1.MakeDecision();
                    if(game.Players[0].PreviousAction == PlayerAction.Fold) { 
                        if(prevRound == 5) {
                            prevRound = 0;
                            current++;
                            if(current >= goal) {
                                break;
                            }

                            game.NewHand();
                        }
                    }
                } else {
                    ai2.MakeDecision();
                    if(game.Players[1].PreviousAction == PlayerAction.Fold) {
                        if(prevRound == 5) {
                            prevRound = 0;
                            current++;
                            if(current >= goal) {
                                break;
                            }

                            game.NewHand();
                        }
                    }
                }

            }
            
            Console.WriteLine("Number of hands player: " + goal);
            Console.WriteLine("Ai1 stack:" + game.Players[0].Stack);
            Console.WriteLine("Ai2 stack:" + game.Players[1].Stack);
            Console.ReadLine();


        }

        private static void HandUpdate() {
            throw new NotImplementedException();
        }
    }
}
