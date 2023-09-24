using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace RJM_CL
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine("Hello and welcome to the RJM! \nTo continue press ENTER");
            Console.ReadLine();
            Console.WriteLine("Enter address of first folder!");
            string directory1 = Console.ReadLine();
            Console.WriteLine("Enter address of second folder!");
            string directory2 = Console.ReadLine();
            Console.WriteLine("Enter first file extension");
            string extension1 = Console.ReadLine();
            Console.WriteLine("Enter second file extension");
            string extension2 = Console.ReadLine();
          
            
            string[] entryOne = Directory.GetFiles(directory1);
            string[] entryTwo = Directory.GetFiles(directory2);


            List<string> first = ListMaker(entryOne, extension1, directory1.Length);
            List<string> second = ListMaker(entryTwo, extension2, directory2.Length);


            var unnecessaryRaws = second.Except(first).ToList();
            DeletionProcces(unnecessaryRaws,directory2, extension2);
            
            Console.WriteLine("Done... \n Press Anything to exit!");
            Console.Read();
            Environment.Exit(0);


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

        private static void DeletionProcces(List<String> unnecessary, string directory2, string extension2)
        {
            Console.WriteLine($"Are you sure you want to delete {unnecessary.Count.ToString()} files? Y/N" );
            String reallyWantToDelete = Console.ReadLine();
            try
            {
                if (reallyWantToDelete.ToUpper() == "Y")
                {
                    foreach (var kle in unnecessary)
                    {
                        Console.WriteLine(kle);
                        //Console.WriteLine(dire2+"\\"+kle+"."+extension2);
                        File.Delete(directory2+"\\"+kle+"."+extension2);
                    }
                }
                else if (reallyWantToDelete.ToUpper() == "N")
                {
                    Console.WriteLine("Press Anything to exit!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Input error, try again!");
                    DeletionProcces(unnecessary, directory2, extension2);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Input error, try again!");
                DeletionProcces(unnecessary, directory2, extension2);
            }
            
            
        }

    }
}