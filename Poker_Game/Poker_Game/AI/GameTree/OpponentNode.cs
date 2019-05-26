
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
