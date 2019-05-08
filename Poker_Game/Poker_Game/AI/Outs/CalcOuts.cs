using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class CalcOuts {
        public Player Player { get; set; }
        public CalcFlushOuts FlushOuts { get; set; }
        public CalcPairOuts PairOuts { get; set; }
        public CalcStraightOuts StraightOuts { get; set; }

        public PokerGame Game { get; set; }

        public CalcOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhands, CalcFlushOuts flushouts,
            CalcPairOuts pairouts, CalcStraightOuts straightouts, PokerGame game) {
            Player = player;
            FlushOuts = flushouts;
            PairOuts = pairouts;
            StraightOuts = straightouts;
            Game = game;

        }

        public int compareOuts(Player player, List<Card> street, PlayerCardsInHand cardsinhands,
            CalcFlushOuts flushouts, CalcPairOuts pairouts, CalcStraightOuts straightouts) {

            if (cardsinhands.IsFlushChance(player) && cardsinhands.IsStraightChance(player)) {
                var outs = flushouts.numberOfOuts + straightouts.numberOfOuts;
                return outs;
            }

            if (cardsinhands.IsFlushChance(player) && cardsinhands.IsStraightChance(player) == false) {
                var outs = flushouts.numberOfOuts;
                return outs;
            }

            if (cardsinhands.IsFlushChance(player) == false && cardsinhands.IsStraightChance(player)) {
                var outs = straightouts.numberOfOuts;
                return outs;
            }

            if (cardsinhands.IsPair(player) && cardsinhands.IsFlushChance(player) == false &&
                cardsinhands.IsFlushChance(player) == false) {
                var outs = pairouts.numberOfOuts;
                return outs;
            }

            else {
                return 0;
            }
        }




    }
}