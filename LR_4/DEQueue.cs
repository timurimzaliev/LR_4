using System;

namespace LR_4
{
    public class DEQueue
    {
        //2.1 Добавление элемента в конец
        public string PushBack(string str)
        {
            char s = Convert.ToChar(Console.ReadLine());
            str += s;
            return str;
        }

        //2.2 Добавление элемента в начало
        public string PushFront(string str)
        {
            char s = Convert.ToChar(Console.ReadLine());
            str = s + str;
            return str;
        }

        //2.3 Извлечение элемента с конца
        public char PopBack(string str)
        {
            return str[str.Length - 1];
        }

        //2.4 Извлечение элемента из начала
        public char PopFront(string str)
        {
            return str[0];
        }

        //2.5 Просмотр последнего элемента
        public char Back(string str)
        {
            return str[str.Length - 1];
        }

        //2.6 Просмотр первого элемента
        public char Front(string str)
        {
            return str[0];
        }

        //2.7 Количество элементов
        public int Size(string str)
        {
            return str.Length;
        }

        //2.9 Преобразование в массив
        public char[] ToArray(string str)
        {
            return str.ToCharArray();
        }
    }
}
