using System;
using System.Collections.Generic;
using System.Linq;

namespace LR_4
{
    public class Myint
    {
        //1.1 Сложение
        public string Add(string first, string second, bool mines)
        {
            bool rem = false;
            int act = 0;
            string result = "";

            char[] compareTo = CompareTo(first, second);
            if (compareTo[1] == '3')
            {
                mines = true;
                first = first.Remove(0, 1);
                second = second.Remove(0, 1);
            }
            else if (compareTo[1] == '2')
            {
                second = second.Remove(0, 1);
                if (CompareTo(first, second)[0] == '<')
                    return Subtract(second, first, true);
                else
                    return Subtract(first, second, false);
            }
            else if (compareTo[1] == '1')
            {
                first = first.Remove(0, 1);
                if (CompareTo(first, second)[0] == '>')
                    return Subtract(first, second, true);
                else
                    return Subtract(second, first, false);
            }
            if (first.Length < second.Length)
            {
                string firstTrade = first;
                first = second;
                second = firstTrade;
            }

            first = new string(first.ToCharArray().Reverse().ToArray());
            second = new string(second.ToCharArray().Reverse().ToArray());
            int k = first.Length;
            int j = second.Length;

            for (int i = 0; i < k; i++)
            {
                if (i < j)
                    act += Convert.ToInt16(Convert.ToString(first[i])) + Convert.ToInt16(Convert.ToString(second[i]));
                else act += Convert.ToInt16(Convert.ToString(first[i]));
                if (rem)
                {
                    act++;
                    rem = false;
                }
                if (act > 9)
                {
                    act = act - 10;
                    rem = true;
                }
                result += act;
                act = 0;
                if (rem)
                {
                    act++;
                    rem = false;
                }
            }
            if (act != 0)
                result += 1;
            if (mines)
                result += "-";
            result = new string(result.ToCharArray().Reverse().ToArray());
            if (result[0] == '0')
                result = result.Remove(0, 1);
            return result;
        }

        //1.2 Вычитание
        public string Subtract(string first, string second, bool mines)
        {
            bool rem = false;
            int act = 0;
            string result = "";

            char[] compareTo = CompareTo(first, second);
            if (compareTo[1] == '0' && compareTo[0] == '<') // Все числа положительные
            {
                string firstTrade = first;
                first = second;
                second = firstTrade;
                mines = true;
            }
            else if (compareTo[1] == '2') // second отрицательное
            {
                second = second.Remove(0, 1);
                return Add(first, second, false);
            }
            else if (compareTo[1] == '1')
            {
                first = first.Remove(0, 1);
                return Add(first, second, true);
            }
            else if (compareTo[1] == '3')
            {
                first = first.Remove(0, 1);
                second = second.Remove(0, 1);
                if (CompareTo(first, second)[0] == '<')
                {
                    string firstTrade = first;
                    first = second;
                    second = firstTrade;
                }
                else
                    mines = true;
            }

            first = new string(first.ToCharArray().Reverse().ToArray());
            second = new string(second.ToCharArray().Reverse().ToArray());
            int k = first.Length;
            int j = second.Length;

            for (int i = 0; i < k; i++)
            {
                if (i < j)
                    act += Convert.ToInt16(Convert.ToString(first[i])) - Convert.ToInt16(Convert.ToString(second[i]));
                else act += Convert.ToInt16(Convert.ToString(first[i]));
                if (rem)
                {
                    act--;
                    rem = false;
                }
                if (act < 0)
                {
                    act = act + 10;
                    rem = true;
                }
                result += act;
                act = 0;
                if (rem)
                {
                    act--;
                    rem = false;
                }
            }

            if (result == "")
                return "0";
            if (new string(result.ToCharArray().Reverse().ToArray())[0] == '0')
                result = result.Remove(result.Length - 1);
            if (mines && result != "0")
                result += "-";
            result = new string(result.ToCharArray().Reverse().ToArray());
            if (result == "")
                result = "0";
            return result;
        }

