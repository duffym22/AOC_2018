using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day_2_Inventory_Mgmt_System
{
   class Program
   {
      static List<string> boxIDs = new List<string>();


      ///Array
      ///[0] = count of 1s
      ///[1] = count of 2s
      ///[2] = count of 3s
      ///[3] = count of 4s
      ///...
      static List<int> countOfVals = new List<int>() { 0, 0 };
      static List<bool> countofValsBools = new List<bool> { false, false };

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
         watch.Restart();

         #region Part 1
         foreach (string item in boxIDs)
         {
            for (int i = 0; i < item.Length; i++)
            {
               if (!charCount.ContainsKey(item[i]))
               {
                  charCount.Add(item[i], 1);
               }
               else
               {
                  charCount[item[i]] += 1;
               }
            }

            foreach (KeyValuePair<char, int> item2 in charCount)
            {
               switch (item2.Value)
               {
                  case 0:
                     break;
                  case 1:
                     break;
                  case 2:
                     if (!countofValsBools[0])
                     {
                        countOfVals[0]++;
                        countofValsBools[0] = true;
                     }
                     break;
                  case 3:
                     if (!countofValsBools[1])
                     {
                        countOfVals[1]++;
                        countofValsBools[1] = true;
                     }
                     break;
                  default:
                     Console.WriteLine("New value: " + item2.Value.ToString());
                     break;
               }

            }

            charCount.Clear();
            countofValsBools = new List<bool>() { false, false, false, false };
         }

         watch.Stop();
         Console.WriteLine(string.Format("T-COUNT: {0} ticks", watch.ElapsedTicks));
         Console.WriteLine(string.Format("T-COUNT: {0} ms", watch.ElapsedMilliseconds));
         Console.WriteLine(string.Format("# of 2s: {0}", countOfVals[0].ToString()));
         Console.WriteLine(string.Format("# of 3s: {0}", countOfVals[1].ToString()));

         int total = countOfVals[0] * countOfVals[1];
         Console.WriteLine(string.Format("Total: {0}", total.ToString()));
         #endregion

         #region Part 2
         watch.Restart();

         int
            firstIndex = -1,
            secondIndex = -1,
            tempDiffs = 0,
            leastDiffs = 999;

         //Iterate through list of IDs - start at 0 and advance
         for (int i = 0; i < boxIDs.Count; i++)
         {
            //Iterate through list of IDs - start at 1
            for (int j = i + 1; j < boxIDs.Count - 1; j++)
            {
               //iterate through string to find first difference
               for (int k = 0; k < boxIDs[i].Length; k++)
               {
                  if (boxIDs[i][k] != boxIDs[j][k])
                  {
                     tempDiffs++;
                  }
               }

               if (tempDiffs < leastDiffs)
               {
                  leastDiffs = tempDiffs;
                  firstIndex = i;
                  secondIndex = j;
               }
               tempDiffs = 0;
            }
         }

         Console.WriteLine(string.Format("Smallest diffs found: {0}", leastDiffs.ToString()));
         Console.WriteLine(string.Format("String 1: {0}", boxIDs[firstIndex]));
         Console.WriteLine(string.Format("String 2: {0}", boxIDs[secondIndex]));

         string buildString = string.Empty;
         for (int i = 0; i < boxIDs[firstIndex].Length; i++)
         {
            if (boxIDs[firstIndex][i] == boxIDs[secondIndex][i])
            {
               buildString += boxIDs[firstIndex][i];
            }
         }
         Console.WriteLine(string.Format("Common string: {0}", buildString));

         #endregion
         watch.Stop();
         Console.WriteLine(string.Format("T-ITERATE: {0} ticks", watch.ElapsedTicks));
         Console.WriteLine(string.Format("T-ITERATE: {0} ms", watch.ElapsedMilliseconds));
         Console.ReadLine();
      }
   }
}
