using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    class CalcBinomial
    {
        private double CalcFaculty(double number)
        {

            double fact, i;

            fact = number;

            for (i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }

            return fact;

        }

        private double CalcBinomial(List<Hand> hands)
        {
            double r, n;

            r = CalcFaculty(hands.Count);
            n = (52 - hands.Count);


            return n / r * (n - r);
        }
    }
}
