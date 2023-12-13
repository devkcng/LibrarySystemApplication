namespace UsersClassLibrary
{
    public class Borrower : Person
    {
        public new string Id { get; set; }

        public Borrower(string id, string name, string address, string age)
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
        }
        
    }
}