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
        static string _FILE = @"C:\Users\mduffy\source\repos\AOC_2018\AOC_2018\Day_5_Alchemical_Reduction\Day5.txt";
        static char[] delimiter2 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        static void Main(string[] args)
        {
            bool
                matchesFound = true;

            string
                temp = string.Empty,
                workingString = string.Empty,
                explodey = string.Empty;

            Read_Input();

            char[]
                workingChars;

            foreach (char thing in delimiter2)
            {
                matchesFound = true;
                workingString = input;
                temp = string.Empty;
                if (workingString.Contains(thing.ToString()))
                {
                    int start = workingString.Length;
                    workingString = workingString.Replace(thing.ToString().ToLower(), "");
                    workingString = workingString.Replace(thing.ToString().ToUpper(), "");
                    int end = workingString.Length;
                    Console.WriteLine(string.Format("Char: {0} | Chars removed: {1}", thing, (start - end)));
                    workingChars = workingString.ToCharArray();
                }
                else
                {
                    Console.WriteLine("Char not found in string" + thing.ToString());
                    workingChars = input.ToCharArray();
                }

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

                Console.WriteLine(string.Format("Char: {0} | String length: {1}", thing, temp.Length));
            }
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
