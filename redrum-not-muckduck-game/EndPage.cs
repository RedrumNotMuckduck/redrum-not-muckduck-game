using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    // This class controls the ending to the game
    // You can find the winning, losing, & thank you scenes here 
    class EndPage
    {
        public static string[] Win = { "\n\tYou saved everyone from the fire!",
        "\t\tThanks, Kevin! You deserve some smores.",
        "\t\t\tHopefully, Dwight will be reprimanded for starting a fire in the office."};

        public static void WinScene()
        {
            Console.Clear();
            Render.TypeByElement(Win);
            // Waits for user to hit key to continue
            Console.ReadKey(true);
        }

        public static string[] Lose = {"\n\tAfter breathing in too much smoke you wake up surrounded by firefighters. ",
        "\t\tNo one knows how the fire was started.",
        "\t\t\tPlay again to solve the puzzle!"};

        public static void LoseScene() 
        {
            Console.Clear();
            Render.TypeByElement(Lose);
            // Waits for user to hit key to continue
            Console.ReadKey(true);
        }

        public static void ThankYou()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("    ████████╗██╗  ██╗ █████╗ ███╗   ██╗██╗  ██╗███████╗    ███████╗ ██████╗ ██████╗     ██████╗ ██╗      █████╗ ██╗   ██╗██╗███╗   ██╗ ██████╗ ██╗");
            Console.WriteLine("    ╚══██╔══╝██║  ██║██╔══██╗████╗  ██║██║ ██╔╝██╔════╝    ██╔════╝██╔═══██╗██╔══██╗    ██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██║████╗  ██║██╔════╝ ██║");
            Console.WriteLine("       ██║   ███████║███████║██╔██╗ ██║█████╔╝ ███████╗    █████╗  ██║   ██║██████╔╝    ██████╔╝██║     ███████║ ╚████╔╝ ██║██╔██╗ ██║██║  ███╗██║");
            Console.WriteLine("       ██║   ██╔══██║██╔══██║██║╚██╗██║██╔═██╗ ╚════██║    ██╔══╝  ██║   ██║██╔══██╗    ██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██║██║╚██╗██║██║   ██║╚═╝");
            Console.WriteLine("       ██║   ██║  ██║██║  ██║██║ ╚████║██║  ██╗███████║    ██║     ╚██████╔╝██║  ██║    ██║     ███████╗██║  ██║   ██║   ██║██║ ╚████║╚██████╔╝██╗");
            Console.WriteLine("       ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝    ╚═╝      ╚═════╝ ╚═╝  ╚═╝    ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝");
        }
    }
}
