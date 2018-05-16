using DemoData.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoData.Repository
{
    public interface IStudentRepository
    {
        Student CreateSutdent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
