using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Console.Write(sumTwoSmallestNumbers(numbers));
            Console.WriteLine();
            Console.WriteLine(Divisors(16).Select(x => x.ToString()).Aggregate((x, y) => x + " " + y));
        }

        public static int DuplicateCount(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            else
            {
                var characters = str.ToLower().ToCharArray();
                var results = characters.GroupBy(x => x).Where(x => x.Count() > 1);
                return results.Count();
            }
            return -1;
        }

        public static int Test(string numbers)
        {
            //Your code is here...
            var converts = numbers.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x));
            int[] results = new int[converts.Count()];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = converts.ElementAt(i) % 2 == 0 ? 1 : 0;
            }
            var grouped = results.GroupBy(x => x);
            var answer = grouped.OrderBy(x => x.Count()).First().Key;
            return Array.FindIndex(results, x => x == answer) + 1;
        }

        //public static string Decode(string morseCode)
        //{
        //    string result = "";
        //    morseCode = morseCode.Trim();
        //    // take words
        //    var words = morseCode.Split(new string[] { "   " },StringSplitOptions.RemoveEmptyEntries);
        //    foreach (var word in words)
        //    {
        //        var characters = word.Split(' ').Where(x=>!string.IsNullOrWhiteSpace(x));
        //        foreach (var charact in characters)
        //        {
        //            result += MorseCode.Get(charact);
        //        }
        //        result += " ";
        //    }

        //}

        public static int[] Divisors(int n)
        {
            if (IsPrime(n))
            {
                return null;
            }
            else
            {
                List<int> result = new List<int>();
                int pd = 2;
                for (int i = pd; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        if (n/i==i)
                        {
                            result.Add(i);
                        }
                        else
                        {
                            result.Add(i);
                            result.Add(n / i);
                        }
                        
                    }
                }
                return result.OrderBy(x=>x).ToArray();
            }
        }
        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            //Code here...
            var lowests = numbers.OrderBy(x => x).Take(2);
            return lowests.Sum(x => x);
        }
    }
}
