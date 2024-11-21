using System;
public class MainClass
{
    static void ShowArray(int[] array)// Выводит массив на экран
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
    public static int[] RandomizerArray(int n)// Генерирует случайный массив чисел
    {
        Random random = new Random();
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(1, 100);
        }

        return array;
    }
    public static int Calculate(ref long product, out double average, params int[] numbers)// Метод для упражнения 2
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
            product *= number;
        }

        average = (double)sum / numbers.Length;

        return sum;
    }
    static void DrawNumber(int number)
    {
        switch (number)
        {
            case 0:
                Console.WriteLine(" #### ");
                Console.WriteLine("#    #");
                Console.WriteLine("#    #");
                Console.WriteLine("#    #");
                Console.WriteLine(" #### ");
                break;
            case 1:
                Console.WriteLine("  #  ");
                Console.WriteLine(" ##  ");
                Console.WriteLine("  #  ");
                Console.WriteLine("  #  ");
                Console.WriteLine(" ### ");
                break;
            case 2:
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine(" #### ");
                Console.WriteLine(" #    ");
                Console.WriteLine(" #### ");
                break;
            case 3:
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine(" #### ");
                break;
            case 4:
                Console.WriteLine(" #  # ");
                Console.WriteLine(" #  # ");
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine("    # ");
                break;
            case 5:
                Console.WriteLine(" #### ");
                Console.WriteLine(" #    ");
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine(" #### ");
                break;
            case 6:
                Console.WriteLine(" #### ");
                Console.WriteLine(" #    ");
                Console.WriteLine(" #### ");
                Console.WriteLine(" #  #");
                Console.WriteLine(" #### ");
                break;
            case 7:
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine("   #  ");
                Console.WriteLine("  #   ");
                Console.WriteLine(" #    ");
                break;
            case 8:
                Console.WriteLine(" #### ");
                Console.WriteLine("#    #");
                Console.WriteLine(" #### ");
                Console.WriteLine("#    #");
                Console.WriteLine(" #### ");
                break;
            case 9:
                Console.WriteLine(" #### ");
                Console.WriteLine(" #  # ");
                Console.WriteLine(" #### ");
                Console.WriteLine("    # ");
                Console.WriteLine(" #### ");
                break;
        }
    }//Метод для упражнения 3
    public enum Grumpiness // Перечисления уровня ворчливости
    {
        Низкий,
        Средний,
        Высокий
    }

    
    public struct Grandpa // Собственно Дед для упражнения 4
    {
        public string Name;
        public Grumpiness Level;
        public string[] Phrases;
        public int BlackEyes;

        public Grandpa(string name, Grumpiness level, string[] phrases) // Инициализация деда
        {
            Name = name;
            Level = level;
            Phrases = phrases;
            BlackEyes = 0;
        }

        
        public int CheckProfanity(params string[] profanityWords)// Метод для проверки матерных слов деда и подсчета фингалов от бабки
        {
            foreach (var phrase in Phrases)
            {
                foreach (var profanity in profanityWords)
                {
                    if (phrase.ToLower().Contains(profanity.ToLower()))
                    {
                        BlackEyes++;
                    }
                }
            }
            return BlackEyes;
        }
    }
    public static void Main()
    {
        
        Console.WriteLine("Упражнение 1\n");
        //Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
        //которые нужно поменять местами. Вывести на экран получившийся массив.
        try
        {

            int[] arr = RandomizerArray(20);

            Console.WriteLine("Исходный массив:");
            ShowArray(arr);


            Console.Write("Введите первое число для замены: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число для замены: ");
            int num2 = int.Parse(Console.ReadLine());

            if ((num1 < 1 || num1 > 100) && (num2 < 1 || num2 > 100))
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((arr.Contains(num1) == false) && (arr.Contains(num2) == false))
            {
                throw new ArgumentException();
            }
            int index1 = Array.IndexOf(arr, num1);
            int index2 = Array.IndexOf(arr, num2);

            if (index1 != -1 && index2 != -1)
            {
                int temp = arr[index1];
                arr[index1] = arr[index2];
                arr[index2] = temp;
            }

            Console.WriteLine("Измененный массив:");
            ShowArray(arr);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целое число");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Ошибка: числа должны быть от 1 до 100");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ошибка: числа для замены должны быть из массива");
        }
        ////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nУпражнение 2\n");
        //Написать метод, где в качества аргумента будет передан массив (ключевое слово params).
        //Вывести сумму элементов массива(вернуть). Вывести(ref) произведение
        //массива.Вывести(out) среднее арифметическое в массиве.
        int[] numbers = RandomizerArray(6);
        long product = 1;
        double average;

        int sum = Calculate(ref product, out average, numbers);

        Console.Write("Массив: ");
        ShowArray(numbers);

        average = Math.Round(average, 3);
        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Среднее арифметическое: {average}");
        Console.ReadKey();
        //////////////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nУпражнение 3\n");
        //Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
        //изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
        //должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
        //пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
        //завершает работу, если пользователь введёт слово: exit или закрыть(оба варианта
        //должны сработать) - консоль закроется.
        while (true)
        {
            Console.Write("Введите число или 'exit/закрыть' для выхода: ");
            string input = Console.ReadLine().ToLower();

            // Проверка на выход из программы
            if (input.Equals("exit") || input.Equals("закрыть"))
            {
                break;
            }

            try
            {
                int number = int.Parse(input);

                if (number >= 0 && number <= 9)
                {
                    DrawNumber(number);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введите целое число");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        
        Console.WriteLine("\nУпражнение 4\n");
        //Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
        //фраз для ворчания(прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
        //бабки = 0 по умолчанию. Создать 5 дедов.У каждого деда - разное количество фраз для
        //ворчания.Напишите метод(внутри структуры), который на вход принимает деда,
        //список матерных слов (params).Если дед содержит в своей лексике матерные слова из
        //списка, то бабка ставит фингал за каждое слово.Вернуть количество фингалов.
        // Создание 5 дедов с разным количеством фраз
        Grandpa ded1 = new Grandpa("Дед Михаил", Grumpiness.Средний, ["Проститутки!", "Гады!", "Японский городовой!"]);
        Grandpa ded2 = new Grandpa("Дед Владимир", Grumpiness.Низкий, ["Гады!", "Куда мир катится?", "А вот в наше время..."]);
        Grandpa ded3 = new Grandpa("Дед Андрей", Grumpiness.Низкий, ["Паразиты!", "Как же вы достали!"]);
        Grandpa ded4 = new Grandpa("Дед Алексей", Grumpiness.Высокий, ["Гады!", "Черти!", "Едрить твою налево!"]);
        Grandpa ded5 = new Grandpa("Дед Василий", Grumpiness.Средний, ["Все пропало!", "Проститутки!"]);

        string[] profanityWords = { "Проститутки", "Гады", "Черти", "Едрить твою налево" };

        Console.WriteLine($"{ded1.Name} получил {ded1.CheckProfanity(profanityWords)} фингала от бабки");
        Console.WriteLine($"{ded2.Name} получил {ded2.CheckProfanity(profanityWords)} фингал от бабки");
        Console.WriteLine($"{ded3.Name} получил {ded3.CheckProfanity(profanityWords)} фингалов от бабки");
        Console.WriteLine($"{ded4.Name} получил {ded4.CheckProfanity(profanityWords)} фингала от бабки");
        Console.WriteLine($"{ded5.Name} получил {ded5.CheckProfanity(profanityWords)} фингал от бабки");
    }
}
