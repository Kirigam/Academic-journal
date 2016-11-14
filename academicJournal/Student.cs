using System;

namespace academicJournal
{
    class Student
    {
        public string name, lastName, patronymic, academicGroup;

        public Student(string name, string lastName, string patronymic, string academicGroup)
        {

            this.name = name;
            this.lastName = lastName;
            this.patronymic = patronymic;
            this.academicGroup = academicGroup;
        }

        static public string validation(string value)
        {
            if ((value.Length < 3) || (value.Length > 12))
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Entered the field too short, keep data again\n");
                    Program.menu();
                }
                else
                {
                    Console.WriteLine("Entered the field too long, keep data again\n");
                    Program.menu();
                }
            }

            char[] a = value.ToCharArray();
            foreach (char c in a)
            {
                if (!(Char.IsLetter(c)))
                {
                    Console.WriteLine("Incorrect input, enter the desired destination again:\n");
                    Program.menu();
                }
            }

            string[] s = value.Split(' ');
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                else s[i] = s[i].ToUpper();
            }
            value = string.Join(" ", s);

            return value;
        }
    }
}
