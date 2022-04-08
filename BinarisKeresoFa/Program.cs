using System;
using System.Xml;

namespace BinarisKeresoFa
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "23*45*+";
            // char[] tmp = data.ToCharArray();
            // for (int i = 0; i < tmp.Length; i++)
            // {
            //     Console.WriteLine(tmp[i]);
            // }
            BinaryExpressionTree fa = BinaryExpressionTree.Build(data);
            Console.WriteLine(fa.Convert());
            
        }
    }
}