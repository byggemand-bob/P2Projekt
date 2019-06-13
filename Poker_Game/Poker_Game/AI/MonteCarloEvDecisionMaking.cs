using System.Collections.Generic;
using System.Linq;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    public class MonteCarloEvDecisionMaking {
        private readonly Hand _hand;
        private readonly Player _player;

        private readonly PokerGame _pokerGame;
        private readonly Settings _settings;
        private readonly List<Card> _street;

        private readonly List<string> _callRange = new List<string>
            {"22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T6s+", "97s+", "87s", "A2o+", "K2o+", "Q2o+", "J9o+", "T9o"};

        private readonly List<string> _raiseRange = new List<string>
            {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"};

        public MonteCarloEvDecisionMaking(PokerGame game, Player player) {
            _pokerGame = game;
            _player = player;
            _street = game.Hand.Street;
            _settings = game.Settings;
            _hand = game.Hand;
        }

        public PlayerAction GetNextAction() {
            EvCalculator ev = new EvCalculator(_settings);
            List<Card> evalCards = GetCardsToEvaluate();
            double mtcWin = 0,
                mtcLoss = 0;

            if(_pokerGame.CurrentRoundNumber() > 1) {
                List<double> expectedValues = new List<double>(ev.CalculateMonteCarlo(_player.Cards, _pokerGame.Hand));
                mtcWin = expectedValues[0];
                mtcLoss = expectedValues[1];
            }

            if(_pokerGame.CurrentRoundNumber() == 1) return PreFlop();
            if(_pokerGame.CurrentRoundNumber() == 2 || _pokerGame.CurrentRoundNumber() == 3)
                return FlopTurn(mtcWin, mtcLoss);
            if(_pokerGame.CurrentRoundNumber() == 4) return River(mtcWin, mtcLoss);

            return CheckFold();
        }

        private PlayerAction River(double mtcWin, double mtcLoss) {
            WinConditions wc = new WinConditions();
            OutsCalculator oc = new OutsCalculator();
            EvCalculator ev = new EvCalculator(_pokerGame.Settings);
            List<Card> cardsToEvaluate = new List<Card>(_player.Cards);

            cardsToEvaluate.AddRange(_street);
            Score currentScore = wc.Evaluate(cardsToEvaluate);

            if(mtcWin > mtcLoss) {
                if(ev.CalculateEv(_street, _player, _hand))
                    if(_pokerGame.CanCall() && _pokerGame.CanRaise())
                        return PlayerAction.Raise;

                if(_pokerGame.CanCall() && !_pokerGame.CanRaise() && !_pokerGame.CanCheck()) return PlayerAction.Call;

                if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) return PlayerAction.Raise;


                if(_pokerGame.CanCall() && !_pokerGame.CanCheck())
                    if(mtcWin > mtcLoss)
                        return PlayerAction.Call;
            }

            return CheckFold();
        }

        private PlayerAction FlopTurn(double mtcWin, double mtcLoss) {
            WinConditions wc = new WinConditions();
            OutsCalculator oc = new OutsCalculator();
            EvCalculator ev = new EvCalculator(_pokerGame.Settings);

            List<Card> cardsToEvaluate = new List<Card>(_player.Cards);
            cardsToEvaluate.AddRange(_street);
            Score currentScore = wc.Evaluate(cardsToEvaluate);
            int compareOuts = oc.CompareOuts(_player.Cards, _street);


            if(mtcWin > mtcLoss) {
                if(ev.CalculateEv(_street, _player, _hand))
                    if(_pokerGame.CanCall() && _pokerGame.CanRaise())
                        return PlayerAction.Raise;

                if(_pokerGame.CanCall() && !_pokerGame.CanRaise() && !_pokerGame.CanCheck()) return PlayerAction.Call;

                if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) return PlayerAction.Raise;


                if(_pokerGame.CanCall() && !_pokerGame.CanCheck())
                    if(mtcWin > mtcLoss)
                        return PlayerAction.Call;
            }

            return CheckFold();
        }

        public PlayerAction PreFlop() {
            RangeParser rangeParser = new RangeParser();
            List<List<Card>> raiseCardRange = rangeParser.Parse(_raiseRange);

            if(ContainsCardHand(raiseCardRange, _player.Cards)) {
                if(_pokerGame.CanRaise()) return PlayerAction.Raise;

                if(_pokerGame.CanCall()) return PlayerAction.Call;
            } else if(ContainsCardHand(rangeParser.Parse(_callRange).Except(raiseCardRange).ToList(), _player.Cards)) {
                if(_pokerGame.CanCall()) return PlayerAction.Call;
            }

            return CheckFold();
        }


        private bool ContainsCardHand(List<List<Card>> range, List<Card> cardHand) {
            foreach(List<Card> element in range)
                if(element[0].CompareTo(cardHand[0]) == 0 && element[1].CompareTo(cardHand[1]) == 0 ||
                   element[1].CompareTo(cardHand[0]) == 0 && element[0].CompareTo(cardHand[1]) == 0)
                    return true;
            return false;
        }

        private List<Card> GetCardsToEvaluate() {
            List<Card> result = new List<Card>(_player.Cards);
            result.AddRange(_street);
            return result;
        }

        private PlayerAction CheckFold() {
            if(_pokerGame.CanCheck()) return PlayerAction.Check;

            return PlayerAction.Fold;
        }
    }
}