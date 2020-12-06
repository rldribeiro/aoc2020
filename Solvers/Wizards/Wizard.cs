using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public abstract class Wizard
    {
        public string Name { get; private set; }

        public Wizard(string name)
        {
            Name = name;
        }

        public abstract long SolvePartOne(string[] input);

        public abstract long SolvePartTwo(string[] input);
    }
}
