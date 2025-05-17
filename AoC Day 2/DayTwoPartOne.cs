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
     */
    public class DayTwoPartOne
    {
        private string _inputData = string.Empty; //Read incoming data as string
        private bool isSafe;
        private int totalSafeFloors = 0;
        
        public void RunDayOnePartOne()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ReadEachLine();
            Console.WriteLine($"Total safe floors: {ReadEachLine()}"); 
            Console.ForegroundColor = ConsoleColor.White;
        }

        private int ReadEachLine()
        {
            _inputData = File.ReadAllText("C:\\Users\\Vikel\\source\\repos\\Advent_Of_Code_2025\\AoC Day 2\\\\InputData.txt");
            StringReader inputReader = new StringReader(_inputData);
            

            if (!String.IsNullOrEmpty(_inputData))
            {
                while (true)
                {
                    string line = inputReader.ReadLine()!;
                    if (line is not null)
                    {
                        Array numberAsArray = line.ToArray();
                        totalSafeFloors = (IsFloorSafe(numberAsArray) ? 1 : 0); //One line if
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("End of data reached.");
                        Console.ForegroundColor = ConsoleColor.White;
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
        private bool IsFloorSafe(Array layer)
        {
            int lead = 0;
            int tail = 0;
            int maxDistanceAllowed = 3;
            int distance = 0;
            int arrayLen = layer.Length;

            for (int i = 0; i < arrayLen - 1; i++) {
                lead = (int)layer.GetValue(i)!;
                tail = (int)layer.GetValue(i + 1)!;

                distance = (lead < tail) ? tail - lead : tail - lead; //One line if statement

                isSafe = (distance <= maxDistanceAllowed) ? true : false; //One line if 

                if(!isSafe) { break; }
            }
            return isSafe;
        }
    }
}
