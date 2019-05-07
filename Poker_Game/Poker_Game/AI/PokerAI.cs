using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class PokerAI {
        private readonly Player _player;
        private readonly List<Hand> _hands;
        private readonly Settings _settings;
        private readonly List<Action> _actions;

        public PokerAI(PokerGame game) {
            _player = game.Players[1]; // AI is always player 1
            _hands = game.Hands;
            _settings = game.Settings;
            _actions = GetActions(game);
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