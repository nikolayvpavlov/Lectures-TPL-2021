using System;
using System.Threading;

namespace DLockingMusings
{
    class Program
    {
        static int data = 100;
        static object objLock = new object();
        
        static void GoodWorker(object param)
        {
            //Monitor.Enter(objLock); //Locking too much.  App is essentially sequential
            string label = param.ToString();
            int tempData;
            for (int i = 0; i < 10; i++)
            {
                lock (objLock)
                {
                    data++;
                    Thread.Sleep(3);
                    data--;
                    tempData = data;
                }
                Console.WriteLine(label + ": " + tempData);
            }
        }
        static void Main(string[] args)
        {
            Thread t1, t2;
            t1 = new Thread(GoodWorker);
            t2 = new Thread(GoodWorker);
            t1.Start("A");
            t2.Start("B");

            t1.Join();
            t2.Join();
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
