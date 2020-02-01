using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpTricksAndTips
{

 

    public class MultiThreads
    {
        static bool done;
        static readonly object locker = new object();

        public static void Go()
        {
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }

        [Test]
        public void TestLock()
        {
            new Thread(Go).Start();
            Go();
        }

        /**********************************************************************/

        static EventWaitHandle _waitHandle = new AutoResetEvent(false);

        static void Operation()
        {
            Console.WriteLine("Start operation...");
            Thread.Sleep(2000);               // Computation...
            Console.WriteLine("Operation finished!");
            _waitHandle.Set();                // Notify the Waiter
            Thread.Sleep(1000);         // Some other computation...
        }

        [Test]
        public void TestSignaling()
        {
            new Thread(Operation).Start();
            Thread.Sleep(1000);                  // Computation...
            Console.WriteLine("Wait...");
            _waitHandle.WaitOne();                    // Wait for notification
            Console.WriteLine("Notified!");
        }


    }

}
