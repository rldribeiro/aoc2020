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
            long beg = 0;
            long sum = 0;
            
            // Go backwards from the anomaly index: most likely better than sum up from begin index.
            for (int i = anomalyIdx - 1; i > 0; i--)
            {
                long min = long.MaxValue;
                long max = 0;

                long.TryParse(input[i], out beg);
                sum = beg;                

                for (int j = i - 1; j > 1; j--)
                {
                    // Sum down all values
                    long incr;
                    long.TryParse(input[j], out incr);
                    sum += incr;

                    // Keep track of min and max of evaluated range
                    long big = beg > incr ? beg : incr;
                    long small = beg < incr ? beg : incr;
                    max = big > max ? big : max;
                    min = small < min ? small : min;
                    
                    // Found a sum
                    if (sum == currValue)
                        return min + max;
                }
            }
            return -1;
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
