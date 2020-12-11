using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{

    public class Leandro10 : Wizard
    {
        private int howManyOnesAreThere = 0;
        private int howManyThreesAreThere = 0;
        private int onesInSeq = 0;
        private List<int> uglyBlockOfOnes;
        private bool countingOnes = false;
        private int[] jolts;

        Dictionary<int, long> uglyMotherFucker = new Dictionary<int, long>();

        public Leandro10(string name) : base(name)
        {
            uglyBlockOfOnes = new List<int>();
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            howManyOnesAreThere = 0;
            howManyThreesAreThere = 0;

            int aiai = 0;
            int uiui = 0;

            jolts = Array.ConvertAll(input, int.Parse);
            Array.Sort(jolts);

            for (int i = 0; i < jolts.Count(); i++)
            {
                if (0 == i)
                {
                    aiai = 0;
                    uiui = jolts[i];
                    LetsCalculateTheDifferenceBetweenAiAndUi(aiai, uiui);
                }

                aiai = jolts[i];
                uiui = i < jolts.Count() - 1 ? jolts[i + 1] : aiai + 3;
                LetsCalculateTheDifferenceBetweenAiAndUi(aiai, uiui);
            }

            return howManyOnesAreThere * howManyThreesAreThere;
        }

        public override long SolvePartTwo(string[] input)
        {
            long sol = 1;

            for (int i = 0; i < uglyBlockOfOnes.Count; i++)
            {
                long multi = (long)Math.Pow(2, uglyBlockOfOnes[i]);
                if (uglyBlockOfOnes[i] == 3)
                    multi--;

                sol *= multi;
            }            
            return sol;
        }

        #endregion

        #region Auxiliary Methods        

        private void LetsCalculateTheDifferenceBetweenAiAndUi(int ai, int ui)
        {
            if (ui - ai == 1)
            {
                if (countingOnes)
                    onesInSeq++;

                countingOnes = true;
                howManyOnesAreThere++;                
            }

            if (ui - ai == 3)
            {                                
                if (onesInSeq > 0)
                    uglyBlockOfOnes.Add(onesInSeq);
                onesInSeq = 0;

                countingOnes = false;
                howManyThreesAreThere++;
            }
        }

        #endregion
    }
}
