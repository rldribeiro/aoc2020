using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers
{
    public class Goncalo03 : Wizard
    {
        private string[] input;
        private int Width { get; set; }
        private int Height { get; set; }

        public Goncalo03(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            this.input = input;
            Width = input[0].Length;
            Height = input.Length;

            long numberOfTrees = 0;
            int SlopX = 3;
            int SlopY = 1;

            MoveToNextPosition(ref numberOfTrees, SlopX, SlopY);

            return numberOfTrees;

        }

        public override long SolvePartTwo(string[] input)
        {

            this.input = input;
            Width = input[0].Length;
            Height = input.Length;

            int[][] slops =
                        {
                new int[] { 1,1 },
                new int[] { 3,1 },
                new int[] { 5,1 },
                new int[] { 7,1 },
                new int[] { 1,2 }
            };


            long numberOfTrees;
            long result = 1;
            
            int SlopX;
            int SlopY;


            foreach (var currentSlop in slops)
            {
                numberOfTrees = 0;

                SlopX = currentSlop[0];
                SlopY = currentSlop[1];

                MoveToNextPosition(ref numberOfTrees, SlopX, SlopY);

                result *= numberOfTrees;
            }

            return result;
        }

        private void MoveToNextPosition(ref long numberOfTrees, int SlopX, int SlopY)
        {
            int posX = 0;
            int posY=0;

            while (posY != Height - 1)
            {
                //map.NextPosition(ref posX, ref posY);
                posX = (posX + SlopX) % Width; // a % b -> a - (a / b) * b;
                posY += SlopY;

                if (input[posY][posX] == '#')
                {
                    numberOfTrees++;
                }
            }
        }
    }
    }
