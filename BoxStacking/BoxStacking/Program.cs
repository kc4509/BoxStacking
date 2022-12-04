//Kelly Chen || kc4509@g.rit.edu
//IGME 206 (E9 Box Stacking Simulation)

using System;
using System.Runtime.Serialization.Formatters;

namespace BoxStacking
{
    class Program
    {
        static void Main(string[] args)
        {
            printArray();
        }

        const int DAYS = 3; // # of days to run simulation
        const int STACKS = 4; // # of stacks every day
        const int MINHEIGHT = 1; // min height of a stack
        const int MAXHEIGHT = 3; // max height of a stack
        const int MINITEMS = 1; // min # of items in a box
        const int MAXITEMS = 9; // max # of items in a box 

        protected static int[,,] stack; //placeholder for 3D array


        //Builds the 3D array for box stacking simulation
        public static void createArray()
        {
            Random rnd = new Random();
            int[,,] arr = new int[DAYS, STACKS, MAXHEIGHT];

            for (int i = 0; i < DAYS; i++)
            {
                 for (int j = 0; j < MAXHEIGHT; j++)
                {
                    for (int k = 0; k < STACKS; k++)
                    {
                        arr[i, k, j] = 0;
                    }
                }
            }

            for (int i =0; i < DAYS; i++)
            {
                
                for (int s = 0; s < STACKS; s++)
                {
                    int test = rnd.Next(MINHEIGHT, MAXHEIGHT + 1);
                    for (int k = 0; k < test; k++)
                    {
                        arr[i, s, k] = rnd.Next(MINITEMS, MAXITEMS + 1);
                    }
                }
            }


            for (int i = 0; i < DAYS; i++)
            {
                for (int j =0; j < MAXHEIGHT; j++)
                {
                    for (int s = 0; s < STACKS; s++)
                    {
                        if (arr[i, s, 1] == 0)
                        {
                            arr[i, s, 1] = arr[i, s, 0];
                            arr[i, s, 0] = 0;
                        }
                        if (arr[i, s, 2] == 0)
                        {
                            arr[i, s, 2] = arr[i, s, 1];
                            arr[i, s, 1] = 0;
                        }

                    }
                }
                
            }

            stack = arr;
        }


        //Prints array in a correct shape
        public static void printArray()
        {
            createArray();
            for (int i = 0; i < DAYS; i++)
            {
                int dayNum = i + 1;
                Console.WriteLine("DAY " + dayNum);

                for (int j = 0; j < MAXHEIGHT; j++)
                {

                    for (int k = 0; k < STACKS; k++)
                    {
                        if (stack[i, k, j] == 0)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write(stack[i, k, j] + " ");
                        }
                        
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
    }
}