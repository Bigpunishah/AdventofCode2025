using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class DayTwoPartTwo : DayTwoPartOne
    {
        private const int DayTwoPartOneAnswer = 680;
        private int totalNewSafeFloors;
        private List<int> originalFloor = [];

        public void DayTwoPartTwoRun()
        {
            ReadEachLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Total vals now safe: {0}", totalNewSafeFloors);
            Console.WriteLine("New total: {0}", totalNewSafeFloors + DayTwoPartOneAnswer);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public void ReadEachLine()
        {
            StringReader inputReader = new(inputData);
            if (!String.IsNullOrEmpty(inputData))
            {
                string? line; //string? means the variable can be null. It’s a nullable reference type.It tells the compiler: "I expect that line might be null, and I'm handling it."
                while ((line = inputReader.ReadLine()) is not null) 
                {
                    originalFloor = StringToIntList(line);
                    if (!IsFloorDistanceSafe(originalFloor) || !IsIncreasingOrDecreasingOnly(originalFloor))
                    {   //Only concerned about the ones that are not safe.
                        if (CheckFloorRemoval(originalFloor)) totalNewSafeFloors++;
                    }
                }
                Console.WriteLine("End of data reached.");
            }
        }

        //New implementation
        public bool CheckFloorRemoval(List<int> origLst)
        {
            for (int countForIndex = 0; countForIndex < origLst.Count; countForIndex++)
            {
                List<int> oneFloorRemoved = new(origLst); // Make a local copy
                oneFloorRemoved.RemoveAt(countForIndex);

                if (IsFloorDistanceSafe(oneFloorRemoved) && IsIncreasingOrDecreasingOnly(oneFloorRemoved))
                {
                    return true;
                }
            }
            return false;
        }

        //New implementation
        public bool IsFloorDistanceSafe(List<int> floorToCheckList)
        {
            int maxDistanceAllowed = 3;
            int lengthForIndex = floorToCheckList.Count - 1;

            for (int i = 0; i < lengthForIndex; i++)
            {
                int lead = floorToCheckList[i];
                int tail = floorToCheckList[i + 1];
                int distance = Math.Abs(lead - tail); //Always returns positive

                if (distance > maxDistanceAllowed)
                {
                    return false;
                }
            }
            return true;
        }

        //public bool IsFloorDistanceSafe(List<int> floorToCheckList)
        //{
        //    int lead;
        //    int tail;
        //    int maxDistanceAllowed = 3;
        //    int distance;

        //    int lengthForIndex = floorToCheckList.Count - 1; //This is to account for the out of bounds index for tail value.

        //    for (int i = 0; i < lengthForIndex; i++)
        //    {
        //        lead = floorToCheckList[i];
        //        tail = floorToCheckList[i + 1];

        //        //if (!AllIncreaseOrAllDecrease(floorToCheckList)) { break; }
        //        distance = (lead < tail) ? tail - lead : lead - tail; //One line if statement

        //        isSafe = (distance <= maxDistanceAllowed); //One line if 

        //        if (!isSafe) { break; }
        //    }
        //    //line.Clear(); //Reset the amount of values for each line
        //    return isSafe;
        //}

        //public bool CheckFloorRemoval(List<int> origLst)
        //{
        //    int countForIndex = 0;
        //    while (countForIndex <= origLst.Count - 1)
        //    {
        //        _oneFloorRemoved = [.. origLst]; //reset the list back to the orignal size {[.. origLst]; = new List<int>();}
        //                                         //removing val at index to check
        //        _oneFloorRemoved.RemoveAt(countForIndex);
        //        if (IsFloorDistanceSafe(_oneFloorRemoved) && IsIncreasingOrDecreasingOnly(_oneFloorRemoved))
        //        {
        //            //Floor distance & The increase pattern is within acceptance.
        //            return true;
        //        }
        //        else
        //        {
        //            //Not safe or passing criteria - add count to index to check if removal helps.
        //            countForIndex++;
        //        }
        //    }
        //    return false;
        //}

    }
}
