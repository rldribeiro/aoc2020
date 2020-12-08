using Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class SolveCommand : ICommand
    {

        public SolveCommand(DayVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DayVM VM { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InsultTime();
            string[] rawInput = VM.RawInput.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Wizard wizard = Hogwarts.SummonWizard(VM.SelectedWizard, VM.SelectedDay);
            DaySolver solver = new DaySolver(wizard);

            VM.SolveA(rawInput, solver);
            VM.SolveB(rawInput, solver);
        }

        private void InsultTime()
        {
            Random rand = new Random();
            Random randAgain = new Random();
            var r = rand.Next(0, 7);
            var r2 = rand.Next(0, (Hogwarts.Insults.Count - 1));
            if (r == 3)
                VM.Insult = "O " + VM.SelectedWizard + " " + Hogwarts.Insults[r2];
            else
                VM.Insult = string.Empty;
        }
    }
}
