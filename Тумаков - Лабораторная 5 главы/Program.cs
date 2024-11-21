using System;

public class MainClass
{
    public static int GetMax(int number1, int number2)//Метод для Упражнения 5.1
    {
        return Math.Max(number1, number2);
    }
    public static void Swap(ref int a, ref int b)//Метод для Упражнения 5.2
    {
        int c = a;
        a = b;
        b = c;
    }
    public static bool Factorial(int n, out long result)//Метод для Упражнения 5.3
    {
        result = 1;

        try
        {
            checked
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
    }
    public static long Factorial(int n)//Метод для Упражнения 5.4
    {
        try
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        catch (OverflowException)
        {
            return 0;
        }
    }
    public static int GCD(int a, int b)//Метод для Домашнего задания 5.1(1)
    {
        while (a != b)
        {
            if (a > b)
            {
                a = a - b;
            }
            else
            {
                b = b - a;
            }
        }

        return a;
    }
    public static int GCD(int a, int b, int c)//Метод для Домашнего задания 5.1(2)
    {
        int gcdAB = GCD(a, b);
        int gcdABC = GCD(gcdAB, c);

        return gcdABC;
    }
    public static int Fibonacci(int n)//Метод для Домашнего задания 5.2
    {

        if (n == 1 || n == 2)
        {
            return 1;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
    public static void Main()
    {
        Console.WriteLine("Упражнение 5.1\n");
        //Написать метод, возвращающий наибольшее из двух чисел. Входные
        //параметры метода – два целых числа.Протестировать метод.
        Console.WriteLine("Наибольшее из двух чисел\n");
        try
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Наибольшее из двух чисел: {0}", GetMax(num1, num2));
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        //////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 5.2\n");
        //Написать метод, который меняет местами значения двух передаваемых
        //параметров.Параметры передавать по ссылке. Протестировать метод.
        Console.WriteLine("Меняет местами значение переменных\n");
        try
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());

            Swap(ref num1, ref num2);

            Console.WriteLine("\nПервое число = " + num1);
            Console.WriteLine("Второе число = " + num2);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        //////////////////////////////////////////////////////////////////////////////////
     
        Console.WriteLine("\nУпражнение 5.3\n");
        //Написать метод вычисления факториала числа, результат вычислений
        //передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
        //если в процессе вычисления возникло переполнение, то вернуть значение false.Для
        //отслеживания переполнения значения использовать блок checked.
        try
        {
            Console.Write("Введите число, у которого хотите узнать факториал: ");
            int number = int.Parse(Console.ReadLine());
            long factorial;
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Factorial(number, out factorial))
            {
                Console.WriteLine($"!{number} = {factorial}");
            }
            else
            {
                Console.WriteLine($"!{number} вызвал переполнение");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: факториал отрицательного числа вычислить нельзя!");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nУпражнение 5.4\n");
        //Написать рекурсивный метод вычисления факториала числа.
        try
        {
            Console.Write("Введите число, у которого хотите узнать факториал: ");
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            long result = Factorial(num);
            if (result == 0)
            {
                throw new OverflowException();
            }
            else
            {
                Console.WriteLine($"!{num} = {result}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: факториал отрицательного числа вычислить нельзя!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: факториал введенного числа вызвал переполнение");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nДомашнее задание 5.1(1)\n");
        //Написать метод, который вычисляет НОД двух натуральных чисел
        //(алгоритм Евклида).
        Console.WriteLine("НОД двух чисел\n");
        try
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 < 0 || num2 < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int gcd = GCD(num1, num2);

            Console.WriteLine($"НОД чисел {num1} и {num2} равен {gcd}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: число должно быть неотрицательным!");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nДомашнее задание 5.1(2)\n");
        //Написать метод с тем же именем, который вычисляет НОД трех натуральных чисел.
        Console.WriteLine("НОД трех чисел\n");
        try
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int num3 = int.Parse(Console.ReadLine());
            if (num1 < 0 || num2 < 0 || num3 < 0)
            {
                throw new ArgumentOutOfRangeException(); 

            }
            int gcdABC = GCD(num1, num2, num3);
            Console.WriteLine($"НОД чисел {num1}, {num2} и {num3} равен {gcdABC}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: число должно быть неотрицательным!");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nДомашнее задание 5.2\n");
        //Написать рекурсивный метод, вычисляющий
        //значение n-го числа ряда Фибоначчи.Ряд Фибоначчи – последовательность
        //натуральных чисел 1, 1, 2, 3, 5, 8, 13... Для таких чисел верно соотношение
        //Fk = F(k - 1) + F(k - 2).
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