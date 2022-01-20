using LR_4;
using System;

namespace CSharp_Shell
{

    public class Program
    {
        public static string a;
        public static string b;
        public static bool end;

        public static void Main()
        {
            Enter();
            SwitchCase_1();

            Console.ReadKey();
        }

        //Enter a и b
        public static void Enter()
        {
            Console.Clear();
            Console.WriteLine("Введите два числа a и b для проведения операций над ними\n\nВведите a:");
            a = Console.ReadLine();
            Console.WriteLine("Введите b:");
            b = Console.ReadLine();
        }

        //Switch Case 1 класс Myint
        public static void SwitchCase_1()
        {
            Console.Clear();
            Myint myint = new Myint();

            //Menu1
            Console.WriteLine("Часть 1:\n\n0. Ввести числа a и b.\n1. Сложение (a + b).\n2. Вычитание (a - b).\n3. Умножение (a * b).\n4. Деление нацело\n5. Максимум (a, b).\n6. Минимум (a, b).\n7. Абсолютное значение.\n8. Сравнение (a, b).\n9. Наибольший общий делитель (a, b).\n10. Преобразовать в строку.\n11. Преобразование в число типа long.\n12. ЧАСТЬ 2.");

            int s = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            switch (s)
            {
                case 0: //Enter a и b
                    {
                        Enter();
                        break;
                    }
                case 1: //Add a + b
                    {
                        string result = myint.Add(a, b, false);
                        Console.Write($"{a} + {b} = {result}");
                        break;
                    }
                case 2: //Subtract
                    {
                        string result = myint.Subtract(a, b, false);
                        Console.Write($"{a} - {b} = {result}");
                        break;
                    }
                case 3: //Multiply a * b
                    {
                        string result = myint.Multiply(a, b, false);
                        Console.Write($"{a} * {b} = {result}");
                        break;
                    }
                case 4: //Divide a * b
                    {
                        string result = myint.Divide(a, b, false);
                        Console.Write($"{a} / {b} = {result}");
                        break;
                    }
                case 5: //Max a и b
                    {
                        string result = myint.Max(a, b);
                        Console.Write($"Максимум между {a} и {b} = {result}");
                        break;
                    }
                case 6: //Min a и b
                    {
                        string result = myint.Min(a, b);
                        Console.Write($"Минимум между {a} и {b} = {result}");
                        break;
                    }
                case 7: //Abs
                    {
                        string result;
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            result = myint.Abs(a);
                            Console.Write($"Абсолютное значение {a} = {result}");
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            result = myint.Abs(b);
                            Console.Write($"Абсолютное значение {b} = {result}");
                        }
                        break;
                    }
                case 8: //CompareTo a и b
                    {
                        char result = myint.CompareTo(a, b)[0];
                        Console.Write($"{a} {result} {b}");
                        break;
                    }
                case 9: //Gcd a и b Наибольший общий делитель
                    {
                        string result = myint.Gcd(a, b);
                        Console.Write($"Наибольший общий делитель {a} и {b} = {result}");
                        break;
                    }
                case 10: //ToString
                    {
                        Console.WriteLine("Введите количество элементов массива:");
                        int n = Convert.ToInt32(Console.ReadLine());
                        char[] arrayToStr = new char[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{i + 1} элемент массива:");
                            arrayToStr[i] = Convert.ToChar(Console.ReadLine());
                        }
                        Console.Clear();
                        string arrayFromStr = myint.ToString(arrayToStr);
                        Console.WriteLine($"Новая строка, полученная из массива = {arrayFromStr}");
                        break;
                    }
                case 11: //LongValue
                    {
                        long result;
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            result = myint.LongValue(a);
                            Console.Clear();
                            Console.Write($"{a} -> {result}");
                        }
                        if (c == "2")
                        {
                            result = myint.LongValue(b);
                            Console.Clear();
                            Console.Write($"{b} -> {result}");
                        }
                        break;
                    }
                case 12: //Часть 2
                    {
                        SwitchCase_2();
                        break;
                    }
                default:
                    {
                        end = true;
                        break;
                    }
            }
            Console.ReadKey();
            if (!end)
                SwitchCase_1();
        }

        //Switch Case 2 Класс DEQueue
        public static void SwitchCase_2()
        {
            Console.Clear();
            DEQueue dEQueue = new DEQueue();

            //Menu2
            Console.WriteLine("Часть 2:\n\n1. Добавление элемента в конец.\n2. Добавление элемента в начало.\n3. Извлечение элемента с конца\n4. Извлечение элемента из начала\n5. Просмотр последнего элемента\n6. Просмотр первого элемента\n7. Количество элементов\n8. Очистка очереди (удаление всех элементов)\n9. Преобразование в массив\n10. ЧАСТЬ 1.");
            int s = Convert.ToInt16(Console.ReadLine());
            switch (s)
            {
                case 1: //PushBack Добавление элемента в конец
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            a = dEQueue.PushBack(a);
                            Console.Write($"a = {a}");
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            b = dEQueue.PushBack(b);
                            Console.Write($"b = {b}");
                        }
                        break;
                    }
                case 2: //PushFront Добавление элемента в начало
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            a = dEQueue.PushFront(a);
                            Console.Write($"a = {a}");
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            b = dEQueue.PushFront(b);
                            Console.Write($"b = {b}");
                        }
                        break;
                    }
                case 3: //PopBack Извлечение элемента с конца
                    {
                        char el_str;
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            el_str = dEQueue.PopBack(a);
                            Console.Write(el_str);
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            el_str = dEQueue.PopBack(b);
                            Console.Write(el_str);
                        }
                        break;
                    }
                case 4: //PopFront Извлечение элемента из начала
                    {
                        char el_str;
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            el_str = dEQueue.PopFront(a);
                            Console.Write(el_str);
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            el_str = dEQueue.PopFront(b);
                            Console.Write(el_str);
                        }
                        break;
                    }
                case 5: //Back Просмотр перового элемента
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Back(a));
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Back(b));
                        }
                        break;
                    }
                case 6: //Front Просмотр последнего элемента
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Front(a));
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Front(b));
                        }
                        break;
                    }
                case 7: //Size Количество элементов
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Size(a));
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            Console.Write(dEQueue.Size(b));
                        }
                        break;
                    }
                case 8: //Clear Очистка очереди (удаление всех элементов)
                    {
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                        {
                            Console.Clear();
                            a = "";
                            Console.Write("Очистка a.");
                        }
                        if (c == "2")
                        {
                            Console.Clear();
                            b = "";
                            Console.Write("Очистка b.");
                        }
                        break;
                    }
                case 9: //ToArray Преобразование в массив
                    {
                        char[] array;
                        Console.WriteLine($"Над каким числом произвести операцию?\n1. a\n2. b");
                        string c = Console.ReadLine();
                        if (c == "1")
                            array = dEQueue.ToArray(a);
                        else if (c == "2")
                            array = dEQueue.ToArray(b);
                        else
                        {
                            array = new char[0];
                            break;
                        }

                        Console.Clear();
                        Console.Write("Массив, полученный из строки = ");
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.Write(array[i] + " ");
                        }
                        break;
                    }
                case 10: //Часть 1
                    {
                        SwitchCase_1();
                        break;
                    }
                default:
                    {
                        end = true;
                        break;
                    }
            }
            Console.ReadKey();
            if (!end)
                SwitchCase_2();
        }
    }
}