using System;

namespace redrum_not_muckduck_game
{
    class Program
    {
        static void Main()
        {
            Board current = new Board();
            current.Render();
            current.AddItemToFoundItems();
            current.Render();

            PlayGame playGame = new PlayGame();
            playGame.StartGame(); 

           
        }

    }
}
