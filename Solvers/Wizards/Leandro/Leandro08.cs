using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{

    public class Leandro08 : Wizard
    {
        private long accumulator;
        private const string acc = "acc";
        private const string nop = "nop";
        private const string jmp = "jmp";

        public Leandro08(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            ComputeAccumulator(input);
            return accumulator;
        }

        public override long SolvePartTwo(string[] input)
        {
            int i = 0;
            while (!ComputeAccumulator(input, i)) i++;
            return accumulator;
        }

        #endregion

        #region Auxiliary Methods

        private bool ComputeAccumulator(string[] input, int switchPosition = -1)
        {
            accumulator = 0;
            int currIdx = 0;
            int nopJmpIdx = 0;
            HashSet<int> visitedIdx = new HashSet<int>();

            while (true)
            {
                visitedIdx.Add(currIdx);

                // Parse instruction
                string instruction = input[currIdx].Split(' ')[0];
                int value = 0;
                int.TryParse(input[currIdx].Split(' ')[1], out value);

                // Check if switching is needed                
                if (switchPosition == nopJmpIdx && (instruction == nop || instruction == jmp))
                    instruction = instruction == nop ? jmp : nop;

                // Perform instruction
                switch (instruction)
                {
                    case acc:
                        accumulator += value;
                        currIdx++;
                        break;
                    case nop:
                        nopJmpIdx++;
                        currIdx++;
                        break;
                    case jmp:
                        nopJmpIdx++;
                        currIdx += value;
                        break;
                }

                // Infinite loop detected
                if (visitedIdx.Contains(currIdx))
                    return false;

                // End of instructions detected
                if (currIdx == input.Length)
                    return true;
            }
        }

        #endregion
    }
}
