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
            double mtcWin = 0,
                   mtcLoss = 0;

            if(_pokerGame.CurrentRoundNumber() > 1) {
                ExpectedValues = new List<double>(ev.CalculateMonteCarlo(_player.Cards, _pokerGame.Hand, _pokerGame.Settings));
                mtcWin = ExpectedValues[0];
                mtcLoss = ExpectedValues[1];
                

            }

            if(_pokerGame.CurrentRoundNumber() == 1) {
                return PreFlop();
            }
            if(_pokerGame.CurrentRoundNumber() == 2 || _pokerGame.CurrentRoundNumber() == 3) {
                return FlopTurn(mtcWin, mtcLoss);
            }
            if(_pokerGame.CurrentRoundNumber() == 4) {
                return River(mtcWin, mtcLoss);
            }

            return CheckFold();
        }

        private PlayerAction River(double mtcWin, double mtcLoss) {
            
            if(_pokerGame.CanCall() && _pokerGame.CanRaise()) {
                if(mtcWin > mtcLoss) {
                    return PlayerAction.Raise;
                }

            }

            if(_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
                if(mtcWin > mtcLoss) {
                    return PlayerAction.Raise;
                }

                return PlayerAction.Check;
            }

            if(_pokerGame.CanCall() && !_pokerGame.CanCheck()) {
                if(mtcWin > mtcLoss) {
                    return PlayerAction.Call;
                }
            }
        

            return CheckFold();
        }

        private PlayerAction FlopTurn(double mtcWin, double mtcLoss) {
            
            if (_pokerGame.CanCall() && _pokerGame.CanRaise())
            {
                if (mtcWin > mtcLoss)
                {
                    return PlayerAction.Raise;
                }

            }

            if (_pokerGame.CanCheck() && _pokerGame.CanRaise())
            {
                if (mtcWin > mtcLoss)
                {
                    return PlayerAction.Raise;
                }

                return PlayerAction.Check;
            }

            if (_pokerGame.CanCall() && !_pokerGame.CanCheck())
            {
                if (mtcWin > mtcLoss)
                {
                    return PlayerAction.Call;
                }
            }


            return CheckFold();
        }


        public PlayerAction PreFlop()
        {
            RangeParser rangeParser = new RangeParser();
            List<List<Card>> raiseCardRange = rangeParser.Parse(_raiseRange);

            if (ContainsCardHand(raiseCardRange, _player.Cards))
            {
                if (_pokerGame.CanRaise())
                {
                    return PlayerAction.Raise;
                }

                if (_pokerGame.CanCall())
                {
                    return PlayerAction.Call;
                }
            }
            else if (ContainsCardHand(rangeParser.Parse(_callRange).Except(raiseCardRange).ToList(), _player.Cards))
            {
                if (_pokerGame.CanCall())
                {
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
