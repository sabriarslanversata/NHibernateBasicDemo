using System;
using NHibernetDemo.Models;
using NHibernetDemo.Services;

namespace NHibernetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                "Data Source=.;Initial Catalog=NHibernateDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var studentService = new StudentService(connectionString);

            //var newStudent = studentService.CreateSutdent(new Student
            //{
            //    FirstName = "Ziyad",
            //    LastName = "Abd Alfattah"
            //});

            //Console.WriteLine(newStudent.ToString());

            //var allStudents = studentService.GetAllStudents();
            //foreach (var student in allStudents)
            //{
            //    Console.WriteLine(student.ToString());
            //}

            //var studentById = studentService.GetStudentById(1);
            //Console.WriteLine(studentById);

            //Update Student (id: 1)
            var studentToUpdate = new Student
            {
                ID = 2,
                FirstName = "Test 1",
                LastName = "Test 2"
            };
            studentService.UpdateStudent(studentToUpdate);


            var allStudents = studentService.GetAllStudents();
            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }

            Console.ReadLine();
        }
    }
}
