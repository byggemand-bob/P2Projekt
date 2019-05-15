using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class AiTest {

        static void Main() {
            TestPotSizeCalculator();

        }

        static void TestPotSizeCalculator() {
            PotSizeCalculator psc = new PotSizeCalculator(new Settings(2, 200, 1,true,1,"Person", 1));
            int potSize = psc.GetPotsize("R-RE-C-R-RE-C-R-RE-C");
            Console.WriteLine(potSize);
            Console.ReadKey();
        }

        static void TestRangeCount() {
            VPIPController rf = new VPIPController(@"Person");
            RangeParser rp = new RangeParser();
            List<List<Card>> result = rp.Parse(new List<string>() { "22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T2s+", "92s+", "83s+", "73s+", "63s+", "52s+", "43s", "A2o+", "K2o+", "Q2o+", "J4o+", "T6o+", "96o+", " 86o+", "75o+", "65o" });
            //List<List<Card>> result = rp.Parse(rf.GetRange());

            Console.WriteLine(result.Count);

            for(int index = 0; index < result.Count; index++) {
                var chand = result[index];
                Console.WriteLine(@"{0}, : {1} of {2}, {3} of {4}", index, chand[0].Rank, chand[0].Suit, chand[1].Rank, chand[1].Suit);
            }

            Console.ReadKey();
        }
    }
}
