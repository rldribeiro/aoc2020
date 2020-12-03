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
    public class Day02Solver
    {
        #region Constructor

        public Day02Solver()
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

        public void SolveA(string[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SolutionA = 0;

            for (int i = 0; i < input.Count(); i++)
            {                
                string[] row = input[i].Split(' ');
                string[] limits = row[0].Split('-');
                int min = 0;
                int max = 0;
                int.TryParse(limits[0], out min);
                int.TryParse(limits[1], out max);
                char letter = row[1].ToCharArray()[0];
                string pass = row[2];
                int oc = pass.Count(x => x == letter);

                if (oc >= min && oc <= max)
                    SolutionA++;
            }

            timer.Stop();
            ElapsedTimeA = timer;
        }        

        public void SolveB(string[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SolutionB = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                string[] row = input[i].Split(' ');
                string[] limits = row[0].Split('-');
                int pos1 = 0;
                int pos2 = 0;
                int.TryParse(limits[0], out pos1);
                int.TryParse(limits[1], out pos2);
                char letter = row[1].ToCharArray()[0];
                string pass = row[2];

                if (pass[pos1 - 1] == letter ^ pass[pos2 - 1] == letter)
                    SolutionB++;
            }

            timer.Stop();
            ElapsedTimeB = timer;
        }

        #endregion
    }
}
