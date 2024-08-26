namespace SF.HW03.Task13_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            var filePath = Path.Combine(DirectoryExtension.GetSolutionRoot(), "Text12.txt");
            var text = string.Empty;
            try
            {
                text = File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine(words.Length);
        }
    }
}