using System;


namespace Lab1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random1 = new Random(1234);

            Random random2 = new Random(1234);

            Console.WriteLine("Послідовність 1");
            for (int i = 0; i < 10; i++)
            {
                int rnd1 = random1.Next(0, 10);

                Console.WriteLine(rnd1);

            }
            Console.WriteLine("Послідовність 2");
            for (int b = 0; b < 10; b++)
            {
                int rnd2 = random2.Next(0, 10);

                Console.WriteLine(rnd2);

            }
        }
    }
}
