using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.Aoc_Day_4
{
    public class DayFourPartOne
    {
        public void DayFourPartOneRun()
        {
            Console.WriteLine("Data: {0}", GetData().Count);
        }
        //High level idea 1: Search based on the first char & search in a pattern that goes all around the in the direction & len of the word XMAS
        //Vertical
        //Horizontal
        //Diaganal
        //Break them out into different methods?

        public List<string> GetData()
        {
            try
            {
                string rawData = File.ReadAllText("AoC Day 4\\InputData.txt").ToString();
                StringReader reader = new StringReader(rawData);
                List<string> data = new List<string>();
                if (!String.IsNullOrEmpty(rawData))
                {
                    while (true)
                    {
                        string line = reader.ReadLine()!;
                        data.Add(line);
                        if (line == null) break;
                    }
                }
                return data;
            }
            catch
            {
                Console.WriteLine("Error getting data.");
                return [];
            }
        }

        private int GetCountOfHorizontalMatches(string data)
        {
            throw new NotImplementedException();
        }
    }
}