        //1.3 Умножение
        public string Multiply(string first, string second, bool mines)
        {
            if (first[0] == '-' && second[0] == '-')
            {
                first = first.Remove(0, 1);
                second = second.Remove(0, 1);
            }
            else if (first[0] == '-')
            {
                first = first.Remove(0, 1);
                mines = true;
            }
            else if (second[0] == '-')
            {
                second = second.Remove(0, 1);
                mines = true;
            }

            mines = false;
            int rem = 0;
            int act;
            string res_act = "";
            string result = "";

            char[] compareTo = CompareTo(first, second);
            if (compareTo[1] == '3')
            {
                first = first.Remove(0, 1);
                second = second.Remove(0, 1);
            }
            else if (compareTo[1] == '2')
            {
                mines = true;
                second = second.Remove(0, 1);
            }
            else if (compareTo[1] == '1')
            {
                mines = true;
                first = first.Remove(0, 1);
            }
            if (first.Length < second.Length)
            {
                string first_second = first;
                first = second;
                second = first_second;
            }

            first = new string(first.ToCharArray().Reverse().ToArray());
            second = new string(second.ToCharArray().Reverse().ToArray());
            int k = first.Length;
            int m = second.Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    act = Convert.ToInt16(Convert.ToString(first[j])) * Convert.ToInt16(Convert.ToString(second[i])) + rem;
                    rem = act / 10;
                    act %= 10;
                    res_act += act;
                }
                if (rem != 0)
                {
                    res_act += rem;
                    rem = 0;
                }
                res_act = new string(res_act.ToCharArray().Reverse().ToArray());
                for (int j = 0; j < i; j++)
                {
                    res_act += 0;
                }
                if (result != "")
                    result = Add(res_act, result, false);
                else
                    result = res_act;
                res_act = "";
            }
            if (mines)
                result = "-" + result;
            return result;
        }

        //1.4 Деление нацело
        public string Divide(string divMain, string divSec, bool mines)
        {
            if (divMain[0] == '-' && divSec[0] == '-')
            {
                divMain = divMain.Remove(0, 1);
                divSec = divSec.Remove(0, 1);
            }
            else if (divMain[0] == '-')
            {
                divMain = divMain.Remove(0, 1);
                mines = true;
            }
            else if (divSec[0] == '-')
            {
                divSec = divSec.Remove(0, 1);
                mines = true;
            }

            if (CompareTo(divMain, divSec)[0] == '<')
                return "0";
            if (divSec == "0")
                return "На ноль делить нельзя";
            if (divSec == "1")
                return divMain;
            int el = 0;
            int el_i = 1;
            int n = divSec.Length;
            string result = "";
            string num1 = divMain.Substring(0, n);
            string num2 = divMain.Remove(0, n);
            string _num2;

            do
            {
                if (CompareTo(num1, divSec)[0] != '<')
                {
                    do //Вычетание (num1 - divSec)
                    {
                        el++;
                        num1 = Subtract(num1, divSec, false);
                    }
                    while (CompareTo(num1, divSec)[0] != '<');
                    if (num2 != "")
                    {
                        if (num1 == "0" && num2.Substring(0, 1) == "0")
                        {
                            do
                            {
                                el_i++;
                                num2 = num2.Remove(0, 1);
                                if (num2 != "")
                                {
                                    _num2 = num2.Substring(0, 1);
                                }
                                else
                                    _num2 = "";
                            }
                            while (_num2 == "0");
                            if (num2 != "" && CompareTo(num2, divSec)[0] != '<')
                                el_i--;
                        }
                        else
                        {
                            num1 = Add(num1 + 0, num2.Substring(0, 1), false);
                            num2 = num2.Remove(0, 1);
                            if (CompareTo(num1, divSec)[0] == '<' && num2 == "")
                                el_i++;
                        }
                    }
                }
                else
                {
                    num1 += num2.Substring(0, 1);
                    num2 = num2.Remove(0, 1);
                }
                for (int i = el_i; i > 0; i--)
                {
                    result += el;
                    el = 0;
                }
                el_i = 1;
                if (result == "0")
                    result = "";
                if (num1.Length > 1)
                    if (num1[0] == '0')
                        num1 = num1.Remove(0, 1);
            }
            while (CompareTo(num1, divSec)[0] != '<' || num2 != "");
            if (num1 != "0")
            {
                result += ",";
            }
            if (mines)
                result = "-" + result;
            return result;
        }

        //1.5 Максимум
        public string Max(string first, string second)
        {
            if (CompareTo(first, second)[0] != '<')
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        //1.6 Минимум
        public string Min(string first, string second)
        {
            if (CompareTo(first, second)[0] != '>')
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        //1.7 Абсолютное значение (модуль)
        public string Abs(string str)
        {

            if (str[0] == '-')
                str = str.Remove(0, 1);
            return str;
        }

        //1.8 Сравнение
        public char[] CompareTo(string first, string second)
        {
            char[] result = new char[2]; //result[0] - знак равенства, result[1] - один из 4х выриантов (0 - все числа положительные, 1 - числ a отрицательное, 2 - числ b отрицательное, 3 - оба числа отрицательные)
            result[1] = '0';
            if (first == "")
                first = "0";
            if (second == "")
                second = "0";
            if (first[0] == '-' && second[0] != '-')
            {
                result[0] = '<';
                result[1] = '1';
                return result;
            }
            else if (first[0] != '-' && second[0] == '-')
            {
                result[0] = '>';
                result[1] = '2';
                return result;
            }
            else if (first[0] == '-' && second[0] == '-')
            {
                result[1] = '3';
                string fir_sec = first;
                first = second;
                second = fir_sec;
                first = first.Remove(0, 1);
                second = second.Remove(0, 1);
            }
            if (first.Length > second.Length)
            {
                result[0] = '>';
                return result;
            }
            else if (first.Length < second.Length)
            {
                result[0] = '<';
                return result;
            }

            int fir;
            int sec;
            for (int i = 0; i < first.Length; i++)
            {
                fir = Convert.ToInt16(Convert.ToString(first[i]));
                sec = Convert.ToInt16(Convert.ToString(second[i]));
                if (fir > sec)
                {
                    result[0] = '>';
                    return result;
                }
                if (fir < sec)
                {
                    result[0] = '<';
                    return result;
                }
            }
            result[0] = '=';
            return result;
        }

        //1.9 Наибольший общий делитель
        public string Gcd(string first, string second)
        {
            string result = "1";
            string buf;
            string str;
            List<string> firstList = new List<string>();
            List<string> secondList = new List<string>();

            if (first[0] == '-')
                first = first.Remove(0, 1);
            if (second[0] == '-')
                second = second.Remove(0, 1);
            str = first;
            for (string s = "2"; str != "1"; s = Add(s, "1", false))
            {
                buf = Divide(str, s, false);
                if (buf[buf.Length - 1] != ',')
                {
                    firstList.Add(s);
                    str = buf;
                    s = "1";
                }
            }
            str = second;
            for (string s = "2"; str != "1"; s = Add(s, "1", false))
            {
                buf = Divide(str, s, false);
                if (buf[buf.Length - 1] != ',')
                {
                    secondList.Add(s);
                    str = buf;
                    s = "1";
                }
            }
            for (int i = 0; i < firstList.Count; i++)
            {
                for (int j = 0; j < secondList.Count; j++)
                {
                    if (i < firstList.Count)
                        if (firstList[i] == secondList[j])
                        {
                            result = Multiply(result, firstList[i], false);
                            firstList[i] = "1";
                            secondList[j] = "1";
                        }
                }
            }

            return result;
        }

        //1.10 ToString
        public string ToString(char[] str)
        {
            string result = new string(str);
            return result;
        }

        //1.11 ToLong
        public long LongValue(string str)
        {
            long result = 0;

            while (result == 0)
            {
                try
                {
                    result = Convert.ToInt64(str);
                }
                catch (Exception)
                {
                    str = str.Remove(str.Length - 1);
                }
            }
            return result;
        }
    }
}
