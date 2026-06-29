using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeTracker
{
    public class GradeTracker
    {
        public static void FindHighestAndLowestAverage()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No students found! Add some students first.");
                return;
            }

            string highestStudent = "";
            string lowestStudent = "";
            double highestAve = double.MinValue;
            double lowestAve = double.MaxValue;
            bool hasValidGrades = false;

            foreach (var student in Students)
            {
                // Make sure the student actually has grades inputted
                if (student.Value.Count > 0)
                {
                    hasValidGrades = true;
                    double currentAve = student.Value.Average();

                    if (currentAve > highestAve)
                    {
                        highestAve = currentAve;
                        highestStudent = student.Key;
                    }
                    if (currentAve < lowestAve)
                    {
                        lowestAve = currentAve;
                        lowestStudent = student.Key;
                    }
                }
            }

            if (!hasValidGrades)
            {
                Console.WriteLine("Students exist, but no grades have been entered yet!");
                return;
            }

            Console.WriteLine("==================================");
            Console.WriteLine($"HIGHEST AVERAGE: {highestStudent} ({highestAve})");
            Console.WriteLine($"LOWEST AVERAGE:  {lowestStudent} ({lowestAve})");
            Console.WriteLine("==================================");
        }
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
            Console.WriteLine($"\n{studentName}");
            Console.WriteLine($"MATH:       {Students[studentName][0]}");
            Console.WriteLine($"ENGLISH:    {Students[studentName][1]}");
            Console.WriteLine($"SCIENCE:    {Students[studentName][2]}");
            Console.WriteLine($"AP:         {Students[studentName][3]}");
            Console.WriteLine($"FILIPINO:   {Students[studentName][4]}");
            Console.WriteLine($"AVERAGE GRADE: {Students[studentName].Average()}");
        }
        public static void Main(String[] args)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("===========GRADE TRACKER==========");
                Console.WriteLine("[1]  ADD STUDENT");
                Console.WriteLine("[2]  ADD GRADES  ");
                Console.WriteLine("[3]  SHOW STUDENT AVERAGE GRADE");
                Console.WriteLine("[4]  SHOW ALL STUDENTS AND THERE AVERAGE GRADE");
                Console.WriteLine("[5]  FIND HIGHEST AND LOWEST AVERAGE");
                Console.WriteLine("[0]  EXIT");
                int nav;
                if (!int.TryParse(Console.ReadLine(), out nav))
                {
                    System.Console.WriteLine("invalid action");
                }
                else
                {
                    if (nav > 5)
                    { System.Console.WriteLine("invalid action"); }
                    else
                    {
                        switch (nav)
                        {
                            case 0:
                                active = false;
                                break;
                            case 1:
                                Console.Clear();
                                AddStudents();
                                break;
                            case 2:
                                Console.Clear();
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
                            case 4:
                                Console.Clear();
                                foreach (var student in Students)
                                {
                                    ShowAve(student.Key);
                                }
                                break;
                            case 5:
                                Console.Clear();
                                FindHighestAndLowestAverage();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}