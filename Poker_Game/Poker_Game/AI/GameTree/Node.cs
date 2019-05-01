using System.Collections.Generic;
using Poker_Game;

namespace Poker_Game.AI.GameTree {
    class Node<T> where T : INodeType {
        public Node<INodeType> Parent { get; set; }
        public List<Node<INodeType>> Children { get; set; }
        public double ExpectedValue { get; set; }
        public char Action { get; set; }

        // For Root-nodes
        public Node() {
            Parent = null;
        }

        public Node(Node<INodeType> parent) {
            Parent = new Node<INodeType>();
            Children = new List<Node<INodeType>>();
        }

        

    }
}
