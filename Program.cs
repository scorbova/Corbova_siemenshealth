using Čorbová_siemenshealth;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "";

        //A loop that runs indefinitely until the user inputs 'exit'
        while (true)
        {
            //After the question user can provide path to JSON file or folder 
            Console.WriteLine("Please provide a folder or a JSON file with folder information:");
            filePath = Console.ReadLine().ToLower();

            if (filePath == "exit")
            {
                break;
            }

            //Implementing functionality, handling exceptions for invalid paths or file formats
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