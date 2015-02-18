using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Teacher : ITeacher
    {
        public string TeacherName { get; private set; }

        public List<ICourse> Courses { get; set; }

        public Teacher(string name)
        {
            this.TeacherName = name;
        }
    }
}
