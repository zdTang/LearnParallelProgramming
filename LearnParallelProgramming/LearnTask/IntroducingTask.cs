﻿namespace LearnParallelProgramming.LearnTask
{
    public static class IntroducingTask
    {
        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(object s)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(s.ToString());
            }
        }

        public static void CreateAndStartSimpleTasks()
        {
            // a Task is a unit of work in .NET land

            // here's how you make a simple task that does something
            Task.Factory.StartNew(() =>
            {
                //Console.WriteLine("Hello, Tasks!");
                Write('-');
            });

            // the argument is an action, so it can be a delegate, a lambda or an anonymous method

            Task t = new Task(() => Write('?'));
            t.Start(); // task doesn't start automatically!

            // this is synchronous main thread -- Mike
            // withouting this line, the code in main funciton will be excuted before those two tasks
            Write('.');
        }


        public static int TextLength(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object '{o}'...");
            return o.ToString().Length;
        }

        public static void TasksWithReturnValues()
        {
            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();
            var task2 = Task.Factory.StartNew(TextLength, text2);
            // getting the result is a blocking operation!
            Console.WriteLine($"Length of '{text1}' is {task1.Result}.");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}.");
        }

        public static void TasksWithState()
        {
            // clumsy 'object' approach
            Task t = new Task(Write, "foo");
            t.Start();
            Task.Factory.StartNew(Write, "bar");
        }

        // Summary:

        // 1. Two ways of using tasks
        //    Task.Factory.StartNew() creates and starts a Task
        //    new Task(() => { ... }) creates a task; use Start() to fire it
        // 2. Tasks take an optional 'object' argument
        //    Task.Factory.StartNew(x => { foo(x) }, arg);
        // 3. To return values, use Task<T> instead of Task
        //    To get the return value. use t.Result (this waits until task is complete)
        // 4. Use Task.CurrentId to identify individual tasks.
    }
}

