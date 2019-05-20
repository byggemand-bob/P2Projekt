using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class EVCalculator {
        private readonly Settings _settings;
        private readonly Player _player;
        private readonly Hand _hand;

        public EVCalculator(Player player, Settings settings, Hand hand) {
            _player = player;
            _settings = settings;
            _hand = hand;
        }

        public double CalculateEv(string path, List<Card> cardHand, List<Card> street, Player player, Hand hand) {
            PotSizeCalculator potcalc = new PotSizeCalculator(_settings);
            MonteCarloTrailOdds mctr = new MonteCarloTrailOdds();

            List<List<Card>> cardHandForTrials = new List<List<Card>>();
            cardHandForTrials.Add(cardHand);

            double winOdds = mctr.RunTrails(100000, cardHandForTrials).WinOdds;
            var lossOdds = mctr.RunTrails(100000, cardHandForTrials).LoseOdds;
            var drawOdds = mctr.RunTrails(100000, cardHandForTrials).DrawOdds;
            var winPot = hand.Pot;
            var lossPot = 0;

            if (player.Action == PlayerAction.Raise || player.Action == PlayerAction.Call) {
                lossPot = 2;
            }

            else if (player.Action == PlayerAction.Check) {
                lossPot = 0;
            }

            return (winOdds / 100) * winPot - (lossOdds / 100) * lossPot;
        }
    }
}


/*
public double CalculateEv(string path, List<Card> cardHand, List<Card> street) {
    OutsCalculator outCalc = new OutsCalculator();
    PotSizeCalculator potCalc = new PotSizeCalculator(_settings);

    double winOdds = 2 * outCalc.CompareOuts(cardHand, street) * 0.01;
    double lossOdds = 1 - winOdds;
    double winPot = potCalc.GetPotsize(path);
    double lossPot = _player.CurrentBet;

    //System.Windows.Forms.MessageBox.Show(((winOdds * winPot) - (lossOdds * lossPot)).ToString());

    return (winOdds * winPot) - (lossOdds * lossPot);
}

public double[] CalculateAll(string[] paths, List<Card> cardHand, List<Card> street) {
    double[] result = new double[paths.Length];
    for(int i = 0; i < paths.Length; i++) {
        result[i] = CalculateEv(paths[i], cardHand, street);
    }

    return result;
}
}
} */
