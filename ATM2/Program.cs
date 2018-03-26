using System;
using System.Collections.Generic;

namespace ATM2
{
    class Program
    {
        static bool C;
        static List<int> NominalValues = new List<int>();
        static void Main(string[] args)
        {
            int n;
            int Note;
            for (;;)
            {
                try
                {
                    Console.WriteLine("Количество номиналов в банкомате: ");
                    n = int.Parse(Console.ReadLine());
                    if (n < 1)
                    {
                        Console.WriteLine("Некорректные входные данные - ");
                        Console.WriteLine("Пожалуйста, попробуйте еще раз!");
                        continue;
                    }
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректные входные данные - ");
                    Console.WriteLine("Пожалуйста, попробуйте еще раз!");
                }
            }
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Купюра: ");
                    Note = int.Parse(Console.ReadLine());
                    if (Note < 1)
                    {
                        Console.WriteLine("Фальшивая купюра!!!");
                        continue;
                    }
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректные входные данные - ");
                    Console.WriteLine("Пожалуйста, попробуйте еще раз!");
                }
            }
            NominalValues = new List<int>(n);
            int k = 0;
            Console.WriteLine("Номиналы в банкомате: ");
            while (k < n)
            {
                try
                {
                    int v = int.Parse(Console.ReadLine());
                    if (v < 1)
                    {
                        continue;
                    }
                    NominalValues.Add(v);
                    k++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректныее входные данные - ");
                    Console.WriteLine("Пожалуйста, попробуйтей еще раз!");
                }
            }
            string Result = "";
            C = false;
            int pos = 0;
            exchange(Note, pos, Result);
            if (!C)
            {
                Console.WriteLine("Размен невозможен!");
            }
            Console.ReadLine();
        }

        public static void exchange(int Note, int pos, string Result)
        {
            if (Note == 0)
            {
                Console.WriteLine(Result);
                C = true;
            }
            else
            {
                if (pos < NominalValues.Count)
                {
                    for (int i = Note / NominalValues[pos]; i > 0; i--)
                    {
                        string Temp = Result;
                        for (int k = 0; k < i; k++)
                        {
                            Temp += NominalValues[pos].ToString();
                        }
                        exchange(Note - i * NominalValues[pos], pos + 1, Temp);
                    }
                    exchange(Note, pos + 1, Result + "");
                }
            }
        }

    }
}
