using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{

    public class Leandro09 : Wizard
    {        
        private long currValue = 0;
        private int anomalyIdx = 0;

        public Leandro09(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            int beg = 0;
            int end = 25;

            // Begin iterating already after the preamble
            for (int i = end; i < input.Length; i++)
            {
                long.TryParse(input[i], out currValue);

                if (!IsNumPossible(input, beg, end))
                {
                    // Save the index to be used in Part Two
                    anomalyIdx = i;
                    return currValue;
                }                    

                beg++;
                end++;
            }

            return -1;
        }

        public override long SolvePartTwo(string[] input)
        {
            // Queue / Dequeue idea by Grande Gonçalo

            Queue<long> interval = new Queue<long>();                        
            long sum = long.Parse(input[anomalyIdx - 1]);
            interval.Enqueue(sum);

            int idx = anomalyIdx - 2;

            while(sum != currValue)
            {
                long value;
                if (sum < currValue)
                {
                    value = long.Parse(input[idx]);
                    interval.Enqueue(value);
                    sum += value;
                    idx--;
                }
                else
                {
                    sum -= interval.Dequeue();
                }
            }

            return interval.Max() + interval.Min();
        }

        #endregion

        #region Auxiliary Methods

        private bool IsNumPossible(string[] input, int beg, int end)
        {
            // Check all possible sums between beg and end
            for (int i = beg; i < end; i++)
            {
                for (int j = i + 1; j < end; j++)
                {
                    int sum1 = 0;
                    int sum2 = 0;
                    int.TryParse(input[i], out sum1);
                    int.TryParse(input[j], out sum2);

                    // If one is found, jump right out!
                    if (currValue == sum1 + sum2)
                        return true;                    
                }
            }

            // None was found: this is the anomaly
            return false;
        }

        #endregion
    }
}
