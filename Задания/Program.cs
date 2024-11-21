using System;

class Programm
{
    static void ShowArray(string name, params int[] array)
    {
        Console.Write(name);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
    }
    static void Main(string[] args)
    {
        int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        ShowArray("Numbers: ", arr);
        Console.WriteLine();
        ShowArray("Numbers: ", 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
    }

}
