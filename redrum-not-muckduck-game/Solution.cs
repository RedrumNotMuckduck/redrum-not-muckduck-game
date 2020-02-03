using System;
using System.Threading;

namespace redrum_not_muckduck_game
{
    // This class controls the solution to win the game and the amount of live user has left
    // You can find the methods for determining a right or wrong guess
    public class Solution
    {
        public static string[] Solutions = new string[] { "dwight", "beet stained cigs", "breakroom" };

        public static bool CheckSolution()
        {
            string[] questions = new string[] { "Michael: \"Who did it?\"", "Michael: \"What did they use?\"", "Michael: \"Where did it happen?\"" };
            for (int i = 0; i < Solutions.Length; i++)
            {
                Render.DeleteScene();
                Render.AskForSolution(questions[i]);
                Game.Board.Render();
                Console.Write("> ");
                string userGuess = Console.ReadLine();
                if (userGuess.ToLower() != Solutions[i])
                {
                    LoseALife();
                    WrongGuess();
                    return false; //Wrong guess - return false so that the game continues
                }
                RightGuess();
            }
            return true; //At this point all guesses were correct so the game ends
        }

        private static void WrongGuess()
        {
            Render.DeleteScene();
            Render.AskForSolution("That sounds off, try again");
            Game.Board.Render();
            Thread.Sleep(1000);//Display if the guess was wrong for 1 second
            Render.DeleteScene();
            Game.Board.Render();
        }

        private static void RightGuess()
        {
            Render.DeleteScene();
            Render.AskForSolution("Thats right!");
            Game.Board.Render();
            Thread.Sleep(1000); //Display if the guess was right/wrong for 1 second
        }

        private static void LoseALife()
        {
            int COLUMN_WHERE_HEARTS_START = 49;
            int ROW_WHERE_HEARTS_START = 2;
            int COLUMN_TO_DELETE_HEART_FROM = Game.Number_of_Lives + COLUMN_WHERE_HEARTS_START;
            Board.board[ROW_WHERE_HEARTS_START, COLUMN_TO_DELETE_HEART_FROM] = ' ';
            Game.Number_of_Lives -= 1;
        }
    }
}

