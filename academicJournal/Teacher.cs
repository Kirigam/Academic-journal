using System;
using System.Collections.Generic;
using System.Linq;

namespace academicJournal
{
    class Teacher
    {
        public string name, lastName;
        static List<Student> studentList = new List<Student>(4);
        static Teacher[] teacherList = new Teacher[] { };

        public Teacher(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        static public void addTeacher(string name, string lastName)
        {
            name = Student.validation(name);
            lastName = Student.validation(lastName);

            Array.Resize(ref teacherList, teacherList.Length + 1);
            teacherList[teacherList.Length - 1] = new Teacher(name, lastName);
            Console.WriteLine("Teachers successfully added to list\n");
            Program.menu();
        }

        static public void addStudent()
        {
            if (teacherList.Length == 0)
            {
                Console.WriteLine("First, add teacher\n");
                Program.menu();
            }

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter patronymic: ");
            string patronymic = Console.ReadLine();
            Console.Write("Enter academic group: ");
            string academicGroup = Console.ReadLine();

            Console.Clear();
            name = Student.validation(name);
            lastName = Student.validation(lastName);
            patronymic = Student.validation(patronymic);

            studentList.Add(new Student(name, lastName, patronymic, academicGroup));
            Console.WriteLine("Students successfully added to list\n");
            Program.menu();
        }

        static public void remove()
        {
            show();

            Console.Write("\nEnter number student: ");
            string i = Console.ReadLine();
            int value = Int32.Parse(i);
            value = value - 1;
            if (value >= 0 && value < studentList.Count)
            {
                Console.Clear();
                studentList.RemoveAt(value);
                Console.WriteLine("Students successfully removed from the list\n");
                Program.menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect input, enter the desired destination again:\n");
                Program.menu();
            }
        }

        static public void sort()
        {
            studentList.Sort(delegate(Student s1, Student s2)
            { return s1.lastName.CompareTo(s2.lastName); });
        }

        static public void showStudent()
        {
            Console.Clear();

            if (studentList.Count == 0)
            {
                Console.WriteLine("List is empty, fill it first\n");
                Program.menu();
            }

            var teacher = from a in teacherList select a.lastName + " " + a.name;
            int i = 0;
            foreach (var s in teacher)
            {
                i++;
                Console.WriteLine("{0} {1}", i, s);
            }

            Console.Write("Select for teachers which will display a list of students: ");
            string choice = Console.ReadLine();
            int value = Int32.Parse(choice);
            if (value < 1 || value > teacherList.Length)
            {
                Console.Clear();
                Console.WriteLine("Incorrect input, enter the desired destination again:\n");
                Program.menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0} {1}:\n", teacherList[value - 1].lastName, teacherList[value - 1].name);
                show();
            }
        }

        static private void show()
        {

            if (studentList.Count == 0)
            {
                Console.WriteLine("List is empty, fill it first\n");
                Program.menu();
            }

            sort();

            var student = from t in studentList select t.lastName + " " + t.name + " " + t.patronymic + " " + t.academicGroup;
            int j = 0;
            foreach (var q in student)
            {
                j++;
                Console.WriteLine("{0}. {1}", j, q);
            }
        }
    }
}
