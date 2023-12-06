using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UsersClassLibrary
{
    public class Borrower: Person
    {
        string id;
        string address;
        public string Id { get { return id; } set { id = value; } }
        public string Address { get { return address; } set { address = value; } }
        public Borrower(string id, string name,string address,string age) 
        {
            Id = id;
            Address = address;
            Name = name;
            Age = age;
        }

    }
}
