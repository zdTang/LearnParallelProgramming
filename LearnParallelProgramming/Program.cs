using LearnParallelProgramming.LearnTask;

namespace LearnParallelProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task
            //IntroducingTask.CreateAndStartSimpleTasks();
            //IntroducingTask.TasksWithState();
            //IntroducingTask.TasksWithReturnValues();
            //================Cancel Token  =======
            //LearnTaskCancelToken.CancelTask();
            //== Waiting some time
            //WaitingTaskTime.Wait();
            //WaitTaskFinish.Test();
            try
            {
                TaskException.Test();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                    Console.WriteLine($"Exception {e.GetType} from {e.Source}");
            }

            Console.WriteLine($"\nBack to Main:  {Task.CurrentId} processing ...");
            Console.ReadKey();
            Console.WriteLine("Main program done, press any key.");
        }
    }
}