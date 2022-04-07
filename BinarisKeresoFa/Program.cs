using System;
using System.Xml;

namespace BinarisKeresoFa
{
    class Program
    {
        static void Main(string[] args)
        {
            // char teszt = 'k';
            // int teszt2 = (int)Char.GetNumericValue(teszt);
            // Console.WriteLine(teszt2);

            char teszt = 'k';
            int num = teszt - '0';
            Console.WriteLine(num);
        }
    }
}