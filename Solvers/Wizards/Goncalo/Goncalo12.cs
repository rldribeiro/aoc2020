using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo12 : Wizard
    {
        private const char North = 'N';
        private const char South = 'S';
        private const char East = 'E';
        private const char West = 'W';
        private const char Left = 'L';
        private const char Right = 'R';
        private const char Foward = 'F';

        private readonly List<char> orientation = new List<char> { North, East, South, West };

        public Goncalo12(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            char facingPosition = East;
            int posX = 0;
            int posY = 0;

            foreach (var item in input)
            {
                char moveAction = item[0];
                int moveValue = Int16.Parse(item.Remove(0, 1));

                if (moveAction == North || (moveAction == Foward && facingPosition == North))
                    posX += moveValue;
                else if (moveAction == South || (moveAction == Foward && facingPosition == South))
                    posX -= moveValue;
                else if (moveAction == East || (moveAction == Foward && facingPosition == East))
                    posY += moveValue;
                else if (moveAction == West || (moveAction == Foward && facingPosition == West))
                    posY -= moveValue;
                else if (moveAction == Left || moveAction == Right)
                    facingPosition = RotateShip(facingPosition, moveAction, moveValue);

            }
            return Math.Abs(posX) + Math.Abs(posY);
        }

        private char RotateShip(char currOrientation, char action, int value)
        {
            int index = orientation.IndexOf(currOrientation);

            if (action == Right)
            {
                index = (index + (value / 90)) % orientation.Count;

            }
            else
            {
                int jump = (360 - value) / 90;
                index = (index + jump) % orientation.Count;
            }

            return orientation[index];
        }

        public override long SolvePartTwo(string[] input)
        {
            int shipX = 0;
            int shipY = 0;
            int waypointX = 10;
            int waypointY = 1;

            foreach (var item in input)
            {
                char moveAction = item[0];
                int moveValue = Int16.Parse(item.Remove(0, 1));

                if (moveAction == North)
                    waypointY += moveValue;
                else if (moveAction == South)
                    waypointY -= moveValue;
                else if (moveAction == East)
                    waypointX += moveValue;
                else if (moveAction == West)
                    waypointX -= moveValue;
                else if (moveAction == Left || moveAction == Right)
                    RotateWaypoint(moveAction, moveValue, ref waypointX, ref waypointY);
                else if (moveAction == Foward)
                {
                    shipX += moveValue * waypointX;
                    shipY += moveValue * waypointY;
                }
            }
            return Math.Abs(shipX) + Math.Abs(shipY);
        }

        private void RotateWaypoint(char moveAction, int moveValue, ref int waypointX, ref int waypointY)
        {
            double angleRadians = (Math.PI / 180) * moveValue * (moveAction == Left ? 1 : -1);
            double x = waypointX * Math.Cos(angleRadians) - waypointY * Math.Sin(angleRadians);
            double y = waypointX * Math.Sin(angleRadians) + waypointY * Math.Cos(angleRadians);

            waypointX = Convert.ToInt32(x);
            waypointY = Convert.ToInt32(y);

        }

    }
}
