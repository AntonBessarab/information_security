using System;
using System.Security.Cryptography;

namespace Lab1_2
{
    public class RandomNumber
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                string randomNumber = Convert.ToBase64String(RandomNumber.GenerateRandomNumber(32));
                Console.WriteLine(randomNumber);
            }
            Console.ReadLine();
        }
    }
}