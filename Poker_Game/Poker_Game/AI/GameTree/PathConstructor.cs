namespace Poker_Game.AI.GameTree {
    class PathConstructor {
        public Node ConstructPath(Node parent, string path, double expectedValue) {
            string[] separatedPath = SeparatePath(path);
            Node startNode = parent;
            Node prevNode = startNode;

            for(int i = 0; i < separatedPath.Length; i++) {
                if(i == separatedPath.Length - 1) {
                    prevNode.Children.Add(new Node(prevNode, separatedPath[i], expectedValue));
                } else {
                    if(!NodeExists(ref prevNode, separatedPath[i])) {
                        Node tempNode = new Node(prevNode, separatedPath[i]);
                        prevNode.Children.Add(tempNode);
                        prevNode = tempNode;
                    }
                }
            }
            return startNode;
        }
        
        private bool NodeExists(ref Node parent, string action) {
            foreach(Node child in parent.Children) {
                if(child.Action == action) {
                    parent = child;
                    return true;
                }
            }
            return false;
        }

        private string[] SeparatePath(string path) {
            return path.Split('-');
        }
    }
}
