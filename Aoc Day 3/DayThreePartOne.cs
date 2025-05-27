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
            string regexpattern = @"mul+\(\d+,\d+\)"; 

            foreach(Match match in Regex.Matches(data, regexpattern))
            {
                Console.WriteLine($"Matches: {match.Value}");
                //Try to print one val then move from there.
                

            }
            return new List<int>();
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
