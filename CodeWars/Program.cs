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
