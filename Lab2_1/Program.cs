using System;
using System.IO;
using System.Text;

class VernamCipher
{
    // Метод для шифрування тексту за допомогою шифру Вернама
    public static byte[] Encrypt(byte[] plaintextBytes, byte[] keyBytes)
    {
        if (plaintextBytes.Length != keyBytes.Length)
        {
            throw new ArgumentException("Довжина ключа повинна бути рівною довжині тексту");
        }

        byte[] ciphertextBytes = new byte[plaintextBytes.Length];

        for (int i = 0; i < plaintextBytes.Length; i++)
        {
            ciphertextBytes[i] = (byte)(plaintextBytes[i] ^ keyBytes[i]);
        }

        return ciphertextBytes;
    }

    static void Main()
    {
        string inputFilePath = "C:\\Users\\anton\\source\\inf.bez\\Lab1_1\\Lab2_1\\Text.txt";

        byte[] plaintextBytes = File.ReadAllBytes(inputFilePath);

        string password = "oyuantdi"; 

        // Кодуємо пароль в байтовий масив
        byte[] keyBytes = Encoding.UTF8.GetBytes(password);

        try
        {
            // Шифруємо текст
            byte[] encryptedBytes = Encrypt(plaintextBytes, keyBytes);

            // Змінюємо розширення файлу на .dat
            string outputFilePath = Path.ChangeExtension(inputFilePath, ".dat");

            // Записуємо зашифровані байти у новий файл
            File.WriteAllBytes(outputFilePath, encryptedBytes);

            Console.WriteLine("Текст був успішно зашифрований і збережений у файлі " + outputFilePath);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Під час виконання сталася помилка: " + ex.Message);
        }
    }
}
