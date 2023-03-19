using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnParallelProgramming.LearnTask
{
    public class TaskException
    {
        public static void Test()// Don't put "async" if there is no "await" in the method
        {
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Can't do this") { Source = "t" };
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Can't access this") { Source = "t2" };
            });
            // Here, we don't wait
            // the Main thread will go first, so that those EXCEPTION WILL NOT DISPLAY
            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                //foreach (var e in ae.InnerExceptions)
                //    Console.WriteLine($"Exception {e.GetType} from {e.Source}");
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;  // Means this Exception will be handled here
                    }
                    return false; // will not handled here, will throw
                });
            }
        }
    }
}
