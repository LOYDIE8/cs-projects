using System;

namespace ToDo
{
    class ToDoList
    {
        public class Task
        {
        public String Goal { get; set;}
        public String Status { get; set;}

        public Task(String goal, String status)
            {
                Goal = goal;
                Status = status;
            }
        }

        public static void Main(String[] args)
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(new Task("clean house", "not done"));
            System.Console.WriteLine($"{tasks[0].Goal} {tasks[0].Status} ");
        }
    }
}