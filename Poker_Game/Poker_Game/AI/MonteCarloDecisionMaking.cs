//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Poker_Game.AI.Opponent.VPIP;
//using Poker_Game.Game;

//namespace Poker_Game.AI {
//    class MonteCarloDecisionMaking {
//        List<string> RaisePreflop = new List<string> {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"};
//        List<string> CallPreflop = new List<string> {"22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T6s+", "97s+", "87s", "A2o+", "K2o+", "Q2o+", "J9o+", "T9o"};

//        private readonly PokerGame _pokerGame

//        public MonteCarloDecisionMaking(PokerGame game) {
            
//        }

//        private 


//        private PlayerAction MonteCarlo() {
//            WinConditions wc = new WinConditions();
//            RangeParser rc = new RangeParser();
//            EVCalculator ev = new EVCalculator(_pokerGame, _settings);
//            OutsCalculator oc = new OutsCalculator();

            

//            List<Card> cardsToEvaluate = new List<Card>(_player.Cards);
//            cardsToEvaluate.AddRange(_street);

//            var handsToRaisePreflop = rc.Parse(RaisePreflop);
//            var handsToCallPreflop = rc.Parse(CallPreflop).Except(handsToRaisePreflop).ToList();
//            var cardHand = _player.Cards;

//            List<double> ExpectedValues =
//                new List<double>(ev.CalculateMonteCarlo(cardHand, _pokerGame.Players[0], _hand, _settings));

//            var mtcBet = ExpectedValues[0];
//            var mtcCall = 0.00;

//            if(ExpectedValues.Count > 1) {
//                mtcCall = ExpectedValues[1];
//            }

//            if(_pokerGame.CurrentRoundNumber() == 1) {
//                if(ContainsCardHand(handsToRaisePreflop, cardHand)) {
//                    if(_player.IsSmallBlind) {
//                        if(_pokerGame.CanRaise()) {
//                            return PlayerAction.Raise;
//                        }

//                        if(_pokerGame.CanCall()) {
//                            return PlayerAction.Call;
//                        }
//                    }
//                }

//                if(ContainsCardHand(handsToCallPreflop, cardHand)) {
//                    if(_pokerGame.CanCall()) {
//                        return PlayerAction.Call;
//                    }
//                }

//            } else if(_pokerGame.CurrentRoundNumber() == 2 || _pokerGame.CurrentRoundNumber() == 3) {
//                // Flop + Turn

//                var currentScore = wc.Evaluate(cardsToEvaluate);
//                var compareOuts = oc.CompareOuts(_player.Cards, _street);

//                if(currentScore <= Score.Pair) {

//                    if(_pokerGame.CanCall() && _pokerGame.CanRaise()) {
//                        if(mtcBet > mtcCall) {
//                            return PlayerAction.Raise;
//                        }

//                        return PlayerAction.Call;
//                    }

//                    if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
//                        if(mtcBet > mtcCall) {
//                            return PlayerAction.Raise;
//                        }

//                        return PlayerAction.Call;
//                    }


//                    if(_pokerGame.CanCall() && !_pokerGame.CanCheck()) {

//                        if(mtcBet > 0.00) {
//                            return PlayerAction.Call;
//                        }
//                    }

//                }


//                if(compareOuts > 0) {
//                    if(oc.CompareOuts(cardHand, _street) > 5) {
//                        if(_pokerGame.CanRaise()) {
//                            return PlayerAction.Raise;
//                        }

//                        if(_pokerGame.CanCall()) {
//                            return PlayerAction.Call;
//                        }
//                    }
//                }
//            } else if(_pokerGame.CurrentRoundNumber() == 4) {
//                var currentScore = wc.Evaluate(cardsToEvaluate);

//                if(currentScore <= Score.Pair) {

//                    if(_pokerGame.CanCall() && _pokerGame.CanRaise()) {
//                        if(mtcBet > mtcCall) {
//                            return PlayerAction.Raise;
//                        }

//                        return PlayerAction.Call;

//                    }

//                    if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
//                        if(mtcBet > mtcCall) {
//                            return PlayerAction.Raise;
//                        }

//                        return PlayerAction.Call;
//                    }


//                    if(_pokerGame.CanCall() && !_pokerGame.CanCheck()) {

//                        if(mtcBet > 0.00) {
//                            return PlayerAction.Call;
//                        }


//                    }
//                }
//            }

//            if(_pokerGame.CanCheck()) {
//                return PlayerAction.Check;
//            }

//            return PlayerAction.Fold;
//        }

//        private bool ContainsCardHand(List<List<Card>> range, List<Card> cardHand) {
//            foreach(var element in range) {
//                if((element[0].CompareTo(cardHand[0]) == 0 && element[1].CompareTo(cardHand[1]) == 0) ||
//                   (element[1].CompareTo(cardHand[0]) == 0 && element[0].CompareTo(cardHand[1]) == 0)) {
//                    return true;
//                }
//            }
//            return false;
//        }

//    }
//}
