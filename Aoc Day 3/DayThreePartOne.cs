using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Advent_Of_Code_2025.Aoc_Day_3
{
    public class DayThreePartOne
    {
        //Try to keep all concerns separated!

        //Read through the document & only find the acceptable pattern:
        //mul(X,Y) - anthing else not valid.

        //Two high level solutions:
        //1.) Find the pattern & only save 2 vals to multip - I like this idea more :)
        //2.) Find the pattern & save the pattern entirely then read?
        public void DayThreePartOneRun()
        {
            string inputData = File.ReadAllText("AoC Day 3\\InputData.txt"); //Get data
            List<int> PatternedValuesList = GetPatternedValsList(inputData); //Get data as list in readable format for equation
        }

        public List<int> GetPatternedValsList(string data)
        {
            string regexpattern = @"[mul(]"; // Wrong - currently only matching chars currently.

            foreach(Match match in Regex.Matches(data, regexpattern, RegexOptions.IgnoreCase))
            {
                Console.WriteLine($"Matches: {match.Value}");

            }
            return new List<int>();

            //Stream Reader Read() method & put the accceptable criteria in a list or array?
            //Yes - break out the array & ensure its within order.
            //char[] mulArray = [ 'm', 'u', 'l', '(', ',', ')'];
            //Array dataArray = data.ToArray();

            //for (int i = 0; i < dataArray.Length; i+=3)
            //{
            //    bool hasMChar = dataArray.GetValue(i).Equals(mulArray[0]);
            //    bool hasUChar = dataArray.GetValue(i + 1).Equals(mulArray[1]);
            //    bool hasLChar = dataArray.GetValue(i + 2).Equals(mulArray[2]);
            //    bool hasStrtParen = dataArray.GetValue(i + 3).Equals(mulArray[3]);
            //    //Mot sure if this the approach I am looking for
            //    //Maybe look into Regex :)

            //    if (hasMChar && hasUChar && hasLChar && hasStrtParen)
            //    { // Close enough to validate :)

            //    }
            //}


        }


        public string GetInputData()
        {
            try
            {
                string inputDat = File.ReadAllText("AoC Day Three\\InputData.txt");
                return inputDat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error grabbing file from location - Make sure you edit properties to always copy! :)");
            }
            return String.Empty;
        }
    }
}
