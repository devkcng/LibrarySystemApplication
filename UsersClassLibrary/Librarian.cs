namespace UsersClassLibrary
{
    public class Librarian : Person
    {   
        public new string Id { get; set; }
        public Librarian(string id, string name, string address, string age)
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
        }
        
    }
}