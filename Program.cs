﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            students.Add(new Student { First = "Nikita", Last = "Smirnov", ID = 123, Scores = new List<int> { 100, 100, 100, 70 } });

            //Упорядочение результатов
            //IEnumerable<Student> studentQuery =
                //from student in students
                //where student.Scores[0] > 90 && student.Scores[3] < 80
                //orderby student.Scores[0] descending
                //select student;

            // foreach (Student student in studentQuery)
            // {
            //    Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            // }
            //

            //Группировка результатов

            //var studentQuery2 =
            //    from student in students
            //    group student by student.Last[0];
            //
            //foreach (var studentGroup in studentQuery2)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    foreach (Student student in studentGroup)
            //    {
            //        Console.WriteLine("   {0}, {1}",
            //                  student.Last, student.First);
            //    }
            //}

            //Преобразование переменных в явно типизированные

            //var studentQuery3 =
            //    from student in students
            //    group student by student.Last[0];

            //foreach (var groupOfStudents in studentQuery3)
            //{
            //    Console.WriteLine(groupOfStudents.Key);
            //    foreach (var student in groupOfStudents)
            //    {
            //        Console.WriteLine("   {0}, {1}",
            //            student.Last, student.First);
            //    }
            //}
            //
            //Упорядочение групп по значению ключа

            //var studentQuery4 =
            //    from student in students
            //    group student by student.Last[0] into studentGroup
            //    orderby studentGroup.Key
            //    select studentGroup;

            //foreach (var groupOfStudents in studentQuery4)
            //{
            //    Console.WriteLine(groupOfStudents.Key);
            //    foreach (var student in groupOfStudents)
            //    {
            //        Console.WriteLine("   {0}, {1}",
            //            student.Last, student.First);
            //    }
            //}
            //
            //Введение индетификатора с помощью let

            //var studentQuery5 =
            //    from student in students
            //    let totalScore = student.Scores[0] + student.Scores[1] +
            //        student.Scores[2] + student.Scores[3]
            //    where totalScore / 4 < student.Scores[0]
            //    select student.Last + " " + student.First;

            //foreach (string s in studentQuery5)
            //{
            //    Console.WriteLine(s);
            //}
            //

            //Использование синтаксиса метода в выражении запроса

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3] // Сумма баллов
                select totalScore; // Выбор по totalScore

            double averageScore = studentQuery6.Average(); // Вычисление среднего int значения
            //Console.WriteLine("Class average score = {0}", averageScore);

            //

            //Преобразование или проецирование в предложение select

            //IEnumerable<string> studentQuery7 =
            //    from student in students
            //    where student.Last == "Garcia"
            //    select student.First;

            //Console.WriteLine("The Garcias in the class are:");
            //foreach (string s in studentQuery7)
            //{
            //    Console.WriteLine(s);
            //}

            //

            //Вывод ID студента и его баллы используя select

            //var studentQuery8 =
            //    from student in students
            //    let x = student.Scores[0] + student.Scores[1] +
            //        student.Scores[2] + student.Scores[3] // Сумма баллов студента
            //    where x > averageScore
            //    select new { id = student.ID, score = x }; // new - создает уникальные переменные для каждого выбранного студента

            //Console.WriteLine("Average score : {0}", averageScore);

            //foreach (var item in studentQuery8)
            //{   
            //    Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score); // "{0}, {1}" - номера параметров после " "
            //}


            //

            //Свой пример - тот же предыдущий вывод только с выводом имени и фамилии

            var studentQuery9 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3] // Сумма баллов студента
                where x > averageScore
                select new { id = student.ID, score = x, first = student.First, last = student.Last }; // new - создает уникальные переменные для каждого выбранного студента

            Console.WriteLine("Average score : {0}", averageScore);

            foreach (var item in studentQuery9)
            {
                Console.WriteLine("Student: {2} {3}, Student ID: {0}, Score: {1}", item.id, item.score, item.first, item.last); // "{0}, {1}" - номера параметров после " "
            }

            //
            Console.Read();
        }

        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

    }
    
}
