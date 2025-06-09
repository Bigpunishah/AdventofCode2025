using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_5
{
    //Idea 1: Regex
    //Idea 2: Arrays & search to match
    public class DayFivePartOne
    {
        private string data = string.Empty;
        private List<(int, int)> pageorderingrules = [];

        public void DayFivePartOneRun()
        {
            GetData();
            //GetPageOrderingRules();
            CheckPageUpdates();
        }//End DayFivePartOneRun

        public void GetData()
        {
            try
            {
                data = File.ReadAllText("AoC Day 5\\InputData.txt");
                //Console.WriteLine(data);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }//End GetData

        public void GetPageOrderingRules()
        {
            string regexpattern = @"\d+\|\d+"; // /d+ one or more number number|number
            if (data is not null)
            {
                MatchCollection matches = Regex.Matches(data, regexpattern);

                foreach (Match match in matches) 
                {
                    //Console.WriteLine(match.Value);
                    //Console.WriteLine(matches.Count);
                    int val1 = int.Parse(Regex.Match(match.Value, @"\d+").Value); //pattern for first value
                    int val2 = int.Parse(Regex.Match(match.Value, @"(?<=\|)\d+").Value); //pattern for second value
                    pageorderingrules.Add((val1, val2));
                }
            }
            else 
            {
                Console.WriteLine("PageOrderingRules is NULL!");
                throw new Exception();
            }
        }//End GetPageOrderingRules

        public void CheckPageUpdates()
        {
            //Pick up here.
            List<string> pageupdates = [];
            string regexpattern = @"[^,]";
            if (data is not null)
            {
                //MatchCollection matchs = Regex.Matches(data, regexpattern);
                //foreach (Match match in matchs)
                //{
                //    Console.WriteLine(match.Value);
                //}
                foreach (string line in data.Split('\n'))
                {
                    Match match = Regex.Match(line, regexpattern);
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
