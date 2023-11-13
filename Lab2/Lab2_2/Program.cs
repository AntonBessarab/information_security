using System;
using System.IO;
using System.Text;

namespace Lab2_2
{
    internal class Program
    {
        public static byte[] Encrypt(byte[] OrTextBytes, byte[] keyBytes)
        {
            byte[] EncTextBytes = new byte[OrTextBytes.Length];
            for (int i = 0; i < OrTextBytes.Length; i++)
            {
                EncTextBytes[i] = (byte)(OrTextBytes[i] ^ keyBytes[i]);
            }
            return EncTextBytes;
        }


        public static byte[] Decrypt(byte[] EncTextBytes, byte[] keyBytes)
        {
            byte[] decryptedBytes = new byte[EncTextBytes.Length];
            for (int i = 0; i < EncTextBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(EncTextBytes[i] ^ keyBytes[i]);
            }
            return decryptedBytes;
        }

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Виберіть опцію:");
                Console.WriteLine("1. Зашифрувати текст");
                Console.WriteLine("2. Розшифрувати текст");
                Console.WriteLine("3. Вийти");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        string inputFilePath = "C:\\Users\\anton\\source\\inf.bez\\Lab2\\Lab2_2\\text.txt";
                        byte[] OrTextBytes = File.ReadAllBytes(inputFilePath);

                        Console.WriteLine("Введіть ключ для шифрування :");
                        string keyInput = Console.ReadLine();

                        if (keyInput.Length != OrTextBytes.Length)
                        {
                            Console.WriteLine("Помилка: довжина паролю повинна бути рівна довжині повідомлення.");
                            break;
                        } 

                        byte[] keyBytes = Encoding.UTF8.GetBytes(keyInput);

                        byte[] encryptedBytes = Encrypt(OrTextBytes, keyBytes);

                        Console.WriteLine("Початкове повідомлення: " + Encoding.UTF8.GetString(OrTextBytes));
                        Console.WriteLine("Ключ: " + Encoding.UTF8.GetString(keyBytes));
                        Console.WriteLine("Зашифроване повідомлення: " + Encoding.UTF8.GetString(encryptedBytes));

                        string outputFilePath = Path.ChangeExtension(inputFilePath, ".dat");

                        File.WriteAllBytes(outputFilePath, encryptedBytes);

                        Console.WriteLine("Текст збережений у файлі " + outputFilePath);
                        break;
                    case 2:
                        inputFilePath = "C:\\Users\\anton\\source\\inf.bez\\Lab2\\Lab2_2\\text.dat";
                        encryptedBytes = File.ReadAllBytes(inputFilePath);

                        Console.WriteLine("Введіть ключ для розшифрування :");
                        keyInput = Console.ReadLine();

                        if (keyInput.Length != encryptedBytes.Length)
                        {
                            Console.WriteLine("Помилка: довжина паролю повинна бути рівна довжині зашифрованого повідомлення.");
                            break;
                        } 

                        keyBytes = Encoding.UTF8.GetBytes(keyInput);

                        byte[] decryptedBytes = Decrypt(encryptedBytes, keyBytes);

                        Console.WriteLine("Розшифроване повідомлення: " + Encoding.UTF8.GetString(decryptedBytes));
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}