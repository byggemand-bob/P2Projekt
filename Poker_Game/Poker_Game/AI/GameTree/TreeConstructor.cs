using System.Collections.Generic;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI.GameTree {
    internal class TreeConstructor {
        private readonly OpponentData _data;
        private readonly Player _player;
        private readonly Settings _settings;
        private readonly List<Card> _street;
        private readonly EvCalculator _evCalculator;

        public TreeConstructor(PokerGame game, OpponentData data) {
            _player = game.Players[1];
            _settings = game.Settings;
            _street = game.Hand.Street;
            _data = data;
            _evCalculator = new EvCalculator(game.Settings);
        }

        public Node CreateTree(int currentRoundNumber) {
            Node rootNode = new Node(null, string.Empty);
            string[] paths = new PathGenerator().GeneratePaths(currentRoundNumber);
            double[] expectedValues = GetEVs(paths, _street, _player, _settings);
            PathConstructor pathConstructor = new PathConstructor(_data, _player.IsSmallBlind);

            for(int i = 0; i < paths.Length; i++) pathConstructor.ConstructPath(rootNode, paths[i], expectedValues[i]);

            return rootNode;
        }

        private double[] GetEVs(string[] paths, List<Card> street, Player player, Settings settings) {
            return _evCalculator.CalculateAll(paths, street, player, settings);
        }
    }
}