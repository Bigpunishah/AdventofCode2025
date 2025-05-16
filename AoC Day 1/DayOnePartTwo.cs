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
        private List<int> leftList = new List<int>();
        private List<int> rightList = new List<int>();
        
        private int rightOccurenceToMultiply;
        private int total;

        public void RunDayOnePartTwo()
        {
            (leftList, rightList) = new DayOnePartOne().PartTwoShortCut();
            SolveProblemTwo(leftList, rightList);
        }

        public void SolveProblemTwo(List<int> incomingLeftL, List<int> incomingRightL)
        {
            int count = int.Max(incomingLeftL.Count, incomingRightL.Count);

            for (int i = 0; i < count; i++)
            {
                rightOccurenceToMultiply = 0;
                for (int j = 0; j < count; j++)
                {
                    if (incomingLeftL[i] == incomingRightL[j])
                    {
                        rightOccurenceToMultiply++;
                    }
                }
                if(rightOccurenceToMultiply > 0)
                Console.WriteLine($"{incomingLeftL[i]} Occured: {rightOccurenceToMultiply} time(s)");
                total += incomingLeftL[i] * rightOccurenceToMultiply;
            }
            Console.WriteLine("The job has complete!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(total);
            Console.ForegroundColor = ConsoleColor.White;
        }//End SolveProblemTwo function
    }
}
