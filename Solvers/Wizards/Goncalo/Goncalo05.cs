using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Wizards.Goncalo
{
    public class Goncalo05 : Wizard
    {
        public Goncalo05(string name) : base(name)
        {
        }

        public override long SolvePartOne(string[] input)
        {
            long result = 0;

            string rowId;
            string columnId;
            int row;
            int column;


            foreach (var item in input)
            {
                rowId = item.Substring(0, 7);
                columnId = item.Substring(7, 3);

                row = CalcPos(0, 127, rowId);
                column = CalcPos(0, 7, columnId);

                if ((row * 8 + column) > result)
                    result = row * 8 + column;
            }

            return result;
        }

        public override long SolvePartTwo(string[] input)
        {
            int result = 0;
            string rowId;
            string columnId;
            int row;
            int column;
            SortedSet<int> sortedIds = new SortedSet<int>();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var item in input)
            {
                rowId = item.Substring(0, 7);
                columnId = item.Substring(7, 3);

                row = CalcPos(0, 127, rowId);
                column = CalcPos(0, 7, columnId);
                result = row * 8 + column;

                sortedIds.Add(result);
            }

            int previousVerifiedId = -1;
            foreach (int item in sortedIds)
            {
                if (previousVerifiedId == -1) // first iteration
                {
                    previousVerifiedId = item;
                    continue;
                }

                if (item - previousVerifiedId == 2)
                {
                    result = item - 1;
                    break;
                }
                previousVerifiedId = item;
            }

            return result;
        }

        private int CalcPos(int startPos, int endPos, string id)
        {
            if (startPos == endPos)
                return startPos;

            var seatsToCut = 1 + (endPos - startPos) / 2;

            if (id[0] == 'B' || id[0] == 'R') //Upper half
            {
                startPos += seatsToCut;
            }
            else
            {
                endPos -= seatsToCut;
            }

            return CalcPos(startPos, endPos, id.Remove(0, 1));
        }
    }
}
