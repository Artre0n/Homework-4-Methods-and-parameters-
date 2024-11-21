using System;

public class MainClass
{
    public static int Fibonacci(int n)
    {

        if (n == 1 || n == 2)
        {
            return 1;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }


    public static void Main()
    {
        try
        {
            Console.Write("Введите номер числа ряда Фибоначчи: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine($"Значение {n}-го числа ряда Фибоначчи: {Fibonacci(n)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: число должно быть больше нуля!");
        }
    }
}