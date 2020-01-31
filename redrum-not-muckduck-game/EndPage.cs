using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class EndPage
    {
        //TODO Refactor TypeByElement from WelcomePage to Render
        public static string[] WinScene = { "You saved everyone from the fire!",
        "Thanks, Kevin! You deserve some smores.",
        "Hopefully, Dwight will be reprimanded for starting a fire in the office."};

        public static void Won()
        {
            WelcomePage.TypeByElement(WinScene);
        }

        public static string[] LoseScene = { "After breathing in too much smoke you wake up surrounded by firefighters. ",
        "No one knows how the fire was started.",
        "Play again to solve the puzzle!"};

        public static void Lose() 
        {
            WelcomePage.TypeByElement(LoseScene);
        }

    }
}
