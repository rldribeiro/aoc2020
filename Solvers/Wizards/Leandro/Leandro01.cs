using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Leandro01 : Wizard
    {
        public Leandro01(string name) : base(name)
        {
        }

        public override int SolvePartOne(string[] input)
        {           
            int[] numInput = new int[input.Count()];
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                int currI = 0;
                if (int.TryParse(input[i], out currI))
                    numInput[i] = currI;
                else
                    numInput[i] = 0;
            }

            Array.Sort(numInput);
            Array.Reverse(numInput);
            bool found = false;

            for (int i = 0; i < numInput.Count(); i++)
            {
                for (int j = numInput.Count() - 1; j >= 0; j--)
                {                    
                    if (numInput[i] + numInput[j] == 2020)
                    {
                        solution = numInput[i] * numInput[j];

                        found = true;
                        break;
                    }
                    if (numInput[i] + numInput[j] > 2020)
                        break;
                }
                if (found)
                    break;
            }
            return solution;
        }

        public override int SolvePartTwo(string[] input)
        {
            int[] numInput = new int[input.Count()];
            int solution = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                int currI = 0;
                if (int.TryParse(input[i], out currI))
                    numInput[i] = currI;
                else
                    numInput[i] = 0;
            }

            Array.Sort(numInput);
            Array.Reverse(numInput);
            bool found = false;

            for (int i = 0; i < numInput.Count(); i++)
            {
                for (int j = numInput.Count() - 1; j > i; j--)
                {
                    if (numInput[i] + numInput[j] > 2020)
                        break;

                    for (int k = j - 1; k > i; k--)
                    {
                        
                        if (numInput[i] + numInput[j] + numInput[k] == 2020)
                        {

                            solution = numInput[i] * numInput[j] * numInput[k];

                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                    break;
            }
            return solution;
        }

    }
}
