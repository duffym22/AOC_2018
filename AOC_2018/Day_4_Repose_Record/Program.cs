using System;
using System.Collections.Generic;
using System.IO;

namespace Day_4_Repose_Record
{
   class Program
   {
      static List<string> lines = new List<string>();
      static List<DateTime> times = new List<DateTime>();
      static Dictionary<int, double> guard_ID_Sleeptime = new Dictionary<int, double>();
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

         lines.Sort();

         int
            guardID = 0;

         double
            timeAsleep = 0;

         DateTime
            result,
            startSleep = DateTime.Now,
            wakesUp = DateTime.Now;

         TimeSpan
            timeSleeping;

         for (int i = 0; i < lines.Count; i++)
         {
            string temp = lines[i].Substring(1, 16);
            DateTime.TryParse(temp, out result);
            string log = lines[i].Substring(lines[i].IndexOf("] ") + 2);

            if (log.StartsWith("Guard"))
            {
               string[] splt = log.Split(' ');
               string ID = splt[1].Remove(0, 1);
               int.TryParse(ID, out guardID);
            }
            else
            {
               while (!log.StartsWith("Guard"))
               {
                  if (i < lines.Count)
                  {
                     temp = lines[i].Substring(1, 16);
                     DateTime.TryParse(temp, out result);
                     log = lines[i].Substring(lines[i].IndexOf("] ") + 2);

                     if (log.StartsWith("Guard"))
                     {
                        i--;
                        break;
                     }
                     else if (log.StartsWith("falls"))
                     {
                        startSleep = result;
                     }
                     else if (log.StartsWith("wakes"))
                     {
                        wakesUp = result;
                        timeSleeping = wakesUp - startSleep;
                        timeAsleep = timeSleeping.TotalMinutes;

                        if (!guard_ID_Sleeptime.ContainsKey(guardID))
                        {
                           guard_ID_Sleeptime.Add(guardID, timeAsleep);
                        }
                        else
                        {
                           guard_ID_Sleeptime[guardID] += timeAsleep;
                        }
                     }
                     i++;
                  }
                  else
                     break;
               }
            }
         }

         int sleepiestGuard = 0;
         double sleepiestTimeSlept = 0;

         foreach (KeyValuePair<int, double> item in guard_ID_Sleeptime)
         {
            if (item.Value > sleepiestTimeSlept)
            {
               sleepiestTimeSlept = item.Value;
               sleepiestGuard = item.Key;
            }
         }


         Console.WriteLine(string.Format("Sleepy Guard: {0}", sleepiestGuard));
         Console.WriteLine(string.Format("Time Slept: {0}", sleepiestTimeSlept));
         Console.ReadLine();


      }
   }
}
