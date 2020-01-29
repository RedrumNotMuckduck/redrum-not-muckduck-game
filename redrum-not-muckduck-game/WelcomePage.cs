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
                Sound.PlaySound("Theme.mp4", 1000);
            }

            TypeLine("Come on an adventure.. If you dare..", 150);
            Console.WriteLine();
            TypeLine("Press any key to continue...", 150);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                StoryIntro();
            }
        }

        public static void StoryIntro()
        {
            TypeLine("Those M&Ms look good. I wonder how many I can stuff in my mouth. As \n" +
                     "you strategically place M&Ms on your tongue you notice it smells like \n" +
                     "a campfire, you crave smores. Looking around you see smoke coming \n" +
                     "into the office from all directions. You are trapped in the office! \n" +
                     "To escape you must find WHO started the fire, WHAT started the fire, \n" +
                     "& WHERE the fire was started. After gathering as much information \n" +
                     "possible head to the reception area to show Michael what you have \n" +
                     "found. Be careful, an incorrect guess will lose you a life.", 70);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Game game = new Game();
                game.PlayGame();
            }
        }

        static void TypeLine(string line, int mili)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(mili);
            }
        }
    }

    public static class Sound
    {
        internal static AudioFileReader audioFile;
        internal static WaveOutEvent outputDevice;

        internal static void PlaySound(string musicFile, int milliSeconds = 0)
        {
            audioFile = new AudioFileReader(musicFile);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            Thread.Sleep(milliSeconds);
        }

        internal static void DisposeAudio()
        {
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}

