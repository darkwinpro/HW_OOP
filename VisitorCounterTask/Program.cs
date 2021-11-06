using System;
//Напишите программу для датчика, который стоит на входе магазина.
//    Программа должна работать так. 
//    После каждого прохода человека счетчик увеличивается на 1 в конце дня счетчик сбрасывается до 0.
namespace VisitorCounterTask
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                VisitorCounter.Increase();
            }
            VisitorCounter.Print(); //Количество посетителей: 50
            VisitorCounter.NextDay();
            for (int i = 0; i < 562; i++)
            {
                VisitorCounter.Increase();
            }
            VisitorCounter.Print(); //Количество посетителей: 562
        }
    }

    public class VisitorCounter
    {
        public static int _visitors;
        
        /// Увеличивает количество посетителей на 1
        public static void Increase()
        {
            _visitors++;
        }
        
        /// Возвращает количество посетителей
        public static int GetCounter()
        {
            return _visitors;
        }
        
        /// Сбрасывает количество посетителей до 0
        public static void NextDay()
        {
            _visitors = 0;
        }
        
        /// Выводит количество посетителей
        public static void Print()
        {
            Console.WriteLine(_visitors);
        }
    }
}