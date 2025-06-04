using System.Text.RegularExpressions;


namespace Advent_Of_Code_2025.Aoc_Day_4
{
    public class DayFourPartOne
    {
        public void DayFourPartOneRun()
        {
            List<string> data = GetData();
            //Console.WriteLine("Horizontal Matches: {0}", GetCountOfHorizontalMatches(data));
            PrintTotalMatches(data);
            //Current answer: 2551 - Wrong, too low
            //Guessed answer: 2600 - Wrong, too high
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
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        data.Add(line);
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

        private void PrintTotalMatches(List<string> data)
        {
            int total = 0;
            total += GetCountOfHorizontalMatches(data);
            total += GetCountOfVerticalMatches(data);
            total += GetCountOfDiagonalMatches(data);
            Console.WriteLine("Total Macthes found: {0}", total);
        }//End GetTotalMatches

        private int GetCountOfHorizontalMatches(List<string> data)
        {
            string stringdata = string.Join("\n", data); //Quick way to convert List<string> into string
            const string regex = @"(XMAS)|(SAMX)";
            MatchCollection collection = Regex.Matches(stringdata, regex);
            return collection.Count();
        }//End GetCountOfHorizontalMatches

        private int GetCountOfVerticalMatches(List<string> data)
        {
            int matchCount = 0;
            const string regex = @"(XMAS)|(SAMX)";
            Regex pattern = new Regex(regex); // Compile once

            // Loop over vertical layers (only go to Count - 3 to avoid out-of-range)
            for (int layer = 0; layer <= data.Count - 4; layer++)
            {
                string layerOne = data[layer];
                string layerTwo = data[layer + 1];
                string layerThree = data[layer + 2];
                string layerFour = data[layer + 3];

                int minLength = Math.Min(
                    Math.Min(layerOne.Length, layerTwo.Length),
                    Math.Min(layerThree.Length, layerFour.Length));

                for (int i = 0; i < minLength; i++)
                {
                    //Strings can be indexed
                    string verticalSlice =
                        $"{layerOne[i]}{layerTwo[i]}{layerThree[i]}{layerFour[i]}";
                    //Console.WriteLine(verticalSlice);
                    if (pattern.IsMatch(verticalSlice))
                    {
                        matchCount++;
                    }
                }
            }
            //Console.WriteLine("End of file reached with {0} matches", matchCount);
            return matchCount;
        }

        private int GetCountOfDiagonalMatches(List<string> data)
        {
            int diagtotal = 0;
            const string regex = @"(XMAS)|(SAMX)";
            Regex pattern = new Regex(regex); // Compile once

            for (int layer = 0; layer <= data.Count - 4; layer++)
            {
                string layerOne = data[layer];
                string layerTwo = data[layer + 1];
                string layerThree = data[layer + 2];
                string layerFour = data[layer + 3];

                int len = layerOne.Length;

                for (int i = 0; i < len; i++)
                {
                    try 
                    {
                        string decline = $"{layerOne[i]}{layerTwo[i + 1]}{layerThree[i + 2]}{layerFour[i + 3]}";
                        //Console.WriteLine(decline);
                        diagtotal += pattern.IsMatch(decline) ? 1 : 0; //One line if

                        string incline = $"{layerFour[i]}{layerThree[i + 1]}{layerTwo[i + 2]}{layerOne[i + 3]}";
                        //Console.WriteLine(incline);
                        diagtotal += pattern.IsMatch(incline) ? 1 : 0; //One line if
                    }
                    catch { }
                }
            }
            //Console.WriteLine(diagtotal);
            return diagtotal;
        }//End GetCountOfDiagonalMatches
    }
}
