using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Poker_Game;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    public class Node {
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public double ExpectedValue { get; set; }
        public string Action { get; set; }
        public Color Color { get; set; }

        public Node(Node parent, string action) {
            Parent = parent;
            Children = new List<Node>();
            Action = action;
            ExpectedValue = 0;
            Color = Color.White;
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
