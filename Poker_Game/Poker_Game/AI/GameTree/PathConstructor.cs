using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI.GameTree {
    class PathConstructor {
        private Node<IRootNode> _rootNode;

        public PathConstructor(Node<IRootNode> rootNode) {
            _rootNode = rootNode;
        }


        public Node<INodeType> ConstructPath(string path) {

        }

    }
}
