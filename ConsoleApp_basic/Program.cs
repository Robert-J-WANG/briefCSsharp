namespace ConsoleApp_basic;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        // // for loop
        // for (int i = 0; i < numbers.Length; i++)
        // {
        //     Console.WriteLine(numbers[i]);
        // }
        //
        // //foreach loop
        // foreach (int number in numbers)
        // {
        //     Console.WriteLine(number);
        // }
        //
        // // while loop
        // int time = 0;
        // while (time < numbers.Length)
        // {
        //     Console.WriteLine(numbers[time]);
        //     time++;
        // }
        //
        // //do while loop
        // do
        // {
        //     Console.WriteLine("hello world");
        //     time++;
        // } while (numbers.Length > 0);

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
            break;
            // continue;
            // return;
        }

        Console.WriteLine("hello world");
    }
}