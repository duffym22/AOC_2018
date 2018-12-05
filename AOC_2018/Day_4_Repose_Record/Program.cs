using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4_Repose_Record
{
   class Program
   {
      static List<string> lines = new List<string>();
      static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_4_Repose_Record\time.csv";
      static void Main(string[] args)
      {
         using (StreamReader reader = new StreamReader(_FILE))
         {
            while (!reader.EndOfStream)
            {
               lines.Add(reader.ReadLine());
            }
         }

         foreach (string item in lines)
         {



         }



      }
   }
}
