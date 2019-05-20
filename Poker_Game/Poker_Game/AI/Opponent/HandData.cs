using System.Linq;
using System.Text;

namespace Poker_Game.AI.Opponent {
    class HandData {
        // Index represents round number 
        public int[] Folds { get; set; }
        public int[] Checks { get; set; }
        public int[] Calls { get; set; }
        public int[] Raises { get; set; }
        public int[] ReRaises { get; set; }
        public int Hands { get; set; }

        public HandData() {
            Folds = new int[5];
            Checks = new int[5];
            Calls = new int[5];
            Raises = new int[5];
            ReRaises = new int[5];
        }

        public HandData(int hands, int[] folds, int[] checks, int[] calls, int[] raises, int[] reRaises) {
            Hands = hands;
            Folds = folds;
            Checks = checks;
            Calls = calls;
            Raises = raises;
            ReRaises = reRaises;
        }


        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Hands.ToString());
            sb.AppendLine(WriteArray(Folds));
            sb.AppendLine(WriteArray(Checks));
            sb.AppendLine(WriteArray(Calls));
            sb.AppendLine(WriteArray(Raises));
            sb.AppendLine(WriteArray(ReRaises));

            return sb.ToString();
        }

        private string WriteArray(int[] array) {
            StringBuilder sb = new StringBuilder();
            foreach(int element in array) {
                if(element == array.Last()) {
                    sb.Append(element); 
                } else {
                    sb.Append(element + ",");
                }
            }

            return sb.ToString();
        }
    }
}
