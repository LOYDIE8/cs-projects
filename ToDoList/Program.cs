using System;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.Arm;

namespace ToDo
{
    class ToDoList
    {
        public class Task
        {
        public String Goal { get; set;}
        public String IsDone { get; set;}

        public Task(String goal, String isDone)
            {
                Goal = goal;
                IsDone = isDone;
            }
        }
        public static void Main(String[] args)
        {
            List<Task> tasks = new List<Task>();
            int loop = 0;
            System.Console.WriteLine("Welcome to our to do list bullshit");
            while(loop == 0){
                System.Console.WriteLine("please choose an action:");
                System.Console.WriteLine("[1] Show Tasks\n[2] Add Tasks\n[3] Change Task Status\n[4] Delete tasks\n[5] Exit");
                int action;
                if (!int.TryParse(Console.ReadLine(), out action))
                {
                    System.Console.WriteLine("INVALID ACTION");
                }
                switch (action)
                {
                    case 1:
                    System.Console.WriteLine("====TASKS==========STATUS====");
                    foreach(Task task in tasks)
                        {
                            System.Console.WriteLine($"{task.Goal}              {task.IsDone}");
                        }
                    System.Console.WriteLine("\n\n");
                    break;
                    case 2:
                    System.Console.WriteLine("PLEASE ENTER TASK NAME");
                    tasks.Add(new Task(Console.ReadLine() ?? "error", "not done"));
                    break;
                    case 3:
                     System.Console.WriteLine("==#====TASKS==========STATUS====");
                     int i = 0;
                    foreach(Task task in tasks)
                        {
                            System.Console.WriteLine($"[{i}]    {task.Goal}              {task.IsDone}");
                            i++;
                        }
                    System.Console.WriteLine("PLEASE CHOOSE WHAT TASK TO CHANGE STATUS");
                    int index;
                    if(!int.TryParse(Console.ReadLine(), out index)) { Console.WriteLine("invalid number bobo"); break; }
                    if(index > tasks.Count){System.Console.WriteLine("wala naman sa choices yan eh bobo"); break;}
                    System.Console.WriteLine("Please enter new status");
                    tasks[index].IsDone = Console.ReadLine()?? "not done";
                    break;
                    case 4:
                    System.Console.WriteLine("==#====TASKS==========STATUS====");
                    i = 0;
                    foreach(Task task in tasks)
                        {
                            
                            System.Console.WriteLine($"[{i}]    {task.Goal}              {task.IsDone}");
                            i++;
                        }
                    System.Console.WriteLine("PLEASE CHOOSE WHAT TASK TO REMOVE");
                    if(!int.TryParse(Console.ReadLine(), out index)) { Console.WriteLine("invalid number bobo"); break; }
                    if(index > tasks.Count){System.Console.WriteLine("wala naman sa choices yan eh bobo"); break;}
                    tasks.RemoveAt(index);
                    break;
                    case 5:
                    loop = 1;
                    break;
                    default:
                    System.Console.WriteLine("Error");
                    loop = 1;
                    break;
                }
            }
        }
    }
}