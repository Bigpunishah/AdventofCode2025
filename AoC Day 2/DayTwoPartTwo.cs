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
    public class DayTwoPartTwo : DayTwoPartOne
    {
        private List<int> _oneFloorRemoved = [];
        private const int DayTwoPartOneAnswer = 680;
        int originalLen;
        private int totalNewSafeFloors;
        private int previous;
        private List<int> orginalFloor = [];

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
                while (true)
                {
                    string line = inputReader.ReadLine()!;
                    if (line is not null)
                    {
                        orginalFloor = StringToIntList(line);
                        if (!IsFloorSafe(orginalFloor)) //Only concerned about the ones that are not safe.
                        {
                            originalLen = orginalFloor.Count; //to know the original len
                            totalNewSafeFloors = CheckFloorRemoval(orginalFloor, originalLen) ? totalNewSafeFloors + 1 : totalNewSafeFloors + 0;
                        }
                        else
                        {
                            previous++;
                        }

                    }
                    else
                    {
                        Console.WriteLine("End of data reached.");
                        break;
                    }
                }
            }
        }

        public bool CheckFloorRemoval(List<int> origLst, int originalLength)
        {
            int countForIndex = 0;
            while (countForIndex <= originalLength - 1)
            {
                _oneFloorRemoved = new List<int>(origLst); //reset the list back to the orignal size
                                            //removing val at index to check
                _oneFloorRemoved.RemoveAt(countForIndex);
                if (IsFloorSafe(_oneFloorRemoved))
                {
                    return true;
                }
                else
                {
                    //Not safe, so we continue but add a value for the index
                    countForIndex++;
                    //_oneFloorRemoved.Clear();
                }
            }
            return false;
        }

    }
}
