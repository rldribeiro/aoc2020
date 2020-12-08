using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public class Fabio05 : Wizard
    {
        
        public Fabio05(string name) : base(name)
        {
        }
        
        public override long SolvePartOne(string[] input)
        {
            return input.Max(GetSeatID);
        }

        public override long SolvePartTwo(string[] input)
        {
            var ids = input.Select(GetSeatID).ToArray();
            Array.Sort(ids);
            long result = 0;
            for (var i = 1; i < ids.Length; i++)
            {
                if (ids[i] - ids[i - 1] == 2)
                {
                    result = ids[i] - 1;
                    break;
                }
            }

            return result;
        }

        private long GetSeatID(string input)
        {
            return GetRow(input) * 8 + GetColumn(input);
        }

        private static int GetRow(string input)
        {
            return GetNumberFromBinary(input.Substring(0, 7), 128, 'F', 'B');
        }
        
        private static int GetColumn(string input)
        {
            return GetNumberFromBinary(input.Substring(7, 3), 8, 'L', 'R');
        }

        private static int GetNumberFromBinary(string input, int length, char lowerId, char upperId)
        {
            var rowMax = length-1;
            var rowMin = 0;
            var currentLength = length;
            for (var i = 0; i < input.Length; i++)
            {
                currentLength /= 2;
                if(input[i] == lowerId)
                {
                    rowMax -= currentLength;
                }

                if (input[i] == upperId)
                {
                    rowMin += currentLength;
                }
            }

            if (rowMax == rowMin)
                return rowMax;
            else
            {
                throw new ArithmeticException("Fucked Up");
            }
        }

    }
}