using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Opponent.VPIP;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class MonteCarloDecisionMaking {
        List<string> _raiseRange = new List<string> {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"};
        List<string> _callRange = new List<string> {"22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T6s+", "97s+", "87s", "A2o+", "K2o+", "Q2o+", "J9o+", "T9o"};

        private readonly PokerGame _pokerGame;
        private readonly Player _player;
        private readonly List<Card> _street;

        public MonteCarloDecisionMaking(PokerGame game) {
            _pokerGame = game;
            _player = game.Players[1];
            _street = game.Hand.Street;
        }

        public PlayerAction GetNextAction() {
            EVCalculator ev = new EVCalculator(_pokerGame, _pokerGame.Settings);
            List<Card> evalCards = GetCardsToEvaluate();
            List<double> ExpectedValues;
            double mtcBet = 0,
                   mtcCall = 0;

            if(_pokerGame.CurrentRoundNumber() > 1) {
                ExpectedValues = new List<double>(ev.CalculateMonteCarlo(_player.Cards, _pokerGame.Hand, _pokerGame.Settings));
                mtcBet = ExpectedValues[0];

                if(ExpectedValues.Count > 1) {
                    mtcCall = ExpectedValues[1];
                }

            }

            if(_pokerGame.CurrentRoundNumber() == 1) {
                return PreFlop();
            }
            if(_pokerGame.CurrentRoundNumber() == 2 || _pokerGame.CurrentRoundNumber() == 3) {
                return FlopTurn(evalCards, mtcBet, mtcCall);
            }
            if(_pokerGame.CurrentRoundNumber() == 4) {
                return River(evalCards, mtcBet, mtcCall);
            }

            return CheckFold();
        }

        private PlayerAction River(List<Card> evalCards, double mtcBet, double mtcCall) {
            WinConditions wc = new WinConditions();
            var currentScore = wc.Evaluate(evalCards);

            if(currentScore >= Score.Pair) {
                if(_pokerGame.CanCall() && _pokerGame.CanRaise()) {
                    if(mtcBet > mtcCall) {
                        return PlayerAction.Raise;
                    }

                    return PlayerAction.Call;
                }

                if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
                    if(mtcBet > mtcCall) {
                        return PlayerAction.Raise;
                    }

                    return PlayerAction.Call;
                }

                if(_pokerGame.CanCall() && !_pokerGame.CanCheck()) {
                    if(mtcBet > 0.00) {
                        return PlayerAction.Call;
                    }
                }
            }

            return CheckFold();
        }

        private PlayerAction FlopTurn(List<Card> cardsToEvaluate, double mtcBet, double mtcCall) {
            OutsCalculator oc = new OutsCalculator();
            WinConditions wc = new WinConditions();

            var currentScore = wc.Evaluate(cardsToEvaluate);
            var compareOuts = oc.CompareOuts(_player.Cards, _street);

            if(currentScore >= Score.Pair) {
                if((_pokerGame.CanCheck() || _pokerGame.CanCall()) && _pokerGame.CanRaise()) {
                    if(mtcBet > mtcCall) {
                        return PlayerAction.Raise;
                    }

                    return PlayerAction.Call;
                }
                
                if(_pokerGame.CanCall() && !_pokerGame.CanCheck()) {
                    if(mtcBet > 0.00) {
                        return PlayerAction.Call;
                    }
                }

                return CheckFold();
            }


            if(compareOuts > 0) {
                if(oc.CompareOuts(_player.Cards, _street) > 5) {
                    if(_pokerGame.CanRaise()) {
                        return PlayerAction.Raise;
                    }

                    if(_pokerGame.CanCall()) {
                        return PlayerAction.Call;
                    }
                }
            }

            return CheckFold();
        }

        private PlayerAction PreFlop() {
            RangeParser rangeParser = new RangeParser();
            List<List<Card>> raiseCardRange = rangeParser.Parse(_raiseRange);

            if(ContainsCardHand(raiseCardRange, _player.Cards)) {
                if(_pokerGame.CanRaise()) {
                    return PlayerAction.Raise;
                }

                if(_pokerGame.CanCall()) {
                    return PlayerAction.Call;
                }
            } else if(ContainsCardHand(rangeParser.Parse(_callRange).Except(raiseCardRange).ToList(), _player.Cards)) {
                if(_pokerGame.CanCall()) {
                    return PlayerAction.Call;
                }
            }

            return CheckFold();
        }

        private bool ContainsCardHand(List<List<Card>> range, List<Card> cardHand) {
            foreach(var element in range) {
                if((element[0].CompareTo(cardHand[0]) == 0 && element[1].CompareTo(cardHand[1]) == 0) ||
                   (element[1].CompareTo(cardHand[0]) == 0 && element[0].CompareTo(cardHand[1]) == 0)) {
                    return true;
                }
            }
            return false;
        }

        private List<Card> GetCardsToEvaluate() {
            List<Card> result = new List<Card>(_player.Cards);
            result.AddRange(_street);
            return result;
        }

        private PlayerAction CheckFold() {
            if(_pokerGame.CanCheck()) {
                return PlayerAction.Check;
            }

            return PlayerAction.Fold;
        }


    }
}
