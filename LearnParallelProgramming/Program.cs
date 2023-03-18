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
            //================Token
            LearnTaskCancelToken.CancelTask();
            Console.WriteLine($"\nIn Main:  {Task.CurrentId} processing ...");
            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
}