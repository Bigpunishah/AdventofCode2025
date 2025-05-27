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
            int total = GetTotal(PatternedValuesList);
            Console.WriteLine($"mul(x,y) total: {total}");
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

        public List<int> GetPatternedValsList(string data)
        {
            string regexpattern = @"mul+\(\d+,\d+\)"; //Pattern to read data
            List<int> values = [];

            foreach(Match match in Regex.Matches(data, regexpattern))
            {
                int valOne = int.Parse(Regex.Match(match.Value, @"\d+").Value); //pattern for first val
                int valTwo = int.Parse(Regex.Match(match.Value, @"(?<=,)\d+").Value); //pattern for second val (lookahead)
                values.Add(valOne);
                values.Add(valTwo);
                //Console.WriteLine($"Matches: {valOne}, {valTwo}");
            }
            return values;
        }

        public int GetTotal(List<int> values)
        {
            int total = 0;
            for (int i = 0; i < values.Count; i += 2)
            {
                total += values[i] * values[i + 1];
                //Console.WriteLine("{0} {1}", values[i], values[i+1]);
            }
            return total;
        }
    }
}
