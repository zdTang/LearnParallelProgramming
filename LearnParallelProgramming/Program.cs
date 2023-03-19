﻿using LearnParallelProgramming.LearnTask;

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
            WaitingTask.Wait();
            Console.WriteLine($"\nIn Main:  {Task.CurrentId} processing ...");
            Console.WriteLine("Main program done, press any key.");
        }
    }
}