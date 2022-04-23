using System;
using System.Collections.Generic;

namespace RomanToInt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }

        static int RomanToInt(string s)
        {
            int len = s.Length;
            int val = 0;

            if (len < 1 || len > 15) return 0;

            Dictionary<char, int> Roman = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            for (int i = 0; i < len - 1; i++)
            {
                int num = Roman[s[i]];
                if (num < Roman[s[i + 1]])
                {
                    if (IsReducer(num))
                        num = -1 * num;
                    else
                        num = 0;
                }
                val += num;
            }
            val += Roman[s[len - 1]];

            return val;
        }

        static bool IsReducer(int num) => num switch { 1 or 10 or 100 => true, _ => false };

    }
}
