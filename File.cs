using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9_1
{
    public class File
    {
        private static int fileCount = 0;

        private string name;
        private DateTime creationDate;
        private long length;

        public static int FileCount => fileCount;
        public int power=0;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ім'я файлу не може бути порожнім");
                name = value;
            }
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата створення не може бути у майбутньому");
                creationDate = value;
            }
        }

        public string PowerPog()
        {
            string bayt = "";
            if (power == 0) bayt = $"{Length} байт";
            else if (power == 1) bayt = $"{Length} кілобайт";
            return bayt;
        }

        public long Length
        {
            get
            {
                if(length>1024 && power==0)
                {
                    length /= 1024;
                    power++;
                }
                return length;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Довжина файлу не може бути від'ємною");
                length = value;
            }
        }

        public File()
        {
            Name = "Новий файл.txt";
            CreationDate = DateTime.Now;
            Length = 0;
            fileCount++;
        }

        public File(string name, DateTime creationDate, long length)
        {
            Name = name;
            CreationDate = creationDate;
            Length = length;
            fileCount++;
        }

        public string GetFileInfo()
        {
            return $"Ім'я: {Name}, Дата створення: {CreationDate}, Розмір: "+PowerPog();
        }

        public void AppendData(long additionalLength)
        {
            if (additionalLength < 0)
                throw new ArgumentException("Додаткова довжина не може бути від'ємною");
            Length += additionalLength;


            Console.WriteLine($"До файлу {Name} додано {additionalLength} байт. Новий розмір: " + PowerPog());
        }

        public static void DisplayFileCount()
        {
            Console.WriteLine($"Всього створено файлів: {fileCount}");
        }
    }
}
