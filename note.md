## c# basic

### 1. Hello World

#### 默认程序代码

```c#
// 命名空间：组织标识代码，防止代码冲突，类似理解哪个班级的张三？？
namespace ConsoleApp_basic;

// Program类， 所有代码都会放在内存中开辟的Program区域中执行
class Program
{
    // 程序的入口方法，所以代码运行的逻辑都放在这个方法里执行
    static void Main()
    {
        // 逻辑代码
        Console.WriteLine("Hello, World!");
    }
}
```

#### 总结

1. Main()注意大小写

2. 字符串是有双引号，**不能使用单引号(和 js 不同)**

3. 默认使用全局内置引用， 配置文件中 enable, 可以设置

```c#
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
      ...
      ...
        <ImplicitUsings>enable</ImplicitUsings>
     ...
    </PropertyGroup>

</Project>
```

### 2. 变量类型

#### c#内置值类型和引用类型

- 常用的值类型：int, double, bool, char

- 常用的引用类型: string

#### 代码示例

```c#

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        // 1. 整数 int
        int age = 18; // 声明并初始化变量，局部变量：只在Main方法内部作用
        age = -18; // int有符号

        // 2. 小数 double
        double num = 18.555;
        num = -123.345; // double有符号

        // float: 需要结尾加f标识
        float num2 = 123.456f;

        // decimal:需要结尾加m标识
        decimal num3 = 123.456m;

        // 3. bool 类型
        bool flag = true;
        flag = false; // bool类型的值只能是true和false

        // 4. char 类型
        char c = 'A';
        // c = "A";
        // c = 'ab';

        // 5. string类型
        string str = "Hello World";

        // 控制台打印变量值: 使用字符串插值
        Console.WriteLine($"age: {age}, num: {num}, num2: {num2}, num3:{num3}, flag: {flag}, c: {c}, str:{str}");

        // 6. var - 动态类型
        // var a; // 必须要初始化，否则无法推导类型
        var a = 1;
        // a = true; // 类型推导完成，就固定了，不能再改类型
        // 不要滥用var, 除非比较麻烦的时候
        // List<Dictionary<string, int>> list = new List<Dictionary<string, int>>();
        var list = new List<Dictionary<string, int>>();

        // 7. 作用域
        {
            int b = 1;
            Console.WriteLine(b);
        }
        {
            int b = 2;
            Console.WriteLine(b);
        }
    }
}
```

#### 总结

1. 小数默认使用 double。除非有特殊说明，才使用 float（虽然占用的内存小，但范围更小）

2. 金钱相关的使用 decimal， 精度更高

3. bool 型的变量**只能赋值 true 或 false**，不能是其他（js 中可以是数字，字符串等等）

4. char 类型**只能使用单引号**，只能存储单个字符

5. 字符串和变量混合打印输出，使用**字符串插值**， 类似 js 中的模版字符串

6. 不要滥用 var

7. 使用花括号来限定变量的作用域

### 3. 类型转换

#### 同类型之间的转换（主要是数字型）

1. 隐式转换（implicit）——编译器自动转（通常安全）

   典型：**小范围/小精度 → 大范围/大精度**（“变宽”），反之不行

   ```c#
   namespace ConsoleApp_basic;
   class Program
   {
       static void Main()
       {

           double d = 1.234;
           float f = 234.123f;
           d = f;
           // f = d; // double的范围更大。无法隐式转化为float

           int i = 123;
           short s = 456;
           i = s;
           // s = i; // int 的范围更大,无法隐式转化为short

       }
   }
   ```

2. 显式转换（explicit）——必须手动写（可能丢失/溢出）

   典型：**大 → 小**、**不同体系**（比如 double ↔ decimal）

   ```c#
   namespace ConsoleApp_basic;
   class Program
   {
       static void Main()
       {
   
           double d = 1.234;
           float f = 234.123f;
           d = f;
           // f = d; // double的范围更大。无法隐式转化为float
   
           f=(float)d; // 显式强制转换
   
           int i = 123;
           short s = 456;
           i = s;
           // s = i; // int 的范围更大,无法隐式转化为short
   
           s=(short)i; // 显式强制转换
   
       }
   }
   ```


#### 不同类型直接的转换

跨类型直接，不能用隐式/显式互转，需要使用内置的其他方法：

1. 数字/bool

   需要表达式（`n != 0`）或 `Convert.ToInt32(bool)`。

   ```c#
   namespace ConsoleApp_basic;

   class Program
   {
       static void Main()
       {
           bool connected = true;
           bool unconnected = false;

           int c = Convert.ToInt32(connected);
           int u = Convert.ToInt32(unconnected);

           Console.WriteLine($"c={c}, u={u}");

           connected = Convert.ToBoolean(c);
           unconnected = Convert.ToBoolean(u);

           Console.WriteLine($"connected={connected}, unconnected={unconnected}");
       }
   }
   ```

   ```bash
   c=1, u=0
   connected=True, unconnnected=False
   ```

2. 值类型（数字+bool) / string

   - 值类型**→ string**：常用 `.ToString()`（可带格式）
   - **string → 数字**：优先 `TryParse`
   - **string → bool**：可以 `bool.TryParse`（主要是 `"true"/"false"`）

   ```c#
   namespace ConsoleApp_basic;
   
   class Program
   {
       static void Main()
       {
           int ii = 123456;
           string int_str = ii.ToString();
           int.TryParse(int_str, out int str_int);
           Console.WriteLine($"int_str={int_str}, str_int={str_int}");
   
           bool flag = true;
           string bool_str = flag.ToString();
           bool.TryParse(bool_str, out bool str_bool);
           Console.WriteLine($"bool_str={bool_str}, str_bool={str_bool}");
   
       }
   }
   ```

   ```bash
   int_str=123456, str_int=123456
   bool_str=True, str_bool=True
   ```

#### 总结

1. **数字类型**：一般“**变宽**（小 → 大）可隐式；**变窄**（大 → 小）要显式”，但 **`double ↔ decimal`、enum/char** 等有特殊规则

2. **bool ↔ 数字**：**不能直接 cast/隐式互转**；需要表达式（`n != 0`）或 `Convert.ToInt32(bool)`

3. **任意类型 → string**：常用 `.ToString()`（可带格式）

4. **string → 数字**：优先 `TryParse`

5. **string → bool**：可以 `bool.TryParse`（主要是 `"true"/"false"`）

    

### 4. 类简介

#### 基础作用

最基础的用法是把一些松散的数据组织到一起

比如，我们有一些数据如下：

```c#
class Program
{
    static void Main()
    {
        string name = "Alice";
        int age = 20;

        string name2 = "Danielle";
        int age2 = 18;

    }
}
```

上面的数据松散，逻辑不相关，可以使用类进行抽象数据

```c#
class Program
{
    class Person
    {
        public string _name;
        public int _age;
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

    }
}
```

通过实例对象，然后分别对各自对象的属性进行赋值，这样有了关联逻辑。

- 成员变量

    类里的变量叫成员变量，通过类创建的实例都能使用这些变量

- 静态变量

    数据整个类的通用变量，使用static关键字修饰，只能通过类本身访问

```c#
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
        
		...
            
        // 访问静态变量
        Console.WriteLine($"the max age of person is {Person.maxAge}");
        
    }
}
```

#### 总结

1. 类的基础作用是组织数据来抽象一个事物

2. 成员（实例）字段（变量），方法是属于某一个具体的对象，比如每个人都有自己的年龄

3. 静态字段（变量），方法，属于整体的类，比如人类的总数不属于某一个具体的人

4. 类成员默认是private的，仅在类的内部访问。申明为public，可以在任意位置访问

    

### 5. 方法简介

#### 概述

方法，简而言之就是做一件事情。做这件事情可能需要一些前提条件（参数），做好之后可能会给出反馈（返回值）。

比如，方法MakeBread用于制作面包，这个方法需要一些原料：面粉，奶，糖等等。制作完成后给我们返回一个面包作为结果

```c#
Bread MakeBread(Flour f, Mike m, Sugar s)
{
    // ... 制作面包的过程
    reture deliciousBread;
}
```

注意：c#中不允许有全局的方法，每个方法必须包含于特定的类中。对比js， 可以随意定义全局的函数。

#### 用法

class中的方法，也是class的成员，因此也有实例方法和静态方法，用法和class的字段（变量）一样

```c#
class Program
{
    class MyMethod
    {
        //成员（实例）方法
        public void Greet()
        {
            Console.WriteLine("Hello World!");
        }
    
        //静态方法
        public static void Greet2()
        {
            Console.WriteLine("Hello World too!");
        }
    }
    
    
    static void Main()
    {
        // 使用成员（实例）方法
        MyMethod m = new MyMethod();
        m.Greet();
        
        // 使用静态方法
        MyMethod.Greet2();
    }
}
```

方法可以有参数和返回值

```c#
class Program
{
    class MyMethod
    {
      ...
          
        // 加密方法
        public static int Encrypt(int x)
        {
            return x * 2 + 4;
        }

        // 解密方法
        public static int Decrypt(int x)
        {
            return (x - 4) / 2;
        }

    }
    
    
    static void Main()
    {
       ...
        
        // 加密一个数字
        int number = 100;
        int result=MyMethod.Encrypt(number);
        Console.WriteLine($"加密后的数字是{result}");
        
        // 解密一个数字
        int result2 = MyMethod.Decrypt(result);
        Console.WriteLine($"解密后的数字是{result2}");
    }
}
```

几个优化写法：

- 创建实例时，直接简化为：`MyMethod m = new ();`编译器能自动推断使用哪个类

- 方法体简单时，可使用lambda表达式，类似js中的箭头函数

    ```c#
    class MyMethod
        {
        
        	public void Greet()=> Console.WriteLine("Hello World!");
        
        	public static void Greet2() => Console.WriteLine("Hello World too!");
        
            // 加密方法
            public static int Encrypt(int x)=>x * 2 + 4;
    
            // 解密方法
            public static int Decrypt(int x)=>(x - 4) / 2;
    
        }
    ```

