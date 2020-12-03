using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    /// <summary>    
    /// --- Day 2 ---    
    /// </summary>
    public class Day03Solver
    {
        #region Constructor

        public Day03Solver()
        {
        }

        #endregion

        #region Properties

        #region Part A        
        public int SolutionA { get; set; }
        public Stopwatch ElapsedTimeA { get; set; }

        #endregion

        #region Part B

        public int SolutionB { get; set; }
        public Stopwatch ElapsedTimeB { get; set; }

        #endregion
        #endregion

        #region Public Method

        public int SolveA(string[] input, int slope1 = 3, int slope2 = 1)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int numTreees = 0;

            int currIdx = 0;
            for (int i = 0; i < input.Count(); i += slope2)
            {
                string currStr = input[i].Trim();

                if (currStr.ElementAt(currIdx) == '#')
                    numTreees++;

                if (currIdx + slope1 > currStr.Length - 1)
                {
                    currIdx = slope1 - (currStr.Length - currIdx);
                }
                else
                {
                    currIdx += slope1;
                }
            }

            timer.Stop();
            ElapsedTimeA = timer;
            SolutionA = numTreees;
            return numTreees;
        }

        public void SolveB(string[] input)
        {
            //Right 1, down 1.
            //Right 3, down 1. (This is the slope you already checked.)
            //Right 5, down 1.
            //Right 7, down 1.
            //Right 1, down 2.
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SolutionB = 1;

            List<(int, int)> slopes = new List<(int, int)>
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };            
            
            foreach(var slope in slopes)
            {
                SolutionB *= SolveA(input, slope.Item1, slope.Item2);
            }

            timer.Stop();
            ElapsedTimeB = timer;
        }

        #endregion
    }
}
