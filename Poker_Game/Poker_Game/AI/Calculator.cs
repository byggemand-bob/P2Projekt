using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    class Calculator
    {
        public int Faculty(int number)
        {

            int fact, i;

            fact = number;

            for (i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }

            return fact;
        }

        public int Binomial(int n, int r)
        {
            return Faculty(n) / Faculty(r) * Faculty(n - r);
        }
    }
}
