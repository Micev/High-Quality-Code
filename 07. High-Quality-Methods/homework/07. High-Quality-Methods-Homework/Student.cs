using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string birthdayDate { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate =
                DateTime.Parse(this.birthdayDate);
            DateTime secondDate =
                DateTime.Parse(other.birthdayDate);
            return firstDate < secondDate;
        }
    }
}
