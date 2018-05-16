

namespace DemoData.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using DemoData.Model;
    using FluentNHibernate.Cfg;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;


    public class StudentRepository : IStudentRepository
    {
        private readonly Configuration _configuration;

        public ISessionFactory SessionFactory { get; }

        private static ISessionFactory CreateSessionFactory(Configuration configuration)
        {
            return Fluently
                     .Configure(configuration)
                     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentRepository>())
                     .BuildSessionFactory();
        }

        public StudentRepository(string connectionString)
        {
            _configuration = new Configuration();
            _configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            //_configuration.AddAssembly(Assembly.GetExecutingAssembly());
            SessionFactory = CreateSessionFactory(_configuration);

        }

        public Student CreateSutdent(Student student)
        {
            using (var session = SessionFactory.OpenSession())
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
            var result = new List<Student>();

            using (var session = SessionFactory.OpenSession())
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
            Student result;

            using (var session = SessionFactory.OpenSession())
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
            using (var session = SessionFactory.OpenSession())
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
            using (var session = SessionFactory.OpenSession())
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
