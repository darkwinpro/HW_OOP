using System;
//Описать класс, элементами которого являются статические методы для работы с двумерными массивами:
//Создания массива М х N;
//Добавить значение в массив. На вход даются, координаты m,n и число, которое хотим записать.
//    Метод, который умножает все элементы массива на любое целое число.
//    Метод, который выводит все элементы массива в консоль.
namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Matrix.Create(5, 5); // создали массив
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Matrix.AddValue(i, j, random.Next(-10, 10)); // заполнили массив
                }
            }
 
            var matrix = Matrix.GetMatrix();
            Matrix.Multiply(2); // увеличить все значения в 2 раза
            Matrix.Print(); // вывести массив в консоль
        }
    }
 
    public class Matrix
    {
        private static int[,] _array;
        

        /// Создает новый двумерный массив
        public static void Create(int x, int y)
        {
            int[,] matrix = new int[x,y];
            _array = matrix;
        }
         
        /// Возвращает созданный двумерный массив
        public static int[,] GetMatrix()
        {
            return _array;
        }
 
        /// Добавляет значение в указанный элемент матрицы
        public static void AddValue(int x, int y, int value)
        {
            _array[x, y] = value;
        }
         
        /// Умножает все значения на число которое принимает этот метод
        public static void Multiply(int mul)
        {
            for (var i = 0; i < _array.GetLength(0); i++)
            {
                for (var j = 0; j < _array.GetLength(1); j++)
                {
                    _array[i, j] *= mul;
                }
            }
        }
         
        /// Метод который выводит массив на экран
        public static void Print()
        {
            for (var i = 0; i < _array.GetLength(0); i++)
            {
                for (var j = 0; j < _array.GetLength(1); j++)
                {
                    Console.Write(_array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}