#### 总结

1. 类中的方法也是类的成员，有实例方法和静态方法区分

2. 方法可是使用lambda表达式简化书写

    

###  6. 值类型和引用类型

#### 引述

类中的构造器方法可以用来方便地初始化实例对象

```c#
class Program
{
    class Person
    {
        public string _name;
        public int _age;
        
        // 构造器方法，通过传参的方式创建实例对象
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }

    static void Main()
    {
        var person = new Person("John", 22);
        Console.WriteLine($"person is {person._name},  age is {person._age}");
    }
}
```

我们现在把person赋值给person2，然后修改person2的age。诡异的事情发生了：**person的age值也被修改了？？**

```c#
static void Main()
    {
        var person = new Person("John", 22);
        var person2 = person;
        person._age = 33;
        Console.WriteLine($"person is {person._name},  age is {person._age}");
        Console.WriteLine($"person2 is {person2._name},  age is {person2._age}");
    }
```

```ba
person is John,  age is 33
person2 is John,  age is 33
```

把修改年龄的事情抽象成一个方法，同样的逻辑，在抽象一个修改int数值的方法

```c#
class Program
{
    class Person
    {
        public string _name;
        public int _age;
        
        // 构造器方法，通过传参的方式创建实例对象
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
    }
    
    static void SetAge(Person person, int age)=> person._age = age;
    static void SetInt(int m, int  n) => m = n;

    static void Main()
    {
       ...
    }
}
```

分别修改一个person实例的年龄和修改一个int数，结果诡异的事也发生了：person实例的年龄修改了，而int数值并没有被修改？？

```c#
static void Main()
    {
        var person = new Person("John", 22);
        var person2 = person;
        
        SetAge(person2,44);
        Console.WriteLine($"person is {person._name},  age is {person._age}");
        Console.WriteLine($"person2 is {person2._name},  age is {person2._age}");

        int m = 100;
        SetInt(m,0);
        Console.WriteLine($"the value is {m}");
    }
```

```bash
person is John,  age is 44
person2 is John,  age is 44
the value is 100
```

为什么对象的年龄能修改，而一个普通数值却无法修改？原因是**c#里的变量有值类型和引用类型的区别**

#### 内置值类型

值类型直接存储的是数据（实例）本身

值类型在以下场景都会发生值的复制：

- 赋值
- 向方法传递参数
- 从方法返回结果

对于值类型，复制指的是复制类型实例的本身。就像直觉一样，复制一个数值就是单独复制这个数值本身。比如下面的实例：

```c#
class Program
{
    public static double Example(double d)
    {
        double e = d;
        return e;
    }

    static void Main()
    {
        double result = Example(2.1415926);
    }
}
```

- 赋值：把d的值复制给e
- 调用方法时传递参数：把值2.1415926复制给d
- 方法返回结果： result的值就是复制了方法体中return的e的值

c# 提供的以下内置值类型（也称简单类型）：

- 整数数值类型
- 浮点数值类型
- bool类型
- char字符类型 - unicode UTF-16字符
- 结构体struct类型

#### 内置**引用类型**

引用类型变量存储的是数据（实例）的引用（内存中的地址），两个变量可以同时引用同一个对象（都指向这个对象数据在内存中的地址）。因此对其中一个变量所做的操作，可能会影响到另一个变量所引用的对象数据。

使用如下关键字来声明引用类型：

- **class**
- interface
- delegate
- record

c#还提供了dynamic， object， **string **作为内置引用类型

#### 补充

引用类型可以引用一个空类型null, 而值类型不能为空（没有一个数值能表示空）。但是可以在类型后面跟上？手动什么可以为空

```c#
namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        string str = null; // 引用类型可以赋值为空
        // int i = null; //值类型不能为空
        int? i = null; // 加？设置为可空值
    }
}
```



### 7. 堆和栈

#### 概述

Stack 在英文中指有序、一层层叠放的物品（堆叠），栈内存（Stack）由系统自动分配和释放，地址空间连续，像整齐码放的货物，先进后出。

Heap 意为“乱堆在一起的物体”或“一堆垃圾”，强调无序和 haphazardly（杂乱）。形容了内存中数据块“随处安放”、凌乱且不需要顺序管理的特点。内存（Heap）由用户手动申请和释放，内存碎片较多，地址空间不连续，像堆积杂物。

总之，Heap堆（桌上的一堆乱放的书，无顺序）vs Stack栈（桌上一摞叠放的书，有顺序）

#### Heap堆

当操作系统运行一个程序（代码）时，需要放程序（代码）放在内存中，cpu一行一行的读取执行。内存被分为2个区域，堆和栈的结构。

堆就是一大块内存，在c#中，创建引用类型的实例的时候，系统会自动从堆内存中分配一块区域来存放数据。我们写代码的时候无需关心具体分配到哪了，也不需要负责释放，因为.net运行时帮我们做。

只需要知道一件事：我们拥有了该实例的引用

```c#
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
    }
}
```

比如，我们创建Person p， 我们根本不关心这个实例的数据 ''name="John", age=23"放在了内存的什么位置，只关心我们现在拥有了一个Person类的实例对象的引用p

```c#
static void Main()
    {
        Person p=new Person("John", 23);
        Person p2 = p;
        p2._name = "Jerry";

        Console.WriteLine($"p name is {p._name},  age is {p._age}");
        Console.WriteLine($"p2 name is {p2._name},   age is {p2._age}");
    }
```

当我们把p(引用)赋值给p2后，p和p2都指向了同一个实例数据("John", 23)， 此时在通过p2修改name的值时，就是修改同一个实例的数据。因此p的实例数据也被修改了。

#### Stack栈

栈是一种后进先出的数据结构

程序运行时会维护调用栈，每个方法都有自己的栈帧，方法结束后，栈帧会被移除

局部变量就存在于方法的栈帧中，参数也可以通过栈帧传递

上面的代码中，当main函数执行结束，里面定义的变量（值类型，已经p, p2类孙引用）都会自动删除

### 8. 数组

#### 概念

用来存放数据的容器或者集合

- 下标从0开始
- 数字的长度固定

适用于存放固定长度的数据

#### 语法

使用new 关键词创建，使用{ } 括号初始化、赋值（js中使用[ ] 括号）

```c#
class Program
{
    static void Main()
    {
        int[] arr = new int[5];
        arr[0] = 1;
        arr[1] = 2;
        arr[2] = 3;
        arr[3] = 4;
        arr[4] = 5;
    }
}
```

简化写法: 定义并初始化

```c#
class Program
{
    static void Main()
    {
        int[] arr =  { 1, 2, 3, 4, 5 };
        Console.WriteLine(arr[0]);
    }
```

定义一个空数组

```c#
    static void Main()
    {
        // 空数组
        int [] arr2 = [];
        Console.WriteLine(arr2.Length);
        arr2[0] = 1; // 长度固定，不能添加元素
        Console.WriteLine(arr2.Length); // 报错
    }
}
```

c#中的数组长度固定，不像js中随便添加元素，想要能扩容，可使用另外一种容器List

```c#
 static void Main()
    {
        //空list
        var list = new List<int>();
        Console.WriteLine(list.Count);
        list.Add(1);
        list.Add(2);
        Console.WriteLine(list.Count);
    }
```

~~二维数组（了解）~~

```c#
 static void Main()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5 },
            { 1, 2, 3, 4, 5 }
        };
        Console.WriteLine(grid[0, 0]);
    }
```



### 9. 异常

程序在运行中发生的错误或者预期之外的情况

比如参数错误，空引用，文件不存在等等

在c#中可以使用try / catch / finally 处理异常

```c#
class Program
{
    static void Main()
    {
        try
        {
            int[] arr = { 1, 2, 3 };
            Console.WriteLine(arr[3]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
```

```bash
System.IndexOutOfRangeException: Index was outside the bounds of the array.
```

对于异常情况进行处理, 可以处理不同的异常，从上到下异常匹配处理

```c#
class Program
{
    static void Main()
    {
        try
        {
            int[] arr = { 1, 2, 3 };
            Console.WriteLine(arr[3]);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception");
        }
    }
}
```

越靠前的异常越精确，最后的Exception是通用的兜底的异常



### 10. loop

C# 里最常用的循环就这几类：`for / foreach / while / do-while`，再加上“控制语句”`break/continue/return`。

#### for：次数明确、需要索引

```c#
class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // for loop
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
```

- 常见场景：数组/List 按下标访问、需要 `i`。

#### foreach：遍历集合（最常用）

```c#
static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
        //foreach loop
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
```

- 适合遍历 `数组、List、Dictionary、IEnumerable`

- 一般更安全、更简洁

- 注意：遍历 `List` 时**不要在 foreach 里直接 Add/Remove**，通常会报错（集合被修改）。**==只读==**

#### while：条件成立就一直循环（次数不固定）

```c#
 static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
     
        // while loop
        int time = 0;
        while (time < numbers.Length)
        {
            Console.WriteLine(numbers[time]);
            time++;
        }
    }
```

- 常见场景：读输入、重试、轮询（一般要小心别写成死循环）。

#### do-while：至少执行一次

```c#
 static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int time = 0;
       
        //do while loop
        do
        {
            Console.WriteLine("hello world");
            time++;
        } while (numbers.Length > 0);
    }
```

- 常见场景：菜单输入/必须先做一次再判断。

#### 常用控制语句

- break：跳出当前循环

    ```c#
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5};
    
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                break;
            }
    
            Console.WriteLine("hello world");
        }
    }
    ```

    ```bash
    1
    hello world
    ```

    完成当前循环，跳出循环，执行循环后面的代码

