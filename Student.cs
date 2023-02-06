using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace study
{
    class Student
    {
        public Guid id; // поля - переменные, которые содержатся в классе
        public string? FIO;
        public int day;
        public int month;
        public int year;
        public string? group;
        public List<string?> subject;
        public List<int?> mark;
        public void Print(int a)
        {
            Console.WriteLine($"\t\t Студент № {a}: ");
            Console.WriteLine($"ФИО: {FIO}");
            DateTime date1 = new DateTime(year, month, day);
            Console.WriteLine($"Дата рождения: {date1.ToShortDateString()}");
            Console.WriteLine($"Группа: {group}");
            Console.WriteLine("Успеваемость: ");
            for (int i = 0; i < subject.Count; i++)
            {
                Console.WriteLine($" {subject[i]} - {mark[i]}");
            }
            Console.WriteLine();
        }
    }
}
