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
            // Register a notification once cancel a Task
            token.Register(() =>
            {
                Console.WriteLine("Notification: thread is cancelled");
                Console.WriteLine($"\nIn token.Register:  {Task.CurrentId} processing ...");
            });

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

            // Another Task start when the Task is cancelled ????
            Task.Factory.StartNew(() =>
                {
                    token.WaitHandle.WaitOne();
                    Console.WriteLine($"\nIn WaitHandle:  {Task.CurrentId} processing ...");
                    Console.WriteLine("Wait handle released, cancelation was requested");
                }
            );

            Console.WriteLine("press one key to stop");
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("this method is over!");
        }
    }
}
