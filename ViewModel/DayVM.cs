using Solvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.Commands;

namespace ViewModel
{
    public class DayVM : INotifyPropertyChanged
    {
        private DaySolver solver;
        private string selectedWizard = Hogwarts.CurrentWizards[0];
        private int selectedDay = 1;

        private string rawInput;

        private int resultA;
        private double elapsedTimeA;
        private double elapsedTicksA;

        private int resultB;
        private double elapsedTimeB;
        private double elapsedTicksB;


        #region Binding Properties

        public string RawInput
        {
            get { return rawInput; }
            set
            {
                if (value != rawInput)
                {
                    rawInput = value;
                    OnPropertyChanged("RawInput");
                }
            }
        }        
        public List<string> Wizards
        {
            get { return Hogwarts.CurrentWizards; }
        }        
        public string SelectedWizard
        {
            get { return selectedWizard; }
            set
            {
                if (value != selectedWizard)
                {
                    selectedWizard = value;
                    OnPropertyChanged("SelectedWizard");
                }
            }
        }
        public List<int> Days
        {
            get
            {
                return Hogwarts.CurrentDays;
            }
        }
        public int SelectedDay
        {
            get { return selectedDay; }

            set
            {
                if (value != selectedDay)
                {
                    selectedDay = value;
                    OnPropertyChanged("SelectedDay");
                }

            }
        }

        // A
        public int ResultA
        {
            get { return resultA; }
            set
            {
                if (value != resultA)
                {
                    resultA = value;
                    OnPropertyChanged("ResultA");
                }
            }
        }
        public double ElapsedTimeA
        {
            get { return elapsedTimeA; }
            set
            {
                if (value != elapsedTimeA)
                {
                    elapsedTimeA = value;
                    OnPropertyChanged("ElapsedTimeA");
                }
            }
        }
        public double ElapsedTicksA
        {
            get { return elapsedTicksA; }
            set
            {
                if (value != elapsedTicksA)
                {
                    elapsedTicksA = value;
                    OnPropertyChanged("ElapsedTicksA");
                }
            }
        }

        // B        
        public int ResultB
        {
            get { return resultB; }
            set
            {
                if (value != resultB)
                {
                    resultB = value;
                    OnPropertyChanged("ResultB");
                }
            }
        }
        public double ElapsedTimeB
        {
            get { return elapsedTimeB; }
            set
            {
                if (value != elapsedTimeB)
                {
                    elapsedTimeB = value;
                    OnPropertyChanged("ElapsedTimeB");
                }
            }
        }
        public double ElapsedTicksB
        {
            get { return elapsedTicksB; }
            set
            {
                if (value != elapsedTicksB)
                {
                    elapsedTicksB = value;
                    OnPropertyChanged("ElapsedTicksB");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged implementation 

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Constructor

        public DayVM()
        {
            RawInput = "";
            SolveCommand = new SolveCommand(this);
        }

        #endregion

        #region Commands

        public SolveCommand SolveCommand { get; set; }

        #endregion

        #region Private/Internal Methods

        internal void Solve(string[] input)
        {
            string[] rawInput = RawInput.Split('\n');
            Wizard wizard = Hogwarts.SummonWizard(selectedWizard, selectedDay);

            solver = new DaySolver(wizard);

                // A
                solver.SolveA(rawInput);            
                ResultA = solver.SolutionA;                                            
                ElapsedTimeA = solver.ElapsedTimeA.ElapsedMilliseconds;
                ElapsedTicksA = solver.ElapsedTimeA.ElapsedTicks;

                // B
                solver.SolveB(rawInput);
                ResultB = solver.SolutionB;
                ElapsedTimeB = solver.ElapsedTimeB.ElapsedMilliseconds;
                ElapsedTicksB = solver.ElapsedTimeB.ElapsedTicks;

            return;
        }

        #endregion
    }
}
