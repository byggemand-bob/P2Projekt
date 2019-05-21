using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Poker_Game.AI.GameTree;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    enum AiMode {
        MonteCarlo,
        ExpectiMax
    }

    class PokerAI {
        private readonly Player _player;
        private readonly Settings _settings;
        private readonly List<Action> _actions;
        private readonly PokerGame _pokerGame;
        private readonly DataController _dataController;
        private PokerTree _pokerTree;
        private AiMode _mode;

        private const double CallModifier = 0.30; 
        private const double RaiseModifier = 0.50;

        public PokerAI(PokerGame game, AiMode mode) {
            _pokerGame = game;
            _player = game.Players[1]; // AI is always player 1
            _settings = game.Settings;
            _actions = GetActions(game);
            _dataController = new DataController(game.Settings.PlayerName);
            _mode = mode;
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
            _pokerTree = null;
        }

        public void PrepareNewTree() {
            if(_mode == AiMode.ExpectiMax) {
                _pokerTree = new PokerTree(_pokerGame.Hand.Street, _player, _settings, _pokerGame.CurrentRoundNumber()); 
            }
        }

        public void SaveData() {
            _dataController.SaveData();
        }

        public void MakeDecision() {
            PlayerAction action = _mode == AiMode.MonteCarlo ? MonteCarlo() : ExpectiMax();
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
        private PlayerAction MonteCarlo1() {
            EVCalculator evCalculator = new EVCalculator(_settings);
            double value = evCalculator.CalculateMonteCarlo(_player.Cards, _pokerGame.Players[0], _pokerGame.Hand);


            if(value - _player.CurrentBet > _player.CurrentBet * 0.5) {
                if(_pokerGame.CanRaise()) {
                    return PlayerAction.Raise;
                }

            }

            if(value - _player.CurrentBet > 0) {
                if(_pokerGame.CanCheck()) {
                    return PlayerAction.Check;
                }

                return PlayerAction.Call;
            }

            return PlayerAction.Fold;
        }

        private PlayerAction MonteCarlo() {
            EVCalculator evCalculator = new EVCalculator(_settings);
            double value = evCalculator.CalculateMonteCarlo(_player.Cards, _pokerGame.Players[0], _pokerGame.Hand);
            MessageBox.Show(value + ", R: " + _pokerGame.Hand.Pot * RaiseModifier + ", C: " + _pokerGame.Hand.Pot * CallModifier);

            if(value >= _pokerGame.Hand.Pot * RaiseModifier) {
                if(_pokerGame.CanRaise()) {
                    return PlayerAction.Raise;
                }
                
            }

            if(value >= _pokerGame.Hand.Pot * CallModifier) {
                if(_pokerGame.CanCheck()) {
                    return PlayerAction.Check;
                }

                return PlayerAction.Call;
            }
            
            return PlayerAction.Fold;
        }

        private PlayerAction ExpectiMax() {
            if(_pokerGame.Hand.CurrentRoundNumber() == 1) {
                return Preflop();
            } else {
                if(_pokerTree == null) {
                    PrepareNewTree();
                }
                if(_player.IsBigBlind) {
                    _pokerTree.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
                } else if(_player.IsSmallBlind && _pokerGame.CurrentTurnNumber() > 1) {
                    _pokerTree.RegisterOpponentMove(_pokerGame.Players[0].PreviousAction);
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
            PlayerAction result =_pokerTree.GetBestAction();
            return result;
        }
    }
}