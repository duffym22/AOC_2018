using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day_2_Inventory_Mgmt_System
{
    class Program
    {
        static ArrayList boxIDs = new ArrayList();
        static Dictionary<char, int> charCount = new Dictionary<char, int>();
        static Stopwatch watch = new Stopwatch();

        static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_2_Inventory_Mgmt_System\boxes.csv";
        static void Main(string[] args)
        {
            watch.Start();
            using (StreamReader reader = new StreamReader(_FILE))
            {
                while (!reader.EndOfStream)
                {
                    boxIDs.Add(reader.ReadLine());
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("T-READFILE: {0} ticks", watch.ElapsedTicks));
            Console.WriteLine(string.Format("T-READFILE: {0} ms", watch.ElapsedMilliseconds));
            Console.ReadLine();

            watch.Restart();

            foreach (string item in boxIDs)
            {
                for (int i = 0; i < item.Length; i++)
                {


                    for (int j = 1; j < item.Length - 1; j++)
                    {
                        if(item[i].Equals(item[j]))
                        {
                            if (!charCount.ContainsKey(item[i]))
                            {
                                charCount.Add(item[i], 1)
                            }
                        }
                    }

                }
            }

        }
    }
}
