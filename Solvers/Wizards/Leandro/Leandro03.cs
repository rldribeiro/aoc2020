using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro03 : IWizard
    {
        public int SolvePartOne(string[] input)
        {
            return HitTrees(input);
        }

        public int SolvePartTwo(string[] input)
        {
            var solution = 1;

            List<(int, int)> slopes = new List<(int, int)>
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };

            foreach (var slope in slopes)
                solution *= HitTrees(input, slope.Item1, slope.Item2);

            return solution;
        }

        #region Private parts

        public int HitTrees(string[] input, int slopeX = 3, int slopeY = 1)
        {
            int numTreees = 0;
            int currIdx = 0;

            for (int i = 0; i < input.Count(); i += slopeY)
            {
                string currStr = input[i].Trim();

                if (currStr.ElementAt(currIdx) == '#')
                    numTreees++;

                if (currIdx + slopeX > currStr.Length - 1)
                    currIdx = slopeX - (currStr.Length - currIdx);
                else
                    currIdx += slopeX;
            }
            return numTreees;
        }

        #endregion
    }
}
