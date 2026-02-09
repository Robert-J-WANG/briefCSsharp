namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        // int[] arr = new int[5];
        // arr[0] = 1;
        // arr[1] = 2;
        // arr[2] = 3;
        // arr[3] = 4;
        // arr[4] = 5;
        int[] arr = { 1, 2, 3, 4, 5 };
        Console.WriteLine(arr[0]);

        // 空数组
        int[] arr2 = [];
        Console.WriteLine(arr2.Length);
        // arr2[0] = 1; // 长度固定，不能添加元素
        // Console.WriteLine(arr2.Length); // 报错

        //空list
        var list = new List<int>();
        Console.WriteLine(list.Count);
        list.Add(1);
        list.Add(2);
        Console.WriteLine(list.Count);

        int[,] grid =
        {
            { 1, 2, 3, 4, 5 },
            { 1, 2, 3, 4, 5 }
        };
        Console.WriteLine(grid[0, 0]);
    }
}