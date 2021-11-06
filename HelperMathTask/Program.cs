using System;
//Напишите программу с классом (HelperMath). В котором будет содержаться статические методы:
//1. Считает длину окружности.
//2. Переводит градусы в Кельвинах в Цельсии и наоборот.
//3. Переводит Кг в граммы и наоборот.
//
//    Постоянные величины должны использоваться как константы!
//    Помните, что когда присваиваете значение константам разрешнается использовать вычисляемые выражения:
//    public const int SecondsInMinute = 60 * 60;
namespace HelperMathTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(HelperMath.GetCircumference(35)); //219.9
            Console.WriteLine(HelperMath.GetCircumference(5)); //31.42

            Console.WriteLine(HelperMath.ConvertCelsiusToKelvin(15)); //288.15
            Console.WriteLine(HelperMath.ConvertCelsiusToKelvin(-9)); //264.15
            Console.WriteLine(HelperMath.ConvertKelvinToCelsius(285)); //11.85
            Console.WriteLine(HelperMath.ConvertKelvinToCelsius(270)); //-3.15

            Console.WriteLine(HelperMath.ConvertGramToKilogram(1000)); //1
            Console.WriteLine(HelperMath.ConvertGramToKilogram(9000)); //9
            Console.WriteLine(HelperMath.ConvertKilogramToGram(12)); //12000
            Console.WriteLine(HelperMath.ConvertKilogramToGram(7)); //7000
        }
    }

    public static class HelperMath
    {
        /// Константа при сложении температуры в Цельсиях и в сумме
        /// получаются температура в Кельвинах
        ///
        /// Пример:
        /// Температура в цельсиях = 100
        /// Как перевести ее в кельвины = 100 + ZeroCelsiumKelvins
        ///
        /// И в тоже время
        /// Константа при вычитании температуры в Кельвинах 
        /// получаются температура Цельсии
        ///
        /// Пример:
        /// Температура в Кельвинах = 100
        /// Как перевести ее в цельсиях = 100 - ZeroCelsiumKelvins
        
        private const double ZeroCelsiumKelvins = 273.15;
        
        /// Считает длинну окружности
        public static double GetCircumference(int radius)
        {
            var perimetr = Math.Round(2 * Math.PI * radius, 2);
            return perimetr;
        }
        
        /// Переводит температуру в Кельвинах в Цельсии
        public static double ConvertKelvinToCelsius(int tempK)
        {
            return Math.Round(tempK - ZeroCelsiumKelvins, 2);
        }
        /// Переводит температуру в Цельсиях в Кельвины
        public static double ConvertCelsiusToKelvin(int tempC)
        {
            return tempC + ZeroCelsiumKelvins;
        }

        /// Переводит килограммы в граммы
        public static double ConvertKilogramToGram(int mass)
        {
            return mass * 1000;
            
        }

        /// Переводит граммы в килограммы
        public static double ConvertGramToKilogram(int mass)
        {
            return Math.Round(mass / 1000f, 2);
        }
    }
}