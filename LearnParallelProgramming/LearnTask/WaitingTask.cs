using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnParallelProgramming.LearnTask
{
    public class WaitingTask
    {
        public static void Wait()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Thread.Sleep(1000);// will wait here and tell system I am not need task here, another task can run
                Console.WriteLine("After sleep--");
                Console.ReadKey();
            });
            t.Start();
        }
    }
}
