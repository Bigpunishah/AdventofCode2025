using System.Text.RegularExpressions;


namespace Advent_Of_Code_2025.Aoc_Day_4
{
    public class DayFourPartOne
    {
        //input word to search
        private const string SearchWord = "XMAS";

        public void DayFourPartOneRun()
        {
            List<string> data = GetData();
            //PrintTotalMatches(data); //Wrong answer
            PrintTotalMatchesAllDirections(data); //Right asnwer

            //Current answer: 2551 - Wrong, too low.
            //Right answer - 2573 - AI input.
        }

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
        
        //Entry method that starts the all-direction word search and prints the total count
        public void PrintTotalMatchesAllDirections(List<string> data)
        {
            int total = CountAllMatches(data);
            Console.WriteLine("Total Matches found (all directions): {0}", total);
        }

        private int CountAllMatches(List<string> data)
        {
            int totalMatches = 0; // Track the total number of matches found
            int levels = data.Count; // Total number of rows (Y-axis)
            int columns = 0; // Longest row length (X-axis)

            // Find the longest row length
            foreach (var row in data)
                if (row.Length > columns) columns = row.Length;

            // Define 8 directions in (rowDelta, colDelta) — conventional grid movement
            (int, int)[] directions = new (int, int)[]
            {
                //(row, col)
                (0, 1),   // → right
                (0, -1),  // ← left
                (1, 0),   // ↓ down
                (-1, 0),  // ↑ up
                (-1, -1), // ↖ up-left
                (-1, 1),  // ↗ up-right
                (1, -1),  // ↙ down-left
                (1, 1)    // ↘ down-right
            };

            // Also check for the reversed version of the word
            string reversedWord = ReverseString(SearchWord);

            // Scan every cell in the grid
            for (int rowIndex = 0; rowIndex < levels; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < data[rowIndex].Length; columnIndex++)
                {
                    foreach (var (rowDirection, colDirection) in directions)
                    {
                        if (IsAreaAMatch(data, rowIndex, columnIndex, rowDirection, colDirection, SearchWord))
                            totalMatches++;

                        if (IsAreaAMatch(data, rowIndex, columnIndex, rowDirection, colDirection, reversedWord))
                            totalMatches++;
                    }
                }
            }
            return totalMatches; // Return total count found
        }

        // Check if a word exists starting from (row, col) in (rowDelta, colDelta) direction
        private static bool IsAreaAMatch(List<string> data, int startRow, int startCol, int rowDir, int colDir, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                int row = startRow + rowDir * i;
                int col = startCol + colDir * i;

                // Check grid boundaries
                if (row < 0 || row >= data.Count) return false;
                if (col < 0 || col >= data[row].Length) return false;

                if (data[row][col] != word[i]) return false;
            }
            return true; // All characters matched
        }

        //Helper method to reverse the search word
        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        //+++++++++++++++++++++++++++++++++++++++++++My Old Code++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
        }//End GetCountOfVerticalMatches

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