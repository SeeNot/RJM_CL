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
            Console.WriteLine("Hello and welcome to the RJM! \nTo continue press ENTER");
            Console.ReadLine();
            Console.WriteLine("Enter address of first folder!");
            string dire1 = Console.ReadLine();
            Console.WriteLine("Enter address of second folder!");
            string dire2 = Console.ReadLine();;
            Console.WriteLine("Enter first file extension");
            string extension1 = Console.ReadLine();
            Console.WriteLine("Enter second file extension");
            string extension2 = Console.ReadLine();
          
            
            string[] entryOne = Directory.GetFiles(dire1);
            string[] entryTwo = Directory.GetFiles(dire2);


            List<string> first = ListMaker(entryOne, extension1, dire1.Length);
            List<string> second = ListMaker(entryTwo, extension2, dire2.Length);



            var unnecessaryRaws = second.Except(first).ToList();
            foreach (var kle in unnecessaryRaws)
            {
                Console.WriteLine(dire2+"\\"+kle+"."+extension2);
                //File.Delete(dire2+"\\"+kle+"."+extension2);
            }


        }

        private static List<string> ListMaker(string[] entry, string extension, int lenght)
        {
            
            for (int i = 0; i < entry.Length; i++)
            {
                entry[i] = entry[i].Remove(0, lenght + 1);
                entry[i] = entry[i].Replace("." + extension, "");
            }
            
            return entry.ToList();
        }
        
    }
}