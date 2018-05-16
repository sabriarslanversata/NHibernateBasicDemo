using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoData.Model;
using FluentNHibernate.Mapping;

namespace DemoData.Mapping
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.ID);

            Map(x => x.FirstName)
              .Length(30)
              .Not.Nullable();

            Map(x => x.LastName)
                .Length(30)
                .Nullable();
        }
    }
}
