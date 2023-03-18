using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnParallelProgramming.LearnTask
{
    internal class LearnTaskCancelToken
    {
        public static void CancelTask()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();//canonical way to recommand to use
                    Console.WriteLine($"{i++}\t");
                }
            }, token);
            t.Start();
            Console.WriteLine("press one key to stop");
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("this method is over!");
        }
    }
}