- continue：跳过本次，进入下一次

    ```c#
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5};
    
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                continue;
            }
    
            Console.WriteLine("hello world");
        }
    }
    ```

    ```bash
    1
    2
    3
    4
    5
    hello world
    ```

    完成当前循环，继续后面的循环，执行循环后面的代码

- return：直接结束整个方法（也会结束循环）

    ```c#
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5};
    
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                return;
            }
    
            Console.WriteLine("hello world");
        }
    }
    ```

    ```bash
    1
    ```

    完成当前循环，结束后面的循环，不执行循环后面的代码（直接结束整个main方法）

### 11. 方法参数和重载

#### 方法参数（Parameters）

方法参数就是**调用方法时传进去的数据**。

默认都是“按值传递”：值类型传值拷贝；引用类型传引用拷贝

- 普通参数

    ```c#
    class Program
    {
        static int Add(int a, int b) => a + b;
    
        static void Main()
        {
            Console.WriteLine(Add(1, 2));
        }
    }
    ```

- 可选参数（有默认值）

    ```c#
    class Program
    {
        static int Add(int a, int b=1) => a + b;
    
        static void Main()
        {
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Add(1));
        }
    }
    ```

    - 默认值是**编译期绑定**，改默认值后，调用方没重新编译可能还用旧默认值。
    - 默认值参数必须放在最后面

- 命名参数（按名字传，不按顺序）

    使用：号

    ```c#
    class Program
    {
    
        static int Add(int a, int b=1) => a + b;
    
        static void Main()
        {
            Console.WriteLine(Add(b:2,a:3));
        }
    }
    ```

- params 可变参数（类似 JS 的 rest）

    使用关键字params

    ```c#
    class Program
    {
        static int AddMore(int a, params int [] nums)
        {
            int r = a;
            foreach (var n in nums)
            {
                r += n;
            }
            return r;
        }
    
        static void Main()
        {
            Console.WriteLine(AddMore(1, 2,3,4,5));
        }
    }
    ```

    

- ref  / in（按引用传，能让方法改调用方变量）

    方法参数默认是按值传递的 （传递的是值的拷贝），想要按引用传递（直接传值的本体），使用ref / in关键字

    ref可以在方法体里修改, 让方法**读写**调用方变量（方法里改，外面就变）。

    in不可以修改。

    ```c#
    
    class Program
    {
      
        // 使用ref /in参数
        static void Change(ref int a, in int b)
        {
            a++;
            // b++; // 报错，只读不能改 
        }
    
        static void UnChange(int a, int b)
        {
            a++;
            b++;
        }
    
        static void Main()
        {
            int a = 1;
            int b = 2;
            UnChange(a,b);
            Console.WriteLine($"a:{a}, b:{b}"); // a:1, b:2
            Change(ref a, b);
            Console.WriteLine($"a:{a}, b:{b}"); // a:2, b:2, a的值被修改了
        }
    }
    ```

- out 传参

    当一个方法中需要返回多个参数时，处理使用return， 可以使用out关键字来返回多一个值

    ```c#
    class Program
    {
        static bool IsEqual(ref int num, out int copy)
        {
            copy = num;
            num++;
            return copy == num ? true : false;
    
        }
    
        static void Main()
        {
            int num = -1;
            bool result= IsEqual(ref num, out int copy);
            Console.WriteLine($"result:{result}, num:{num}, copy:{copy}");
        }
    }
    ```

    ```bash
    result:False, num:0, copy:-1
    ```

    总结： **`in`（只读输入）+ `ref`（就地修改）+ `out`（带出额外结果）+ `return`（主结果）**

#### 方法重载（Overload）

**同一个方法名**，可以有**不同参数列表**（参数个数/类型/顺序不同），编译器会根据你调用时传的参数自动匹配

- 只能靠“参数列表”区分（类型/个数/顺序）

    ```c#
    static int Add(int a) => a + 1;
    static int Add(int a, int b) => a + b;
    static double Add(int a, double b) =>a+b;
    ```

- 不能只靠“返回值不同”来重载

    ```c#
    static int Add(int a, int b) => a + b;
    static void Add(int a, int b)=>Console.WriteLine(a + b);
    ```

    返回值不同不能重载

### 12. 深入理解类

类中的成员有字段，属性，方法，构造器等

#### 字段field - 用来存储数据

类中的字段就是类中定义的变量，用来存储数据

```c#
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        public string _name;
        public int _age;
    }

    static void Main()
    {
        Person p = new Person;
        p._name = "Tom";
        p._age=-100; // 可以随意非法赋值或修改
        
        Console.WriteLine($"Name is {p._name}, and {p._age} years old.");
    }
}
```

使用字段直接管理数据时，任何人都能随便改，甚至改成非法值， 于是我们想：**能不能在赋值时拦一下、加规则？**

#### 属性（Property）- “管住访问”

对外暴露的访问入口（本质是 get/set 方法），可以在 `set` 里做校验/修正。

通常私有字段，而公开属性

通过set方法设置修改规则

```c#
class Program
{
    class Person
    {
        // public string _name;
        // public int _age;

        // 私有字段：真正存数据
        private string _name;
        private int _age;
        
        // 属性：对外入口
        public string Name
        {
            get => _name;
            //设置效验规则
            set => _name = string.IsNullOrEmpty(value) ? "unknown" : value;
        }

        // 属性：对外入口
        public int Age
        {
            get => _age;
            //设置效验规则
            set => _age = value < 0 ? 0 : value;
        }
    }

    static void Main()
    {
        Person p = new Person();
        p.Name = "";
        p.Age = -100;

        Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
    }
}
```

```bash
Name is unknown, and 0 years old.
```

现在外面再 `u.Age = -100;`，会被修正。
 **这就是属性的核心用途**：封装、校验、控制读写。

但写到这里会发现：**每个属性都要写一套 field + get/set，好麻烦。**



#### 自动属性（Auto-Property）- 优化

如果暂时不需要复杂逻辑，就用自动属性，省事：

```c#
namespace ConsoleApp_basic;

class Program
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static void Main()
    {
        Person p = new Person();
        p.Name = "";
        p.Age = -100;

        Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
    }
}
```

使用自动属性时，编译器会在背后生成“隐藏字段”。

**问题**：又回到“谁都能随便改”的感觉了——比如 Name/ Age 随时能改，容易把对象改坏。

于是我们想：**能不能做到：创建时能赋值，创建后尽量别乱改？**



#### 构造器（Constructor）-  保证“出生就合法”

构造器能够在 `new` 的那一刻就把对象初始化好，强制必填、做校验，保证对象一创建就是可用的。

```c#
namespace ConsoleApp_basic;

class Program
{
    class Person
    { 
        /*
         * 自动属性
         */
        public string Name { get; set; }
        public int Age { get; set; }
        
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
        Person p = new Person("Tom",-99);
        Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
    }
}
```

```bash
Name is Tom, and 0 years old.
```

**问题：初始化后的实例数据，也可以随意更改**

```c#
static void Main()
    {
        Person p = new Person("Tom",-99);
        p.Name = "Jerry";
        p.Age = 99;
        Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
    }
```

```bash
Name is Jerry, and 99 years old.
```



#### 属性的访问控制

自动属性的本质

```c#
public int Age { get; set; }
```

编译器会**偷偷生成**一个私有字段，大致等价于：

```c#
private int _age;
public int Age
{
    get => _age;
    set => _age = value;
}

```

所以：访问控制本质都是在**控制“什么时候、谁能改这个隐藏字段"**

- `get; set;` —— 完全可读写

    ```c#
    public int Age { get; set; }
    ```

    外部：能读、能改;  内部：能读、能改

- `get; private set;` —— 外部只读，内部可控修改（非常常用）

    不希望外部随意 set，只允许通过方法改变状态

    ```c#
    class Program
    {
        class Person
        {
            public string Name { get; private set; }
            public int Age { get; set; }
    
            public void SetName(string name)
            {
                Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
            }
            
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
            Person p = new Person("Tom",-99);
            // p.Name = "Jerry"; // 不能重新赋值
            // 只能通过方法修改
            p.SetName("Jerry");
            
            p.Age = 99;
            Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
        }
    }
    ```

- `get;` —— 只读属性

    谁都不能 set,  只能在构造器或声明时赋值

    ```c#
    namespace ConsoleApp_basic;
    
    class Program
    {
        class Person
        {
            public string Name { get; private set; }
            public int Age { get; }
    
            public void SetName(string name)
            {
                Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
            }
            
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
            Person p = new Person("Tom",-99);
            p.SetName("Jerry");
            
            // p.Age = 99; // Age只读
            Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
        }
    }
    ```

- **Init - 初始化器**

    在初始化实例时，可以赋值，但是之后就不能再修改

    ```c#
    class Program
    {
        class Person
        {
            // 初始化器
            public string Name { get; init; }
            public int Age { get; }
            
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
                Name = "Jerry" // 初始化时可以修改
            };
            
            // p.Name = "Jerry"; // 初始化完成后不能重新赋值
            // p.Age = 99; // Age只读
            Console.WriteLine($"Name is {p.Name}, and {p.Age} years old.");
        }
    }
    ```

    **初始化器vs构造器：**

    - **构造器 = 保证对象“必须正确地被创建”**，**init = 让对象“创建时写起来舒服，但创建后不能被改”**
    - 构造器：**“这是创建一个合法对象所必须的条件”**， init：**“这是对象的初始化数据”**
    - 构造器：**你不提供 Name，我拒绝被创建**，init：**你可以创建我，但如果给了 Name，我就锁死它**

- 总结：

    - `get;` + 构造器：最强约束：只能在构造器里赋值。构造后永远不变， 对象一出生就“定型”

    - `get; private set;` + 构造器：构造器初始化，后续允许内部方法修改。外部不能改，内部可通过方法维护状态

    - `get; init;` + 构造器：只能在创建阶段赋值，后续无法修改

    - `get; set;` + 构造器：构造器只是“给个初始值”，并不限制后续修改

        

### 13. 类的继承

### 

### 

