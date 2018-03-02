namespace Playtika.NETSummit.Problem4
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string lastName, out string firstName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
