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
            int total = ReadDataForTotalCount(input);
            Console.WriteLine("DayThreePartTwo total: {0}", total);
        }
        public int ReadDataForTotalCount(string inputData)
        {
            const string doRegexPattern = @"(do\(\))|(don't\(\))"; // Match "do()" or "don't()"
            int indexWaterline = 0;
            int total = 0;
            bool isEnabled = true;

            MatchCollection matches = Regex.Matches(inputData, doRegexPattern);

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                int indexFound = match.Index;

                // Get substring from previous waterline to this match
                string substring = inputData.Substring(indexWaterline, indexFound - indexWaterline);

                // If enabled, process the substring for mul()s
                if (isEnabled)
                {
                    total += GetNewTotal(substring);
                }

                // Update enabled/disabled state
                if (match.Value == "don't()")
                {
                    isEnabled = false;
                }
                else if (match.Value == "do()")
                {
                    isEnabled = true;
                }

                // Move the waterline past this match
                indexWaterline = indexFound + match.Length;
            }

            // Process remaining text after last match if enabled
            if (isEnabled && indexWaterline < inputData.Length)
            {
                string remaining = inputData.Substring(indexWaterline);
                total += GetNewTotal(remaining);
            }

            return total;
        }

        //public int ReadDataForTotalCount(string inputData) : Gave answer 5272063 wrong
        //{
        //    //Verify this ChatGPT response.
        //    const string doRegexPattern = @"(do\(\))|(don't\(\))"; // Literal match for "do()" or "don't()"

        //    int indexWaterline = 0; // Start of substring to process
        //    int total = 0;

        //    MatchCollection matches = Regex.Matches(inputData, doRegexPattern); //Match collection

        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        Match match = matches[i]; //Indexing matches
        //        int indexFound = match.Index;

        //        // Get the string from waterline to this match
        //        int length = indexFound - indexWaterline;
        //        if (length < 0) length = 0; // Prevent negative lengths (defensive programming)

        //        string substring = inputData.Substring(indexWaterline, length);

        //        switch (match.Value)
        //        {
        //            case "do()":
        //                // Check if this is the last match
        //                bool isLast = (i + 1 >= matches.Count);
        //                indexWaterline = match.Index;

        //                if (isLast)
        //                {
        //                    // Read from do() to end
        //                    int remaining = inputData.Length - indexWaterline;
        //                    string finalSegment = inputData.Substring(indexWaterline, remaining);
        //                    total += GetNewTotal(finalSegment);
        //                }
        //                break;

        //            case "don't()":
        //                if (indexWaterline == 0)
        //                {
        //                    // We started with do(), and now found a don't()
        //                    total += GetNewTotal(substring);
        //                }
        //                break;
        //        }

        //        // Always update waterline after processing this match
        //        indexWaterline = match.Index;
        //    }

        //    return total;
        //}


        //public int DoWork (string inputData)
        //{
        //    //How will I read the dont() if I read the do()?
        //    const string doRegexPatter = @"(do\(\))|(don't\(\))"; //do or dont spotted with | or operator

        //    int indexWaterline = 0; //Keep track within data
        //    List<int> doList = [];
        //    int total = 0;

        //    foreach (Match match in Regex.Matches(inputData, doRegexPatter))
        //    {
        //        int indexFound = match.Index;
        //        Console.WriteLine($"{ inputData.Length} {indexWaterline} {indexFound}" );
        //        string substring = inputData.Substring(indexWaterline, indexFound);

        //        switch (match.Value.ToString())
        //        {
        //            case "do()":
        //                indexWaterline = indexFound;
        //                if(match.NextMatch().Value != "don't()" && match.NextMatch().Value != "do()") //if the next match is not found then...
        //                {
        //                    //EOF met
        //                    indexFound = inputData.Length - indexFound;
        //                    substring = inputData.Substring(indexWaterline, indexFound);
        //                    total += GetNewTotal(substring);
        //                }
        //                break;

        //            case "don't()":
        //                if (indexWaterline == 0) //starting with do() by default
        //                {
        //                    //Should be the first don't() found
        //                    total += GetNewTotal(substring);
        //                    break;
        //                }
        //                break;
        //        }
        //        indexWaterline = indexFound; //waterline is set to indexFound if not done so already
        //        //Console.WriteLine(match.Value);
        //    }
        //    return total;

        //}

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
