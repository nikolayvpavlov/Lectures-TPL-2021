using System;
using System.Threading;

namespace CRaceConditionDemo
{
    class Program
    {
        static int data = 100;
        static int data2 = 200;
        static object objLock = new object();
        static object objLock2 = new object();

        static void NaughtyWorker()
        {
            for (int i = 0; i < 10; i++)
            {
                data = data + 1;
                Thread.Sleep(3);
                data--;
                Console.WriteLine(data);
            }
        }

        static void GoodWorker()
        {
            for (int i = 0; i < 10; i++)
            {
                Monitor.Enter(objLock);
                data++;
                Thread.Sleep(3);
                data--;
                Console.WriteLine(data);
                Monitor.Exit(objLock);
            }
        }

        static void GoodWorker2()
        {
            for (int i = 0; i < 10; i++)
            {
                Monitor.Enter(objLock2);
                data2++;
                Thread.Sleep(3);
                data2--;
                Console.WriteLine(data2);
                Monitor.Exit(objLock2);
            }
        }

        static void Main(string[] args)
        {
            Thread t1, t2, t3, t4;
            t1 = new Thread(NaughtyWorker);
            t2 = new Thread(NaughtyWorker);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine();
            Console.WriteLine();
            data = 100;
            data2 = 100;
            t1 = new Thread(GoodWorker);
            t2 = new Thread(GoodWorker);
            t3 = new Thread(GoodWorker2);
            t4 = new Thread(GoodWorker2);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
