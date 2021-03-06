﻿using System;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace redrum_not_muckduck_game
{
    // This class controls the intro to the game
    // You can find Acsii Art & Story here
    class WelcomePage
    {
        public static void AcsiiArt()
        {
            Console.WriteLine(""); 
            Console.WriteLine("      ██▀███  ▓█████ ▓█████▄ ▄▄▄█████▓ █    ██  ███▄ ▄███▓  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌▓  ██▒ ██▒██  ▓██▒▓██▒▀█▀ ██▒  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ▓██ ░▄█ ▒▒███   ░██   █▌▒ ▓██░ ▓░ ██  ▒██░▓██    ▓██░  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌░ ▓██▀▀█▄ ▓█  ░██░▒██    ▒██   ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ░██▓ ▒██▒░▒████▒░▒████▓   ▒██▒ ░██▒█████▓ ▒██▒   ░██▒  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ░ ▒▓ ░▒▓░░░ ▒░ ░ ▒▒▓  ▒   ▒ ░░   ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("       ░▒ ░ ▒░ ░ ░  ░ ░ ▒  ▒     ░    ░░▒░ ░ ░ ░  ░      ░  ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("       ░░   ░    ░    ░ ░  ░   ░       ░░░ ░ ░ ░      ░     ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("            ███▄    █  ▒█████  ▄▄▄█████▓", Color.FromArgb(204, 34, 0));
            Console.WriteLine("            ██ ▀█   █ ▒██▒  ██▒▓  ██▒ ▓▒", Color.FromArgb(204, 34, 0));
            Console.WriteLine("           ▓██  ▀█ ██▒▒██░  ██▒▒ ▓██░ ▒░", Color.FromArgb(204, 34, 0));
            Console.WriteLine("           ▓██▒  ▐▌██▒▒██   ██░░ ▓██▓ ░ ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("           ▒██░   ▓██░░ ████▓▒░  ▒██▒ ░ ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("           ░ ▒░   ▒ ▒ ░ ▒░▒░▒░   ▒ ░░   ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("           ░ ░░   ░ ▒░  ░ ▒ ▒░     ░    ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("     ███▄ ▄███▓ █    ██  ▄████▄   ██ ▄█▀▓█████▄  █    ██  ▄████▄   ██ ▄█▀", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ▓██▒▀█▀ ██▒ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ▒██▀ ██▌ ██  ▓██▒▒██▀ ▀█   ██▄█▒ ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ▓██    ▓██░▓██  ▒██░▒▓█    ▄ ▓███▄░ ░██   █▌▓██  ▒██░▒▓█    ▄ ▓███▄░ ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ▒██    ▒██ ▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ░▓█▄   ▌▓▓█  ░██░▒▓▓▄ ▄██▒▓██ █▄ ", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ▒██▒   ░██▒▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄░▒████▓ ▒▒█████▓ ▒ ▓███▀ ░▒██▒ █▄", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ░ ▒░   ░  ░░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒ ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░▒ ▒▒ ▓▒", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ░  ░      ░░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░ ░ ▒  ▒ ░░▒░ ░ ░   ░  ▒   ░ ░▒ ▒░", Color.FromArgb(204, 34, 0));
            Console.WriteLine("    ░      ░    ░░░ ░ ░ ░        ░ ░░ ░  ░ ░  ░  ░░░ ░ ░ ░        ░ ░░ ░ ", Color.FromArgb(204, 34, 0));
       
            TypeByLetter("    Come on an adventure.. If you dare..", 150);
            Console.WriteLine();
            TypeByLetter("    Press any key to continue...", 150);
            // Waits for user to hit key to start game
            Console.ReadKey(true);
        }

        public static void TypeByLetter(string line, int milliseconds)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(milliseconds);
            }
        }

        public static void StoryIntro()
        {
            Console.Clear();
            Render.TypeByElement(intro);
        }

        private static string[] intro = { "\n    Those M&Ms look good. I wonder how many I can stuff in my mouth.",
        "    As you strategically place M&Ms on your tongue,",
        "\t    you notice it smells like a campfire... you crave smores.",
        "    Looking around you see smoke coming into the office from all directions. ",
        "\n\t\t    You are trapped in the office!",
        "\n    To escape you must find WHO started the fire,", "" +
        "\t    WHAT started the fire,",
        "\t\t    & WHERE the fire was started.",
        "    After gathering as much information possible head to the reception area,", 
        "\t    to show Michael what you have found.",
        "    Be careful, an incorrect guess will lose you a life"};
    }  
}

