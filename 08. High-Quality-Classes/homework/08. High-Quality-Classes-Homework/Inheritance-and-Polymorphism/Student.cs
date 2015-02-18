using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    class Student : IStudent
    {
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
        }
    }
}
