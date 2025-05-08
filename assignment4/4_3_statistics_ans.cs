using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            string[] subjects = { "Math", "Science", "English" };

            int[] sum = new int[3];
            int[] max = new int[3];
            int[] min = new int[3];

            for (int i = 0; i < 3; i++)
            {
                max[i] = 0;
                min[i] = 100;
            }

            string[] names = new string[stdCount];
            int[] totals = new int[stdCount];

            for (int i = 1; i <= stdCount; i++)
            {
                names[i - 1] = data[i, 1];
                int total = 0;

                for (int j = 0; j < 3; j++)
                {
                    int score = int.Parse(data[i, j + 2]);
                    sum[j] += score;

                    if (score > max[j]) max[j] = score;
                    if (score < min[j]) min[j] = score;

                    total += score;
                }

                totals[i - 1] = total;
            }

            Console.WriteLine("Average Scores: ");
            for (int j = 0; j < 3; j++)
            {
                double avg = sum[j] / (double)stdCount;
                Console.WriteLine(subjects[j] + ": " + avg.ToString("F2"));
            }

            Console.WriteLine("\nMax and min Scores: ");
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine(subjects[j] + ": (" + max[j] + ", " + min[j] + ")");
            }

            Console.WriteLine("\nStudents rank by total scores:");

            string[] suffixes = { "1st", "2nd", "3rd", "4th", "5th" };

            for (int i = 0; i < stdCount; i++)
            {
                int rank = 1;
                for (int j = 0; j < stdCount; j++)
                {
                    if (totals[j] > totals[i])
                    {
                        rank++;
                    }
                }

                Console.WriteLine(names[i] + ": " + suffixes[rank - 1]);
            }

            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/
