using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnParallelProgramming.LearnTask
{
    public class WaitTaskFinish
    {
        public static void Test()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("I will take 5 seconds");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("t is wake up!");
            }, token);
            t.Start();

            Task t2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("t2 is wake up!");
            }, token);
            //Task.WaitAny(t2)
            //Task.WaitAll(t, t2);
            Task.WaitAny(new[] { t, t2 }, 4000, token);
            // aT this moment, t1 is not finish, while t2 is done
            Console.WriteLine($"Task t status is {t.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");
        }

    }
}
