using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Solvers
{
    /// <summary>    
    /// --- Day 4 ---    
    /// </summary>
    public class DaySolver
    {
        #region Constructor

        public DaySolver(Wizard wizard)
        {
            CurrentWizard = wizard;
        }

        #endregion

        #region Properties

        public Wizard CurrentWizard { get; set; }

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
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                SolutionA = CurrentWizard.SolvePartOne(input);

                timer.Stop();
                ElapsedTimeA = timer;
            }
            catch
            {
                string wizName = CurrentWizard == null ? string.Empty : CurrentWizard.Name;
                MessageBox.Show($"For some reason, it was not possible to solve Part A:\neither the wizard {wizName} didn't write it, or the magic was bullshit.");
            }
        }

        public void SolveB(string[] input)
        {
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                SolutionB = CurrentWizard.SolvePartTwo(input);
                
                timer.Stop();
                ElapsedTimeB = timer;
            }
            catch
            {
                string wizName = CurrentWizard == null ? string.Empty : CurrentWizard.Name;
                MessageBox.Show($"For some reason, it was not possible to solve Part B:\neither the wizard {wizName} didn't write it, or the magic was bullshit.");
            }            
        }

        #endregion        
    }
}