### 14. 委托 → lambda → 事件

#### 1. 问题

我们的Order的实例中，订单 `Pay()` 支付成功后，我们通常要做很多“后续动作”：

- 记录日志

- 发送邮件/短信

- 更新库存

- 发票、积分、消息通知……

    ```c#
    public void Pay()
        {
            if (_status != OrderStatus.Created)
                throw new InvalidOperationException("Only a Created order can be paid.");
    
            _status = OrderStatus.Paid;
    
            // ❌ 支付后续逻辑写死在这里
            Console.WriteLine($"[Log] Order paid, amount={_amount}");
            Console.WriteLine("[Email] Send payment confirmation email");
            Console.WriteLine("[Inventory] Reduce stock");
        }
    ```

    

**问题：这些后续动作经常变化**，而且不应该都写死在 `Order` 类里， 不同类型的order需要的后续动作不同。这样可能导致：

- **Order 类职责爆炸**：订单类变成“订单 + 日志 + 邮件 + 库存”
- **后续动作经常变**：你改邮件内容也要改 `Order.Pay()`
- **测试困难**：你只是想测试“状态变 Paid”，结果各种输出/依赖混进来

👉 所以我们需要：

> **把“支付后的动作”从 Order 中拿出去，但仍然能在支付后执行。**

这就是需要一个策略：**把“支付后要做什么”委托给外部决定。**



#### 2. 委托

**委托（delegate）**可以理解为：

> **“一个变量，保存的是某个方法（函数）的引用”**
>  也就是：你可以把“要执行的代码”当作数据传递。类似与js中的回调函数

**定义委托：**

- 先定义委托类型（类似与数据的类型）

    我们定义：支付成功后要回调一个方法，它接收当前订单：

    ```c#
    public delegate void PaymentSucceededHandler(Order order);
    ```

    意思是：

    > 任何“签名符合 `void (Order)`”的方法，都可以作为支付成功后的处理器。

- 再申明这个类型的变量，又来存储方法的引用

    ```c#
    public PaymentSucceededHandler OnSuccess;
    ```

**使用委托：**

- **通过属性**

    定义好的变量，可作为类的成员变量（属性）使用， 外部方法通过属性委托

    ```c#
    
    public delegate void PaymentSucceededHandler(Order order);
    public abstract class Order: IPayable
    {
       ...
           
        public PaymentSucceededHandler OnSuccess;
        
    	...    
            
        protected void HandlePaymentSucceeded()
        {
            OnSuccess(this);
        }
    }
    ```

    ```c#
    
    public class OnlineOrder : Order
    {
       ...
           
        // 重写Pay()
        public override void Pay()
        {
            // 继承父类
            EnsureCanPay();
            _gateway.Charge(_amount);
            _status = OrderStatus.Paid;
            
            //继承父类
            HandlePaymentSucceeded();
        }
        
    }
    
    ```

    ```C#
    class Program
    {
    	...
        
        static void LogPaid(Order order)
        {
            Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        }
        
        static void Main()
        {
    		...
             // 实例化对象
            var onlineOrder = new OnlineOrder(123456,fakePaymentGateway);
            // 赋值 - 挂载委托回调（类的属性赋值方式）
            onlineOrder.OnSuccess = LogPaid;
            // 类的内部执行被委托的方法
            onlineOrder.Pay();
        }
    }
    ```

    

- **通过内部方法**

    对变量状态的更新，也可以定义一个方法，在类的内部控制，而把成员变量私有化

    ```c#
    
    public delegate void PaymentSucceededHandler(Order order);
    public abstract class Order: IPayable
    {
       ...
           
        protected PaymentSucceededHandler OnSuccess;
        
    	...    
            
        protected void HandlePaymentSucceeded()
        {
            OnSuccess(this);
        }
        
        // 开放的的挂载委托的方法
        public void setSuccessHandler(PaymentSucceededHandler handler)
        {
            OnSuccess = handler;
        }
        
    }
    ```

    ```c#
    class Program
    {
    	...
        
        static void Main()
        {
    		...
    
            var onlineOrder = new OnlineOrder(123456,fakePaymentGateway);
            
            // 赋值 - 挂载委托回调（使用类的方法赋值方式） 
            onlineOrder.setSuccessHandler(LogPaid);
           
            onlineOrder.Pay();
        }
    }
    ```

    

**委托的“多播”能力**: 

同一次支付后，想执行多个动作，而不是只能传一个方法。怎么办？？

委托有多播能力，可以挂载多个方法，也可以删除：

| Type         | Action |
| ------------ | ------ |
| 赋值         | 使用=  |
| 挂载多个方法 | 使用+= |
| 移除方法     | 使用-= |
| 清空         | = null |

- 通过属性委托时:

    直接使用属性执行

    ```c#
    class Program
    {    
        static void LogPaid(Order order)
        {
            Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        }
    
        static void SendEmail(Order order)
        {
            Console.WriteLine($"[SendEmail] Order paid, amount={order.Amount}");
        }
    
        static void ReduceStock(Order order)
        {
            Console.WriteLine($"[ReduceStock] Order paid, amount={order.Amount}");
        }
    
        static void Main()
        {
          ...
            var onlineOrder = new OnlineOrder(123456,fakePaymentGateway);
            // 赋值 - 挂载委托回调
            onlineOrder.OnSuccess = LogPaid;
            
            // 订阅 - 追加
            onlineOrder.OnSuccess += SendEmail;
            onlineOrder.OnSuccess+=ReduceStock;
    
            // 取消 - 移除
            onlineOrder.OnSuccess -= LogPaid;
            // 清除 
            onlineOrder.OnSuccess -= null;
            
            onlineOrder.Pay();
        }
    }
    ```

- 通过方法委托时:

    需要自定义各自的操作方法

    ```c#
    
    public delegate void PaymentSucceededHandler(Order order);
    public abstract class Order: IPayable
    {
       ...
           
        protected PaymentSucceededHandler OnSuccess;
        
    	...    
            
        protected void HandlePaymentSucceeded()
        {
            OnSuccess(this);
        }
        
        // 开放的的挂载委托的方法
        public void setSuccessHandler(PaymentSucceededHandler handler)
        {
            OnSuccess = handler;
        }
        
        public void AddSuccessHandler(PaymentSucceededHandler handler)
        {
            OnSuccess += handler;
        }
    
        public void RemoveSuccessHandler(PaymentSucceededHandler handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            OnSuccess -= handler;   
        }
    
        public void ClearSuccessHandler()
        {
            OnSuccess = null;
        }
        
    }
    ```

    ```c#
    class Program
    {
    	...
        
        static void Main()
        {
    		...
    
            var onlineOrder = new OnlineOrder(123456,fakePaymentGateway);
            
            // 赋值 - 挂载委托回调（使用类的方法赋值方式） 
            onlineOrder.SetSuccessHandler(LogPaid);
            onlineOrder.AddSuccessHandler(SendEmail);
            onlineOrder.AddSuccessHandler(ReduceStock);
            onlineOrder.RemoveSuccessHandler(LogPaid);
            onlineOrder.ClearSuccessHandler();
            
            onlineOrder.Pay();
        }
    }
    ```



#### 3. 内置委托 Action/Func

自定义 delegate 太啰嗦了, 我们为了“回调 void(Order)”专门写了一行：

```c#
public delegate void PaymentSucceededHandler(Order order);
```

但这种“回调签名”其实很常见：

- 无返回值 → `void`
- 有一个参数 → `Order`

C# 里已经内置了通用委托类型。

- `Action<T>`：表示一个方法，**有一个参数 T，返回 void**

- `Func<T, TResult>`：表示一个方法，**有一个参数 T，返回 TResult**

因此，我们实例中的的回调签名是：`void (Order)`， 可以直接用：`Action<Order>`

优化后的代码：

```c#

// public delegate void PaymentSucceededHandler(Order order); 不需要自定义类型了
public abstract class Order: IPayable
{
   ...
       
    public Action<Order> OnSuccess; // 使用内置的类型
    
	...    
        
    protected void HandlePaymentSucceeded()
    {
        OnSuccess(this);
    }
}
```



#### 4. lambda表达式

目前，上面的实例，现在能传方法了，但有时候不想专门写一个 `static void LogPaid(Order o)` 方法——只想就地写两三行逻辑。

这时，就需要使用到lambda表达式。

lambda表达式，类似于js中的箭头函数。作用是把“临时方法/匿名方法”写得更短。

- 以前：先要定义一个具名方法，再使用委托传递次方法进去

```c#
static void LogPaid(Order order)
    {
        Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
    }

...
    
onlineOrder.OnSuccess = LogPaid;
```

- 使用lambda表达式：直接写一个匿名函数进去

```c#
onlineOrder.OnSuccess =(Order order) => { Console.WriteLine($"[Log] Order paid, amount={order.Amount}")}
```

优化后的代码：

```c#
namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
		...

        var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);

        // 赋值 - 挂载委托回调
        onlineOrder.OnSuccess = (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");
        
        // 订阅 - 追加
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[SendEmail] Order paid, amount={order.Amount}");
        onlineOrder.OnSuccess += (order)=>Console.WriteLine($"[ReduceStock] Order paid, amount={order.Amount}");
        // 取消 - 移除
        onlineOrder.OnSuccess -= (order)=>Console.WriteLine($"[Log] Order paid, amount={order.Amount}");

        onlineOrder.Pay();
    }
}
```

因此，我们解决了：

- **✅ 不用为一次性的逻辑专门创建方法**
- **✅ 代码更贴近“调用处表达意图”**

#### 5. 事件 `event`

- 问题：

    我们把把回调暴露为 public 委托字段/属性，外部可以

    - 直接 `.Invoke()` 触发

    - `= null` 清空

    - `= someOtherHandler` 替换

    我们需要一种机制：**只开放订阅通道，不开放触发权**。

