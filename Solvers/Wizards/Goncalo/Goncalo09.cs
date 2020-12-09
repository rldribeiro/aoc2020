using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo09 : Wizard
    {
        private const int preamble = 25;
        private string[] input;
        private int invalidNumber = 0;

        public Goncalo09(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            this.input = input;
            int result = 0;
            Queue<(int number, HashSet<int> sums)> visitedNumbers = new Queue<(int number, HashSet<int> sums)>();

            GetPreambleNumbers(ref visitedNumbers);

            GetInvalidNumber(ref result, ref visitedNumbers);

            invalidNumber = result;
            return result;
        }

        private void GetInvalidNumber(ref int result, ref Queue<(int number, HashSet<int> sums)> visitedNumbers)
        {
            for (int i = preamble; i < input.Length; i++)
            {
                int inputValue = Int32.Parse(input[i]);

                if (!ValidateAndAddNewEntry(ref visitedNumbers, inputValue))
                {
                    result = inputValue;
                    break;
                }
            }
        }

        private void GetPreambleNumbers(ref Queue<(int number, HashSet<int> sums)> visitedNumbers)
        {
            for (int i = 0; i < preamble && i < input.Length; i++)
            {
                HashSet<int> sums = new HashSet<int>();
                int intInput = Int32.Parse(input[i]);

                for (int j = i + 1; j < preamble && j < input.Length; j++)
                {
                    sums.Add(intInput + Int16.Parse(input[j]));
                }
                visitedNumbers.Enqueue((intInput, sums));
            }
        }

        private bool ValidateAndAddNewEntry(ref Queue<(int number, HashSet<int> sums)> visitedNumbers, int inputValue)
        {
            bool entryIsValid = false;

            for (int i = 0; i < visitedNumbers.Count; i++)
            {
                entryIsValid |= visitedNumbers.ElementAt(i).sums.Contains(inputValue);
                visitedNumbers.ElementAt(i).sums.Add(inputValue + visitedNumbers.ElementAt(i).number);
            }

            visitedNumbers.Enqueue((inputValue, new HashSet<int>()));
            visitedNumbers.Dequeue();
            return entryIsValid;

        }

        public override long SolvePartTwo(string[] input)
        {
            long result = 0;

            long sum = 0;
            Queue<long> valuesResult = new Queue<long>();

            for (int i = 0; i < input.Length; i++)
            {
                long auxInput = Int64.Parse(input[i]);
                sum += auxInput;
                valuesResult.Enqueue(auxInput);

                while (sum > invalidNumber)
                {
                    sum -= valuesResult.Dequeue();
                }

                if (sum == invalidNumber) // result found
                {
                    result = valuesResult.Min() + valuesResult.Max();
                    break;
                }
            }

            return result;
        }
    }
}
