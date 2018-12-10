using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Alchemical_Reduction
{
    class Program
    {
        static List<string> lines = new List<string>();
        static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_5_Alchemical_Reduction\Day5.txt";

        static void Main(string[] args)
        {
            Read_Input();
        }

        static void Read_Input()
        {
            using (StreamReader reader = new StreamReader(_FILE))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
        }
    }
}
