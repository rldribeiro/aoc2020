using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{
    /// <summary>    
    /// --- Day 4 ---    
    /// </summary>
    public class DaySolver
    {
        #region Constructor

        public DaySolver(string wizardName, int day)
        {
            // fazer escolha com wizardId e day
            CurrentWizard = ChoseWizard(wizardName, day);
        }

        private IWizard ChoseWizard(string wizardName, int day)
        {
            IWizard wizard = null;
            switch (day)
            {
                case 1:
                    if (wizardName.Equals(WizardNames.FABIO)) return new Fabio01();
                    if (wizardName.Equals(WizardNames.GONCALO)) return new Goncalo01();
                    if (wizardName.Equals(WizardNames.LEANDRO)) return new Leandro01();
                    break;
                case 2:
                    if (wizardName.Equals(WizardNames.FABIO)) return new Fabio02();
                    if (wizardName.Equals(WizardNames.GONCALO)) return new Goncalo02();
                    if (wizardName.Equals(WizardNames.LEANDRO)) return new Leandro02();
                    break;
                case 3:
                    if (wizardName.Equals(WizardNames.FABIO)) return new Fabio03();
                    if (wizardName.Equals(WizardNames.GONCALO)) return new Goncalo03();
                    if (wizardName.Equals(WizardNames.LEANDRO)) return new Leandro03();
                    break;
                case 4:
                    if (wizardName.Equals(WizardNames.FABIO)) return new Fabio04();
                    if (wizardName.Equals(WizardNames.GONCALO)) return new Goncalo04();
                    if (wizardName.Equals(WizardNames.LEANDRO)) return new Leandro04();
                    break;
            }

            return wizard;
        }

        #endregion

        #region Properties

        public IWizard CurrentWizard { get; set; }

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
