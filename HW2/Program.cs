using System;
namespace PersonManagement
{
    public class Person
    {
        private string name;
        private string address;
        private double salary;
        public Person() { }
        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("You must input Salary.");
            }
            if (!double.TryParse(sSalary, out double salary))
            {
                throw new Exception("You must input digit.");
            }
            if (salary <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }
            return new Person(name, address, salary);
        }
        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine($"Name:{person.Name}");
            Console.WriteLine($"Address:{person.Address}");
            Console.WriteLine($"Salary:{person.Salary:F1}");
        }
        public static Person[] SortBySalary(Person[] persons)
        {
            if (persons == null || persons.Length == 0)
            {
                throw new Exception("Can't Sort Person");
            }
            Person[] sortedArray = (Person[])persons.Clone();
            int n = sortedArray.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortedArray[j].Salary > sortedArray[j + 1].Salary)
                    {
                        Person temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }
            return sortedArray;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====Management Person program=====");
            int totalPerson = 3;
            Person[] persons = new Person[totalPerson];
            for (int i = 0; i < totalPerson; i++)
            {
                Console.WriteLine("Input Information of Person");
                Console.Write("Please input name:");
                string name = Console.ReadLine();
                Console.Write("Please input address:");
                string address = Console.ReadLine();
                Person person = null;
                while (person == null)
                {
                    Console.Write("Please input salary:");
                    string sSalary = Console.ReadLine();
                    try
                    {
                        person = Person.InputPersonInfo(name, address, sSalary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                persons[i] = person;
            }
            try
            {
                Person[] sortedPersons = Person.SortBySalary(persons);
                Console.WriteLine();
                foreach (Person p in sortedPersons)
                {
                    Console.WriteLine("Information of Person you have entered:");
                    Person.DisplayPersonInfo(p);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}