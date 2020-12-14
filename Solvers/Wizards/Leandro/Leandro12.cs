using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{

    public class Leandro12 : Wizard
    {
        private const char N = 'N';
        private const char S = 'S';
        private const char E = 'E';
        private const char W = 'W';
        private const char F = 'F';
        private const char R = 'R';
        private const char L = 'L';

        private long x;
        private long y;

        private long wayX;
        private long wayY;

        private char orientation;

        public Leandro12(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            y = 0;
            x = 0;

            orientation = E;

            for (int i = 0; i < input.Count(); i++)
            {
                char instruction = input[i].ElementAt(0);
                int value = int.Parse(input[i].Substring(1));

                switch (instruction)
                {
                    case F:
                        MoveDaBarco(orientation, value);
                        break;
                    case R:
                    case L:
                        RotateDaBarco(instruction, value);
                        break;
                    default:
                        MoveDaBarco(instruction, value);
                        break;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }



        public override long SolvePartTwo(string[] input)
        {
            wayX = 10;
            wayY = 1;

            y = 0;
            x = 0;

            orientation = E;

            for (int i = 0; i < input.Count(); i++)
            {
                char instruction = input[i].ElementAt(0);
                int value = int.Parse(input[i].Substring(1));

                switch (instruction)
                {
                    case F:
                        y += wayY;
                        x += wayX;
                        break;
                    case R:
                    case L:
                        RotateDaWayPointa(instruction, value);
                        break;
                    default:
                        MoveDaWayPointa(instruction, value);
                        break;
                }
            }

            return -1;
        }

        #endregion

        #region Auxiliary Methods        

        private void MoveDaBarco(char instruction, int value)
        {
            switch (instruction)
            {
                case N:
                    y += value;
                    break;
                case S:
                    y -= value;
                    break;
                case E:
                    x += value;
                    break;
                case W:
                    x -= value;
                    break;
            }
        }

        private void RotateDaBarco(char instruction, int value)
        {
            bool reverse = instruction == L ? true : false;
            List<char> cardinals = new List<char>
            {
                N, E, S, W
            };
            if (reverse) cardinals.Reverse();

            int idx = cardinals.IndexOf(orientation);
            idx = (idx + value / 90) % 4;

            orientation = cardinals[idx];
        }

        private void RotateDaWayPointa(char instruction, int value)
        {
            bool clockWise = instruction == R ? true : false;
            long tempValue = 0;
            if (value == 180)
            {
                wayX = -wayX;
                wayY = -wayY;
            }
            else if ((value == 90 && clockWise) || (value == 270 && !clockWise))
            {
                tempValue = wayX;
                wayX = wayY;
                wayY = -tempValue;
            }
            else if ((value == 90 && !clockWise) || (value == 270 && clockWise))
            {
                tempValue = wayX;
                wayX = -wayY;
                wayY = tempValue;
            }
        }

        private void MoveDaWayPointa(char instruction, int value)
        {
            switch (instruction)
            {
                case N:
                    wayY += value;
                    break;
                case S:
                    wayY -= value;
                    break;
                case E:
                    wayX += value;
                    break;
                case W:
                    wayX -= value;
                    break;
            }
        }

        #endregion
    }
}
