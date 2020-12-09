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
        private string selectedWizard = Hogwarts.CurrentWizards[0];
        private int selectedDay = DateTime.Now.Day;

        private string rawInput;

        private long resultA;
        private double elapsedTimeA;
        private double elapsedTicksA;

        private long resultB;
        private double elapsedTimeB;
        private double elapsedTicksB;

        private string insult;

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
        public string Insult
        {
            get { return insult; }

            set
            {
                if (value != insult)
                {
                    insult = value;
                    OnPropertyChanged("Insult");
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

        private bool errorOne = false;

        public bool ErrorOne
        {
            get { return errorOne; }
            set
            {
                if (value != errorOne)
                {
                    errorOne = value;
                    OnPropertyChanged("ErrorOne");
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

        private bool errorTwo = false;

        public bool ErrorTwo
        {
            get { return errorTwo; }
            set
            {
                if (value != errorTwo)
                {
                    errorTwo = value;
                    OnPropertyChanged("ErrorTwo");
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

        internal async void SolveA(string[] rawInput, DaySolver solver)
        {            
            // A
            try
            {
                ErrorOne = false;
                solver.SolveA(rawInput);

                // Cute animation
                long solSize = solver.SolutionA;
                int inc = solSize < 30 ? 1 : (int)Math.Floor(solSize / 30.0);                
                for (long i = 0; i < solver.SolutionA; i += inc)
                {
                    ResultA = i;
                    WidthA = (int)Math.Ceiling(Decimal.Divide(i, solver.SolutionA) * 256);
                    await Task.Delay(1);
                }
                
                // Final results
                WidthA = 256;
                ResultA = solver.SolutionA;
                ElapsedTimeA = solver.ElapsedTimeA.ElapsedMilliseconds;
                ElapsedTicksA = solver.ElapsedTimeA.ElapsedTicks;                
            }
            catch
            {
                ErrorOne = true;
                //MessageBox.Show($"For some reason, it was not possible to solve Part One:\neither the wizard {selectedWizard} didn't write it, or the magic was bullshit.");
            }           
        }

        internal async void SolveB(string[] rawInput, DaySolver solver)
        {
            // B
            try
            {
                ErrorTwo = false;
                solver.SolveB(rawInput);

                // Cute animation
                long solSize = solver.SolutionB;
                int inc = solSize < 30 ? 1 : (int)Math.Floor(solSize / 30.0);
                for (long i = 0; i < solver.SolutionB; i += inc)
                {
                    ResultB = i;
                    WidthB = (int)Math.Ceiling(Decimal.Divide(i, solver.SolutionB) * 256);
                    await Task.Delay(1);
                }

                // Final results
                WidthB = 256;
                ResultB = solver.SolutionB;
                ElapsedTimeB = solver.ElapsedTimeB.ElapsedMilliseconds;
                ElapsedTicksB = solver.ElapsedTimeB.ElapsedTicks;
            }
            catch
            {
                ErrorTwo = true;
                //MessageBox.Show($"For some reason, it was not possible to solve Part Two:\neither the wizard {selectedWizard} didn't write it, or the magic was bullshit.");
            }
        }

        #endregion
    }
}
