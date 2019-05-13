using System;
using System.Collections.Generic;
using System.Linq;
using Poker_Game.AI.GameTree;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class PokerAI {
        private readonly Player _player;
        private readonly List<Hand> _hands;
        private readonly Settings _settings;
        private readonly List<Action> _actions;
        private readonly VPIPController _vpipController;
        private readonly PokerGame _pokerGame;
        private PokerTree _pokerTree;

        public PokerAI(PokerGame game) {
            _pokerGame = game;
            _player = game.Players[1]; // AI is always player 1
            _hands = game.Hands;
            _settings = game.Settings;
            _actions = GetActions(game);
            _vpipController = new VPIPController(_settings.PlayerName);
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
        public void PrepareNewHand(PokerGame game) {
            if(_hands.Count > 1) {
                _vpipController.UpdateStats(_hands[_hands.Count - 2].Rounds[0].Turns); 
            }
        }

        public void PrepareNewRound(PokerGame game) {
            _pokerTree = new PokerTree(new List<Card>() {_player.Cards[0], _player.Cards[1]}, game.CurrentHand().Street, _player, _settings, game.Players[0].Action);
        }

        public void SaveData() {
            _vpipController.SaveData();
        }

        public void MakeDecision(PlayerAction realPlayerAction) {
            switch(Evaluate(realPlayerAction)) {
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

        private PlayerAction Evaluate(PlayerAction realPlayerAction) {
            return _hands.Last().CurrentRoundNumber() == 1 ? Preflop() : AfterPreflop(realPlayerAction);
        }

        // CallBot
        private PlayerAction Preflop() {
            if(_pokerGame.CanCall()) {
                return PlayerAction.Call;
            }

            return PlayerAction.Check;
        }

        private PlayerAction AfterPreflop(PlayerAction realPlayerAction) {
            _pokerTree.RegisterOpponentMove(realPlayerAction);
            return _pokerTree.GetBestAction();
        }
    }
}