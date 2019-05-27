using System.Text;

namespace Poker_Game.AI.Opponent {
    internal class HandData {
        public HandData() {
            Folds = new int[4];
            Checks = new int[4];
            Calls = new int[4];
            Raises = new int[4];
            ReRaises = new int[4];
            Hands = 0;
        }

        // Index represents round number 
        public int[] Folds { get; set; }
        public int[] Checks { get; set; }
        public int[] Calls { get; set; }
        public int[] Raises { get; set; }
        public int[] ReRaises { get; set; }
        public int Hands { get; set; }

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
            for(int i = 0; i < array.Length; i++)
                if(i == array.Length - 1)
                    sb.Append(array[i]);
                else
                    sb.Append(array[i] + ",");

            return sb.ToString();
        }
    }
}