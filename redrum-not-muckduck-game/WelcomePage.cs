using System;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace redrum_not_muckduck_game
{
    class WelcomePage
    {
       
        public static void AcsiiArt()
        {
           Console.WriteLine("  ██▀███  ▓█████ ▓█████▄ ▄▄▄█████▓ █    ██  ███▄ ▄███▓  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌▓  ██▒ ██▒██  ▓██▒▓██▒▀█▀ ██▒  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ▓██ ░▄█ ▒▒███   ░██   █▌▒ ▓██░ ▓░ ██  ▒██░▓██    ▓██░  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌░ ▓██▀▀█▄ ▓█  ░██░▒██    ▒██   ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ░██▓ ▒██▒░▒████▒░▒████▓   ▒██▒ ░██▒█████▓ ▒██▒   ░██▒  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ░ ▒▓ ░▒▓░░░ ▒░ ░ ▒▒▓  ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("   ░▒ ░ ▒░ ░ ░  ░ ░ ▒  ▒     ░    ░░▒░ ░ ░ ░  ░      ░  ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("   ░░   ░    ░    ░ ░  ░   ░       ░░░ ░ ░ ░      ░     ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("        ███▄    █  ▒█████  ▄▄▄█████▓", Color.FromArgb(204, 34, 0));
           Console.WriteLine("        ██ ▀█   █ ▒██▒  ██▒▓  ██▒ ▓▒", Color.FromArgb(204, 34, 0));
           Console.WriteLine("       ▓██  ▀█ ██▒▒██░  ██▒▒ ▓██░ ▒░", Color.FromArgb(204, 34, 0));
           Console.WriteLine("       ▓██▒  ▐▌██▒▒██   ██░░ ▓██▓ ░ ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("       ▒██░   ▓██░░ ████▓▒░  ▒██▒ ░ ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("       ░ ▒░   ▒ ▒ ░ ▒░▒░▒░   ▒ ░░   ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("       ░ ░░   ░ ▒░  ░ ▒ ▒░     ░    ", Color.FromArgb(204, 34, 0));
           Console.WriteLine(" ███▄ ▄███▓ █    ██  ▄████▄   ██ ▄█▀▓█████▄  █    ██  ▄████▄   ██ ▄█▀", Color.FromArgb(204, 34, 0));
           Console.WriteLine("▓██▒▀█▀ ██▒ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ▒██▀ ██▌ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("▓██    ▓██░▓██  ▒██░▒▓█    ▄ ▓███▄░ ░██   █▌▓██  ▒██░▒▓█    ▄ ▓███▄░ ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("▒██    ▒██ ▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ░▓█▄   ▌▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ", Color.FromArgb(204, 34, 0));
           Console.WriteLine("▒██▒   ░██▒▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄░▒████▓ ▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄", Color.FromArgb(204, 34, 0));
           Console.WriteLine("░ ▒░   ░  ░░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒ ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒", Color.FromArgb(204, 34, 0));
           Console.WriteLine("░  ░      ░░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░ ░ ▒  ▒ ░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░", Color.FromArgb(204, 34, 0));
           Console.WriteLine("░      ░    ░░░ ░ ░ ░        ░ ░░ ░  ░ ░  ░  ░░░ ░ ░ ░        ░ ░░ ░ ", Color.FromArgb(204, 34, 0));
       
            //TypeLine("Come on an adventure.. If you dare..", 450);
            //Console.WriteLine();
            //TypeLine("Press any key to continue...", 450);

            if (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                StoryIntro();
            }
        }

        public static void StoryIntro()
        {
            //TypeLine("Those M&Ms look good. I wonder how many I can stuff in my mouth. As \n" +
            //         "you strategically place M&Ms on your tongue you notice it smells like \n" +
            //         "a campfire, you crave smores. Looking around you see smoke coming \n" +
            //         "into the office from all directions. You are trapped in the office! \n" +
            //         "To escape you must find WHO started the fire, WHAT started the fire, \n" +
            //         "& WHERE the fire was started. After gathering as much information \n" +
            //         "possible head to the reception area to show Michael what you have \n" +
            //         "found. Be careful, an incorrect guess will lose you a life.", 70);
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
}

