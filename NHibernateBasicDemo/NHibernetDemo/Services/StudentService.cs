using System.Collections.Generic;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernetDemo.Models;

namespace NHibernetDemo.Services
{
    /// <summary>
    /// A class that represents the implementation of CRUD operations on Student table.
    /// </summary>
    public class StudentService
    {
        private readonly Configuration _configuration;

        public StudentService(string connectionString)
        {
            _configuration = new Configuration();
            _configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            _configuration.AddAssembly(Assembly.GetExecutingAssembly());
        }

        public Student CreateSutdent(Student student)
        {
            var sefact = _configuration.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(student);
                    tx.Commit();
                }
            }

            return student;
        }

        public List<Student> GetAllStudents()
        {
            var sefact = _configuration.BuildSessionFactory();
            var result = new List<Student>();

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    result = session.CreateCriteria<Student>().List<Student>() as List<Student>;

                    tx.Commit();
                }
            }

            return result;
        }

        public Student GetStudentById(int id)
        {
            var sefact = _configuration.BuildSessionFactory();
            Student result;

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    result = session.Get<Student>(id);

                    tx.Commit();
                }
            }

            return result;
        }

        public Student UpdateStudent(Student student)
        {
            var sefact = _configuration.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Update(student);

                    tx.Commit();
                }
            }

            return student;
        }

        public void DeleteStudent(int id)
        {
            var sefact = _configuration.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var student = session.Get<Student>(id);
                    session.Delete(student);

                    tx.Commit();
                }
            }
        }
    }
}