using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Fabio02 : Wizard
    {
        public Fabio02(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            var validPasswords = 0;

            for (var i = 0; i < input.Length; i++)
            {
                ParseLine(input, i, out var min, out var max, out var letter, out var password);

                var numOccur = 0;
                for (var j = 0; j < password.Length; j++)
                    if (password[j] == letter)
                        numOccur++;

                if (numOccur > min && numOccur < max)
                    validPasswords++;
            }

            return validPasswords;
        }

        public override long SolvePartTwo(string[] input)
        {
            var validPasswords = 0;

            for (var i = 0; i < input.Length; i++)
            {
                ParseLine(input, i, out var equalIndex, out var differentIndex, out var letter, out var password);

                if ((password[equalIndex - 1] == letter) ^ (password[differentIndex - 1] == letter))
                    validPasswords++;
            }

            return validPasswords;
        }

        private static void ParseLine(string[] list, int i, out int min, out int max, out char letter,
            out string password)
        {
            var a = list[i].Split('-');
            min = ConvertToInt(a[0]);

            a = a[1].Split(' ');
            max = ConvertToInt(a[0]);

            var b = a[1].Split(':');
            letter = b[0][0];

            a = a[2].Split(' ');
            password = a[0];
        }

        private static int ConvertToInt(string s)
        {
            var y = 0;
            for (var i = 0; i < s.Length; i++)
                y = y * 10 + (s[i] - '0');

            return y;
        }
    }
}
