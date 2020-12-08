using System;
using System.Collections;
using System.Collections.Generic;

namespace Solvers
{
    public class Fabio03 : Wizard
    {
        public Fabio03(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            //var matrix = FillMatrix(input);
            var slopX = 3;
            var slopY = 1;
            return GetTreesFoundForSlop(input, slopX, slopY);
        }

        private static long GetTreesFoundForSlop(string[] input, int slopX, int slopY)
        {
            var treesFound = 0;
            var posX = 0;
            var posY = 0;
            var width = input[0].Length;
            while (posY <= input.Length - 1)
            {
                var pos = input[posY][posX - (posX / width) * width];
                if (pos == '#')
                    treesFound++;

                posX += slopX;
                posY += slopY;
            }

            return treesFound;
        }

        public override long SolvePartTwo(string[] input)
        {
            int[][] slops = new int[][]
            {
                new int[] { 1,1 },
                new int[] { 3,1 },
                new int[] { 5,1 },
                new int[] { 7,1 },
                new int[] { 1,2 }
            };

            long result=1;
            foreach (var slop in slops)
            {
                result *= GetTreesFoundForSlop(input,slop[0],slop[1]);
            }
            return result;
        }

        Matrix2D<char> FillMatrix(string[] input)
        {
            int width = input[0].Length;
            int height = input.Length;

            var matrix = new Matrix2D<char>(height, width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = input[i][j];
                }
            }

            return matrix;
        }

        private class Matrix2D<T> : IEnumerable<T>
        {
            private readonly T[] _data;

            public int Rows { get; }
            public int Columns { get; }

            public T this[int row, int col]
            {
                get => _data[row + col * Rows];
                set => _data[row + col * Rows] = value;
            }

            public Matrix2D(int rows, int columns)
            {
                Rows = rows;
                Columns = columns;
                _data = new T[Rows * Columns];
            }

            public IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)_data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _data.GetEnumerator();
            }
        }

    }
}
