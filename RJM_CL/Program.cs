using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RJM_CL
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine("Enter first file extension");
            string dire1 = "D:\\Martins\\real imiges\\test1\\Jpeg" ;
            string dire2 = "D:\\Martins\\real imiges\\test1\\Raw";
            string extension1 = Console.ReadLine();
            Console.WriteLine("Enter second file extension");
            string extension2 = Console.ReadLine();
          
            
            string[] entryOne = Directory.GetFiles(dire1);
            string[] entryTwo = Directory.GetFiles(dire2);

            for (int i = 0; i < entryOne.Length; i++)
            {
                entryOne[i] = entryOne[i].Remove(0, dire1.Length + 1);
                entryOne[i] = entryOne[i].Replace("." + extension1, "");
            }

            List<string> first = entryOne.ToList();
            for (int i = 0; i < entryTwo.Length; i++)
            {
                entryTwo[i] = entryTwo[i].Remove(0, dire2.Length + 1);
                entryTwo[i] = entryTwo[i].Replace("." + extension2, "");
            }

            List<string> second = entryTwo.ToList();


            var unnecessaryRaws = second.Except(first).ToList();
            foreach (var kle in unnecessaryRaws)
            {
                Console.WriteLine(kle);
                Console.WriteLine(dire2+"\\"+kle+"."+extension2);
                File.Delete(dire2+"\\"+kle+"."+extension2);
            }


        }
    }
}