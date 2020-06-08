using System;
using System.Collections.Generic;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Počet testovacích případů:");
            long countCases = Convert.ToInt64(Console.ReadLine());
            long[] finalResults = new long[countCases];

            for (int cases = 0; cases < countCases; cases++)
            {
                Console.WriteLine($"Případ {cases + 1}:");
                string[] stringInput = Console.ReadLine().Split();
                long passLength = Convert.ToInt64(stringInput[0]);
                long sequenceLength = Convert.ToInt64(stringInput[1]);
                string sequence = Console.ReadLine();

                List<long[]> combinations = AllCombinations(new long[] { 0, 1 }, 2, passLength);
                List<string> stringCombs = new List<string>();

                for (int i = 0; i < combinations.Count; i++)
                {
                    string nums = "";
                    foreach (long num in combinations[i])
                    {
                        nums += num.ToString();
                    }
                    stringCombs.Add(nums);

                }

                List<string> safeCombinations = new List<string>();
                foreach (string s in stringCombs)
                {
                    if (!s.Contains(sequence))
                    {
                        safeCombinations.Add(s);
                    }
                }

                finalResults[cases] = safeCombinations.Count;
            }
            
            for (int i = 0; i < countCases; i++)
            {
                Console.WriteLine($"Případ {i + 1}: " + finalResults[i]);
            }
            Console.ReadKey();
        }

        public static long[] ConvertPermitives(long n, long[] arr, long len, long L)
        {
            long[] combo = new long[L];
            for (int i = 0; i < L; i++)
            {
                combo[i] = arr[n % len];
                n /= len;
            }
            return combo;
        }

        public static List<long[]> AllCombinations(long[] arr, long len, long L)
        {
            List<long[]> allCombs = new List<long[]>();
            for (int i = 0; i < (long)Math.Pow(len, L); i++)
            {
                allCombs.Add(ConvertPermitives(i, arr, len, L));
            }
            return allCombs;
        }
    }
}
