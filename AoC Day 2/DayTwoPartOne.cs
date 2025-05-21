using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_2
{
    /*
     * Problem overview:
     *  Input data has multiple levels to be read
     *  each layer needs to be following a certain pattern
     *  ascending or descending at max 3 units
     *  123456 - passes because it increases by 1
     *  145678 - passes becasue 1-4 is 3 away
     *  155678 - fails since 1-5 is more than 3 
     *  
     *  Idea to solve:
     *  1.) Get length of how many layers in data.
     *  2.) Use count to index to a layer
     *      a.) then put layer into array
     *      b.) get count for indexing
     *      c.) search that layer for pass or fail
     *      d.) collect count 
     *  3.) Problem complete?
     *  
     *  Error in process: All increasing or all decreasing. Missed that portion!
     */
    public class DayTwoPartOne
    {
        private string _inputData = string.Empty; //Read incoming data as string
        private bool isSafe;
        private int totalSafeFloors = 0;
        readonly List<string> currentFloorList = [];
        
        public void RunDayOnePartOne()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total safe floors: {ReadEachLine()}"); 
            Console.ForegroundColor = ConsoleColor.White;
        }

        private int ReadEachLine()
        {
            _inputData = File.ReadAllText("AoC Day 2\\\\InputData.txt");
            StringReader inputReader = new(_inputData);
            

            if (!String.IsNullOrEmpty(_inputData))
            {
                while (true)
                {
                    string line = inputReader.ReadLine()!;
                    if (line is not null)
                    {
                        totalSafeFloors = (IsFloorSafe(line) ? (totalSafeFloors += 1) : (totalSafeFloors += 0)); //One line if
                    }
                    else
                    { 
                        Console.WriteLine("End of data reached.");
                        break;
                    }
                }
            }
            return totalSafeFloors;
        }
        //Check layer
        //Check distance
        //If distance max is met break - IsSafe = false
        //Else continue 
        private bool IsFloorSafe(string line)
        {
            int lead;
            int tail;
            int maxDistanceAllowed = 3;
            int distance;

            //int arrayLen = layer.Length;

            foreach (string number in line.Split([' ',], StringSplitOptions.RemoveEmptyEntries))
            {
                currentFloorList.Add(number);
            }

            int lengthForIndex = currentFloorList.Count - 1; //This is to account for the out of bounds index for tail value.

            for (int i = 0; i < lengthForIndex; i++)
            {
                if (!AllIncreaseOrAllDecrease(line)) { break; }
                lead = int.Parse(currentFloorList[i]);
                tail = int.Parse(currentFloorList[i+1]);

                distance = (lead < tail) ? tail - lead : lead - tail; //One line if statement

                isSafe = (distance <= maxDistanceAllowed); //One line if 

                if(!isSafe) { break; }
            }
            currentFloorList.Clear(); //Reset the amount of values for each line
            return isSafe;
        }

        public static bool AllIncreaseOrAllDecrease(string line) //all increasing or all decreasing
        {
            List<int> ints = []; //list to hold (int)string vals
            bool isSafe = false;

            foreach (string stringInteger in line.Split([ " ", ], StringSplitOptions.RemoveEmptyEntries))
            {
                ints.Add(int.Parse(stringInteger));
            }
            //Fix here & remove extra parse? 
            //Work on removal of val in floor checks

            for (int i = 0; i < ints.Count - 2; i++)
            {
                int lead = ints[i];
                int mid = ints[i + 1];
                int tail = ints[i + 2];
                bool isIncreasing = lead < mid && mid < tail;
                bool isDecreasing = lead > mid && mid > tail;
                isSafe = (isDecreasing || isIncreasing);

                if (!(isIncreasing || isDecreasing)) { isSafe = false; break; }
            }
            return isSafe;
        }
    }
}