- 事件

    `event` 是对委托的封装：

    - 外部：只能 `+=` / `-=`
    - 内部：才能 `Invoke()`（触发事件）

- 使用事件event

    使用修饰符event，把一个委托变成事件event

    ```c#
        // 委托变成事件
        public event Action<Order> OnSuccess;
    ```

因此，通过event，我们解决了：

- ✅ 外部可以自由订阅多个“支付成功后动作”
-  ✅ 但外部无法伪造触发、无法清空/替换全部订阅
-  ✅ 订单类保持封装：**支付成功由订单自己宣布**



#### 6. 小结

1. 委托是什么？——方法引用/把行为当参数

2. Action/Func 是什么？——通用委托类型，减少自定义 delegate

3. lambda 是什么？——快速创建委托实例，写临时逻辑

4. event 是什么？——封装委托：外部只能订阅/取消，触发权在类内部

5. 为什么需要 event？——防止外部乱触发/乱赋值，保护发布-订阅模型



### 15. 扩展方法

#### 1. 新的需要

出现一个“框架级别”的真实需求：我想把常用逻辑写成更顺手的调用方式。

- 需求 1：很多地方都要“订阅默认通知”， 每次都写：

    ```c#
    onlineOrder.OnSuccess += LogPaid;
    onlineOrder.OnSuccess += o => Console.WriteLine("[Email] ...");
    ```

​	如果项目里几十个地方都这么写，会很重复，而且调用处不够“像框架”。

- 使用工具类实现：

    最直接的写法是写一个静态工具方法：

    ```c#
    static class OrderHelpers
    {
        public static void AddDefaultPaidHandlers(Order order)
        {
            order.Paid += ...
        }
    }
    ```

    调用时是：

    ```c#
    OrderHelpers.AddDefaultPaidHandlers(onlineOrder);
    ```

    **问题：**

    - 读起来不如 `onlineOrder.AddDefaultPaidHandlers()` 自然
    - 不像 LINQ / ASP.NET Core 那种“像对象自带方法”的风格

于是，使用扩展方法来解决。



#### 2. 扩展方法

扩展方法（Extension Methods）是一种允许在不修改原始源代码、不继承现有类型的前提下，为现有类型（类、结构体、接口）添加新方法的机制。

- 如何定义？

    ```c#
    public static class XxxExtensions
    {
        public static 返回类型 方法名(this 被扩展类型 obj, 其他参数...)
    }
    ```

    - 通过定义一个**静态类**static class
    - 方法必须是 **static**
    - 第一个参数使用 `this` 关键字修饰，指定被扩展的类型

- 如何使用？

    - 使用时要 `using` 对应命名空间（否则找不到）
    - 调用时与普通实例方法无异，属于一种语法糖。

    也就是说，调用时虽然写了类似实例方法的调用形式，实际上编译器能自动查找对应的静态方法，底层还是使用静态方法来实现。**只是让代码的编写更舒服**。 

    

####  3. 扩展方法实例

写一个order的扩展方法，让订阅默认通知更像实例对象自带的能力：

- `AddDefaultSuccessHandlers()`

- 并返回 `Order`，可以链式写法（像框架一样）

    ```c#
    public static class OrderExtensions
    {
        public static Order AddDefaultSuccessHandlers(this Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
    
            order.OnSuccess += (o) => Console.WriteLine($"[Log] Order paid, amount={o.Amount}");
            order.OnSuccess += (o) => Console.WriteLine($"[SendEmail] Order paid, amount={o.Amount}");
            order.OnSuccess += (o) => Console.WriteLine($"[ReduceStock] Order paid, amount={o.Amount}");
    
            return order;
        }
    }
    ```

- 调用

    ```c#
    class Program
    {
        static void Main()
        {
    		...
                
            var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);
    
            onlineOrder.AddDefaultSuccessHandlers(); //调用扩展方法
            onlineOrder.Pay();
        }
    }
    ```

这一步解决了什么？

- ✅ 重复订阅逻辑被封装成一行

- ✅ 调用处更清晰、更像框架风格

- ✅ 我们用到了上一章的 lambda（在扩展方法里订阅事件）

    

#### 4. 链式调用

新问题：想要“可配置”的订阅，而不是写死默认逻辑。

可以把不同的订阅拆分成不同的方法，只要返回值的类型符合下一次调用方法的参数类型，就能实现链式调用。

- 拆分不同逻辑的订阅方法

    ```c#
    public static class OrderExtensions
    {
        public static Order AddLogHandlers(this Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            order.OnSuccess += (o) => Console.WriteLine($"[Log] Order paid, amount={o.Amount}");
            return order;
        }
        
        public static Order SendEmailHandlers(this Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            order.OnSuccess += (o) => Console.WriteLine($"[SendEmail] Order paid, amount={o.Amount}");
            return order;
        }
        
        public static Order ReduceStockHandlers(this Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            order.OnSuccess += (o) => Console.WriteLine($"[ReduceStock] Order paid, amount={o.Amount}");
            return order;
        }
    
    }
    ```

- 使用链式调用 - 根据需要选择

    ```c#
    class Program
    {
        static void Main()
        {
    		...
                
            var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);
    		// 链式调用
            onlineOrder.AddLogHandlers().SendEmailHandlers().ReduceStockHandlers().Pay();
        }
    }
    ```



现在虽然，不同的动作方法分开了，但是，具体如何实现的逻辑也写死了。需要把具体的实现交出来，因此可以结合委托。

我们用扩展方法再升级：**让调用方把行为作为参数传进来**（再次接上上一章的“委托/Action/lambda”）。

- 使用**委托/Action/lambda** 传递行为

    重新定义一个更通过的扩展方法 AddSuccessHandlers

    ```c#
    public static class OrderExtensions
    {
        public static Order AddSuccessHandlers(this Order order, Action<Order> handler)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            order.OnSuccess += handler;
            return order;
        }
    }
    ```

    链式调用，并能自定义行为

    ```c#
    class Program
    {
        static void Main()
        {
    		...
                
            var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);
    		// 链式调用 
            onlineOrder.AddSuccessHandlers(o => Console.WriteLine($"[Log] Order paid, amount={o.Amount}"))
                .AddSuccessHandlers(o => Console.WriteLine($"[SendEmail] Order paid, amount={o.Amount}"))
                .AddSuccessHandlers(o => Console.WriteLine($"[ReduceStock] Order paid, amount={o.Amount}")).Pay();
        }
    }
    ```



#### 5. 优化

**也可以对类现有的实例方法进行扩展，而不改变类本身的结构和逻辑。**

比如我们的实例方法Pay()， 没有返回值，可能会影响链式调用的继续进行，比如我们需要对pay结束之后有其他动作时。

- 定义一个对Pay()方法的扩展方法PayNow( ) - 内部调用实例方法，再返回一个order

    ```c#
        // ✅ 把“支付”也包装成扩展方法：返回 order 以便链式继续
        public static Order PayNow(this Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            {
                order.Pay();
            }
            return order;
        }
    ```

- 再定义一个pay之后能执行的扩展方法

    ```c#
     // 支付后再执行一个动作（再次用 Action<Order>)
        public static Order PayAfter(this Order order, Action<Order> afterPay)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (afterPay == null) throw new ArgumentNullException(nameof(afterPay));
            if (order.Status != OrderStatus.Paid) throw new InvalidOperationException("Order  is not Paid");
            afterPay(order);
            return order;
        }
    ```

- 执行全链式调用

    ```c#
    class Program
    {
        static void Main()
        {
    		...
                
            var onlineOrder = new OnlineOrder(123456, fakePaymentGateway);
    		// 链式调用 
            onlineOrder.AddSuccessHandlers(o => Console.WriteLine($"[Log] Order paid, amount={o.Amount}")).PayNow().PayAfter(o => Console.WriteLine($"[AfterPay] Status is now {o.Status}"));
            
        }
    }
    ```

**这里发生了什么（关键理解）?**

- 扩展方法只是语法层面的“更顺手调用方式”

- `PayNow()` 内部调用的还是 `order.Pay()`

- 多态仍然生效：Online/Store 各走自己的 Pay 实现

- 规则仍然由 `Order` 体系保证（不会因为扩展方法就能乱来）

    

#### 6. 小结

扩展方法到底解决了什么？

1. **把常用逻辑“包装成像对象自带方法”的调用方式**
     `order.AddDefaultSuccessHandlers()` / `order.AddSuccessHandlers(...)`

2. **链式调用（Fluent API）**：通过“返回 this/返回对象本身”实现
     这就是 ASP.NET Core 配置风格的核心体验来源

3. **扩展方法经常与委托/lambda一起出现**
    比如：`PayAfter(this Order order, Action<Order> afterPay)`

    

### 16. 泛型（Generics）→ 泛型约束（Constraints）

#### 1. 什么问题？

我们已经有订单类型：

- 抽象 `Order`
- `OnlineOrder`, `StoreOrder`

现在很自然会有**“数据存取”**的需求：

- 保存订单
- 获取全部

因此，为order类创建一个仓库OrderRepository， 用来执行上面的业务操作

```c#
public class OrderRepository
{
    private readonly List<Order> _orders;
    public void Add(Order order) => _orders.Add(order);
    public List<Order> GetAll() => new List<Order>(_orders);
}
```

执行上面的业务操作

```c#
class Program
{
    static void Main()
    {

        var fakePaymentGateway = new FakePaymentGateway();

        var repo = new OrderRepository();

        repo.Add(new OnlineOrder(123, fakePaymentGateway));
        repo.Add(new StoreOrder(456).PayNow());

        var orders = repo.GetAll();
        foreach (var o in orders)
        {
            Console.WriteLine($"order Id: {o.Id}, Amount: {o.Amount}, Status: {o.Status}");
        }
    }
}
```

**这样写有什么问题？**

现在老板说：除了订单，还要存：

- `Invoice`（发票）
- `Customer`（客户）
- `Product`（商品）

你会发现你要写：

