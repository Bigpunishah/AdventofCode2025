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

            ////Define directions to search should be shape of x
            //(int, int)[] directions = new (int, int)[]
            //{
            //    //(y,x)
            //    (1, 1), //downright
            //    (1,-1), //downleft
            //    //(-1, -1), //upleft
            //    //(-1, 1), //upright
            //}; 

            //Check to ensure the smallest floor is column len
            foreach(string level in data) 
                if(units < level.Length) units = level.Length;

            for(int levelIndex = 0; levelIndex < levels; levelIndex++) 
            {
                for (int unitIndex = 0; unitIndex < units; unitIndex++) 
                {
                    if(IsXMatch(data, levelIndex, unitIndex, word, wordReversed))
                        Console.WriteLine($"Level {levelIndex} \nUnit:{unitIndex} \nHas Passed critera");

                    //totalXMatches++;
                }
            }
            return totalXMatches;
        }//End CountAllXShapeMatches

        public bool IsXMatch(List<string> data, int level, int unit, string word, string wordrev)
        {
            //if down right is TRUE then.. check down right starting from UNIT+2 
            int down = 1; //(1, 0) levels
            int right = 1; //(0, 1) units
            int left = -1; //(0, -1) units

            //Checking down right
            for (int i = 0; i < word.Length; i++)
            {
                int thelevel = level + down * i; // * 0 = 0
                int theunit = unit + right * i;

                if(thelevel < 0 || thelevel >= data.Count) return false; //checking bounds
                if (theunit < 0 || theunit >= data[thelevel].Length) return false;

                //Check to ensure meets criteria
                if (data[thelevel][theunit] != word[i] && data[thelevel][theunit] != wordrev[i]) return false; 
            }

            //Checking down left
            for (int i = 0; i < word.Length; i++)
            {
                unit += 2; //this moves the unit on the floor over by 2 units
                int thelevel = level + down * i; // * 0 = 0
                int theunit = unit + left * i;

                if (thelevel < 0 || thelevel >= data.Count) return false; //checking bounds
                if (theunit < 0 || theunit >= data[thelevel].Length) return false;

                //Check to ensure meets criteria
                if (data[thelevel][theunit] != word[i] && data[thelevel][theunit] != wordrev[i]) return false;
            }

            //If it made it thus far: Pass :)
            return true;
        }



    }
}
