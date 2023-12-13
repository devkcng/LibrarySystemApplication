namespace UsersClassLibrary
{
    public class Librarian : Person
    {
        public Librarian(string id, string name, string address, string age)
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
        }

        public new string Id { get; set; }
    }
}