namespace TicketApplication
{
    public class Person
    {
        // first name and last name 
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}