using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    /// <summary>
    ///
    /// --- Day 1: Report Repair ---    
    /// Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.
    /// 
    /// Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
    /// 
    /// For example, suppose your expense report contained the following:
    /// 
    /// 1721
    /// 979
    /// 366
    /// 299
    /// 675
    /// 1456
    /// 
    /// In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.
    /// 
    /// Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together?
    /// </summary>
    public class Day01Solver
    {
        #region Constructor

        public Day01Solver()
        {
            SolutionNumbersA = new List<int>() { 0, 0 };
            SolutionNumbersB = new List<int>() { 0, 0, 0 };

            AttemptsA = new List<(int, int)>();
            AttemptsB = new List<(int, int, int)>();
        }

        #endregion

        #region Properties

        
        public int SolutionA { get; set; }
        public List<int> SolutionNumbersA { get; set; }
        public Stopwatch ElapsedTimeA { get; set; }
        public List<(int, int)> AttemptsA { get; set; }
        public int SolutionB { get; set; }
        public List<int> SolutionNumbersB { get; set; }        
        public Stopwatch ElapsedTimeB { get; set; }
        public List<(int, int, int)> AttemptsB { get; set; }

        #endregion

        #region Public Method

        public void SolveA(int[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Array.Sort(input);
            Array.Reverse(input);
            bool found = false;                 

            for (int i = 0; i < input.Count(); i++)
            {
                for (int j = input.Count() - 1; j >= 0; j--)
                {
                    AttemptsA.Add((input[i], input[j]));
                    if (input[i] + input[j] == 2020)
                    {
                        SolutionNumbersA[0] = input[i];
                        SolutionNumbersA[1] = input[j];      
                        
                        SolutionA = input[i] * input[j];

                        found = true;
                        break;
                    }
                    if (input[i] + input[j] > 2020)
                        break;
                }
                if (found)
                    break;
            }

            timer.Stop();
            ElapsedTimeA = timer;
        }

        public void SolveB(int[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Array.Sort(input);
            Array.Reverse(input);
            bool found = false;            

            for (int i = 0; i < input.Count(); i++)
            {
                for (int j = input.Count() - 1; j > i; j--)
                {
                    if (input[i] + input[j] > 2020)
                        break;

                    for (int k = j - 1; k > i; k--)
                    {
                        AttemptsB.Add((input[i], input[j], input[k]));
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            SolutionNumbersB[0] = input[i];
                            SolutionNumbersB[1] = input[j];
                            SolutionNumbersB[2] = input[k];

                            SolutionB = input[i] * input[j] * input[k];

                            found = true;
                            break;
                        }

                        if (input[i] + input[j] + input[k] > 2020)
                            break;
                    }
                }

                if (found)
                    break;
            }
            timer.Stop();
            ElapsedTimeB = timer;
        }

        #endregion
    }
}
