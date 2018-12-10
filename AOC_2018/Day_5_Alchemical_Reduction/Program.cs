using System;
using System.Collections.Generic;
using System.IO;

namespace Day_5_Alchemical_Reduction
{
    ///Answers submitted:
    /// 12607 - WRONG - too high
    /// 11546 - CORRECT
    class Program
    {
        static int _DIFF = 32;
        static List<string> lines = new List<string>();
        static string input;
        static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_5_Alchemical_Reduction\Day5.txt";

        static void Main(string[] args)
        {
            Read_Input();
            bool matchesFound = true;
            string
                temp = string.Empty,
                explodey = string.Empty;

            char[]
                workingChars = input.ToCharArray();

            while (matchesFound)
            {
                workingChars = Explode_Chars(workingChars, out matchesFound);
                if (matchesFound)
                {
                    foreach (char item in workingChars)
                    {
                        if (!item.Equals('0'))
                        {
                            temp += item;
                        }
                    }
                    workingChars = temp.ToCharArray();
                    temp = string.Empty;
                }
                else
                {
                    break;
                }
            }

            temp = string.Empty;
            foreach (char item in workingChars)
            {
                temp += item;
            }

            Console.WriteLine("Final string: " + temp);
            Console.WriteLine("Items remaining: " + temp.Length);
            Console.ReadLine();
        }

        static void Read_Input()
        {
            using (StreamReader reader = new StreamReader(_FILE))
            {
                while (!reader.EndOfStream)
                {
                    input = reader.ReadLine();
                    //lines.Add(reader.ReadLine());

                }
            }
        }

        static char[] Explode_Chars(char[] explode, out bool matchesFound)
        {
            matchesFound = false;
            for (int i = 0; i < explode.Length; i++)
            {
                int j = i + 1;
                if (j < explode.Length)
                {
                    byte b1, b2;

                    b1 = Convert.ToByte(explode[i]);
                    b2 = Convert.ToByte(explode[j]);

                    int r = b1 - b2;

                    if (Math.Abs(r).Equals(_DIFF))
                    {
                        matchesFound = true;
                        explode[i] = explode[j] = '0';
                        i++;
                    }
                }
            }

            return explode;
        }
    }
}