- `InvoiceRepository`
- `CustomerRepository`
- `ProductRepository`

而它们的 CRUD 结构几乎一样，**会大量重复代码**。 因此使用泛型可以解决。

#### 2. 泛型

泛型的核心思想是**“推迟声明”**：在编写代码时不指定具体类型（用 `T` 代替），直到代码被实际调用时再决定它是 `int`、`string` 还是 `Order`。让同一套代码适用于多种类型，同时保持类型安全。

所有涉及到具体类型的地方，都可以使用泛型。 C# 中常见的泛型家族成员：

- 泛型类 (Generic Classes)
- 泛型接口 (Generic Interfaces)
- 泛型接口 (Generic Interfaces)
- 泛型委托 (Generic Delegates)

每个泛型家族成员，都内置了常用的泛型结构，比如经典的 `List<T>`, `IEnumerable<T>`, `Action<T>等等`



#### 3. 泛型类

这是最常见的**容器型**泛型。它定义了一个可以装载任何类型的“模版结构”。

内置的泛型类几乎都在 `System.Collections.Generic` 命名空间下。它们解决了各种数据的存储问题。

- **`List<T>`**: 最常用的**动态数组**。
- **`Dictionary<TKey, TValue>`**: **键值对集合**（哈希表），查找速度极快。
- **`Queue<T>` / `Stack<T>`**: **队列**（先进先出）和**栈**（后进先出）。
- **`Task<T>`**: **异步任务**的返回值包装，在 `async/await` 编程中随处可见。

**示例：** `List<string> names = new List<string>();` 这里的 `List` 就是内置泛型类。

也可以自定义泛型类，由于对不同类型数据的再组装。

比如改写我们上面的 `OrderRepository`类，为一个泛型类 `Repository`可以存取任何类型

```c#
public class Repository<T>
{
    private readonly List<T> _items =[]; // 使用内置泛型 List<T>
    
    public void  Add(T item) => _items.Add(item);
    public List<T> GetAll() => [.._items];
}
```

使用的时候可以传递具体的类型

```c#
using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        // 使用组合+外部依赖
        var fakePaymentGateway = new FakePaymentGateway();

        // 存储Order
        var orderRepo = new Repository<Order>();
        orderRepo.Add(new OnlineOrder(123,fakePaymentGateway));
        orderRepo.Add(new StoreOrder(456).PayNow());
        var orders=orderRepo.GetAll();
        foreach (var order in orders)
        {
            Console.WriteLine($"order Amount: {order?.Amount}, Status: {order?.Status}");
        }
        
        // 也可以存储其他类型： 比如Invoice
        var invoiceRepo = new Repository<Invoice>();
        invoiceRepo.Add(new Invoice("abc-123",2000));
        invoiceRepo.Add(new Invoice("efg-345",4000));
        var invoices=invoiceRepo.GetAll();
        foreach (var invoice in invoices)
        {
            Console.WriteLine($"invoice N0: {invoice.InvoiceNo} Amount: {invoice?.Amount}, Status: {invoice?.IsPaid}");
        }
    }
}
```

```bash
order Amount: 123, Status: Created
order Amount: 456, Status: Paid

invoice N0: abc-123 Amount: 2000, Status: False
invoice N0: efg-345 Amount: 4000, Status: False
```

**这一步解决了什么？**

- 写一次 `Repository<T>`，就能存 `Order`、存 `Invoice`、存任何类型。
- 这就是泛型类最直观的价值。

**还有什么问题？**

现在只有一个 `Repository<T>` 类。

如果将来想换实现（内存版 / 文件版 / 数据库版），希望上层代码不改。

这就需要接口：**仓储应该提供哪些能力**。

#### 4. 泛型接口

定义了一套**不限制具体类型**的行为规范。

内置接口定义了对象之间交互的“协议”。

- **`IEnumerable<T>`**: **可迭代接口**。这是 LINQ 的基石，所有的集合（List, Array 等）都实现了它。
- **`ICollection<T>`**: 定义了集合的基本操作（添加、删除、计数）。
- **`IComparable<T>`**: 定义了**比较逻辑**。如果你想让你的对象能排序，就得实现它。
- **`IDictionary<TKey, TValue>`**: 定义了字典类应该具备的所有功能。

我们可以自定义一个泛型接口，来约束一套能力（行为），比如

```c#
public interface IRepository<T>
{
    void Add(T item);
    List<T> GetAll();
}
```

以后任何类型如果需要这种接口所具备的能力，都可以使用这个接口来约束。

给我们的泛型`Repository<T>`赋能

```c#
public class Repository<T>: IRepository<T>
{
    private readonly List<T> _items =[];
    
    public void  Add(T item) => _items.Add(item);

    public List<T> GetAll() => [.._items];
}
```

**这一步解决了什么？**

- 业务层可以依赖 `IRepository<Order>`，以后换成数据库仓储也不用改业务层。

#### 5. 泛型方法 

类本身可能不是泛型的，但某个**动作（功能）**可以处理多种类型。因此，把这种功能也可以抽象成泛型方法。

比如，做 Web API 时，很常见的流程是：

> 从仓储取 `Order` → 转成返回模型 DTO → 返回给前端

如果不用泛型方法，会写很多“针对不同类型的 map 方法”。

我们专门写一个泛型方法 Map<TSource, TResult>， 来映射不限类型的方法。 写之前，需要一个DTO模型的类。

> **DTO模型 :**
>
> DTO 的意思是**数据传输对象(Data Transfer Object)**。 它们被用作从服务返回的对象，以避免暴露领域实体。 例如，如果你有一个名为User 的类，其中包含一个Password 属性，你不想从你的API 返回这个数据，所以你可以创建一个UserDTO，它没有这个属性，并从你的API 安全地返回它。

定义DTO模型类 OrderDto

```c#
public class OrderDto
{
    public decimal Amount { get; set; }
    public OrderStatus Status { get; set; }
    public string Type { get; set; } = "";
}
```

先定义一个方法（可以变成扩展方法）来映射Order数据

```c#
public static class Mapper
{
    public static OrderDto Map(this Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        
        return new OrderDto()
        {
            Amount = order.Amount,
            Status = order.Status,
            Type = order.GetType().Name,
        };
    }
}
```

使用

```c#
class Program
{
    static void Main()
    {
        var order = new StoreOrder(123);
        var orderDto= order.Map();
        Console.WriteLine($"{orderDto.Type} - {orderDto.Amount} - {orderDto.Status}");
    }
}
```

但是映射的逻辑写死在内部了，使用委托，把逻辑交给外部使用者

```c#
public static class Mapper
{
    public static OrderDto Map(this Order order, Func<Order, OrderDto> mapper)
    {
        if (mapper == null) throw new ArgumentNullException(nameof(order));
        return mapper(order); // 委托回调
    }
}
```

```c#
class Program
{
    static void Main()
    {
        var order = new StoreOrder(123);
        var orderDto= order.Map(o => new OrderDto()
        {
            Amount = o.Amount,
            Status = o.Status,
            Type = o.GetType().Name
        });
        Console.WriteLine($"{orderDto.Type} - {orderDto.Amount} - {orderDto.Status}");
    }
}
```

现在的类型是写死的，只适用于Order, 改成泛型， 变成一个可扩展的泛型方法

```c#
public static class Mapper
{
    public static TResult Map<TResult,TSource>(this TSource source, Func<TSource, TResult> mapper)
    {
        if (mapper == null) throw new ArgumentNullException(nameof(mapper));
        return mapper(source);
    }
}
```

使用此泛型方法

```c#
class Program
{
    static void Main()
    {
        var order = new StoreOrder(123);
        var orderDto = order.Map(o => new OrderDto()
        {
            Amount = o.Amount,
            Status = o.Status,
            Type = o.GetType().Name
        });

        Console.WriteLine($"{orderDto.Type} - {orderDto.Amount} - {orderDto.Status}");

        // 不限类型使用，使用委托回调，自定义逻辑
        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var result = arr.Map(a =>
        {
            string str = "";
            foreach (var i in a)
            {
                str += i;
            }

            return str;
        });

        Console.WriteLine(result);
    }
}
```

```bash
StoreOrder - 123 - Created
12345678910
```



#### 6. 泛型委托

这是“函数的模版”，它规定了函数应该长什么样，但不规定处理什么数据。

- 内置委托 - 为了让不用每次都手动写 `delegate` 关键字，官方直接给了你三个万能模板：
    - **`Action<T1, T2, ...>`**: **无返回值**的函数。最多支持 16 个参数。 *用途：* 打印日志、修改状态、执行动作。
    - **`Func<T1, ..., TResult>`**: **有返回值**的函数。最后一个泛型参数永远是返回值类型。*用途：* 计算数值、转换对象、LINQ 的 `Select`。
    - **`Predicate<T>`**: 返回值为 `bool` 的函数（相当于 `Func<T, bool>`）。*用途：* 过滤条件、判断是否存在。

上面的示例中： lambda 本质上是在创建一个委托实例，而 Action/Func 就是泛型委托类型



#### 7. 泛型约束

**什么问题？**

现在，我们使用的泛型接口或者类型太自由了，没有约束力。比如我们有个新的需求：

- 使用id查询 GetById( ) 的功能

如果想在 `IRepository<T>` 里加：

```c#
T? GetById(int id);
```

但是**不是所有 T 都有 Id**。比如现有 `Order` 类目前也没有 `Id` 属性，所以我们不能“假装它有”。

这就是“泛型自由度太大”的典型矛盾：

- 想写通用代码
- 又需要 T 具备某种能力

👉 正解：**用接口表达能力，再用 where 约束保证能力存在**。

也就是说，把这个格外需要的能力，封装成一个接口，需要时，配合where加上这个约束。

先定义能力接口：IHasId。 不修改原有的结构

```c#
public interface IHasId
{
    int Id { get; }
}
```

原有的Order类补上Id的功能 - 使用partial关键字

