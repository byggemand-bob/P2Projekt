using System;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    class PokerTree {
        public Node RootNode { get; private set; }
        public Node CurrentNode { get; private set; }

        public PokerTree() {
            RootNode = CreateTree();
        }

        private Node CreateTree() {
            Node result = new Node(null, string.Empty);
            CurrentNode = RootNode;
            PathGenerator pg = new PathGenerator();
            PathConstructor ph = new PathConstructor();
            string[] paths = pg.GeneratePaths();

            foreach(string path in paths) {
                ph.ConstructPath(result, path, 5 /*Udbyt med CalcEV*/);
            }
            return result;
        }

        // MinMax
        public PlayerAction ChoosePath() {
            throw new NotImplementedException();


        }


    }
}
