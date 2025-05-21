using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_2
{
    /*My understanding of the problem
     * tell me if im wrong lol
     * 
     * We are re-evaluating the non-safe floors
     * we are going to check to see if we remove a val
     * if it becomes safe
     * we are going to add to the orignal count
     * orig count: 680
     * 
     *  7 6 4 2 1: Safe without removing any level.
     *  1 2 7 8 9: Unsafe regardless of which level is removed.
     *  9 7 6 2 1: Unsafe regardless of which level is removed.
     *  1 3 2 4 5: Safe by removing the second level, 3.
     *  8 6 4 4 1: Safe by removing the third level, 4.
     *  1 3 6 7 9: Safe without removing any level.
     */
    public class DayTwoPartTwo
    {
        private List<int> _oneFloorRemoved = [];

        public static bool AllIncreaseOrAllDecrease(List<int> list) //all increasing or all decreasing
        {
            bool isSafe = false;

            for (int i = 0; i < list.Count - 2; i++)
            {
                int lead = list[i];
                int mid = list[i + 1];
                int tail = list[i + 2];
                bool isIncreasing = lead < mid && mid < tail;
                bool isDecreasing = lead > mid && mid > tail;
                isSafe = (isDecreasing || isIncreasing);

                if (!(isIncreasing || isDecreasing)) { isSafe = false; break; }
            }
            return isSafe;
        }
        //public List<int> ReturnOneFloorMissing(List<int> unSafeLevels, List<int> originalList, int indexToRemove)
        //{
        //    //Remove floor indexToRemove
        //    _oneFloorRemoved = originalList;
        //    _oneFloorRemoved.RemoveAt(indexToRemove);
        //    return _oneFloorRemoved;
        //}//End CheckUnsafeFloor
    }
}
