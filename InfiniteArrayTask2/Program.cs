using System;

//Написать программу с классом. В котором будут методы для прибавления значения в массив.
//Количество добавлений значений в массив нам не известно.
//https://www.youtube.com/watch?v=6iw0gsKBP90

namespace InfiniteArrayTask2
{
    public class Program
    {
        public static void Main()
        {
            InfiniteArray.Add(5);
            InfiniteArray.Add(5);
            InfiniteArray.Add(8);
            InfiniteArray.Add(856);
            InfiniteArray.Print(); // 5 5 8 856
            Console.Write(InfiniteArray.GetCount()); // 4
            
            InfiniteArray.Clear();
            InfiniteArray.Print(); // Ничего не выводит
            var array = InfiniteArray.GetArray(); // Вернул int[0] (массив нулевой длины)
            Console.Write(InfiniteArray.GetCount()); // 0
            Console.Write(InfiniteArray.GetCapacity()); // не изменилось
        }
    }

    /// Можно и желательно при реализации данного класса использовать класс Array
    /// и его методы Array.Copy, Array.Resize
    /// Подробней тут: https://metanit.com/sharp/tutorial/20.5.php
    public static class InfiniteArray
    {
        private static int[] _arrayOfElements;  // массив только элементов
        private static int _countOfElenents;    //счетчик вводимых элементов
        static InfiniteArray()
        {
            _arrayOfElements = new int[4];
        }
        

        /// Возвращает количество элементов, которые уже были добавлены в массив.
        /// После вызова метода Clear становится 0. 
        public static int GetCount()
        {
            return _countOfElenents;
        }

        /// Это вместимость вашей буферной зоны.
        ///
        /// Возвращает количество элементов, которые потенциально могут быть добавлены 
        /// в массив без выделения памяти. После вызова метода Clear эта вместимость не должна меняться.
        ///
        /// Пояснение:
        /// Вы можете заранее создать массив, в котором будет храниться немного больше элементов, 
        /// для того чтобы при каждом добавлении элемента не создавать новый массив и не копировать 
        /// значения всех элементов. 
        ///
        /// Пример: 
        /// У вас Capacity может быть 8, но количество элементов 5.
        /// Что будет означать, что вы сможете добавить еще 3 элемента в ваш массив
        /// без дополнительных аллокаций памяти.
        ///
        /// И например когда вы будете добавлять 9-ый элемент, вы можете создать новый буфер, 
        /// который будет хранить уже 16 элементов. Т.е. Capacity будет 16, а Cout будет 9.
        public static int GetCapacity()
        {
            
            if (_countOfElenents > _arrayOfElements.Length)
            {
                return _arrayOfElements.Length * 2;
            }
            return _arrayOfElements.Length;

        }

        /// Добавляет в массив новый элемент.
        public static void Add(int element)
        {
            _countOfElenents += 1;
            Resize(GetCapacity());              // проверяем вместительность и если нужно увеличиваем буфер
            _arrayOfElements[_countOfElenents - 1] = element;       //дописываем новый элемент
        }

        /// Возвращает массив состоящий строго из значений, которые были
        /// в него добавлены (т.е. без пустых лишних элементов).
        ///
        /// Можно возвращать тут копию массива, который содержит ТОЛЬКО
        /// элементы, которые реально используются.
        public static int[] GetArray()
        {
            int[] elements = new int[_countOfElenents];
            for (var i = 0; i < _countOfElenents; i++)
            {
                elements[i] = _arrayOfElements[i];
            }

            return elements;
        }

        /// Увеличивает размер массива и копирует старые элементы в новый массив.
        private static void Resize(int newSize)
        {
            
            if (newSize > _arrayOfElements.Length)      //если элемент не помещается 
            {
                int[] tempArray = new int[newSize];     //увеличиваем временный массив

                for (var i = 0; i < _arrayOfElements.Length; i++) //переносим старые элементы из оригинального массива
                {
                    tempArray[i] = _arrayOfElements[i];
                }

                _arrayOfElements = tempArray;           // новый расширенный массив с старыми элементами
            }
        }
        
        /// Удаляет все элементы массива.
        /// Если после этого вызвать Print ничего не будет распечатано.
        public static void Clear()
        {
            _countOfElenents = 0;
        }
        
        /// Выводит на консоль все элементы массива.
        public static void Print()
        {
            for (var i = 0; i < _countOfElenents; i++)
            {
                Console.Write(_arrayOfElements[i] + " ");
            }
        }
    }
}