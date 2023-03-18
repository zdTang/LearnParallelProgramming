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
            // it's possible to create a 'composite' cancelation source that involves several tokens
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            // make a token source that is linked on their tokens
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
              planned.Token, preventative.Token, emergency.Token);
            // Register a notification once cancel a Task
            paranoid.Token.Register(() =>
            {
                Console.WriteLine("Notification: thread is cancelled");
                Console.WriteLine($"\nIn token.Register:  {Task.CurrentId} processing ...");
            });

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();//canonical way to recommand to use
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
            }, paranoid.Token);
            t.Start();

            // Another Task start when the Task is cancelled ????
            Task.Factory.StartNew(() =>
                {
                    paranoid.Token.WaitHandle.WaitOne();
                    Console.WriteLine($"\nIn WaitHandle:  {Task.CurrentId} processing ...");
                    Console.WriteLine("Wait handle released, cancelation was requested");
                }
            );

            Console.WriteLine("press one key to stop");
            Console.ReadKey();
            planned.Cancel();
            Console.WriteLine("this method is over!");
        }
    }
}
