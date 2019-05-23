using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI.GameTree {
    class OpponentNode : Node {
        public double DecisionProbability { get; }

        public OpponentNode(Node parent, string action, double probability) : base(parent, action) {
            DecisionProbability = probability;
        }

        public OpponentNode(Node parent, string action, double value, double probability) : base(parent, action, value) {
            DecisionProbability = probability;
        }

    }
}
