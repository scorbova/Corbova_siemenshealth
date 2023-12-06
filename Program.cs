using Čorbová_siemenshealth;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

class Program
{
    static void Main(string[] args)
    {
        // Main program
        //string filePath = @"C:\Users\user\OneDrive\Počítač\Sofi\Job\Siemens_Healthineers\zadanie\EXAMPLEFOLDER";
        //string filePath2 = @"C:\Users\user\OneDrive\Počítač\Sofi\Job\Siemens_Healthineers\zadanie\EXAMPLEFOLDER\myfolder.json";
        string filePath = "";

        while (true)
        {
            Console.WriteLine("Please provide a folder or a JSON file with folder information:");
            filePath = Console.ReadLine().ToLower();

            if (filePath == "exit")
            {
                break;
            }

            try
            {
                Directory_management dir = new Directory_management(filePath);
                dir.ImplementAll();
            }

            catch (Exception e)
            {
                Console.WriteLine("Isn't a valid path or file format");
            }

            Console.WriteLine("\n");
            
        }
    }
}