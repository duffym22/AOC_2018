using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AOC_2018
{
    class Program
    {
        static bool duplicateFound = false;
        static int frequency = 0;
        static ArrayList freqValues = new ArrayList();
        static List<int> uniqueValue = new List<int>();
        static Stopwatch watch = new Stopwatch();

        static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\Day1_Chronal_Calibration\freqValues.csv";

        static void Main(string[] args)
        {
            watch.Start();
            using (StreamReader reader = new StreamReader(_FILE))
            {
                while (!reader.EndOfStream)
                {
                    freqValues.Add(Convert.ToInt32(reader.ReadLine()));
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("T-READFILE: {0} ticks", watch.ElapsedTicks));
            Console.WriteLine(string.Format("T-READFILE: {0} ms", watch.ElapsedMilliseconds));
            watch.Restart();

            #region Part 1
            foreach (int item in freqValues)
            {
                frequency += item;
            }

            watch.Stop();
            Console.WriteLine(string.Format("T-PART 1: {0} ticks", watch.ElapsedTicks));
            Console.WriteLine(string.Format("T-PART 1: {0} ms", watch.ElapsedMilliseconds));
            Console.WriteLine(string.Format("Frequency: {0}", frequency.ToString()));
            watch.Restart();
            #endregion

            #region Part 2

            Console.WriteLine("Frequency reset back to 0");
            frequency = 0;
            while (!duplicateFound)
            {
                for (int i = 0; i < freqValues.Count; i++)
                {
                    frequency = frequency + (int)freqValues[i];
                    if (!uniqueValue.Contains(frequency))
                    {
                        uniqueValue.Add(frequency);
                        uniqueValue.Sort();
                    }
                    else
                    {
                        duplicateFound = true;
                        break;
                    }
                    Console.WriteLine(frequency > 0 ? "+" : frequency == 0 ? "0" : "-");
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("T-PART 2: {0} ticks", watch.ElapsedTicks));
            Console.WriteLine(string.Format("T-PART 2: {0} ms", watch.ElapsedMilliseconds));
            Console.WriteLine(string.Format("First duplicate frequency found: {0}", frequency));
            Console.ReadLine();

            #endregion
        }
    }
}
