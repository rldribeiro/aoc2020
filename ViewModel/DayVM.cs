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
        private int selectedDay = DateTime.Now.Day;

        private string rawInput;

        private long resultA;
        private double elapsedTimeA;
        private double elapsedTicksA;

        private long resultB;
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
                return Enumerable.Range(1, DateTime.Now.Day <= 25 ? DateTime.Now.Day : 25).ToList();
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
        public long ResultA
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

        private int widthA;

        public int WidthA
        {
            get { return widthA; }
            set
            {
                if (value != widthA)
                {
                    widthA = value;
                    OnPropertyChanged("WidthA");
                }
            }
        }

        private int widthB;

        public int WidthB
        {
            get { return widthB; }
            set
            {
                if (value != widthB)
                {
                    widthB = value;
                    OnPropertyChanged("WidthB");
                }
            }
        }

        // B        
        public long ResultB
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

        internal async void Solve(string[] input)
        {
            string[] rawInput = RawInput.Split('\n');

            Wizard wizard = Hogwarts.SummonWizard(selectedWizard, selectedDay);

            solver = new DaySolver(wizard);

            // A
            try
            {
                solver.SolveA(rawInput);
                long solSize = solver.SolutionA;
                for (long i = 0; i < solver.SolutionA; i += solSize / 30)
                {
                    ResultA = i;                    
                    WidthA = (int)Math.Ceiling(Decimal.Divide(i, solver.SolutionA) * 256);
                    await Task.Delay(1);
                }
                ResultA = solver.SolutionA;
                WidthA = 256;
                ElapsedTimeA = solver.ElapsedTimeA.ElapsedMilliseconds;
                ElapsedTicksA = solver.ElapsedTimeA.ElapsedTicks;
            }
            catch
            {
                MessageBox.Show($"For some reason, it was not possible to solve Part One:\neither the wizard {selectedWizard} didn't write it, or the magic was bullshit.");
            }

            // B
            try
            {
                solver.SolveB(rawInput);
                long solSize = solver.SolutionB;

                for (long i = 0; i < solver.SolutionB; i += solSize / 30)
                {
                    ResultB = i;
                    WidthB = (int)Math.Ceiling(Decimal.Divide(i, solver.SolutionB) * 256);
                    await Task.Delay(1);
                }
                ResultB = solver.SolutionB;
                WidthB = 256;
                ElapsedTimeB = solver.ElapsedTimeB.ElapsedMilliseconds;
                ElapsedTicksB = solver.ElapsedTimeB.ElapsedTicks;
            }
            catch
            {
                MessageBox.Show($"For some reason, it was not possible to solve Part Two:\neither the wizard {selectedWizard} didn't write it, or the magic was bullshit.");
            }
        }

        #endregion
    }
}
