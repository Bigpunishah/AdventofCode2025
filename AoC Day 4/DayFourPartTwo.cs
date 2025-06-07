using Advent_Of_Code_2025.Aoc_Day_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_4
{
    public class DayFourPartTwo : DayFourPartOne
    {
        //Goal: Find all instances of MAS in the shape of an X 
        //S.S.
        //.A.
        //M.M.
        //Order does not matter as long as theres an X
        private const string word = "MAS";
        public void DayFourPartTwoRun()
        {
            List<string> data = GetData();
            int total = CountAllXShapeMatches(data);
            Console.WriteLine("Total {0}", total);
        }//End DayFourPartTwoRun

        //Count all matched
        public int CountAllXShapeMatches(List<string> data)
        {
            int totalXMatches = 0;
            int levels = data.Count(); // -- (x)
            int units = 0; // | (y)
            string wordReversed = ReverseString(word); //Word in rev

            //Check to ensure the smallest floor is column len
            foreach(string level in data) 
                if(units < level.Length) units = level.Length;

            for(int levelIndex = 0; levelIndex < levels; levelIndex++) 
            {
                for (int unitIndex = 0; unitIndex < units; unitIndex++) 
                {
                    if(IsXMatch(data, levelIndex, unitIndex, word, wordReversed))
                        totalXMatches++;
                }
            }
            return totalXMatches;
        }//End CountAllXShapeMatches

        public bool IsXMatch(List<string> data, int level, int unit, string word, string wordrev)
        {
            //Check to ensure enough space to work 3x3
            if (level + 2 >= data.Count || unit + 2 >= data[level].Length)
                return false;

            //vals as chars
            char topleft = data[level][unit];
            char bttmright = data[level + 2][unit + 2];

            char mid = data[level + 1][unit + 1];

            char topright = data[level][unit + 2];
            char bttmleft = data[level + 2][unit];

            //Now check string
            string diag1 = $"{topleft}{mid}{bttmright}";
            string diag2 = $"{topright}{mid}{bttmleft}";
            //Console.WriteLine(checkmatch);
            //Console.WriteLine(checkmatchrev);

            if ((diag1 == word || diag1 == wordrev) && (diag2 == word || diag2 == wordrev))
                return true;
            return false;
        }
    }
}
