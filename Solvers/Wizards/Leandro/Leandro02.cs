using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro02 : IWizard
    {
        public int SolvePartOne(string[] input)
        {
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                string[] row = input[i].Split(' ');
                HackedString hacked = HackTheString(row);

                int oc = hacked.pass.Count(x => x == hacked.letter);

                if (oc >= hacked.pos1 && oc <= hacked.pos2)
                    solution++;
            }

            return solution;
        }

        public int SolvePartTwo(string[] input)
        {
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                string[] row = input[i].Split(' ');
                HackedString hacked = HackTheString(row);

                if (hacked.pass[hacked.pos1 - 1] == hacked.letter ^ hacked.pass[hacked.pos2 - 1] == hacked.letter)
                    solution++;
            }

            return solution;
        }

        #region Auxiliary methods

        private HackedString HackTheString(string[] row)
        {
            var hacked = new HackedString();

            string[] limits = row[0].Split('-');
            int.TryParse(limits[0], out hacked.pos1);
            int.TryParse(limits[1], out hacked.pos2);
            hacked.letter = row[1].ToCharArray()[0];
            hacked.pass = row[2];

            return hacked;
        }


        private struct HackedString
        {
            public int pos1;
            public int pos2;
            public char letter;
            public string pass;
        }

        #endregion
    }
}
