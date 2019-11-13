gitusing System;
public class Program
{
    public static void Main() 
    {
        double Chislo = 99909.999; // Значение, необходимое вывести
        int Razryad = (int)Math.Log10(Chislo);                      // Разряд этого значения
        Shortening(Chislo, Razryad); // Вызов метода
        Console.ReadLine();
    }
    public static string Shortening(double value, int rank) // Метод сокращающий запись числа и определяющий его разряд в диапазоне от до 10^3 до 10^17
    {
        string output="?";               // Строка, которая впоследствии вернет запись числа
        int afterComma = 1;              // Парамент определяющий кол-во знаков после запятой
        if (rank >= 3 & rank < 6) // Начало многоступенчатого условия, которое по разряду определяет как его записать 
        {
            value = value / 1000; 
            output = Math.Round(value, afterComma) + " тыс";
        }
        else if (rank >= 6 & rank < 9)
        {
            value = value / 1000000;
            output = Math.Round(value, afterComma) + " млн";
        }
        else if (rank >= 9 & rank < 12)
        {
            value = value / 1000000000;
            output = Math.Round(value, afterComma) + " млрд";
        }
        else if (rank >= 12 & rank < 15)
        {
            value = value / 1000000000000;
            output = Math.Round(value, afterComma) + " трлн";
        }
        else if (rank >= 15 & rank < 18)
        {
            value = value / 1000000000000000;
            output = Math.Round(value, afterComma) + " квадрлн";
        }
        Console.WriteLine(output);
        return output;
    }
}


