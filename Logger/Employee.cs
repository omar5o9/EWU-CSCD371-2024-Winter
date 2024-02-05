
namespace Logger
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public string Department { get; set; }

        // Comment: Inheriting from Person to reuse the common code for FirstName, LastName, and FullName.
    }
}
