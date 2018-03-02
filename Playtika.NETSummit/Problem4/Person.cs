namespace Playtika.NETSummit.Problem4
{
    // Change positions of parameters in Deconstruct
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
