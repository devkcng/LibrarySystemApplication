namespace UsersClassLibrary
{
    public class Borrower : Person
    {
        public Borrower(string id, string name, string address, string age, string violations)
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
            this.Violations = violations;
        }
        public string Violations {  get; set; }

        public new string Id { get; set; }
    }
}