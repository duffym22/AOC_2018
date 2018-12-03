using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace Day_3_No_Matter_How_You_Slice_It
{
   class Program
   {
      static List<string> lines = new List<string>();
      static List<Rectangle> rekt = new List<Rectangle>();
      static List<Rectangle> overlapRect = new List<Rectangle>();
      static int
         largestX = 0,
         largestY = 0;
      static string _FILE = @"C:\Users\mduffy\source\repos\AOC_2018\AOC_2018\Day_3_No_Matter_How_You_Slice_It\slice.csv";
      static void Main(string[] args)
      {
         using (StreamReader reader = new StreamReader(_FILE))
         {
            while (!reader.EndOfStream)
            {
               lines.Add(reader.ReadLine().Trim());
            }
         }

         foreach (string item in lines)
         {
            //Parse line
            //Examples
            // - #1 @ 1,3: 4x4
            // - #2 @ 3,1: 4x4
            // - #3 @ 5,5: 2x2
            //start at 1 to skip '#'
            string temp = item.Substring(1, item.Length - 1);
            int ind = temp.IndexOf("@ ");
            int fabricNum, x, y, w, h;
            int.TryParse(temp.Substring(0, ind - 1).Remove(0, 1), out fabricNum);
            temp = item.Substring(ind + 2, item.Length - ind - 2).Trim();
            string[] splt = temp.Split(':');
            string[] coord = splt[0].Split(',');
            string[] fabSize = splt[1].Split('x');
            int.TryParse(coord[0], out x);
            largestX = x > largestX ? x : largestX;
            int.TryParse(coord[1], out y);
            largestY = x > largestY ? y : largestY;
            int.TryParse(fabSize[0], out w);
            int.TryParse(fabSize[0], out h);
            rekt.Add(new Rectangle(x, y, w, h));
         }

         Console.WriteLine("Largest X: " + largestX.ToString());
         Console.WriteLine("Largest Y: " + largestY.ToString());

         for (int i = 0; i < rekt.Count; i++)
         {
            for (int j = i + 1; j < rekt.Count - 1; j++)
            {
               if (rekt[i].IntersectsWith(rekt[j]))
               {
                  Rectangle tempRect = rekt[i];
                  tempRect.Intersect(rekt[j]);
                  overlapRect.Add(tempRect);
               }
            }
         }

         int totalOverlap = 0;

         for (int i = 0; i < overlapRect.Count; i++)
         {
            for (int j = i + 1; j < overlapRect.Count; j++)
            {
               int fabric;
               if (overlapRect[i].IntersectsWith(overlapRect[j]))
               {
                  Rectangle tempRect = overlapRect[i];
                  tempRect.Intersect(overlapRect[j]);
                  fabric = tempRect.Height * tempRect.Width;
                  totalOverlap += fabric;
               }
               else
               {
                  fabric = overlapRect[i].Height * overlapRect[i].Width;
               }
               Console.WriteLine(string.Format("Overlap sq in: {0}", fabric));

            }
         }

         Console.WriteLine(string.Format("Total overlap (sq in): {0}", totalOverlap.ToString()));
         Console.ReadLine();
      }

   }

}
