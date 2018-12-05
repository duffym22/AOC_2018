using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Day_3_No_Matter_How_You_Slice_It
{
   class Program
   {
      static List<string> lines = new List<string>();
      static List<Rectangle> rekt = new List<Rectangle>();
      static List<Rectangle> overlapRect = new List<Rectangle>();
      static List<Rectangle> overlappingOverlap = new List<Rectangle>();
      static int[,] grid;

      static int
         largestX = 0,
         largestY = 0;

      static string _FILE = @"C:\Users\Matthew\source\repos\AOC_2018\AOC_2018\Day_3_No_Matter_How_You_Slice_It\slice.csv";
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
            //Parse line
            //Examples
            // - #1 @ 1,3: 4x4
            // - #2 @ 3,1: 4x4
            // - #3 @ 5,5: 2x2
            //start at 1 to skip '#'
            string temp = item.Replace(" ", "");
            temp = temp.Substring(1, temp.Length - 2);
            int ind = temp.IndexOf("@");
            int fabricNum, x, y, w, h;
            temp = temp.Remove(0, 1);
            int.TryParse(temp.Substring(0, 1), out fabricNum);
            ind = temp.IndexOf("@");
            temp = temp.Substring(ind + 1, (temp.Length - ind - 1));
            string[] splt = temp.Split(':');
            string[] coord = splt[0].Split(',');
            string[] fabSize = splt[1].Split('x');
            int.TryParse(coord[0], out x);
            int.TryParse(coord[1], out y);
            int.TryParse(fabSize[0].Trim(), out w);
            int.TryParse(fabSize[1].Trim(), out h);
            Rectangle rect = new Rectangle(x, y, w, h);
            largestX = rect.Right > largestX ? rect.Right : largestX;
            largestY = rect.Bottom > largestY ? rect.Bottom : largestY;
            rekt.Add(rect);
         }

         Console.WriteLine("Largest X: " + largestX.ToString());
         Console.WriteLine("Largest Y: " + largestY.ToString());
         Console.WriteLine("Total sq in: " + (largestX * largestY).ToString());

         //create 2D array with the largest dimensions
         //this will be populated with Xs where an overlap exists
         grid = new int[largestX, largestY];

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

         for (int i = 0; i < overlapRect.Count; i++)
         {
            for (int j = overlapRect[i].X; j < overlapRect[i].Right; j++)
            {
               for (int k = overlapRect[i].Y; k < overlapRect[i].Bottom; k++)
               {
                  grid[j, k] = 1;
               }
            }
         }

         int
            totalOverlap = 0;

         for (int i = 0; i < largestX; i++)
         {
            for (int j = 0; j < largestY; j++)
            {
               totalOverlap += grid[i, j];
            }
         }


         Console.WriteLine(string.Format("Total overlap (sq in): {0}", totalOverlap.ToString()));
         Console.ReadLine();
      }

   }

}
