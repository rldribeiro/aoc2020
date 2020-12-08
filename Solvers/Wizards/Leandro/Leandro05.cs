using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro05 : Wizard
    {
        private int[] seatIds;

        public Leandro05(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            long solution = 0;
            seatIds = new int[input.Count()];

            for (int i = 0; i < input.Count(); i++)
            {
                int row = Calculate(input[i].ToCharArray(), 127, 0, 7, 'F', 'B', true);
                int column = Calculate(input[i].ToCharArray(), 7, 7, 10, 'L', 'R', false);

                int seatId = row * 8 + column;

                seatIds[i] = seatId;

                if (seatId > solution)
                    solution = seatId;
            }

            return solution;
        }

        public override long SolvePartTwo(string[] input)
        {            
            Array.Sort(seatIds);
            
            long expectedId = seatIds[0];

            for (int i = 0; i < seatIds.Count(); i++)
            {
                if (expectedId < seatIds[i])
                    return expectedId;

                expectedId++;
            }
            return -1;
        }

        #endregion

        #region Auxiliary Methods

        private int Calculate(char[] input, int max, int init, int finit, char lower, char upper, bool keepThingsLow)
        {
            int min = 0;

            for (int i = init; i < finit; i++)
            {
                if (input[i] == lower)
                    max -= (max - min + 1) / 2;
                if (input[i] == upper)
                    min += (max - min + 1) / 2;
            }

            return keepThingsLow ? Math.Min(min, max) : Math.Max(min, max);
        }

        #endregion
    }
}
