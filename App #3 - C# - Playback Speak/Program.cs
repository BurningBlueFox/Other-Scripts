using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;

namespace PlaybackTalk
{
    class Program
    {
        static void Main(string[] args)
        {
            //Show the Aplication name, version and author to the user.
            Console.WriteLine("PlaybackTalk || Version 1.0 || by: BurningBlueFox");
            Thread.Sleep(2000);
            SpeechSynthesizer synth = new SpeechSynthesizer();


            while (true)
            {
                Console.Clear();
                Console.Write("Type to talk:");
                string command = Console.ReadLine();
                if (command.Length > 0)
                    synth.Speak(command);
            }
        }
    }
}
