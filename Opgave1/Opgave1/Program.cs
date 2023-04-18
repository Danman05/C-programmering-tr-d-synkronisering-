/*
 * Opgave 1 - C# programmering tråd synkronisering 
*/
namespace Opgave1
{
    internal class Program
    {
        private static int count;
        private static object _lock = new object();
        static void Main(string[] args)
        {

            // ThreadPool method

            ThreadPool.QueueUserWorkItem(AddTwo);
            Thread.Sleep(500);
            ThreadPool.QueueUserWorkItem(RemoveOne);


            // Thread method

            //Thread countUp = new Thread(AddTwo);
            //Thread countDown = new Thread(RemoveOne);

            //countUp.Start();
            //Thread.Sleep(500);
            //countDown.Start();

            //countUp.Join();
            //countDown.Join();

            Console.Read();

        }

        /// <summary>
        /// Adds two to the static count
        /// Uses Monitor to keep the shared ressource safe
        /// </summary>
        /// <param name="obj"></param>
        static void AddTwo(object obj)
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    count += 2;
                }
                finally
                {
                    Console.WriteLine($"Counter increased to: {count}");
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// Removes one from the static count.
        /// Uses Monitor to keep the shared ressource safe
        /// </summary>
        /// <param name="obj"></param>
        static void RemoveOne(object obj)
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    count -= 1;
                }
                finally
                {
                    Console.WriteLine($"Counter decreased to: {count}");
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);
            }
        }
    }
}