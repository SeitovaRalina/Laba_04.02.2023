using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace study
{
    // методы объекта класса
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                Console.WriteLine("\t\t Меню");
                Console.WriteLine("1. Заполнение");
                Console.WriteLine("2. Студенты, которые учатся в заданной группе");
                Console.WriteLine("3. Студенты - должники");
                Console.WriteLine("4. Студенты - отличники");
                Console.WriteLine("5. Студенты моложе 20 лет");
                Console.WriteLine("6. Выход");
                int str = "2. Студенты, которые учатся в заданной группе    ".Length;
                Console.SetCursorPosition(str, 1);
                bool bup = true, check = true;
                int c = 1;
                while (bup == true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter && c == 1)
                    {
                        bup = false;
                        Console.Clear();
                        string s = "";
                            while (s != "стоп")
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t Добавление информации о новых студентах");
                                Student student = new Student();
                                Console.Write($"ФИО: ");
                                student.FIO = Console.ReadLine();
                                Console.Write($"Дата рождения: \n- день ");
                                student.day = int.Parse(Console.ReadLine());
                                Console.Write("- месяц ");
                                student.month = int.Parse(Console.ReadLine());
                                Console.Write("- год ");
                                student.year = int.Parse(Console.ReadLine());
                                Console.Write($"Группа: ");
                                student.group = Console.ReadLine();
                                Console.WriteLine("Успеваемость: ");
                                string a = "";
                                student.subject = new List<string>();
                                student.mark = new List<int?>();
                                while (a != "стоп")
                                {
                                    Console.Write("Предмет: ");
                                    string? sub = Console.ReadLine();
                                    student.subject.Add(sub);
                                    Console.Write(" оценка: ");
                                    int? m = int.Parse(Console.ReadLine());
                                    student.mark.Add(m);
                                    Console.Write("\nДля остановки ввода успеваемости введите \"стоп\": ");
                                    a = Console.ReadLine();
                                }
                                students.Add(student);
                                Console.Write("\nДля остановки введите \"стоп\": ");
                                s = Console.ReadLine();
                            }
                    }
                    if (key.Key == ConsoleKey.Enter && c == 2)
                    {
                        bup = false;
                        Console.Clear();
                        for (int i = 0; i < students.Count; i++)
                        {
                            students[i].Print(i+1);
                        }
                        Console.Write("Выберите группу: ");
                        string name = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"\t\t Студенты, которые учатся в группе {name}");
                        Console.WriteLine();
                        check = true;
                        for (int i=0; i< students.Count;i++)
                        {
                            if (students[i].group == name)
                            {
                                check = false;
                                students[i].Print(i+1);
                            }  
                        }
                        if (check) Console.WriteLine("Нет данных:(");
                    }
                    if (key.Key == ConsoleKey.Enter && c == 3)
                    {
                        bup = false;
                        Console.Clear();
                        Console.WriteLine("\t\t Студенты-должники");
                        Console.WriteLine();
                        check = true;
                        for (int i = 0; i < students.Count; i++)
                        {
                            for (int j = 0; j < students[i].mark.Count; j++)
                            {
                                if (students[i].mark[j] == 2 || students[i].mark[j] == null)
                                {
                                    check = false;
                                    students[i].Print(i + 1);
                                    break;
                                }
                            }
                        }
                        if (check) Console.WriteLine("Нет данных:(");
                    }
                    if (key.Key == ConsoleKey.Enter && c == 4)
                    {
                        bup = false;
                        Console.Clear();
                        Console.WriteLine("\t\t Студенты - отличники");
                        Console.WriteLine();
                        check = true;
                        int cnt5;
                        for (int i = 0; i < students.Count; i++)
                        {
                            cnt5 = 0;
                            for (int j = 0; j < students[i].mark.Count; j++)
                            {
                                if (students[i].mark[j] == 5) cnt5++;
                            }
                            if (cnt5 == students[i].mark.Count)
                            {
                                students[i].Print(i + 1);
                                check = false;
                            }
                        }
                        if (check) Console.WriteLine("Нет данных:(");
                    }
                    if (key.Key == ConsoleKey.Enter && c == 5)
                    {
                        bup = false;
                        Console.Clear();
                        Console.WriteLine("\t\t Студенты моложе 20 лет");
                        Console.WriteLine();
                        string dr;
                        check = true;
                        for (int i = 0; i < students.Count; i++)
                        {
                            var date = new DateTime(students[i].year, students[i].month, students[i].day);
                            var age = DateTime.Now.Year - date.Year;
                            if (DateTime.Now.Month < date.Month ||
                               (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)) age--;
                            if (age < 20)
                            {
                                check = false;
                                students[i].Print(i + 1);
                            }
                        }
                        if (check) Console.WriteLine("Нет данных:(");
                    }
                    if (key.Key == ConsoleKey.Enter && c == 6)
                    {
                        bup = false;
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 6) || (key.Key == ConsoleKey.UpArrow && c == 2))
                    {
                        Console.SetCursorPosition(str, 1);
                        c = 1;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 1) || (key.Key == ConsoleKey.UpArrow && c == 3))
                    {
                        Console.SetCursorPosition(str,2);
                        c = 2;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 2) || (key.Key == ConsoleKey.UpArrow && c == 4))
                    {
                        Console.SetCursorPosition(str, 3);
                        c = 3;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 3) || (key.Key == ConsoleKey.UpArrow && c == 5))
                    {
                        Console.SetCursorPosition(str, 4);
                        c = 4;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 4) || (key.Key == ConsoleKey.UpArrow && c == 6))
                    {
                        Console.SetCursorPosition(str, 5);
                        c = 5;
                    }
                    else if ((key.Key == ConsoleKey.DownArrow && c == 5) || (key.Key == ConsoleKey.UpArrow && c == 1))
                    {
                        Console.SetCursorPosition(str, 6);
                        c = 6;
                    }
                }
                if (c != 6)
                {
                    Console.Write("Вернуться назад? ");
                    ConsoleKeyInfo key1 = Console.ReadKey();
                    Console.Clear();
                }
                else Console.CursorVisible = true;
            }
        }
    }
}