using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solvers
{

    public class Leandro11 : Wizard
    {
        private int occupiedSeats;
        private char[][] map;
        private char[][] tempMap;
        private int xL;
        private int yL;

        public Leandro11(string name) : base(name)
        {
        }

        #region Solutions

        public override long SolvePartOne(string[] input)
        {
            int adjacent;
            bool modifications;

            yL = input.Count();
            xL = input[0].Length;

            map = new char[yL][];
            tempMap = new char[yL][];

            occupiedSeats = 0;

            for (int i = 0; i < yL; i++)
                map[i] = input[i].ToCharArray();

            do
            {
                modifications = false;

                // Get available seats
                for (int i = 0; i < map.Count(); i++)
                {
                    tempMap[i] = new char[xL];

                    for (int j = 0; j < map[i].Count(); j++)
                    {
                        adjacent = map[i][j] != '.' ? CountAdjacents(j, i) : 0;

                        if (map[i][j] == 'L' && adjacent == 0)
                        {
                            tempMap[i][j] = '#';
                            modifications = true;
                            occupiedSeats++;
                        }
                        else if (map[i][j] == '#' && adjacent >= 4)
                        {
                            tempMap[i][j] = 'L';
                            modifications = true;
                            occupiedSeats--;
                        }
                        else
                            tempMap[i][j] = map[i][j];
                    }
                }
                map = tempMap;
                tempMap = new char[yL][];
            }
            while (modifications);
            return occupiedSeats;
        }

        public override long SolvePartTwo(string[] input)
        {
            int adjacent;
            bool modifications;

            yL = input.Count();
            xL = input[0].Length;

            map = new char[yL][];
            tempMap = new char[yL][];

            occupiedSeats = 0;

            for (int i = 0; i < yL; i++)
                map[i] = input[i].ToCharArray();

            do
            {
                modifications = false;

                // Get available seats
                for (int i = 0; i < map.Count(); i++)
                {
                    tempMap[i] = new char[xL];

                    for (int j = 0; j < map[i].Count(); j++)
                    {
                        adjacent = map[i][j] != '.' ? CountAdjacentsThatAreSoVeryVeryFarAway(j, i) : 0;

                        if (map[i][j] == 'L' && adjacent == 0)
                        {
                            tempMap[i][j] = '#';
                            modifications = true;
                            occupiedSeats++;
                        }
                        else if (map[i][j] == '#' && adjacent >= 5)
                        {
                            tempMap[i][j] = 'L';
                            modifications = true;
                            occupiedSeats--;
                        }
                        else
                            tempMap[i][j] = map[i][j];
                    }
                }
                map = tempMap;
                tempMap = new char[yL][];
            }
            while (modifications);
            return occupiedSeats;
        }

        #endregion

        #region Auxiliary Methods        
        private int CountAdjacents(int x, int y)
        {
            int occupiedAdjacent = 0;

            for (int i = -1; i < 2; i++)
            {
                if (x + i < 0 || x + i >= xL)
                    continue;

                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    if (y + j < 0 || y + j >= yL)
                        continue;

                    if (map[y + j][x + i] == '#')
                        occupiedAdjacent++;
                }
            }

            return occupiedAdjacent;
        }

        private int CountAdjacentsThatAreSoVeryVeryFarAway(int x, int y)
        {
            int occupiedAdjacent = 0;
            int iteration = 0;
            bool[] ahahahahah = Enumerable.Repeat(false, 8).ToArray();

            List<int[]> combinations = new List<int[]>
            {
                new int[]{0 , -1},
                new int[]{1 , -1},
                new int[]{1 , 0},
                new int[]{1 , 1},
                new int[]{0 , 1},
                new int[]{-1 , 1},
                new int[]{-1 , 0},
                new int[]{-1 , -1}
            };

            do
            {
                iteration++;
                for (int i = 0; i < ahahahahah.Count(); i++)
                {
                    int dX = combinations[i][0];
                    int dY = combinations[i][1];

                    if (!ahahahahah[i])
                    {
                        if (x + iteration * dX < 0 || x + iteration * dX >= xL ||
                            y + iteration * dY < 0 || y + iteration * dY >= yL ||
                            map[y + iteration * dY][x + iteration * dX] == 'L')
                        {
                            ahahahahah[i] = true;
                        }
                        else if (map[y + iteration * dY][x + iteration * dX] == '#')
                        {                            
                            occupiedAdjacent++;
                            ahahahahah[i] = true;
                        }
                    }
                }
            }
            while (ahahahahah.Any(ah => ah == false));

            return occupiedAdjacent;
        }
        #endregion
    }
}
