using System;

//Написать программу с классом. В котором будут методы для прибавления значения в массив.
//Количество добавлений значений в массив нам не известно.
//https://www.youtube.com/watch?v=6iw0gsKBP90

namespace InfiniteArrayTask
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
        private static int[] _arrayBuffer;      //расширенный массив
        private static int _countOfElenents;    //счетчик вводимых элементов
        private static int _capacity = 1;       //вместительность расширенного массива

        /// Возвращает количество элементов, которые уже были добавлены в массив.
        /// После вызова метода Clear становится 0. 
        public static int GetCount()
        {
            if (_countOfElenents == 1)
            {
                return 1;
            }
            return _arrayOfElements.Length;
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
            if (_countOfElenents > _capacity)
            {
                _capacity *= 2;
            }
            
            return _capacity;
        }

        /// Добавляет в массив новый элемент.
        public static void Add(int element)
        {
            _countOfElenents += 1;
            
            if (_countOfElenents == 1)  //создаем начальные массивы при первом добавлении элемента
            {
                _arrayBuffer = new int[1];
                _arrayOfElements = new int[1];
            }
            
            Resize(GetCapacity());      // проверяем вместительность и если нужно увеличиваем буфер
            _arrayBuffer[_countOfElenents - 1] = element;   //размещаем новый элемент в буфере
            Resize(GetCapacity());      //копируем все элементы из буфера в результативный массив
            

        }
        
        /// Возвращает массив состоящий строго из значений, которые были
        /// в него добавлены (т.е. без пустых лишних элементов).
        ///
        /// Можно возвращать тут копию массива, который содержит ТОЛЬКО
        /// элементы, которые реально используются.
        public static int[] GetArray()
        {

            return _arrayOfElements;
        }

        /// Увеличивает размер массива и копирует старые элементы в новый массив.
        private static void Resize(int newSize)
        {
            
            if (newSize > _arrayBuffer.Length)      //если элемент не помещается в буфер
            {
                int[] tempArray = new int[newSize];     //увеличиваем буфер 
                _arrayBuffer = tempArray;

                for (var i = 0; i < _arrayOfElements.Length; i++) //переносим старые элементы из оригинального массива
                {
                    _arrayBuffer[i] = _arrayOfElements[i];
                }
                return;     //выходим, чтобы записать новый элемент в буфер
            }
            
            _arrayOfElements = new int[_countOfElenents];
            for (var i = 0; i < _arrayOfElements.Length; i++)   //копируем ВСЕ элементы из буфера в результатиный массив
            {
                _arrayOfElements[i] = _arrayBuffer[i];
            }
        }
        
        /// Удаляет все элементы массива.
        /// Если после этого вызвать Print ничего не будет распечатано.
        public static void Clear()
        {
            int[] tempArray = new int[0];
            _arrayOfElements = tempArray;
            _countOfElenents = 0;
        }
        
        /// Выводит на консоль все элементы массива.
        public static void Print()
        {
            for (var i = 0; i < _arrayOfElements.Length; i++)
            {
                Console.Write(_arrayOfElements[i] + " ");
            }
        }
    }
}