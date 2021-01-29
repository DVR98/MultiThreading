using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        //Paramaterized Thread
        public static void ThreadMethod(object o){
            for (int i = 1; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            bool stopped = false;

            //Thread1
            Thread t = new Thread(new ThreadStart(() => {
                //Run untill user presses any key
                while (!stopped){
                    Console.WriteLine("Press any key to stop the threads from running");
                    Console.WriteLine("ThreadProc: {0}", 2);
                    Thread.Sleep(1000);

                    //Thread2
                    Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod));

                    //Start Thread2
                    t2.Start(2);
                }
            }));

            //Start Thread1
            t.Start();
            
            //Stop both threads if user presses any key
            Console.ReadKey();
            stopped = true;

            //Wait for Main thread to finish, then terminate app
            t.Join();
        }
    }
}
