using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_1
{
    public class DayOnePartOne
    {
        private string _inputData = string.Empty; //Read incoming data as string
        List<int> numbers = new List<int>(); //List to hold the values from the input data

        public void RunDayOnePartOne()
        {
            //Method to run the code in its entirety.
            List<int> leftNumbers = new List<int>();
            List<int> rightNumbers = new List<int>();
            string data = CopyFile();

            (leftNumbers, rightNumbers) = StringToLeftListAndRightList(data);

            leftNumbers.Sort();
            rightNumbers.Sort();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Total distance: " + ReturnDistance(leftNumbers, rightNumbers));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Advent of Code Day 1 Executed Successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public (List<int>, List<int>) PartTwoShortCut()
        {
            string data = CopyFile();
            List<int> leftNumbers = new List<int>();
            List<int> rightNumbers = new List<int>();
            (leftNumbers, rightNumbers) = StringToLeftListAndRightList(data);
            leftNumbers.Sort();
            rightNumbers.Sort();
            return (leftNumbers, rightNumbers);
        }

        public string CopyFile()
        {
            try
            {
                _inputData = File.ReadAllText("AoC Day 1\\InputData.txt"); //Get all data from 
                Console.WriteLine("File Copied.");
                return _inputData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying accessing file: {0}", ex);
                return string.Empty;
            }

        }//End of ReadFile() function

        public (List<int>, List<int>) StringToLeftListAndRightList(string inputData)
        {
            var leftListToReturn = new List<int>();
            var rightListToReturn = new List<int>();
            try
            {
                if (inputData is not null)
                {
                    //Console.WriteLine(inputData.ToString());
                    //iterating for each numberString, split by space between.
                    foreach(string numberStr in inputData.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        numbers.Add(int.Parse(numberStr));
                        //Console.WriteLine($"{numberStr} has been added to list");
                    }
                    Console.WriteLine("Converted String to List.");
                    (leftListToReturn, rightListToReturn) = SeparateLists(numbers);
                    return (leftListToReturn, rightListToReturn);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input data is null.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return (null!, null!);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error converting string to list: {0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return (null!, null!);
            }
        }//End of AddStringToList

        private (List<int>, List<int>) SeparateLists(List<int> incomingList) 
        { 
            List<int> listLeft = new List<int>();
            List<int> listRight = new List<int>();
            bool left = true;

            int count = incomingList.Count;

            //bool returnStatus = left;

            if(incomingList is not null)
            {
                for(int i = 0; i < count; i++)
                {
                    if (left)
                    {
                        listLeft.Add(incomingList[i]);
                        //Console.WriteLine(i);
                        left = false;
                    }
                    else
                    {
                        listRight.Add(incomingList[i]);
                        left = true;
                    }
                }

                Console.WriteLine("Returning left list");
                return (listLeft, listRight);
            }
            else
            {
                Console.WriteLine("Incoming list is null.");
                return (null!, null!);
            }

        }//End PrepareList

        private int ReturnDistance(List<int> left, List<int> right)
        {
            int total = 0;
            for(int i = 0; i < left.Count; i++)
            {
                total += Math.Abs(left[i] - right[i]);
            }
            //Console.WriteLine("Returning Total Distance.");
            return total;   
        }
    }
}
