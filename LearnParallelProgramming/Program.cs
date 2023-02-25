namespace LearnParallelProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntroducingTask.CreateAndStartSimpleTasks();
            //IntroducingTask.TasksWithState();
            //IntroducingTask.TasksWithReturnValues();

            Console.WriteLine("Main program done, press any key.");
            Console.ReadKey();
        }
    }
}