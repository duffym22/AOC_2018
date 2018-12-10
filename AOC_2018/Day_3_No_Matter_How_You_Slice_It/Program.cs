using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Day_3_No_Matter_How_You_Slice_It
{
    class Program
    {
        static List<int> claimIDs = new List<int>();
        static List<string> lines = new List<string>();
        static List<Rectangle> rekt = new List<Rectangle>();
        static List<Rectangle> rekt2 = new List<Rectangle>();
        static List<Rectangle> rekt3 = new List<Rectangle>();
        static Dictionary<int, Rectangle> claims = new Dictionary<int, Rectangle>();
        static Dictionary<int, int> gridNums = new Dictionary<int, int>();
        static int[,] grid;
        //static string[,] grid;

        static List<string>
            freeClaimID = new List<string>();

        static int
            overlapClaims = 0,
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
                temp = item.Replace("\"", "");
                int fabricNum, x, y, w, h;
                temp = temp.Remove(0, 1);
                int ind = temp.IndexOf("@");
                int.TryParse(temp.Substring(0, ind), out fabricNum);
                temp = temp.Substring(ind + 1, (temp.Length - ind - 1));
                temp = temp.Trim();
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
                claims.Add(fabricNum, rect);
            }

            Console.WriteLine("Largest X: " + largestX.ToString());
            Console.WriteLine("Largest Y: " + largestY.ToString());
            Console.WriteLine("Total sq in: " + (largestX * largestY).ToString());

            //create 2D array with the largest dimensions
            //this will be populated with Xs where an overlap exists
            grid = new int[largestX, largestY];

            //iterate through the list of all claims
            for (int i = 1; i <= claims.Count; i++)
            {
                //declare a rectangle object to go through all X and Y dimensions
                Rectangle tempRect = claims[i];

                //iterate through X dimension (rows)
                for (int j = tempRect.X; j < tempRect.Right; j++)
                {
                    //iterate through Y dimension (columns)
                    for (int k = tempRect.Y; k < tempRect.Bottom; k++)
                    {
                        grid[j, k] += 1;
                    }
                }
            }

            //Iterate through the X dimension (rows)
            for (int i = 0; i < largestX; i++)
            {
                //Iterate through the Y dimension (columns)
                for (int j = 0; j < largestY; j++)
                {
                    //take the current value at j,k
                    int value = grid[i, j];
                    //if the dictionary doesnt have a counter for that value
                    //add it with a default value of 1
                    if (!gridNums.ContainsKey(value))
                    {
                        gridNums.Add(value, 1);
                    }
                    else
                    {
                        //otherwise, increment the value already in the dictionary
                        gridNums[value] += 1;
                    }
                }
            }

            //print out the claims to the console
            for (int i = 0; i < gridNums.Keys.Count; i++)
            {
                if(i >= 2)
                {
                    overlapClaims += gridNums[i];
                }
                Console.WriteLine(string.Format("{0} claims: {1}", i, gridNums[i]));
            }

            Console.WriteLine("Total overlap: " + overlapClaims.ToString());

            bool overlapsFound = false;
            int gridClaim = 0;
            //iterate through the list of all claims
            for (int i = 1; i <= claims.Count; i++)
            {
                //declare a rectangle object to go through all X and Y dimensions
                Rectangle tempRect = claims[i];

                //iterate through X dimension (rows)
                for (int j = tempRect.X; j < tempRect.Right; j++)
                {
                    //iterate through Y dimension (columns)
                    for (int k = tempRect.Y; k < tempRect.Bottom; k++)
                    {
                        //if the value at position j,k is greater than one
                        //then there are overlaps - move onto the next one
                        if (grid[j, k] > 1)
                        {
                            overlapsFound = true;
                            break;
                        }
                    }

                    //move onto the next claim
                    if (overlapsFound)
                        break;
                }

                //if no overlaps were found, then we found the free claim!
                if(!overlapsFound)
                {
                    gridClaim = i;
                    break;
                }
                else
                {
                    //if we did find overlapping claims, then reset and move onto the next claim ID
                    overlapsFound = false;
                }
            }
            Console.WriteLine("Free claim ID: " + gridClaim.ToString());
            Console.ReadLine();
        }
    }

}
