using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Goncalo01 : Wizard
    {
        public Goncalo01(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            int[] inputDates = input.Select(t => Convert.ToInt32(t)).ToArray();

            HashSet<int> checkedValues = new HashSet<int>();
            int result = 0;
            int pair = 0;
            int item = 0;

            for (int i = 0; i < inputDates.Length; i++)
            {
                item = inputDates[i];
                pair = 2020 - item;
                if (checkedValues.Contains(pair))
                {
                    result = item * pair;
                    break;
                }
                checkedValues.Add(item);
            }

            return result;

        }

        public override long SolvePartTwo(string[] input)
        {
            int[] inputDates = input.Select(t => Convert.ToInt32(t)).ToArray();

            HashSet<int> checkedValues = new HashSet<int>();
            int result = 0;
            int pair = 0;
            int elem1 = 0;
            int elem2 = 0;
            bool found = false;

            for (int i = 0; i < inputDates.Length - 2; i++)
            {
                elem1 = inputDates[i];
                for (int j = 1; j < inputDates.Length; j++)
                {
                    elem2 = inputDates[j];
                    pair = 2020 - elem1 - elem2;

                    if (checkedValues.Contains(pair))
                    {
                        result = pair * elem1 * elem2;
                        found = true;
                        break;
                    }
                    checkedValues.Add(elem2);
                }

                if (found)
                    break;
            }

            return result;
        }
    }
}
