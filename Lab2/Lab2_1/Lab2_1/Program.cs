using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Lab2_1
{
    internal class Program
    {
        // Метод для шифрування тексту за допомогою шифру Вернама
        public static byte[] Encrypt(byte[] OrTextBytes, byte[] keyBytes)
        {

            byte[] EncTextBytes = new byte[OrTextBytes.Length];

            for (int i = 0; i < OrTextBytes.Length; i++)
            {
                EncTextBytes[i] = (byte)(OrTextBytes[i] ^ keyBytes[i]);
            }

            return EncTextBytes;
        }

        static void Main()
        {
            string inputFilePath = "C:\\Users\\anton\\source\\inf.bez\\Lab2\\Lab2_1\\Lab2_1\\text.txt";

            byte[] OrTextBytes = File.ReadAllBytes(inputFilePath);

            byte[] keyBytes = GenerateRandomKey(OrTextBytes.Length);

            // Шифруємо текст
            byte[] encryptedBytes = Encrypt(OrTextBytes, keyBytes);

            Console.WriteLine("Початкове повідомлення: " + Encoding.UTF8.GetString(OrTextBytes));
            Console.WriteLine("Ключ: " + Encoding.UTF8.GetString(keyBytes));
            Console.WriteLine("Зашифроване повідомлення: " + Encoding.UTF8.GetString(encryptedBytes));

            // Змінюємо розширення файлу на .dat
            string outputFilePath = Path.ChangeExtension(inputFilePath, ".dat");

            // Записуємо зашифровані байти у новий файл
            File.WriteAllBytes(outputFilePath, encryptedBytes);

            Console.WriteLine("Текст збережений у файлі " + outputFilePath);

        }
        public static byte[] GenerateRandomKey(int length)
        {
            byte[] key = new byte[length];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
        }
    }
}