using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro06 : Wizard
    {
        public Leandro06(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            HashSet<char> currentVotes = new HashSet<char>();
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {    
                currentVotes.UnionWith(input[i].Trim().ToCharArray());

                if (string.IsNullOrEmpty(input[i].Trim()) || i == input.Count() - 1)
                { 
                    solution += currentVotes.Count();
                    currentVotes.Clear();
                }                
            }

            return solution;
        }

        public override long SolvePartTwo(string[] input)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToArray();
            char[] otherChars = alphabet;            
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                if (!string.IsNullOrWhiteSpace(input[i]))
                    otherChars = (char[])otherChars.Intersect(input[i].ToCharArray());

                if (string.IsNullOrWhiteSpace(input[i]) || i == input.Count() - 1)
                {
                    solution += otherChars.Count();
                    otherChars = alphabet;
                }
            }

            return solution;
        }

        #endregion

        #region Auxiliary Methods


        #endregion
    }
}
