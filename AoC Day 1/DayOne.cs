using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_1
{
    public class DayOne
    {
        private string _inputData = string.Empty; //Read incoming data as string
        private const string _filePath = @"C:\Users\Vikel\source\repos\Advent_Of_Code_2025\AoC Day 1\InputData.txt"; //File path to incoming
        //private string _filePath = Path.Combine(AppContext.BaseDirectory, "InputData.txt"); //File path to incoming
        List<int> numbers = new List<int>(); //List to hold the values from the input data

        public void Run()
        {
            //Method to run the code in its entirety.
            List<int> leftNumbers = new List<int>();
            List<int> rightNumbers = new List<int>();
            string data = CopyFile();

            numbers = ConvertStringToList(data);
            leftNumbers = SeparateLists(numbers, true);
            rightNumbers = SeparateLists(numbers, false);

            leftNumbers.Sort();
            rightNumbers.Sort();

            Console.WriteLine("Total distance: " + ReturnDistance(leftNumbers, rightNumbers));
            Console.WriteLine("Advent of Code Day 1 Executed Successfully!");
        }

        private string CopyFile()
        {
            try
            {
                _inputData = File.ReadAllText(_filePath); //Get all data from 
                Console.WriteLine("File Copied.");
                return _inputData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying accessing file: {0}", ex.Message);
                Console.WriteLine("The path it tried: {0}", _filePath);  
                return string.Empty;
            }

        }//End of ReadFile() function

        private List<int> ConvertStringToList(string inputData)
        {
            try
            {
                if (inputData is not null)
                {
                    //Console.WriteLine(inputData.ToString());
                    //iterating for each numberString, split by space between.
                    int i = 0;
                    foreach(string numberStr in inputData.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        numbers.Add(int.Parse(numberStr));
                        //Console.WriteLine($"{numberStr} has been added to list");
                    }
                    Console.WriteLine("Converted String to List.");
                    return numbers;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input data is null.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error converting string to list: {0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return null!;
            }
        }//End of AddStringToList

        private List<int> SeparateLists(List<int> incomingListData, bool left) 
        { 
            List<int> listLeft = new List<int>();
            List<int> listRight = new List<int>();

            bool returnStatus = left;

            if(incomingListData is not null)
            {
                for(int i = 0; i < incomingListData.Count; i++)
                {
                    if (left)
                    {
                        listLeft.Add(incomingListData[i]);
                        //Console.WriteLine(i);
                        left = false;
                    }
                    else
                    {
                        listRight.Add(incomingListData[i]);
                        left = true;
                    }
                }

                if (returnStatus)
                {
                    Console.WriteLine("Returning left list");
                    return listLeft;
                }
                else
                {
                    Console.WriteLine("Returning right list");
                    return listLeft;
                }
            }
            else
            {
                return null!;
            }

        }//End PrepareList

        private int ReturnDistance(List<int> left, List<int> right)
        {
            int total = 0;
            for(int i = 0; i < left.Count; i++)
            {
                total += Math.Abs(left[i] - right[i]);
            }
            Console.WriteLine("Returning Total Distance.");
            return total;   
        }

    }
}
