using System;
using DemoData.Repository;
using DemoData.Model;

namespace NHibernetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                "Data Source=.\\SQLEXPRESS;Initial Catalog=NHibernateDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            IStudentRepository repository = new StudentRepository(connectionString);

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
                ID = 1,
                FirstName = "Test 2",
                LastName = "Test 2"
            };
            repository.UpdateStudent(studentToUpdate);


            var allStudents = repository.GetAllStudents();
            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }

            Console.ReadLine();
        }
    }
}
