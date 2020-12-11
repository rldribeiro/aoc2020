using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo11 : Wizard
    {
        private const char floor = '.';
        private const char occuppied = '#';
        private const char empty = 'L';
        private int mapWidth;
        private int mapHeight;


        private List<char[]> seats { get; set; }
        private List<char[]> auxSeats { get; set; }

        public Goncalo11(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            auxSeats = new List<char[]>();
            seats = new List<char[]>();

            foreach (var item in input)
            {
                auxSeats.Add(item.ToCharArray());
                seats.Add(item.ToCharArray());
            }
            mapWidth = seats[0].Length;
            mapHeight = seats.Count;

            Console.WriteLine("-----Part1-----");

            int result = 0;
            bool seatsHasChanges = false;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            do
            {
                seatsHasChanges = false;
                for (int j = 0; j < seats.Count; j++)
                {
                    for (int i = 0; i < seats[j].Length; i++)
                    {
                        int adjOccupiedSeats = AmmountOfOccupiedAdjSeats(j, i);
                        switch (seats[j][i])
                        {
                            case occuppied:
                                if (adjOccupiedSeats >= 4)
                                {
                                    auxSeats[j][i] = empty;
                                    result--;
                                    seatsHasChanges = true;
                                }
                                break;
                            case empty:
                                if (adjOccupiedSeats == 0)
                                {
                                    auxSeats[j][i] = occuppied;
                                    result++;
                                    seatsHasChanges = true;
                                }
                                break;
                            default:
                                auxSeats[j][i] = seats[j][i];
                                break;
                        }
                    }
                }
                CopyAuxToOriginal();

            } while (seatsHasChanges);

            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            auxSeats = new List<char[]>();
            seats = new List<char[]>();

            foreach (var item in input)
            {
                auxSeats.Add(item.ToCharArray());
                seats.Add(item.ToCharArray());
            }
            mapWidth = seats[0].Length;
            mapHeight = seats.Count;
            int result = 0;

            bool seatsHasChanges;
            do
            {
                seatsHasChanges = false;
                for (int j = 0; j < seats.Count; j++)
                {
                    for (int i = 0; i < seats[j].Length; i++)
                    {
                        int adjOccupiedSeats = AmmountOfOccupiedSeatsUsingFalconEye(j, i);
                        switch (seats[j][i])
                        {
                            case occuppied:
                                if (adjOccupiedSeats >= 5)
                                {
                                    auxSeats[j][i] = empty;
                                    result--;
                                    seatsHasChanges = true;
                                }
                                break;
                            case empty:
                                if (adjOccupiedSeats == 0)
                                {
                                    auxSeats[j][i] = occuppied;
                                    result++;
                                    seatsHasChanges = true;
                                }
                                break;
                            default:
                                auxSeats[j][i] = seats[j][i];
                                break;
                        }
                    }
                }
                CopyAuxToOriginal();

            } while (seatsHasChanges);

            return result;
        }

        public void CopyAuxToOriginal()
        {
            for (int i = 0; i < auxSeats.Count; i++)
            {
                for (int j = 0; j < auxSeats[i].Length; j++)
                {
                    seats[i][j] = auxSeats[i][j];
                }
            }
        }

        private int AmmountOfOccupiedAdjSeats(int row, int column)
        {
            int adjOccupiedSeats = 0;
            for (int i = -1; i <= 1; i++)
            {
                if (row + i < 0 || row + i > mapHeight - 1)
                    continue;

                for (int j = -1; j <= 1; j++)
                {
                    if ((j == 0 && i == 0) || column + j < 0 || column + j > mapWidth - 1)
                        continue;

                    if (seats[row + i][column + j] == occuppied)
                        adjOccupiedSeats++;
                }
            }

            return adjOccupiedSeats;
        }

        private int AmmountOfOccupiedSeatsUsingFalconEye(int row, int column)
        {
            int adjOccupiedSeats = 0;

            for (int i = -1; i <= 1; i++)
            {
                if (row + i < 0 || row + i > mapHeight - 1)
                    continue;


                for (int j = -1; j <= 1; j++)
                {
                    int auxY = j;
                    int auxX = i;

                    bool sitFound = false;
                    do
                    {
                        if ((auxX == 0 && auxY == 0) || column + auxY < 0 || column + auxY > mapWidth - 1 || row + auxX < 0 || row + auxX > mapHeight - 1)
                            break;

                        if (seats[row + auxX][column + auxY] == occuppied)
                        {
                            adjOccupiedSeats++;
                            sitFound = true;
                        }
                        else if (seats[row + auxX][column + auxY] == empty)
                            break;
                        else
                        {
                            auxY += j;
                            auxX += i;
                        }
                    } while (!sitFound);
                }
            }

            return adjOccupiedSeats;
        }

    }
}
