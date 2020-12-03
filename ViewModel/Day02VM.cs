using Solvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel
{
    public class Day02VM : INotifyPropertyChanged
    {
        private Day02Solver solver;

        private string rawInput;

        private int resultA;
        private double elapsedTimeA;
        private double elapsedTicksA;

        private int resultB;
        private double elapsedTimeB;
        private double elapsedTicksB;


        #region Binding Properties

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

        #endregion

        #region INotifyPropertyChanged implementation 

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Constructor

        public Day02VM()
        {
            solver = new Day02Solver();

            RawInput = "";
            Solve02Command = new Solve02Command(this);
        }

        #endregion

        #region Commands

        public Solve02Command Solve02Command { get; set; }

        #endregion

        #region Private/Internal Methods

        internal void Solve(string[] input)
        {
            string[] rawInput = RawInput.Split('\n');
            
            solver.SolveA(rawInput);
            ResultA = solver.SolutionA;
            ElapsedTimeA = solver.ElapsedTimeA.ElapsedMilliseconds;
            ElapsedTicksA = solver.ElapsedTimeA.ElapsedTicks;

            solver.SolveB(rawInput);
            ResultB = solver.SolutionB;
            ElapsedTimeB = solver.ElapsedTimeB.ElapsedMilliseconds;
            ElapsedTicksB = solver.ElapsedTimeB.ElapsedTicks;

            return;
        }

        #endregion
    }
}
