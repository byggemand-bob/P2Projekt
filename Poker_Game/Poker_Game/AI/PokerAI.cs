using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Poker_Game.AI.GameTree;
using Poker_Game.AI.Opponent;
using Poker_Game.AI.Opponent.VPIP;
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
        private const double RaiseModifier = 0.60;

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

        public void MakeDecision(List<Card> cardHand, Round CurrentRound, List<Card> street, Settings settings, Player player, Hand hand) {
            PlayerAction action = _mode == AiMode.MonteCarlo ? MonteCarlo(cardHand, CurrentRound, street, settings, player, hand) : ExpectiMax();
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
            double value = evCalculator.CalculateMonteCarlo(_player.Cards, _pokerGame.Players[0], _pokerGame.Hand, _settings);


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

        private PlayerAction MonteCarlo(List<Card> cardHand, Round CurrentRound, List<Card> street, Settings settings, Player player, Hand hand) {
            EVCalculator evCalculator = new EVCalculator(_settings);
<<<<<<< HEAD
            double value = evCalculator.CalculateMonteCarlo(_player.Cards, _pokerGame.Players[0], _pokerGame.Hand, settings);
            //MessageBox.Show(value + ", R: " + _pokerGame.Hand.Pot * RaiseModifier + ", C: " + _pokerGame.Hand.Pot * CallModifier);
=======
            double value = evCalculator.CalculateMonteCarlo(_player.Cards, _pokerGame.Players[0], _pokerGame.Hand);
            MessageBox.Show(value + ", R: " + _pokerGame.Hand.Pot * RaiseModifier + ", C: " + _pokerGame.Hand.Pot * CallModifier);
>>>>>>> 1dc229133321b456bf41e0a9b086d4d958c04231

            WinConditions wc = new WinConditions();

            RangeParser rc = new RangeParser();

            EVCalculator ev = new EVCalculator(settings);

            OutsCalculator oc = new OutsCalculator();

            List<string> RaisePreflop = new List<string>
                {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"};

            List<string> CallPreflop = new List<string>
                {"55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T6s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o"};

            List<Card> cardsToEvaluate = new List<Card>(cardHand);

            var compareOuts = oc.CompareOuts(street, cardHand);

            cardsToEvaluate.AddRange(street);

            var handsToRaisePreflop = rc.Parse(RaisePreflop);
            var handsToCallPreflop = rc.Parse(CallPreflop).Except(handsToRaisePreflop);


            if (CurrentRound.CurrentTurnNumber() == 0) {
                if (handsToRaisePreflop.Contains(cardHand)) {
                    return PlayerAction.Raise;
                }

                if (handsToCallPreflop.Contains(cardHand)) {
                    return PlayerAction.Call;
                }

                return PlayerAction.Fold;

            }

            if (CurrentRound.CurrentTurnNumber() == 1) {
                if (wc.Evaluate(cardsToEvaluate) >= Score.Pair) {

                    var mtc = ev.CalculateMonteCarlo(cardHand, player, hand, settings);
                    if (mtc > 0) {
                        if (mtc > 0.33 * _pokerGame.Hand.Pot && _pokerGame.CanRaise()) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }

                }

                if (compareOuts > 0) {
                    if (compareOuts > 3) {
                        return PlayerAction.Raise;
                    }

                    return PlayerAction.Call;
                }

                return PlayerAction.Fold;
            }

            if (CurrentRound.CurrentTurnNumber() == 2) {
                if (wc.Evaluate(cardsToEvaluate) >= Score.Pair) {

                    var mtc = ev.CalculateMonteCarlo(cardHand, player, hand, settings);
                    if (mtc > 0) {
                        if (mtc > 0.33 * _pokerGame.Hand.Pot && _pokerGame.CanRaise()) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }

                }

                if (compareOuts > 0) {
                    if (compareOuts > 3) {
                        return PlayerAction.Raise;
                    }

                    return PlayerAction.Call;
                }

                return PlayerAction.Fold;
            }

<<<<<<< HEAD
            if (CurrentRound.CurrentTurnNumber() == 3) {
                if (wc.Evaluate(cardsToEvaluate) >= Score.Pair) {

                    var mtc = ev.CalculateMonteCarlo(cardHand, player, hand, settings);
                    if (mtc > 0) {
                        if (mtc > 0.33 * _pokerGame.Hand.Pot && _pokerGame.CanRaise()) {
                            return PlayerAction.Raise;
                        }

                        return PlayerAction.Call;
                    }

                }

                return PlayerAction.Fold;
=======
            if(_pokerGame.CanCheck()) {
                return PlayerAction.Check;
>>>>>>> 1dc229133321b456bf41e0a9b086d4d958c04231
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