```c#
public abstract partial class Order : IHasId
{
    private static int _nextId = 1;
    public int Id { get; } = _nextId++;
}
```

扩展 IRepository：where T : IHasId

```c#
public interface IRepository<T> where T : IHasId
{
    void Add(T item);
    List<T> GetAll();
    T? GetById(int id);
}
```

`Repository<T>` 实现 GetById（现在可以安全访问 x.Id）

```c#
public class Repository<T>: IRepository<T>  where T: IHasId
{
    private readonly List<T> _items =[];
    
    public void  Add(T item) => _items.Add(item);

    public List<T> GetAll() => [.._items];
    
    public T? GetById(int id) => _items.Find(x => x.Id == id);
}
```

```c#
using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        var fakePaymentGateway = new FakePaymentGateway();
        
        var nRepo = new Repository<Order>();
        nRepo.Add(new OnlineOrder(999, fakePaymentGateway));
        nRepo.Add(new OnlineOrder(888, fakePaymentGateway));
        var res=nRepo.GetById(1);
        Console.WriteLine($"{res?.Id} - {res?.Amount} - {res?.Status}");
    }
}
```

**这一节得到什么？**

- `where T : IHasId` 让编译器保证：T 一定有 `Id`
- 你的通用仓储可以写 `x.Id`，不会报错

#### 8. 泛型结构体

用于轻量级、高性能的**值类型**包装。

`GetById` 返回 `T?` 只能表达“有/没有”，但无法携带错误原因。真实 Web API 常常需要：

- 找不到：NotFound
- 参数不合法：BadRequest
- 等等

我们用一个泛型结构体 `Result<T>` 表达：

- `IsSuccess`
- `Value`
- `Error`

```c#
public readonly struct Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new Result<T>(true, value, null);
    public static Result<T> Fail(string error) => new Result<T>(false, default, error);
}
```

让仓储用 Result<T> 返回（更贴近 API）

```c#
public interface IRepository<T> where T : IHasId
{
    void Add(T item);
    List<T> GetAll();
    Result<T> GetById(int id);
}
```

```c#
public class Repository<T> : IRepository<T> where T : IHasId
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public List<T> GetAll() => new List<T>(_items);

    public Result<T> GetById(int id)
    {
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T>.Fail("Not found") : Result<T>.Success(found);
    }
}
```

```c#
class Program
{
    static void Main()
    {

        var fakePaymentGateway = new FakePaymentGateway();
              
        var nRepo = new Repository<Order>();
        nRepo.Add(new OnlineOrder(999, fakePaymentGateway));
        nRepo.Add(new OnlineOrder(888, fakePaymentGateway));
        
        var res=nRepo.GetById(1);
        Console.WriteLine(res.IsSuccess);
        Console.WriteLine(res.Value.Amount);
        
    }
}
```



#### 9. 小结

**泛型类**：Repository<T>`（一次实现，多类型复用）

**泛型接口**：`IRepository<T>`（抽象规则，便于替换实现）

**泛型约束**：`where T : IHasId`（保证 T 有 Id，才能写 GetById）

**泛型结构体**：`Result<T>`（表达成功/失败 + 携带值/错误）

**泛型方法**：`Map<TSource, TResult>`（实体→OrderDto，API 输出）

**泛型委托**：`Func<>/Action<>`（事件/lambda里大量使用）



### 17. Task / async / await（异步）

#### 1. **什么问题？**

在 Web API 中，耗时通常不是 CPU 计算，而是 **IO 等待**：

- 数据库查询
- HTTP 请求第三方服务
- 读写文件

使用同步方法，遇到 IO 等待时，任务会傻等占着线程。一旦变成“慢查询”，调用处就会被卡住。

比如下面：我们先写一个“同步”的慢查询：用 `Thread.Sleep(3000)` 模拟 3 秒数据库延迟。

```c#
public class SlowSyncRepository<T>:IRepository<T> where T: IHasId
{
    private readonly List<T> _items= [];
    
    public void Add(T item)
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        return _items;
    }
    
    public Result<T> GetById(int id)
    {
        // 模拟慢 IO：阻塞线程 3 秒
        Thread.Sleep(3000);
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T>.Fail("Not found") : Result<T>.Success(found);
    }
}
```

使用这些同步方法

```c#
class Program
{
    static void Main()
    {
        var slowRepo = new SlowSyncRepository<Order>();
        slowRepo.Add(new StoreOrder(123456)); // 这里线程被卡住 3 秒
        Console.WriteLine("3秒之后执行");
        
        var orders = slowRepo.GetAll(); // 这里线程被卡住 3 秒
        Console.WriteLine("3秒之后执行");
        foreach (var o in orders)
        {
            Console.WriteLine(o.Amount);
        }

        var result = slowRepo.GetById(1); // 这里线程被卡住 3 秒
        Console.WriteLine("3秒之后执行");
        Console.WriteLine(result.Value?.Status);
    }
}
```

**问题是什么？**

- 使用这些同步方法期间，线程完全被阻塞（Sleep/IO 等待）
- 在 Web API 里，这会让线程池压力变大、并发能力下降

因此，我们要把“等待”变成异步等待， 而方法标识成异步方法。

#### 2. 异步 async / await

异步的理解：遇到 IO 等待时，不要傻等占着线程，而是“挂起等待”，等结果回来再继续。

通俗理解就是：代码运行层面，要等待。而线程运行方面，不等，释放此线程去执行其他任务。

**异步能提升并发处理能力**，尤其是 Web 服务。

**如何实现异步？**

使用3个关键字标识：

- 异步的任务使用await等结果
- 想在方法里用 `await`，方法必须标记 `async`
- 方法返回类型通常是 `Task` 或 `Task<T>`

Task 是什么：代表“未来会完成的一件事”。类似于js中的Promise。

- `Task`：表示一个将来完成的操作（无返回值）

- `Task<T>`：表示将来完成并产生一个 `T` 结果的操作 ，是一个泛型类

    

#### 3. 异步方法的使用

先改造新的repository接口：

- 方法名通常加 `Async`（约定俗成，便于阅读）
- 类型是Task/ Task<T>

```c#
public interface IAsyncRepository<T>
{
    Task AddAsync(T item);
    Task<List<T?>> GetAllAsync();
    Task<Result<T?>> GetByIdAsync(int id);
}
```

接下来如何写异步repository呢？？

- 方法名标记 `async`
- 异步任务标记`await`

```c#
public class AsyncRepository<T>: IAsyncRepository<T>  where T: IHasId
{
    private readonly List<T> _items =[];
    
    public async Task  AddAsync (T item)
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        _items.Add(item);
    }

    public async Task<List<T?>> GetAllAsync()
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        return  [.._items];
    }
    
    public async Task<Result<T?>> GetByIdAsync(int id)
    {
        // 模拟 IO 延迟（比如写数据库）
        await Task.Delay(3000);
        var found = _items.Find(x => x.Id == id);
        return found is null ? Result<T?>.Fail("Not found") : Result<T?>.Success(found);
    }
}
```

实现异步任务操作 

- 最外层的main函数也要实现异步（逐层传递）, 一路 async 到顶 
- main函数也要改成 Task 类型 

```c#
using System.ComponentModel;
using System.Globalization;

namespace ConsoleApp_basic;

