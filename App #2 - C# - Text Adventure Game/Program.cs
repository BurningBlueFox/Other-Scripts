using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;



namespace TextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Show the Aplication name, version and author to the user.
            Console.WriteLine("Text Adventure Game || Version 1.2 || by: BurningBlueFox");
            
            ConsoleColor old_color = Console.ForegroundColor;
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Text Adventure Game");

            //Start Puzzle
            Random r = new Random();
            int time = 9;
            bool unlocked = false;
            Introduction();



            while (true)
            {
                if (unlocked == true) 
                { 
                    //End the game
                    break;
                }
                int wait_time =  r.Next(2) + 1;

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nWhat object would you like to use? ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string command = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                
                command = command.ToLower();
                if (command.Length == 0)
                {
                    Console.WriteLine("You need to type something!");
                    synth.Speak("Please type something");
                    continue;
                }

                Thread.Sleep(wait_time * 500);

                switch (command)
                { 
                    
                    case "help":
                        Console.WriteLine("Type the object would you like to use? ");
                    break;

                    case "quit":
                         unlocked = true;
                    break;

                    case "number":
                        Console.WriteLine("{0}", r.Next(9) + 1);
                    break;

                    case "door":
                    if (time == 12)
                    {
                        
                        Console.WriteLine("The door is unlocked and you exit the room.");
                        synth.Speak("Success");
                        unlocked = true;
                    }
                    else 
                    {
                        
                        Console.WriteLine("The door is locked.");
                        synth.Speak("Locked");
                    }
                        
                    break;

                    case "clock":
                    Console.Write("You read the time...");
                    synth.Speak("You read the time");
                    wait_time = r.Next(2) + 2;
                    Thread.Sleep(wait_time * 1000);
                    Console.Write("is " + time + ":00 now.");
                    break;

                    case "painting":
                    Console.WriteLine("Just a painting of a dozen trees.");
                    synth.Speak("could this mean something");
                    break;

                    case "chair":
                    Console.WriteLine("You sit on the chair to think about what to do...");
                         wait_time = r.Next(2) + 2;
                    Thread.Sleep(wait_time * 1000);
                    Console.WriteLine("You hear the clock ticking.");
                         wait_time = r.Next(2) + 5;
                    Thread.Sleep(wait_time * 1000);
                    Console.WriteLine("After a while, you stand up again.");
                    time++;
                    if (time > 12)
                        time = 1;
                    break;
                }

                
            }
            //end program
            Console.ForegroundColor = old_color;
        }

        static void Introduction()
        {
            Thread.Sleep(1000);
            Console.WriteLine("You wake up in a room.");
            Thread.Sleep(1000);
            Console.WriteLine("There is some objects in the room: \n");
            Thread.Sleep(1000);
            Console.WriteLine("You see a Door behind you,");
            Thread.Sleep(1000);
            Console.WriteLine("a Chair to your right,");
            Thread.Sleep(1000);
            Console.WriteLine("a Clock to your left,");
            Thread.Sleep(1000);
            Console.WriteLine("and a Painting in front of you.");
            Thread.Sleep(1000);
        }
        

        }
    }
