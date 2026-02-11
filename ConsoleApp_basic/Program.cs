namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        /*
         * 字段
         */
        // public string _name;
        // public int _age;

        /*
         * 属性
         */
        // private string _name;
        // private int _age;
        //
        // public string Name
        // {
        //     get => _name;
        //     set => _name = string.IsNullOrEmpty(value) ? "unknown" : value;
        // }
        //
        // public int Age
        // {
        //     get => _age;
        //     set => _age = value < 0 ? 0 : value;
        // }
        
        /*
         * 自动属性
         */
        // public string Name { get; private set; }
        
        // 初始化器
        public string Name { get; init; }
        public int Age { get; }

        // public void SetName(string name)
        // {
        //     Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
        // }
        
        /*
         * 构造器
         */
        public Person(string name, int age)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
            Age = age < 0 ? 0 : age;
        }
        
    }

    static void Main()
    {
        Person p = new Person("Tom",-99)
        {
            Name = "Jerry"
        };
        // p.Name = "Jerry"; // 不能重新赋值
        // 只能通过方法修改
        // p.SetName("Jerry");

        
        // p.Age = 99; // Age只读
        Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
    }
}