class Program
{
    static async Task Main()
    { 
        var asyncRepo = new AsyncRepository<Order>();
        
        await asyncRepo.AddAsync(new StoreOrder(123456)); // 异步方法，等3秒执行后面的，但线程不卡
        Console.WriteLine("3秒之后执行");
        
        var orders = await asyncRepo.GetAllAsync(); // 异步方法，等3秒执行后面的，但线程不卡
        Console.WriteLine("3秒之后执行");
        foreach (var o in orders)
        {
            Console.WriteLine(o?.Amount);
        }
        
        var result =await asyncRepo.GetByIdAsync(1); // 异步方法，等3秒执行后面的，但线程不卡
        Console.WriteLine("3秒之后执行");
        Console.WriteLine(result.Value?.Status);

    }
}
```

注意：如果忘记写await, 拿到的结果是Task类型，而不是T类型

#### 4. 小结

- `Task`/`Task<T>`：代表未来完成的操作/未来的结果，一个可等待的类型
- `async`：仅仅标识，方法内将使用 `await`
- `await`：真正发生异步的地方，异步等待结果，不阻塞线程（尤其适合 IO）
- Web API 常见模式：仓储/服务方法 `Async`，一路 `await` 到 endpoint



### 18. LINQ

#### 1. 什么问题？

我们需要对订单集合的具体数据进行操作，比如循环查询，筛选，排序等等，目前的代码结构下操作，集合处理会很啰嗦。

比如，循环过滤已支付订单并取金额

```c#
class Program
{
    static void Main()
    {
        var fakePaymentGateway = new FakePaymentGateway();

        var orders = new List<Order>()
        {
            new OnlineOrder(123, fakePaymentGateway),
            new StoreOrder(456),
            new OnlineOrder(789, fakePaymentGateway),
        };

        // 支付2个订单
        orders[0].Pay();
        orders[1].Pay();

        // 过滤筛选已经支付的订单金额
        var payAmounts = new List<decimal>();
        foreach (var o in orders)
        {
            if (o.Status == OrderStatus.Paid)
            {
                payAmounts.Add(o.Amount);
            }
        }

        // 循环打印出已经支付的金额
        Console.WriteLine("Paid amounts:");
        foreach (var amount in payAmounts)
        {
            Console.WriteLine(amount);
        }
    }
}
```

**问题是什么？**

- 逻辑分散：过滤+取值+收集写了很多行
- 很难“链式表达意图”
- 组合多个条件/映射会更长

因此，我们需要把这些常见操作变成“可组合的扩展方法”。这就是LINQ

#### 2. 什么是LINQ？

LINQ（Language Integrated Query） 本质上就是：内置的**一堆对 `IEnumerable<T>` 的扩展方法**，而这些扩展方法的参数通常是 **委托（lambda）**，并且全是 **泛型**。

LINQ（Language Integrated Query）让你用统一方式对集合做：

- 过滤（Where）
- 投影/映射（Select）
- 排序（OrderBy）
- 聚合/判断（Any/All/Count/Sum）

学习LINQ，能够真正读懂并写出类似下面这种“框架风格”的代码：

```c#
orders.Where(o => o.Status == Paid).Select(o => o.Amount).ToList();
```

#### 3. Where（过滤）/  Select（投影/映射）

`Where` 接收一个条件函数（委托），返回满足条件的序列：

```c#
orders.Where(o => o.Status == Paid)
```

这里的 `o => ...` 就是 lambda（第14章）

`Select` 把每个元素映射成另一个形态：

```c#
orders.Select(o => o.Amount)
```

用 LINQ 改写 **'循环过滤已支付订单并取金额'**的逻辑

**注意：** 

- LINQ 需要 `using System.Linq;`
- LINQ 经常需要 `.ToList()` / `.ToArray()`。

```c#
class Program
{
    static void Main()
    {
    	...

        // 过滤筛选已经支付的订单金额    
        // ✅ LINQ：Where + Select + ToList
        var payAmounts = orders.Where(o => o.Status == OrderStatus.Paid).Select(o => o.Amount).ToList();

        // 循环打印出已经支付的金额
        Console.WriteLine("Paid amounts:");
        foreach (var amount in payAmounts)
        {
            Console.WriteLine(amount);
        }
    }
}
```

**为什么 Where/Select 之后还要 ToList()？**

LINQ 很多操作是对 `IEnumerable<T>` 的**延迟执行**（lazy evaluation）：

- `Where` / `Select` 只是“描述规则”
- 固定结果，就用 ToList() 把结果立刻算出来
- 真正遍历时（foreach、ToList、Count 等）才执行。

#### 4. LINQ 其他常用操作

- Any / All：判断是否存在/是否全部满足

    ```c#
    bool anyPaid = orders.Any(o => o.Status == OrderStatus.Paid);
    bool allPaid = orders.All(o => o.Status == OrderStatus.Paid);
    ```

- FirstOrDefault：取第一个匹配项（可能为 null）

    ```c#
    var firstPaid = orders.FirstOrDefault(o => o.Status == OrderStatus.Paid);
    ```

- OrderBy：排序

    ```c#
    var sorted = orders.OrderBy(o => o.Amount).ToList();
    ```

- GroupBy：按类型分组（Online/Store）

    ```c#
    var groups = orders.GroupBy(o => o.GetType().Name);
    ```

#### 5. LINQ 综合练习：像 Web API 一样处理数据

在 Web API 里，通常不会直接返回“领域对象/实体”（Order 可能有很多内部信息）。

更常见做法是：**映射成一个“返回模型”**（DTO 思想），只给前端需要的字段。

我们之前已经定义过返回模型OrderDto

```c#
public class OrderDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public OrderStatus Status { get; set; }
    public string Type { get; set; } = "";
}
```

**第一步：准备数据（订单列表，含不同类型和状态）**

```c#
class Program
{
    static void Main()
    {
        var fakePaymentGateway = new FakePaymentGateway();
        
        //创建订单列表
        var orders = new List<Order>()
        {
            new OnlineOrder(2234132, fakePaymentGateway),
            new StoreOrder(54624),
            new OnlineOrder(754523, fakePaymentGateway),
            new StoreOrder(3141),
            new StoreOrder(625342353),
            new StoreOrder(2314454),
            new OnlineOrder(7245, fakePaymentGateway),
            new OnlineOrder(1653735, fakePaymentGateway),
        };

        // 支付2个订单
        orders[0].Pay();
        orders[2].Pay();
        orders[3].Pay();
        orders[5].Pay();
        orders[6].Pay();
        orders[7].Pay();
        
        Console.WriteLine("=== Raw Orders ===");
        foreach (var o in orders)
        {
            Console.WriteLine($"{o.Id} {o.GetType().Name} {o.Amount} {o.Status}");
        }
    }
}
```

```bash
=== Raw Orders ===
1 OnlineOrder 2234132 Paid
2 StoreOrder 54624 Created
3 OnlineOrder 754523 Paid
4 StoreOrder 3141 Paid
5 StoreOrder 625342353 Created
6 StoreOrder 2314454 Paid
7 OnlineOrder 7245 Paid
8 OnlineOrder 1653735 Paid
```

订单状态：有的 Paid，有的 Created

**第二步：过滤（Where）——只拿已支付订单**

现在需求：只返回已支付订单（Paid）。

```c#
class Program
{
    static void Main()
    {

		//创建订单列表
 		...

        // 支付2个订单
		...
        
        // 过滤（Where）——只拿已支付订单
        var paidOrders = orders.Where(o => o.Status == OrderStatus.Paid).ToList();
        
        Console.WriteLine("=== Paid Orders ===");
        
        foreach (var o in paidOrders)
        {
            Console.WriteLine($"{o.Id} {o.GetType().Name} {o.Amount} {o.Status}");
        }

    }
}
```

```bash
=== Paid Orders ===
1 OnlineOrder 2234132 Paid
3 OnlineOrder 754523 Paid
4 StoreOrder 3141 Paid
6 StoreOrder 2314454 Paid
7 OnlineOrder 7245 Paid
8 OnlineOrder 1653735 Paid
```

**第三步：映射（Select）——把 Order 转成 OrderDto（返回模型）**

现在需求：API 返回 `OrderDto` 列表，而不是 `Order`。

```c#
class Program
{
    static void Main()
    {

		//创建订单列表
 		...

        // 支付2个订单
		...
        
        // 过滤（Where）——只拿已支付订单
		...

        // 映射（Select）——把 Order 转成 OrderDto（返回模型）
        var result = paidOrders.Select(p => new OrderDto()
        {
            Id = p.Id,
            Type = p.GetType().Name,
            Amount = p.Amount,
            Status = p.Status
        }).ToList();
        
        Console.WriteLine("=== API Result (OrderDto) ===");
        foreach (var r in result)
        {
            Console.WriteLine($"{r.Id} {r.Type} {r.Amount} {r.Status}");
        }

    }
}
```

```bash
=== API Result (OrderDto) ===
1 OnlineOrder 2234132 Paid
3 OnlineOrder 754523 Paid
4 StoreOrder 3141 Paid
6 StoreOrder 2314454 Paid
7 OnlineOrder 7245 Paid
8 OnlineOrder 1653735 Paid
```



到这一步，已经做出了 Web API 最常见的“返回前处理”：

> **Where（过滤） + Select（映射） + ToList（执行）**



**第四步：排序（OrderBy/OrderByDescending）**

现在需求：返回结果按金额从大到小排序。

```c#
class Program
{
    static void Main()
    {

		//创建订单列表
 		...

        // 支付2个订单
		...
        
        // 过滤（Where）——只拿已支付订单
		...

        // 映射（Select）——把 Order 转成 OrderDto（返回模型）
        ...
            
		// 排序：返回结果按金额从大到小排序
        var desOrders = result.OrderByDescending(o => o.Amount).ToList();
        
        Console.WriteLine("=== API Result OrderByDescending ===");
        foreach (var r in desOrders)
        {
            Console.WriteLine($"{r.Id} {r.Type} {r.Amount} {r.Status}");
        }
    }
}
```

```bash
=== API Result OrderByDescending ===
6 StoreOrder 2314454 Paid
1 OnlineOrder 2234132 Paid
8 OnlineOrder 1653735 Paid
3 OnlineOrder 754523 Paid
7 OnlineOrder 7245 Paid
4 StoreOrder 3141 Paid
```



**第五步：统计与分组（GroupBy + Count + Sum）**

现在需求：做一个简单报表（很像后台管理 API）：

- 按订单类型分组（OnlineOrder / StoreOrder）
- 统计每组的数量 Count
- 统计每组的总金额 Sum

我们先定义一个统计模型：

```c#
public class OrderReportItem
{
    public string Type { get; set; } = "";
    public int Count { get; set; }
    public decimal TotalAmount { get; set; }
}
```

过滤 + 分组统计 LINQ操作

```c#
class Program
{
    static void Main()
    {

		//创建订单列表
 		...

        // 支付2个订单
		...
        
        // 过滤（Where）——只拿已支付订单
		...

        // 映射（Select）——把 Order 转成 OrderDto（返回模型）
        ...
            
		// 排序：返回结果按金额从大到小排序
        ...
        
        // 统计与分组（GroupBy + Count + Sum）    
      	var report = desOrders.GroupBy(o => o.Type).Select(r => new OrderReportItem()
        {
            Type = r.Key, // Key就是分组的依据 （这里就是Type)
            Count = r.Count(),
            TotalAmount = r.Sum(x => x.Amount)
        }).ToList();
        
        Console.WriteLine("=== Paid Orders Report ===");
        foreach (var item in report)
        {
            Console.WriteLine($"{item.Type} | Count={item.Count} | TotalAmount={item.TotalAmount}");
        }      
    }
}
```

```bash
=== Paid Orders Report ===
StoreOrder | Count=2 | TotalAmount=2317595
OnlineOrder | Count=4 | TotalAmount=4649635
```

Web API 高频数据处理, 组合链条非常关键：

- `Where`：过滤
- `Select`：映射成返回模型
- `OrderBy/OrderByDescending`：排序
- `GroupBy` + `Count/Sum`：统计
- `ToList`：执行并固化结果（避免延迟执行带来的意外）



#### 6. 小结

- LINQ 是一组对 `IEnumerable<T>` 的扩展方法（第15章）

- 条件/映射通常用 lambda（第14章）

- LINQ 大多是延迟执行，`ToList()` 会立刻执行并把结果固定下来

- Web API 常用：Where、Select、Any、FirstOrDefault、OrderBy、GroupBy
