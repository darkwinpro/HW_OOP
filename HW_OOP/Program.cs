using System;
//В статическом классе должен быть описан статический метод (GetNumber) при вызове,
//которого отображается текущее значение статического поля.
//И второй статический метод (SetNumber). Который устанавливает значение.

namespace GetSetTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Point.SetNumber(5);
            Console.WriteLine(Point.GetNumber()); //5
            Point.SetNumber(8);
            Console.WriteLine(Point.GetNumber()); //8
            Point.SetNumber(15);
            Console.WriteLine(Point.GetNumber()); //15
            Point.SetNumber(1);
            Console.WriteLine(Point.GetNumber()); //1
        }
    }

    public static class Point
    {
        private static int _number;
        /// Устанавливает целое число
        public static void SetNumber(int number)
        {
            _number = number;
        }
        /// Возвращает установленное целое число
        public static int GetNumber()
        {
            return _number;
        }
    }
}