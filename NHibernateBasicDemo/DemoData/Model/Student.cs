namespace DemoData.Model
{
    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public override string ToString()
        {
            return string.Format($"{ID} - {FirstName} {LastName}");
        }
    }
}