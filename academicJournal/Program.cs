using System;

namespace academicJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
            Console.ReadKey();
        }

        static public void menu()
        {
            Console.WriteLine("1.Add teacher");
            Console.WriteLine("2.Add student");
            Console.WriteLine("3.Remuve student");
            Console.WriteLine("4.Show student");
            Console.WriteLine("5.Exit");
            Console.Write("Enter a desired destination: ");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();
                        Console.Clear();
                        Teacher.addTeacher(name, lastName);
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        Teacher.addStudent();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        Teacher.remove();
                        break;
                    }
                case "4":
                    {
                        Teacher.showStudent();
                        Console.Write("\nBack(yes): ");
                        string a = Console.ReadLine();
                        if (a == "yes")
                        {
                            Console.Clear();
                            menu();
                        }
                        else
                        {
                            goto case "4";
                        }
                        break;
                    }
                case "5":
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect input, enter the desired destination again:\n");
                        menu();
                        break;
                    }
            }
        }
    }
}