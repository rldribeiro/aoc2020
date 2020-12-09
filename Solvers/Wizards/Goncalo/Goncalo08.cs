using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo08 : Wizard
    {
        private const string jmp = "jmp";
        private const string nop = "nop";
        private const string acc = "acc";

        public Goncalo08(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            string action;
            int number;
            int accumulator = 0;
            HashSet<int> operationsId = new HashSet<int>();

            int i = 0;

            while (i < input.Length)
            {
                if (operationsId.Contains(i))
                    break;

                operationsId.Add(i);

                number = int.Parse(input[i].Substring(4, input[i].Length - 4), NumberStyles.AllowLeadingSign);
                action = input[i].Substring(0, 3);

                if (action == acc)
                    accumulator += number;
                else if (action == jmp)
                {
                    i += number;
                    continue;
                }

                i++;
            }

            return accumulator;
        }

        public override long SolvePartTwo(string[] input)
        {
            string action;
            int number;
            int accumulator = 0;
            bool allPossibleCorruptedOperationsFound = false;
            int iterator = 0;
            List<int> visitedIds = new List<int>();
            Stack<(int id, int accumulated)> possibleCorruptedOpeIds = new Stack<(int, int)>();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            while (iterator < input.Length)
            {

                if (visitedIds.Contains(iterator))
                {
                    allPossibleCorruptedOperationsFound = true; // all possible corrupted positions found

                    // Go back to last possible corrupted operation and repeat everything from that step onwards
                    (iterator, accumulator) = possibleCorruptedOpeIds.Pop();
                    int opePos = visitedIds.IndexOf(iterator);
                    visitedIds.RemoveRange(opePos, visitedIds.Count - opePos); //delete all operations done from last possible corrupted operation

                    action = input[iterator].Substring(0, 3);
                    action = action == nop ? jmp : nop;
                }
                else
                {
                    action = input[iterator].Substring(0, 3);
                }

                number = int.Parse(input[iterator].Substring(4, input[iterator].Length - 4), NumberStyles.AllowLeadingSign);

                visitedIds.Add(iterator);

                if (action == acc)
                {
                    accumulator += number;
                }
                else if (action == jmp)
                {
                    if (!allPossibleCorruptedOperationsFound)
                        possibleCorruptedOpeIds.Push((iterator, accumulator));
                    iterator += number;
                    continue;
                }
                else if (action == nop)
                {
                    if (!allPossibleCorruptedOperationsFound)
                        possibleCorruptedOpeIds.Push((iterator, accumulator));
                }

                iterator++;

            }

            return accumulator;
        }
    }
}
