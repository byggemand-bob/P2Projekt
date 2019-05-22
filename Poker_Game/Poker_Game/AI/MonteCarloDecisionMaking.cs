using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Game.AI.Opponent.VPIP;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class MonteCarloDecisionMaking {
        private List<List<Card>> _raiseRange;
        private List<List<Card>> _callRange;
        private readonly PokerGame _pokerGame;
        private readonly List<Card> _cardHand;
        private readonly List<Card> _street;

        private const double CallModifier = 0.30;
        private const double RaiseModifier = 0.60;

        public MonteCarloDecisionMaking(PokerGame game) {
            _pokerGame = game;
            _cardHand = game.Players[1].Cards;
            _street = game.Hand.Street;
            GetRange();
        }

        private void GetRange() {
            RangeParser rp = new RangeParser();
            _raiseRange = rp.Parse(new List<string>
                {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"});

            _callRange = rp.Parse(new List<string>
                {"55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T6s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o"})
                .Except(_raiseRange).ToList();
        }
        
        public PlayerAction MakeDecision() {
            List<Card> cardsToEvaluate = new List<Card>(_cardHand);
            cardsToEvaluate.AddRange(_street);

            if(_pokerGame.CurrentRoundNumber() == 1) {
                return Preflop();
            }

            if(_pokerGame.CurrentRoundNumber() > 1 && _pokerGame.CurrentRoundNumber() <= 3) { // Flop + Turn
                return FlopTurn(cardsToEvaluate);
            }

            if(_pokerGame.CurrentRoundNumber() == 4) { // River
                return River(cardsToEvaluate);
            }

            return CheckFold();
        }

        private PlayerAction River(List<Card> cardsToEvaluate) {
            WinConditions wc = new WinConditions();
            if(wc.Evaluate(cardsToEvaluate) >= Score.Pair) {
                if(_pokerGame.CanRaise()) {
                        return PlayerAction.Raise;
                }

                if(_pokerGame.CanCall()) { 
                    return PlayerAction.Call;
                }

                return CheckFold();
            }

            return CheckFold();
        }

        private PlayerAction FlopTurn(List<Card> cardsToEvaluate) {
            OutsCalculator oc = new OutsCalculator();
            WinConditions wc = new WinConditions();

            int compareOuts = oc.CompareOuts(_cardHand, _street);
            if(wc.Evaluate(cardsToEvaluate) >= Score.Pair) {
                EvFlopTurn();
            } else if(compareOuts > 0) {
                return OutsFlopTurn();
            }

            return CheckFold();
        }

        private PlayerAction OutsFlopTurn() {
            OutsCalculator oc = new OutsCalculator();
            int outs = oc.CompareOuts(_cardHand, _street);

            if(outs > 4 && _pokerGame.CanRaise()) {
                return PlayerAction.Raise;
            }

            if(outs <= 4 && _pokerGame.CanCall()) {
                return PlayerAction.Call;
            }

            return CheckFold();
        }

        private PlayerAction EvFlopTurn() {
            EVCalculator ev = new EVCalculator(_pokerGame.Settings);
            var eValue = ev.CalculateMonteCarlo(_cardHand, _pokerGame.Players[0], _pokerGame.Hand, _pokerGame.Settings);
            MessageBox.Show(eValue.ToString());
            if(eValue > 0) {
                if(eValue > 0.25 * _pokerGame.Hand.Pot && _pokerGame.CanRaise()) {
                    return PlayerAction.Raise;
                }

                if(eValue < 0.25 * _pokerGame.Hand.Pot && _pokerGame.CanCall()) {
                    return PlayerAction.Call;
                }
            }

            return CheckFold();
        }

        private PlayerAction Preflop() {
            if(ContainsCardHand(_raiseRange, _cardHand) && _pokerGame.CanRaise()) {
                return PlayerAction.Raise;
            }

            if(ContainsCardHand(_callRange, _cardHand) && _pokerGame.CanCall()) {
                return PlayerAction.Call;
            }

            if(_pokerGame.CanCheck()) {
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

        private PlayerAction CheckFold() {
            if(_pokerGame.CanCheck()) {
                return PlayerAction.Check;
            }

            return PlayerAction.Fold;
        }


        private PlayerAction MakeDecisionOld() {
            EVCalculator evCalculator = new EVCalculator(_pokerGame.Settings);
            double value = evCalculator.CalculateMonteCarlo(_cardHand, _pokerGame.Players[0], _pokerGame.Hand, _pokerGame.Settings);


            if(value >= _pokerGame.Hand.Pot * RaiseModifier && _pokerGame.CanRaise()) {
                return PlayerAction.Raise;
            }

            if(value >= _pokerGame.Hand.Pot * CallModifier && _pokerGame.CanCall()) {
                return PlayerAction.Call;
            }

            if(_pokerGame.CanCheck()) {
                return PlayerAction.Check;
            }

            return PlayerAction.Fold;
        }



    }
}
