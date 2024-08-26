using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SF.HW03.Task13_6_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filePath = Path.Combine(DirectoryExtension.GetSolutionRoot(), "Text1.txt");
            var lines = Array.Empty<string>();

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
                return;
            }

            char[] delimiters = { ' ', '\r', '\n' };

            Console.WriteLine($"Количество строк: {lines.Length}");

            // Предварительно разделяем все строки на слова
            var allWords = lines.SelectMany(line => line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)).ToArray();

            MeasurePerformance("List<T>", () =>
            {
                var wordsList = new List<string>();
                foreach (var word in allWords)
                {
                    wordsList.Add(word);
                }
                return wordsList.Count;
            });

            MeasurePerformance("LinkedList<T>", () =>
            {
                var wordsLinkedList = new LinkedList<string>();
                foreach (var word in allWords)
                {
                    wordsLinkedList.AddLast(word);
                }
                return wordsLinkedList.Count;
            });
        }

        /// <summary>
        /// Измеряет производительность выполнения заданного действия и выводит результаты.
        /// </summary>
        /// <param name="collectionName">Название коллекции, для которой производится измерение.</param>
        /// <param name="action">Действие, производительность которого измеряется. Должно возвращать количество элементов.</param>
        private static void MeasurePerformance(string collectionName, Func<int> action)
        {
            var timer = Stopwatch.StartNew();
            int count = action();
            timer.Stop();

            Console.WriteLine($"{collectionName}:");
            Console.WriteLine($"  Время выполнения: {timer.ElapsedMilliseconds} мс");
            Console.WriteLine($"  Количество слов: {count}");
            Console.WriteLine();
        }
    }
}