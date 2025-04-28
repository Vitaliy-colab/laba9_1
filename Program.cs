using System;
using laba9_1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            File file1 = new File();
            Console.WriteLine(file1.GetFileInfo());

            File file2 = new File("Документ.docx", new DateTime(2023, 5, 10), 2048);
            Console.WriteLine(file2.GetFileInfo());

            file1.AppendData(100);
            file2.AppendData(512);

            file1.Name = "Звіт.txt";
            file1.CreationDate = new DateTime(2023, 6, 15);
            Console.WriteLine("\nОновлена інформація про файл 1:");
            Console.WriteLine(file1.GetFileInfo());

            File.DisplayFileCount();
            Console.WriteLine($"Кількість файлів (через властивість): {File.FileCount}");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}