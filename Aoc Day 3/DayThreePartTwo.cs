using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.Aoc_Day_3
{
    class DayThreePartTwo : DayThreePartOne
    {
        //Do another Regex for the Do() & Dont() expressions 
        //Use if statements within a loop?
        public void DayThreePartTwoRun()
        {
            //check the amount of do()'s & dont()'s
            string input = GetInputData();
            DoWork(input);
        }

        public int DoWork (string inputData)
        {
            //How will I read the dont() if I read the do()?
            const string doRegexPatter = @"do\(\)|don't\(\)"; //do or dont spotted with | or operator

            int indexWaterline = 0; //Keep track within data
            List<int> doList = [];
            int total = 0;

            foreach (Match match in Regex.Matches(inputData, doRegexPatter))
            {
                int indexFound = match.Index;
                string substring = inputData.Substring(indexWaterline, indexFound);

                switch (match.Value.ToString())
                {
                    case "do()":
                        indexWaterline = indexFound;
                        if(match.NextMatch().Value != "don't()" && match.NextMatch().Value != "do()") //if the next match is not found then...
                        {
                            //EOF met
                            indexFound = inputData.Length - indexFound;
                            substring = inputData.Substring(indexWaterline, indexFound);
                            total += GetNewTotal(substring);
                        }
                        break;

                    case "don't()":
                        if (indexWaterline == 0) //starting with do() by default
                        {
                            //Should be the first don't() found
                            total += GetNewTotal(substring);
                            //doList = GetPatternedValsList(substring);
                            //total += GetTotal(doList);
                            break;
                        }
                        
                        break;

                }
                indexWaterline = indexFound;
                Console.WriteLine(match.Value);
            }
            //List for data & append if the value is not met in the bracket of dos & donts?
            //do while? do: append chars to list while match isnt found?
            return total;

        }

        public int GetNewTotal(string substring)
        {
            List<int> doList = [];
            int total = 0;
            doList = GetPatternedValsList(substring);
            total = GetTotal(doList);
            return total;

        }

    }
}
