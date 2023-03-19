using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnParallelProgramming.LearnTask
{
    public class WaitingTaskTime
    {
        public static void Wait()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                //Thread.Sleep(1000);// will wait here and tell system I am not need task here, another task can run
                //SpinWait.SpinUntil(,);  // using SpinWait
                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);// the return value will tell if it is end by cancel or not
                Console.WriteLine(cancelled ? "Boob disarmed." : "BOOM!!!");
            }, token);
            t.Start();
            Console.ReadKey();// this one also block main thread
            cts.Cancel();
        }
    }
}
