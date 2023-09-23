using System;
using System.IO;

namespace RJM_CL
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string dire1;
            string dire2;


            string[] entryOne = Directory.GetFiles("D:\\Martins\\real imiges\\test1");

            foreach (var fil1 in entryOne)
            {
                Console.WriteLine(fil1);
            }

            Console.ReadLine();

        }
    }
}