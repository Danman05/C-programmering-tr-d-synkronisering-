/*
 *  Opgave 2 + 3
*/

using System.Collections.Concurrent;

namespace Opgave2
{
    internal class Program
    {

        // Static lock object to use in Monitor
        // Static count to keep track of printed characters
        static object _lock = new object();
        static int count;
        static void Main(string[] args)
        {

            // Threads to print out stars and hashes
            Thread starThread = new Thread(WriteStars);
            Thread hashThread = new Thread(WriteHashes);

            starThread.Start();
            Thread.Sleep(250);
            hashThread.Start();

            starThread.Join();
            hashThread.Join();

            Console.Read();
        }

        /// <summary>
        /// Writes 60 stars to the console, to use thread safety i use Monitor.Enter and Monitor.Exit
        /// </summary>
        static void WriteStars()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {

                        Console.Write("*");
                        count++;
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Console.Write($" {count}");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
        /// <summary>
        /// Writes 60 hashes to the console, to use thread safety i use Monitor.Enter and Monitor.Exit
        /// </summary>
        static void WriteHashes()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {

                        Console.Write("#");
                        count++;
                    }
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Console.Write($" {count}");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
    }
}