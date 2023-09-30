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
            string directory1 = DirectoryInput();
            Console.WriteLine("Enter address of second folder!");
            string directory2 = DirectoryInput();
            Console.WriteLine("Enter first file extension");
            string extension1 = Console.ReadLine();
            Console.WriteLine("Enter second file extension");
            string extension2 = Console.ReadLine();
          
            
            string[] entryOne = Directory.GetFiles(directory1);
            string[] entryTwo = Directory.GetFiles(directory2);


            List<string> first = ListMaker(entryOne, extension1, directory1.Length);
            List<string> second = ListMaker(entryTwo, extension2, directory2.Length);


            var unnecessaryRaws = second.Except(first).ToList();
            DeletionProcess(unnecessaryRaws,directory2, extension2);
            
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

        private static void DeletionProcess(List<String> unnecessary, string directory2, string extension2)
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
                        //File.Delete(directory2+"\\"+kle+"."+extension2);
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
                    DeletionProcess(unnecessary, directory2, extension2);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Input error, try again!");
                DeletionProcess(unnecessary, directory2, extension2);
                
            }
            
            
        }

        private static string DirectoryInput()
        {
            string value1 = "nothing";
            string directory1 = Console.ReadLine();
            if (directory1 != null)
            { 
                string[] directoryCheck = directory1.Split('\\');
                if (directoryCheck[directoryCheck.Length-1].ToLower() != "jpeg" &&
                    directoryCheck[directoryCheck.Length-1].ToLower() != "raw")
                {
                    Console.WriteLine("For safety the folder name in which the pictures are should be name \"jpeg\" or \"raw\"");
                    Console.WriteLine("Enter the directory!");
                    return DirectoryInput();
                }
                if (Directory.Exists(directory1)) 
                {
                    Console.WriteLine("IS true");
                    value1 = directory1;
                    return directory1;
                }
                else
                {
                    Console.WriteLine("That folder does not exist!");
                    Console.WriteLine("Enter the directory!");
                    return DirectoryInput();
                }
            }
            else
            {
                Console.WriteLine("There was a null exception");
                return DirectoryInput();
            }
        }
    }
}