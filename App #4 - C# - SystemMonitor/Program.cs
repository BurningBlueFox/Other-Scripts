using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Speech.Synthesis;

namespace Jarvis
{
    class Program
    {
        //Create the synthetizer
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        
        static void Main(string[] args)
        {
            //Show the Aplication name, version and author to the user.
            Console.WriteLine("Jarvis (SysMon) || Version 1.0 || by: BurningBlueFox");
            //List of greetings to talk
            List<string> greetings_messages = new List<string>();
            greetings_messages.Add("Hello");
            greetings_messages.Add("Hi");
            greetings_messages.Add("Greetings");
            greetings_messages.Add("Hello there");
            greetings_messages.Add("Jarvis Speaking");

            //Random number generator forr the list
            Random r = new Random();



            //This will great the user in the default voice.

            Talk(greetings_messages[r.Next(greetings_messages.Count)], VoiceGender.Neutral, 2);

            #region MyPerformanceCounters
            //This will pull the current CPU load in percentage.
            PerformanceCounter perf_cpu_count = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            perf_cpu_count.NextValue();
            //This will pull the current RAM available in MBytes.
            PerformanceCounter perf_ram_count = new PerformanceCounter("Memory", "Available MBytes");
            perf_ram_count.NextValue();
            //This will get the System Up Time in seconds.
            PerformanceCounter perf_uptime_count = new PerformanceCounter("System", "System Up Time");
            perf_uptime_count.NextValue();
            #endregion

            TimeSpan uptime_span = TimeSpan.FromSeconds(perf_uptime_count.NextValue());
            string system_uptime_message = string.Format("System time is {0} days {1} hours {2} minutes {3} seconds",
                (int)uptime_span.TotalDays,
                (int)uptime_span.Hours,
                (int)uptime_span.Minutes,
                (int)uptime_span.Seconds);

            Talk(system_uptime_message, VoiceGender.Neutral, 3);
            bool isChromeOpenedYet = false;
            //INFINITE LOOP
            while (true)
            {
                if(isChromeOpenedYet == false)
                {
                    OpenWebsite("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                    isChromeOpenedYet = true;
                }

                int current_cpu_percentage = (int)perf_cpu_count.NextValue();
                int current_ram_available = ((int)perf_ram_count.NextValue() / 1024);

                //Every 1 second, print the CPU load on screen
                Console.Clear();
                Console.WriteLine("CPU load      : {0}%", current_cpu_percentage);
                Console.WriteLine("RAM available : {0}GB", current_ram_available);

                if (current_cpu_percentage > 80)
                {
                    if(current_cpu_percentage == 100)
                    {
                        
                        string cpu_load_vocal_message = String.Format("CPU Overload");
                        Talk(cpu_load_vocal_message, VoiceGender.Neutral);
                    }
                    else
                    {
                        string cpu_load_vocal_message = String.Format("CPU use is {0} percent", current_cpu_percentage);
                        Talk(cpu_load_vocal_message, VoiceGender.Neutral);
                    }
                }
                if(current_ram_available < 1)
                {
                    
                    string ram_load_vocal_message = String.Format("RAM available is {0} GB", current_ram_available);
                    Talk(ram_load_vocal_message, VoiceGender.Neutral);
                
                }

                //Speak the values to the user using text to speech
                
                
                Thread.Sleep(1000);
            }   
        }

        /// <summary>
        /// Speaks with a selected voice and message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voice_gender"></param>
        public static void Talk(string message, VoiceGender voice_gender)
        {
            synth.SelectVoiceByHints(voice_gender);
            synth.Speak(message);
        }
        /// <summary>
        /// Speaks with a selected voice, message and speech rate
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voice_gender"></param>
        /// <param name="rate"></param>
        public static void Talk(string message, VoiceGender voice_gender, int rate)
        {
            int old_rate = synth.Rate;
            synth.Rate = rate;
            Talk(message, voice_gender);
            synth.Rate = old_rate;
        }
        /// <summary>
        /// Open a website
        /// </summary>
        /// <param name="URL"></param>
        public static void OpenWebsite(string URL)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URL;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();
        }
    }
}
