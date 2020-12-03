using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public class Solve01Command : ICommand
    {

        public Solve01Command(Day01VM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Day01VM VM { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string[] rawInput = VM.RawInput.Split('\n');
            int[] input = new int[rawInput.Count()];

            for (int i = 0; i < rawInput.Count(); i++)
            {
                int currI = 0;
                if (int.TryParse(rawInput[i], out currI))
                    input[i] = currI;
                else
                    input[i] = 0;
            }
            
            VM.Solve(input);
        }
    }
}
