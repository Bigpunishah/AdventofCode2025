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
        private List<string> pageupdates = [];

        public void DayFivePartOneRun()
        {
            GetData();
            GetPageOrderingRules();
            GetPageUpdates();
            IsPageUpdateInOrder();
        }//End DayFivePartOneRun

        void GetData()
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

        private void GetPageOrderingRules()
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

        private List<string> GetPageUpdates()
        {
            string regexpattern = @"(\d+(?:,\d+)+)"; //int,int,+... ?:, unknwn amnt 
            if (data is not null)
            {
                MatchCollection matchs = Regex.Matches(data, regexpattern);
                foreach (Match match in matchs) 
                {
                    pageupdates.Add(match.Value);
                    //Console.WriteLine(match.Value);
                }
            }
            return pageupdates;
        }//End CheckPageUpdates

        private bool IsPageUpdateInOrder()
        {
            int totalloops = pageorderingrules.Count;
            //Check the vals in order
            for(int i = 0; i < totalloops; i++)
            {
                //Pick up here.
            }
            return false;

        }//End IsPageUpdateInOrder

        private int GetTotalOfMiddleValue()
        {
            throw new NotImplementedException();
        }
    }
}
