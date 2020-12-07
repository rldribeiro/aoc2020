using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Fabio01 : Wizard
    {
        public Fabio01(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            int[] inputNum = input.Select(t => Convert.ToInt32(t)).ToArray();

            for (var i = 0; i < inputNum.Length; i++)
            {
                var baseValue = inputNum[i];
                for (var j = i + 1; j < inputNum.Length; j++)
                {
                    var otherValue = inputNum[j];
                    if (baseValue + otherValue == 2020)
                        return baseValue * otherValue;
                }
            }
            return -1;
        }

        public override long SolvePartTwo(string[] input)
        {
            int[] inputNum = input.Select(t => Convert.ToInt32(t)).ToArray();

            for (var i = 0; i < inputNum.Length; i++)
            {
                var baseValue = inputNum[i];
                for (var j = i + 1; j < inputNum.Length; j++)
                {
                    var secondValue = inputNum[j];
                    for (var k = j + 1; k < inputNum.Length; k++)
                    {
                        var thirdValue = inputNum[k];
                        if (baseValue + secondValue + thirdValue == 2020)
                            return baseValue * secondValue * thirdValue;
                    }
                }
            }

            return -1;
        }
    }
}
