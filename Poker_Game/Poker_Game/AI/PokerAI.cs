using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class PokerAI {
        private readonly Player _player;
        private readonly List<Hand> _hands;
        private readonly Settings _settings;
        private readonly List<Action> _actions;
        private readonly VPIPController _vpipController;

        public PokerAI(PokerGame game) {
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

        public void SaveData() {
            _vpipController.SaveData();
        }

        public void MakeDecision() {
            switch(Evaluate()) {
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

        private PlayerAction Evaluate() {
            if(_hands.Last().CurrentRoundNumber() == 1) {
                return Preflop();
            } else {
                return AfterPreflop();
            }
        }

        private PlayerAction Preflop() {
            throw new NotImplementedException();
            double pfr = _vpipController.PFR;
            // Check PFR chart




        }

        private PlayerAction AfterPreflop() {
            throw new NotImplementedException();
        }

    }
}


//private double CalcFaculty(double number) {
//double fact, i;
//fact = number;
//for(i = number - 1; i >= 1; i--) {
//    fact = fact * i;
//}

//return fact;
//}

//private double CalcBinomial(List<Hand> hands) {
//double r, n;

//r = CalcFaculty(Hands.Count);
//n = (52 - Hands.Count);


//return n / r * (n - r);
//}