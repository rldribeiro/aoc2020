using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo06 : Wizard
    {
        public Goncalo06(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            int result = 0;

            HashSet<char> questions = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {

                for (int j = 0; j < input[i].Length-1; j++)
                {
                    questions.Add(input[i][j]);
                }

                if ((i + 1 == input.Length) || (input[i + 1].Length == 1)) // new group
                {
                    result += questions.Count;
                    questions.Clear();
                }
            }

            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            int result = 0;
            List<char> commonQuestions = new List<char>();
            HashSet<char> personQuestions = new HashSet<char>();
            bool skipToNextGroup = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (skipToNextGroup == false)
                {
                    personQuestions.Clear();

                    for (int j = 0; j < input[i].Length-1; j++) //read line
                    {
                        personQuestions.Add(input[i][j]);
                    }

                    if (commonQuestions.Count == 0 && !skipToNextGroup) //first line of the group
                    {
                        foreach (var item in personQuestions)
                        {
                            commonQuestions.Add(item);
                        }

                    }
                    else //verify the common characters
                    {
                        int iterator = 0;

                        while (iterator < commonQuestions.Count && commonQuestions.Count > 0)
                        {
                            if (!personQuestions.Contains(commonQuestions[iterator]))
                                commonQuestions.Remove(commonQuestions[iterator]);
                            else
                                iterator++;
                        }
                    }

                    if (commonQuestions.Count == 0)
                        skipToNextGroup = true;
                }
                if ((i + 1 == input.Length) || (input[i + 1].Length == 1)) // new group
                {
                    result += commonQuestions.Count;
                    i++;
                    skipToNextGroup = false;
                    commonQuestions.Clear();
                }
            }
            return result;
        }
    }
}
