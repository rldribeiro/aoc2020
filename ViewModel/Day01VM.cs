using Solvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel
{
    public class Day01VM : INotifyPropertyChanged
    {
        private Day01Solver solver;

        private string rawInput;

        private int resultA;        
        private double elapsedTimeA;
        private double elapsedTicksA;
        private int numberA01;
        private int numberA02;        
        private int resultB;
        private double elapsedTimeB;
        private double elapsedTicksB;
        private int numberB02;
        private int numberB01;
        private int numberB03;
        private int widthA01;
        private int widthA02;
        private int widthB01;
        private int widthB02;
        private int widthB03;
        private List<(int, int)> attemptsA;
        private List<(int, int, int)> attemptsB;

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
        public double ElapsedTimeA {
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
        public int NumberA01 {
            get { return numberA01; }
            set
            {
                if (value != numberA01)
                {
                    numberA01 = value;
                    OnPropertyChanged("NumberA01");
                }
            }
        }
        public int NumberA02
        {
            get { return numberA02; }
            set
            {
                if (value != numberA02)
                {
                    numberA02 = value;
                    OnPropertyChanged("NumberA02");
                }
            }
        }
        public int WidthA01
        {
            get { return widthA01; }
            set
            {
                if (value != widthA01)
                {
                    widthA01 = value;
                    OnPropertyChanged("WidthA01");
                }
            }
        }
        public int WidthA02
        {
            get { return widthA02; }
            set
            {
                if (value != widthA02)
                {
                    widthA02 = value;
                    OnPropertyChanged("WidthA02");
                }
            }
        }
        public List<(int, int)> AttemptsA
        {
            get { return attemptsA; }
            set
            {
                if (value != attemptsA)
                {
                    attemptsA = value;
                    OnPropertyChanged("AttemptsA");
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
        public int NumberB01
        {
            get { return numberB01; }
            set
            {
                if (value != numberB01)
                {
                    numberB01 = value;
                    OnPropertyChanged("NumberB01");
                }
            }
        }
        public int NumberB02
        {
            get { return numberB02; }
            set
            {
                if (value != numberB02)
                {
                    numberB02 = value;
                    OnPropertyChanged("NumberB02");
                }
            }
        }
        public int NumberB03
        {
            get { return numberB03; }
            set
            {
                if (value != numberB03)
                {
                    numberB03 = value;
                    OnPropertyChanged("NumberB03");
                }
            }
        }
        public int WidthB01
        {
            get { return widthB01; }
            set
            {
                if (value != widthB01)
                {
                    widthB01 = value;
                    OnPropertyChanged("WidthB01");
                }
            }
        }
        public int WidthB02
        {
            get { return widthB02; }
            set
            {
                if (value != widthB02)
                {
                    widthB02 = value;
                    OnPropertyChanged("WidthB02");
                }
            }
        }
        public int WidthB03
        {
            get { return widthB03; }
            set
            {
                if (value != widthB03)
                {
                    widthB03 = value;
                    OnPropertyChanged("WidthB03");
                }
            }
        }
        public List<(int, int, int)> AttemptsB
        {
            get { return attemptsB; }
            set
            {
                if (value != attemptsB)
                {
                    attemptsB = value;
                    OnPropertyChanged("AttemptsB");
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

        public Day01VM()
        {
            solver = new Day01Solver();

            RawInput = "";            
            Solve01Command = new Solve01Command(this);
        }

        #endregion

        #region Commands

        public Solve01Command Solve01Command { get; set; }

        #endregion

        #region Private/Internal Methods

        internal void Solve(int[] input)
        {
            // Solve
            solver.SolveA(input);
            solver.SolveB(input);            

            // Show results
            ResultA = solver.SolutionA;
            ElapsedTimeA = solver.ElapsedTimeA.ElapsedMilliseconds;
            ElapsedTicksA = solver.ElapsedTimeA.ElapsedTicks;
            NumberA01 = solver.SolutionNumbersA[0];
            NumberA02 = solver.SolutionNumbersA[1];
            AttemptsA = solver.AttemptsA;

            ResultB = solver.SolutionB;
            ElapsedTimeB = solver.ElapsedTimeB.ElapsedMilliseconds;
            ElapsedTicksB = solver.ElapsedTimeB.ElapsedTicks;
            NumberB01 = solver.SolutionNumbersB[0];
            NumberB02 = solver.SolutionNumbersB[1];
            NumberB03 = solver.SolutionNumbersB[2];
            AttemptsB = solver.AttemptsB;

            // Set bars (I WANT TO ANIMATE THIS SOMWHOW!!!)
            WidthA01 = NumberA01 / 5;
            WidthA02 = NumberA02 / 5;

            WidthB01 = NumberB01 / 5;
            WidthB02 = NumberB02 / 5;
            WidthB03 = NumberB03 / 5;
        }
        
        #endregion
    }
}
