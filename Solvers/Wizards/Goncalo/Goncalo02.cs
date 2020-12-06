using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Goncalo02 : Wizard
    {
        public Goncalo02(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            int result = 0;
            int occurrences = 0;
            char character;

            foreach (var entry in input)
            {
                string[] words = entry.Split(' ');

                int[] nums = words[0].Split('-').Select(i => Convert.ToInt32(i)).ToArray();

                character = words[1].FirstOrDefault();
                occurrences = words[2].Split(character).Length - 1;

                if (occurrences >= nums[0] && occurrences <= nums[1])
                    result++;
            }

            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            int result = 0;
            char characterToAnalyze;
            char characterPos1;
            char characterPos2;

            foreach (var entry in input)
            {
                string[] words = entry.Split(' ');

                int[] nums = words[0].Split('-').Select(i => Convert.ToInt32(i)).ToArray();

                characterToAnalyze = words[1].FirstOrDefault();
                characterPos1 = words[2][nums[0] - 1];
                characterPos2 = words[2][nums[1] - 1];

                if (characterPos1 == characterToAnalyze ^ characterPos2 == characterToAnalyze) //XOR
                    result++;
            }

            return result;
        }
    }
}
