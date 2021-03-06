﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Poker_Game.AI.GameTree;
using Poker_Game.AI.Opponent;
using Poker_Game.AI.Opponent.VPIP;
using Poker_Game.Game;

namespace Poker_Game.AI {
    public enum AiMode {
        MonteCarlo,
        ExpectiMax
    }

    public class PokerAi {
        private readonly Player _player;
        private readonly Settings _settings;
        private readonly List<Action> _actions;
        private readonly PokerGame _pokerGame;
        private readonly DataController _dataController;
        private readonly Round _round;
        private readonly List<Card> _street;
        private readonly Hand _hand;
        private readonly ExpectiMaxDecisionMaking _expectiMaxDecisionMaking;
        private readonly MonteCarloDecisionMaking _monteCarloDecisionMaking;

        private const int ExpectiMaxMininmumData = 10; 


        public PokerAi(PokerGame game) {
            _pokerGame = game;
            _player = game.Players[1]; // AI is always player 1
            _settings = game.Settings;
            _actions = GetActions(game);
            _dataController = new DataController(game.Settings.PlayerName);
            _round = game.CurrentRound();
            _street = game.Hand.Street.ToList();
            _hand = game.Hand;

            if(game.Settings.EvaluationStyle == AiMode.MonteCarlo) {
                _monteCarloDecisionMaking = new MonteCarloDecisionMaking(_pokerGame); 
            } else {
                _expectiMaxDecisionMaking = new ExpectiMaxDecisionMaking(_dataController.PlayerData);
            }
        }

        private List<Action> GetActions(PokerGame game) {
            List<Action> result = new List<Action> {
                game.Fold,
                game.Call,
                game.Check,
                game.Raise
            };
            return result;
        }

        // Called at the start of a new hand
        public void PrepareNewHand() {
            _dataController.UpdateData(_pokerGame.Hand);
            //_expectiMaxDecisionMaking.ClearTree();
        }

        public void PrepareNewTree() {
            if(_settings.EvaluationStyle == AiMode.ExpectiMax && _pokerGame.CurrentRoundNumber() > 1) {
                _expectiMaxDecisionMaking.CreateNewTree(_pokerGame); 
            }
        }

        public void SaveData() {
            _dataController.SaveData();
        }

        public void MakeDecision() {
            PlayerAction action;
            if(_settings.EvaluationStyle == AiMode.ExpectiMax && _dataController.PlayerData.Hands > ExpectiMaxMininmumData) {
                action = ExpectiMax();
            } else {
                action = MonteCarlo();
            }


            switch(action) {
                case PlayerAction.Fold:
                    _actions[0].Invoke();
                    break;
                case PlayerAction.Call:
                    _actions[1].Invoke();
                    break;
                case PlayerAction.Check:
                    _actions[2].Invoke();
                    break;
                case PlayerAction.Raise:
                    _actions[3].Invoke();
                    break;
            }
        }

        private PlayerAction MonteCarlo() {
            return _monteCarloDecisionMaking.GetNextAction();
        }

        private PlayerAction MonteCarloOld() {
            WinConditions wc = new WinConditions();
            RangeParser rc = new RangeParser();
            EVCalculator ev = new EVCalculator(_pokerGame, _settings);
            OutsCalculator oc = new OutsCalculator();

            List<string> RaisePreflop = new List<string>
                {"88+", "A2s+", "K5s+", "Q8s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"};
            List<string> CallPreflop = new List<string>
                {"22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T6s+", "97s+", "87s", "A2o+", "K2o+", "Q2o+", "J9o+", "T9o"};

            List<Card> cardsToEvaluate = new List<Card>(_player.Cards);
            cardsToEvaluate.AddRange(_street);

            var handsToRaisePreflop = rc.Parse(RaisePreflop);
            var handsToCallPreflop = rc.Parse(CallPreflop).Except(handsToRaisePreflop).ToList();
            var cardHand = _player.Cards;

            List<double> ExpectedValues =
                new List<double>(ev.CalculateMonteCarlo(cardHand, _hand, _settings));

            var mtcBet = ExpectedValues[0];
            var mtcCall = 0.00;

            if (ExpectedValues.Count > 1) {
                mtcCall = ExpectedValues[1];
            }
            
            if (_pokerGame.CurrentRoundNumber() == 1) {
                if (ContainsCardHand(handsToRaisePreflop, cardHand)) {
                    if (_player.IsSmallBlind) {
                        if (_pokerGame.CanRaise()) {
                            return PlayerAction.Raise;
                        }

                        if (_pokerGame.CanCall()) {
                            return PlayerAction.Call;
                        }
                    }
                }

                if (ContainsCardHand(handsToCallPreflop, cardHand)) {
                    if (_pokerGame.CanCall()) {
                        return PlayerAction.Call;
                    }
                }

            }
            else if (_pokerGame.CurrentRoundNumber() == 2 || _pokerGame.CurrentRoundNumber() == 3) {
                // Flop + Turn

                var currentScore = wc.Evaluate(cardsToEvaluate);
                var compareOuts = oc.CompareOuts(_player.Cards, _street);

                if (currentScore <= Score.Pair) {
                    
                    if (_pokerGame.CanCall() && _pokerGame.CanRaise()) {
                        if (mtcBet > mtcCall) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }

                    if (_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
                        if (mtcBet > mtcCall) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }


                    if (_pokerGame.CanCall() && !_pokerGame.CanCheck()) {

                        if (mtcBet > 0.00) {
                            return PlayerAction.Call;
                        }
                    }
                    
                }


                if (compareOuts > 0) {
                    if (oc.CompareOuts(cardHand, _street) > 5) {
                        if (_pokerGame.CanRaise()) {
                            return PlayerAction.Raise;
                        }

                        if (_pokerGame.CanCall()) {
                            return PlayerAction.Call;
                        }
                    }
                }
            }
            else if (_pokerGame.CurrentRoundNumber() == 4) {
                var currentScore = wc.Evaluate(cardsToEvaluate);

                if (currentScore >= Score.Pair) {

                    if (_pokerGame.CanCall() && _pokerGame.CanRaise()) {
                        if (mtcBet > mtcCall) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;

                    }

                    if (_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
                        if (mtcBet > mtcCall) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }


                    if (_pokerGame.CanCall() && !_pokerGame.CanCheck()) {

                        if (mtcBet > 0.00) {
                            return PlayerAction.Call;
                        }


                    }
                }
            }

            if (_pokerGame.CanCheck())
            {
                return PlayerAction.Check;
            }

            return PlayerAction.Fold;
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

        private PlayerAction ExpectiMax() {
            if(_pokerGame.Hand.CurrentRoundNumber() == 1) {
                return Preflop();
            } else {
                //if(_pokerTree == null) {
                //    PrepareNewTree();
                //}
                if(_player.IsBigBlind) {
                    _expectiMaxDecisionMaking.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
                } else if(_player.IsSmallBlind && _pokerGame.CurrentTurnNumber() > 1) {
                    _expectiMaxDecisionMaking.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
                }

                return AfterPreflop();
            }
        }

        // CallBot
        private PlayerAction Preflop() {
            if(_pokerGame.CanCall()) {
                return PlayerAction.Call;
            }

            return PlayerAction.Check;
        }

        private PlayerAction AfterPreflop() {
            PlayerAction result =_expectiMaxDecisionMaking.GetNextAction();
            return result;
        }
    }
}