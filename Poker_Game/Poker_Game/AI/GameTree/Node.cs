using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    public class Node {
        public Node Parent { get; }
        public List<Node> Children { get; }
        public double Value { get; set; }
        public string Action { get; }

        public Node(Node parent, string action) {
            Parent = parent;
            Children = new List<Node>();
            Action = action;
            Value = 0;
        }

        // For leafnodes
        public Node(Node parent, string action, double value) {
            Parent = parent;
            Children = new List<Node>();
            Action = action;
            Value = value;
        }

        public PlayerAction GetAction() { // Rename?
            switch(Action) {
                case "R":
                case "RE":
                    return PlayerAction.Raise;
                case "C":
                    return PlayerAction.Call;
                case "Ch":
                    return PlayerAction.Check;
                case "F":
                    return PlayerAction.Fold;
                default:
                    return PlayerAction.None;
            }
        }

    }
}
