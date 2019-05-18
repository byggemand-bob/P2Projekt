using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    public class Node {
        public Node Parent { get; }
        public List<Node> Children { get; }
        public double ExpectedValue { get; }
        public string Action { get; }

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
