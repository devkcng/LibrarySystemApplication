using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersClassLibrary
{
    public class Person
    {
        string name;
        string age;
        public string Name { get { return name; } set { name = value; } }
        public string Age { get { return age; } set { age = value; } }
    }
}
