using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3_No_Matter_How_You_Slice_It
{
   class Program
   {
      static List<string> lines = new List<string>();
      static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_2_Inventory_Mgmt_System\slices.csv";
      static void Main(string[] args)
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
