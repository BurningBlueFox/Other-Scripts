using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Namespace
namespace App_1
{   
    // Class
    class Program
    {    

        // Function
        static void Main(string[] args)
        {
            //Show the Aplication name, version and author to the user.
            Console.WriteLine("Number Printer || Version 1.0 || by: BurningBlueFox");
            
            string example = "Type a number: \n Or type a to print 0-100 numbers.";

            Console.WriteLine(example);

            ConsoleKeyInfo key_info = Console.ReadKey();
            Console.Clear();

            if (key_info.KeyChar == 'a')
            {
                PrintNumberOnScreen100Times();
            }
            else 
            {
                Console.WriteLine("Did you type {0}", key_info.KeyChar.ToString());
                //Console.WriteLine("Did you type " + key_info.KeyChar.ToString());
            }
            Console.ReadKey();
            
        }

        /// <summary>
        /// Prints number from 0 to 100
        /// </summary>
        static void PrintNumberOnScreen100Times()
        {
            //for (int loop_counter = 0; loop_counter <= 100; loop_counter++)
            for (int loop_counter = 0; loop_counter <= 100; loop_counter++)
            {
               // PrintNumberOnScreen();
                Console.WriteLine(loop_counter);
            }
        }
    }
}
