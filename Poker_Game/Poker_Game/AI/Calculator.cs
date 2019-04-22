using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    class Calculator
    {
        ulong x;
        public ulong Faculty(ulong number)
        {

            ulong fact, i;

            fact = number;

            for (i = number - 1; i >= 1; i--)
            {
                if (ulong.MaxValue / i > x)
                {
                    fact = fact * i;
                }
                else
                {
                    return 0;
                }
            }
            
            return fact;
        }

        public ulong FacultyXDevidedByFacultyY(ulong startFrom, ulong endAt)
        //multiplies every number from startFrom down to but not including endAt ex. 10 and 7: 10 x 9 x 8 = 720.
        {
            ulong i;
            x = startFrom;

            for (i = startFrom - 1; i > endAt; i--)
            {
                if (ulong.MaxValue / i > x)
                {
                    x *= i;
                }
                else
                {
                    return 0;
                }
            }
            return x;
        }

        public ulong Binomial(ulong n, ulong r)
        {
            return FacultyXDevidedByFacultyY(n, n - r) / Faculty(r);
        }
    }
}
