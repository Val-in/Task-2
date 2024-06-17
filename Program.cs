using System;
using System.Collections.Specialized;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @"D:\Desktop\TestFolder";
            try
            {
                if (Directory.Exists(dir))
                {
                    long size = CheckSize(dir);
                    Console.WriteLine($"Folder {dir} exists, size: {size} bites");
                }
                else
                {
                    Console.WriteLine($"Folder TestFolder not found");
                }
            }
            catch (Exception ex)
            { Console.WriteLine($"Error: {ex.Message}"); }
            
        }
        public static long CheckSize(string dir)
        {
            long size = 0;
            try
            {
                // Получить все файлы в папке и суммировать их размеры
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    Console.WriteLine($"{file}");
                    try
                    {
                        FileInfo fi = new FileInfo(file);
                        Console.WriteLine(fi.Length);
                        size += fi.Length;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Не удалось получить размер файла {file}: {ex.Message}");
                    }
                }

                // Получить все вложенные папки и рекурсивно суммировать их размеры
                string[] directories = Directory.GetDirectories(dir);
                foreach (string directory in directories)
                {
                    size += CheckSize(directory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке директории {dir}: {ex.Message}");
            }

            return size;
        }
    }
}

