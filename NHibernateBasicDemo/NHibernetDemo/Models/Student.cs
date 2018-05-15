namespace NHibernetDemo.Models
{
    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", ID, FirstName, LastName);
        }
    }
}