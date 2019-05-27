namespace Poker_Game.AI.GameTree {
    internal class OpponentNode : Node {
        public OpponentNode(Node parent, string action, double probability) : base(parent, action) {
            DecisionProbability = probability;
        }

        public OpponentNode(Node parent, string action, double value, double probability) :
            base(parent, action, value) {
            DecisionProbability = probability;
        }

        public double DecisionProbability { get; }
    }
}