using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo10 : Wizard
    {
        SortedSet<int> sortedAdaptarsBag = new SortedSet<int>();

        //Stores the number of ways to complete the chain. Key -> id, Value -> number of ways
        Dictionary<int, long> waysToCompleteChainById = new Dictionary<int, long>();

        public Goncalo10(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            int _1joltCount = 0;
            int _3joltCount = 0;

            foreach (var item in input)
            {
                sortedAdaptarsBag.Add(Int16.Parse(item));
            }

            int pos1 = 0;
            for (int i = 0; i < sortedAdaptarsBag.Count; i++)
            {
                int pos2 = sortedAdaptarsBag.ElementAt(i);
                int joltDiff = pos2 - pos1;
                pos1 = pos2;

                switch (joltDiff)
                {
                    case 1:
                        _1joltCount++;
                        break;
                    case 3:
                        _3joltCount++;
                        break;
                    default:
                        break;
                }

            }

            int result = _1joltCount * (_3joltCount + 1);
            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            sortedAdaptarsBag.Add(0);

            return HowManyAvailableChargers(0);

        }

        /// <summary>
        ///  Return the number of ways to complete the chain to a specific sortedAdaptarsBag[idx]
        /// </summary>
        private long HowManyAvailableChargers(int idx)
        {
            int currJolt = sortedAdaptarsBag.ElementAt(idx);
            long result = 0;

            if (idx == sortedAdaptarsBag.Count - 1)
                return 1;

            if (waysToCompleteChainById.ContainsKey(idx))
                return waysToCompleteChainById[idx];

            for (int i = 1; i <= 3 && idx + i < sortedAdaptarsBag.Count; i++)
            {
                if (sortedAdaptarsBag.ElementAt(idx + i) - currJolt <= 3)
                {
                    result += HowManyAvailableChargers(idx + i);
                }
            }

            waysToCompleteChainById.Add(idx, result);

            return result;
        }
    }
}
