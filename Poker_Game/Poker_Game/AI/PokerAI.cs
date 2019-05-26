using System;
using System.Collections.Generic;
using Poker_Game.AI.Opponent;
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
        private readonly ExpectiMaxDecisionMaking _expectiMaxDecisionMaking;
        private readonly MonteCarloDecisionMaking _monteCarloDecisionMaking;

        private const int ExpectiMaxMininmumData = 10; 


        public PokerAi(PokerGame game) {
            _pokerGame = game;
            _player = game.Players[1]; // AI is always player 1
            _settings = game.Settings;
            _actions = GetActions(game);
            _dataController = new DataController(game.Settings.PlayerName);

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

        public void PrepareNewHand() {
            _dataController.UpdateData(_pokerGame.Hand);
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

        private PlayerAction ExpectiMax() {
            if(_pokerGame.Hand.CurrentRoundNumber() == 1) {
                return Preflop();
            } else {
                if(_player.IsBigBlind) {
                    _expectiMaxDecisionMaking.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
                } else if(_player.IsSmallBlind && _pokerGame.CurrentTurnNumber() > 1) {
                    _expectiMaxDecisionMaking.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
                }

                return AfterPreflop();
            }
        }

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