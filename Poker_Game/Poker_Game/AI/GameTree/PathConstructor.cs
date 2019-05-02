using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI.GameTree {
    class PathConstructor {
      //"R-RE-C-R-RE-C-R-RE-C"

        public Node ConstructPath(Node parent, string path, double expectedValue) {
            string[] separatedPath = SeparatePath(path);
            Node startNode = parent;
            Node prevNode = startNode;
            
            foreach (string action in separatedPath) {
                prevNode.Children.Add(separatedPath.Last() == action
                    ? new Node(prevNode, action, expectedValue)
                    : new Node(prevNode, action));
            }

            return startNode;
        }

        private Node NodeExists(Node parent, string action) {
            foreach(Node child in parent.Children) {
                if(child.Action == action) {
                    return child;
                }
            }

            return new Node(parent, action);
        }


        private string[] SeparatePath(string path) {
            return path.Split('-');
        }
        

    }
}
