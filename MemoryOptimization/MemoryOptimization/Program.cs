using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Calcculation of unedited code started...");
            original();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Calculation took {elapsedMs} miliseconds.\n\n\n");

            watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Calcculation of edited code started...");
            edited();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Calculation took {elapsedMs} miliseconds.\n\n\n");

            void original()
            {
                int[,,] Matrix = new int[500, 500, 500];
                int res = 0;

                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 500; j++)
                    {
                        for (int k = 0; k < 500; k++)
                        {
                            Matrix[k, j, i] += 2;
                        }
                    }
                }

                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 500; j++)
                    {
                        for (int k = 0; k < 500; k++)
                        {
                            Matrix[k, j, i]--;
                        }
                    }
                }
            }

            void edited()
            {
                int[,,] Matrix = new int[500, 500, 500];
                // int res = 0; unnecessary declaration

                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 500; j++)
                    {
                        for (int k = 0; k < 500; k++) // time locality because the same indexes are used regularly
                        {
                            Matrix[i, j, k] += 2; // changed the order of the indexes to achieve space locality
                        }
                    }
                }

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        for (int k = 0; k < 100; k++)
                        {
                            Matrix[i, j, k]--; // changed the order of the indexes to achieve space locality
                        }
                    }
                }
            }
        }
    }
}
