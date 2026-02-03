namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        // 成员变量
        public string _name;
        public int _age;
        // 静态变量
        public static int maxAge=120;
    }
    static void Main()
    {
        Person allice=new Person();
        allice._name = "Allice";
        allice._age = 20;
        Console.WriteLine($"allice name is {allice._name}, age is {allice._age}");
        
        Person bob = new Person();
        bob._name = "Bob";
        bob._age = 30;

        Console.WriteLine($"bob name is {bob._name}, age is {bob._age} ");
        // 访问静态变量
        Console.WriteLine($"the max age of person is {Person.maxAge}");
        
    }
}