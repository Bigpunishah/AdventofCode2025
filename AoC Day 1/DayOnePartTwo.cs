using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2025.AoC_Day_1
{
    /* Problem understanding:
     *      use left as base reference
     *      multiply left by occurences of right
     *      Ex: value 3 is the first in left colmn
     *          right has 3 total of 5 times
     *          (left * right = total) 3 * 5 = 15
     *          
     *          now lets say the next number in
     *          left is 3 again we know theres 
     *          5 occurences of 3's
     *          then total += 15 again.
     *        
     */
    public class DayOnePartTwo : DayOnePartOne
    {
        private string data = new DayOnePartTwo().CopyFile();
        private int currentLeftValue;
        private int currentRightValue;
        private int rightOccurenceToMultiply;
        private List<int> incomingList = new List<int>();

        public void Run()
        {

        }

         
    }
}
