using System;

namespace redrum_not_muckduck_game
{
    class Program
    {
        static void Main()
        {
            Board current = new Board();
            current.AddItemToFoundItems();
            current.UpdateCurrentPlayerLocation("Melissa");
            current.Render();

            Game playGame = new Game();
            playGame.StartGame();
        }
    }
}
