using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.Aoc_Day_3
{
    public class DayThreePartOne
    {
        //Try to keep all concerns separated!
        public void DayThreePartOneRun()
        {

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
