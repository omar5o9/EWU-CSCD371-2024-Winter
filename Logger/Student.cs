

namespace Logger
{
    public class Student : Person
    {
        public int StudentId { get; set; }

        // Comment: Inheriting from Person to reuse the common code for FirstName, LastName, and FullName.
    }
}
