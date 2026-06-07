using System;
using System.Collections.Generic;

namespace GradeTracker
{
    public class GradeTracker
    {
        public static Dictionary<String, List<int>> Students = new Dictionary<String, List<int>>();

        public static void AddStudents()
        {
            System.Console.WriteLine("Enter Student name:");
            String studentName = Console.ReadLine() ?? "";
            if (String.IsNullOrWhiteSpace(studentName))
            {
                System.Console.WriteLine("ERROR INVALID INPUT!");
                return;
            }
            else if (Students.ContainsKey(studentName))
            {
                System.Console.WriteLine("ERROR STUDENT ALREADY EXIST!");
                return;
            }
            else
            {
                Students.Add(studentName, new List<int> { });
            }
        }

        public static void AddGrades()
        {
            System.Console.WriteLine("Enter Students name you wish to input grades on: ");
            String studentName = Console.ReadLine() ?? "";
            if (String.IsNullOrWhiteSpace(studentName))
            {
                System.Console.WriteLine("ERROR INVALID INPUT!");
                return;
            }
            else if (!Students.ContainsKey(studentName))
            {
                System.Console.WriteLine("ERROR STUDENT DOESN'T EXIST!");
                return;
            }
            else
            {
                System.Console.WriteLine("enter grades\n");
                System.Console.WriteLine("MATH: ");
                int math = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("ENGLISH: ");
                int eng = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("SCIENCE: ");
                int science = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("AP: ");
                int ap = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("FILIPINO: ");
                int filipino = Convert.ToInt32(Console.ReadLine());
                Students[studentName].AddRange(new int[] { math, eng, science, ap, filipino });
            }
        }
        public static void ShowAve(string studentName)
        {
            var allgrades = Students[studentName];

        }
        public static void Main(String[] args)
        {
            //    students.Add("lloyd", new List<int>{});
            //    students["lloyd"].Add(10);
            //    students["lloyd"].Add(9);
            //    students["lloyd"].Add(120);
            //    students["lloyd"].Add(103);
            //    System.Console.WriteLine($"{string.Join("",students.Keys)}");
            //    var allGrades = students.Values.SelectMany(x => x);
            //    System.Console.WriteLine($"{string.Join(", ", allGrades)}");

            Console.WriteLine("===========GRADE TRACKER==========");
            Console.WriteLine("[1]  ADD STUDENT");
            Console.WriteLine("[2]  ADD GRADES  ");
            Console.WriteLine("[3]  SHOW STUDENT AVERAGE GRADE");
            Console.WriteLine("[4]  SHOW ALL STUDENTS AND THERE AVERAGE GRADE");
            Console.WriteLine("[5]  FIND HIGHEST AND LOWEST AVERAGE");
            int nav;
            if (!int.TryParse(Console.ReadLine(), out nav))
            {
                if (nav > 5) { System.Console.WriteLine("invalid action"); }
            }
            switch (nav)
            {
                case 1:
                    AddStudents();
                    break;
                case 2:
                    AddGrades();
                    break;
                case 3:
                    System.Console.WriteLine("Enter Students name: ");
                    String studentName = Console.ReadLine() ?? "";
                    if (String.IsNullOrWhiteSpace(studentName))
                    {
                        System.Console.WriteLine("ERROR INVALID INPUT!");
                        return;
                    }
                    else if (!Students.ContainsKey(studentName))
                    {
                        System.Console.WriteLine("ERROR STUDENT DOESN'T EXIST!");
                        return;
                    }
                    else
                    {
                        ShowAve(studentName);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}