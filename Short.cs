using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            double value = 2134534522; // Значение, необходимое вывести
            string[] massiveRaz = { " тыс", " млн", " млрд", " трлн", " квадрлн" };
            int afterComma = 1; // Парамент определяющий кол-во знаков после запятой
            Console.WriteLine(value.Shortening(massiveRaz, afterComma)); // Вывод с указанием языка массива данных
            Console.ReadLine();
        }
    }
    static class Razryad
    { 

        public static string Shortening(this double value, string[] massiveRaz, int afterComma) // Метод, сокращающий запись числа и определяющий его разряд в диапазоне от до 10^3 до 10^17
        {
            int Razmer = massiveRaz.Length;
            if (Razmer < 5)
            {
                Console.WriteLine("Ошибка вывода, элементов массива меньше 5!!!");
            }
            int rank = (int)Math.Log10(value); // Разряд этого значения
            string output = "?";               // Строка, которая впоследствии вернет запись числа         
            if (rank >= 3 & rank < 6) // Начало многоступенчатого условия, которое по разряду определяет как его записать 
            {
                value = value / 1000;
                output = Math.Round(value, afterComma) + massiveRaz[0];
            }
            else if (rank >= 6 & rank < 9)
            {
                value = value / 1000000;
                output = Math.Round(value, afterComma) + massiveRaz[1];
            }
            else if (rank >= 9 & rank < 12)
            {
                value = value / 1000000000;
                output = Math.Round(value, afterComma) + massiveRaz[2];
            }
            else if (rank >= 12 & rank < 15)
            {
                value = value / 1000000000000;
                output = Math.Round(value, afterComma) + massiveRaz[3];
            }
            else if (rank >= 15 & rank < 18)
            {
                value = value / 1000000000000000;
                output = Math.Round(value, afterComma) + massiveRaz[4];
            }
            return output;

        }
        public static string Shortening( this double value, int afterComma)
        {
            string[] massRaz = new string[5];
            string vyvod = Shortening(value, massRaz, afterComma);
            return vyvod;
        }
        public static string Shortening(this double value, string[] massiveRaz)
        {
            int afterComma = 2;
            string vyvod = Shortening(value, massiveRaz, afterComma);
            return vyvod;
        }
    }
}
