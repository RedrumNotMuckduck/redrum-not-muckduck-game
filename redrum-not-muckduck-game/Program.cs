using System;
using System.IO;
namespace redrum_not_muckduck_game
{
    class Program
    {
        static void Main()
        {                
            // Creates & starts new game
            Game game = new Game();
            bool isNewGame = true;
            SaveWholeBoard.GetWorkingBoardDirectory();
            SaveElements.GetWorkingElementDirectory();

            if (new FileInfo(SaveWholeBoard.WorkingBoardDirectory).Length == 0)
            {
                game.Play(isNewGame);
            }
            else
            {
                SaveWholeBoard.Stored();
                SaveElements.StoredElements();
                game.Play(!isNewGame);

            }
        }
    }
}
