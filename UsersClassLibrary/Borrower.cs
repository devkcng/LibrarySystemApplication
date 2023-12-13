namespace UsersClassLibrary
{
    public class Borrower : Person
    {
        public Borrower(string id, string name, string address, string age)
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
        }

        public new string Id { get; set; }
    }
}