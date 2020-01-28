using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;
using System.Threading;
using System.Runtime.InteropServices;

namespace redrum_not_muckduck_game
{
    class WelcomePage
    {
        public static bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static void AcsiiArt()
        {
            
            Console.WriteLine("  ██▀███  ▓█████ ▓█████▄ ▄▄▄█████▓ █    ██  ███▄ ▄███▓  ");
            Console.WriteLine(" ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌▓  ██▒ ██▒██  ▓██▒▓██▒▀█▀ ██▒  ");
            Console.WriteLine(" ▓██ ░▄█ ▒▒███   ░██   █▌▒ ▓██░ ▓░ ██  ▒██░▓██    ▓██░  ");
            Console.WriteLine(" ▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌░ ▓██▀▀█▄ ▓█  ░██░▒██    ▒██   ");
            Console.WriteLine(" ░██▓ ▒██▒░▒████▒░▒████▓   ▒██▒ ░██▒█████▓ ▒██▒   ░██▒  ");
            Console.WriteLine(" ░ ▒▓ ░▒▓░░░ ▒░ ░ ▒▒▓  ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░  ");
            Console.WriteLine("   ░▒ ░ ▒░ ░ ░  ░ ░ ▒  ▒     ░    ░░▒░ ░ ░ ░  ░      ░  ");
            Console.WriteLine("   ░░   ░    ░    ░ ░  ░   ░       ░░░ ░ ░ ░      ░     ");
            Console.WriteLine("        ███▄    █  ▒█████  ▄▄▄█████▓");
            Console.WriteLine("        ██ ▀█   █ ▒██▒  ██▒▓  ██▒ ▓▒");
            Console.WriteLine("       ▓██  ▀█ ██▒▒██░  ██▒▒ ▓██░ ▒░");
            Console.WriteLine("       ▓██▒  ▐▌██▒▒██   ██░░ ▓██▓ ░ ");
            Console.WriteLine("       ▒██░   ▓██░░ ████▓▒░  ▒██▒ ░ ");
            Console.WriteLine("       ░ ▒░   ▒ ▒ ░ ▒░▒░▒░   ▒ ░░   ");
            Console.WriteLine("       ░ ░░   ░ ▒░  ░ ▒ ▒░     ░    ");
            Console.WriteLine(" ███▄ ▄███▓ █    ██  ▄████▄   ██ ▄█▀▓█████▄  █    ██  ▄████▄   ██ ▄█▀");
            Console.WriteLine("▓██▒▀█▀ ██▒ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ▒██▀ ██▌ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ");
            Console.WriteLine("▓██    ▓██░▓██  ▒██░▒▓█    ▄ ▓███▄░ ░██   █▌▓██  ▒██░▒▓█    ▄ ▓███▄░ ");
            Console.WriteLine("▒██    ▒██ ▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ░▓█▄   ▌▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ");
            Console.WriteLine("▒██▒   ░██▒▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄░▒████▓ ▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄");
            Console.WriteLine("░ ▒░   ░  ░░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒ ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒");
            Console.WriteLine("░  ░      ░░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░ ░ ▒  ▒ ░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░");
            Console.WriteLine("░      ░    ░░░ ░ ░ ░        ░ ░░ ░  ░ ░  ░  ░░░ ░ ░ ░        ░ ░░ ░ ");
            if (IsWindows)
            {
                //Sound.PlaySound("Theme.mp4", 1000);
            }
            
            TypeLine("Come on an adventure.. If you dare..");
            Console.WriteLine();
            TypeLine("Press any key to continue...");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Game game = new Game();
                game.PlayGame();
            }
        }

        static void TypeLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(150); // Sleep for 150 milliseconds
            }
        }
    }

    public static class Sound
    {
        // THANKS RADIAH
        internal static AudioFileReader audioFile;
        internal static WaveOutEvent outputDevice;

        // plays the specified sound file. If a milliSecond is also provided, that is used in the Thread.Sleep()
        internal static void PlaySound(string musicFile, int milliSeconds = 0)
        {
            // initialize audio device
            audioFile = new AudioFileReader(musicFile);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);

            // play and sleep after if requested
            outputDevice.Play();
            Thread.Sleep(milliSeconds);
        }

        // dispose of unmanaged audio resources
        internal static void DisposeAudio()
        {
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}

