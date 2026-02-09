namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        public string _name;
        public int _age;

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }

    static void Main()
    {
        Person p=new Person("John", 23);
        Person p2 = p;
        p2._name = "Jerry";

        Console.WriteLine($"p name is {p._name},  age is {p._age}");
        Console.WriteLine($"p2 name is {p2._name},   age is {p2._age}");
    }
}