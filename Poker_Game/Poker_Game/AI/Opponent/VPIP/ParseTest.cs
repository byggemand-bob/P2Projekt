using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent.VPIP {
    class ParseTest {

        static void Main() {
            RangeParser rp = new RangeParser();
            List<List<Card>> list = rp.Parse(new List<string>
                {"88+", "A2s+", "K9s+", "Q9s+", "J9s+", "T9s+", "98s", "87s", "A10o+", "K9o+", "Q9o+", "J9o+", "T9o"});

            foreach(var element in list) {
                Console.WriteLine(element[0].ToString() + ", " + element[1].ToString());
            }

            Console.Read();
        }
    }
}
