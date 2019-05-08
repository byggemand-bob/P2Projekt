using System.Collections.Generic;

namespace Poker_Game.AI.GameTree {
    public class Node {
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public double ExpectedValue { get; set; }
        public string Action { get; set; }

        public Node(Node parent, string action) {
            Parent = parent;
            Children = new List<Node>();
            Action = action;
            ExpectedValue = 0;
        }

        public Node(Node parent, string action, double expectedValue) {
            Parent = parent;
            Children = new List<Node>();
            Action = action;
            ExpectedValue = expectedValue;
        }
    }
}
