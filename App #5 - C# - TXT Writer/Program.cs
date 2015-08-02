using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TXT_Writer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Show the Aplication name, version and author to the user.
            Console.WriteLine("TXT writer || Version 0.1 || by: BurningBlueFox");
            Console.WriteLine("press a key to go");
            

            Write();
            Read();
            Console.ReadKey();
        }
        public static void Write()
        {
            //Creates Random() object to dice the numbers.
            Random r = new Random();

            //Creates the variables
            float int1 = r.Next(10001);
            int int2 = r.Next(10001);
            int int3 = r.Next(10001);
            int int4 = r.Next(10001);
            int int5 = r.Next(10001);
            int int6 = r.Next(10001);
            int int7 = r.Next(10001);
            int int8 = r.Next(10001);
            int int9 = r.Next(10001);

            //Creates an array of strings
            string[] linesWrite = { int1.ToString(),
                               int2.ToString(),
                               int3.ToString(),
                               int4.ToString(),
                               int5.ToString(),
                               int6.ToString(),
                               int7.ToString(),
                               int8.ToString(),
                               int9.ToString() };

            //System.IO.File.WriteAllLines creates a TXT and writes the collection of strings on the file...
            //and then closes the file.
            File.WriteAllLines(@"C:\Users\Public\TestFolder\Example Method 1.txt", linesWrite);

            ShowStep("Created a .txt file @ the adress.");
        }
        public static void Read()
        {
            //Creates a string array to read the TXT file.
            string[] linesRead = File.ReadAllLines(@"C:\Users\Public\TestFolder\Example Method 1.txt");

            ShowStep("Readed from the adress");

            //Creates a int array using the Linq library to convert the string into a int value.
            int[] values = linesRead.Select(s => int.Parse(s)).ToArray();

            ShowStep("Coverted string info to int.");

            ShowStep("");
            Console.WriteLine("The numbers are:\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}",
                                values[0],
                                values[1],
                                values[2],
                                values[3],
                                values[4],
                                values[5],
                                values[6],
                                values[7],
                                values[8]);



        }
        public static void ShowStep(string message)
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
