﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Solvers
{
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
        public long SolutionA { get; set; }
        public Stopwatch ElapsedTimeA { get; set; }

        #endregion

        #region Part B

        public long SolutionB { get; set; }
        public Stopwatch ElapsedTimeB { get; set; }

        #endregion

        #endregion

        #region Public Method

        public void SolveA(string[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SolutionA = CurrentWizard.SolvePartOne(input);

            timer.Stop();
            ElapsedTimeA = timer;
        }

        public void SolveB(string[] input)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SolutionB = CurrentWizard.SolvePartTwo(input);

            timer.Stop();
            ElapsedTimeB = timer;
        }

        #endregion        
    }
}
