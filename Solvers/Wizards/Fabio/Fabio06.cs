using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public class Fabio06 : Wizard
    {

        public Fabio06(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            var sumAnswers = 0;
            var lineToProcess = string.Empty;
            foreach (var line in input)
                if (string.IsNullOrWhiteSpace(line))
                {
                    sumAnswers += ProcessLinePart1(lineToProcess);
                    lineToProcess = string.Empty;
                }
                else
                {
                    lineToProcess += line;
                }

            if (!string.IsNullOrWhiteSpace(lineToProcess))
                sumAnswers += ProcessLinePart1(lineToProcess);
            
            return sumAnswers;
        }

        private int ProcessLinePart1(string lineToProcess)
        {
            return new HashSet<char>(lineToProcess).Count;
        }

        public override long SolvePartTwo(string[] input)
        {
            var sumAnswers = 0;
            char[] lineToProcess = null;
            foreach (var line in input)
            {
                if (lineToProcess == null )
                {
                    if(!string.IsNullOrWhiteSpace(line))
                        lineToProcess = line.ToCharArray();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    sumAnswers += lineToProcess.Length;
                    lineToProcess = null;
                }
                else
                {
                    lineToProcess = lineToProcess.Intersect(line).ToArray();
                }
            }

            if (lineToProcess != null)
                sumAnswers += lineToProcess.Length;
            
            return sumAnswers;
        }
    }
}