using System;

namespace redrum_not_muckduck_game
{
    // This class controls all of the updates made to the game board
    // You can find how to delete a scene, render available rooms, scene description, & quotes
    class Render
    {
        public static void AdjacentRooms()
        {
            int ROW_WHERE_OPTIONS_START = 14;
            int COLUMN_WHERE_OPTIONS_START = 2;
            string header = "You have the choice to go to: ";
            for (int i = 0; i < header.Length; i++)
            {
                Board.board[ROW_WHERE_OPTIONS_START, COLUMN_WHERE_OPTIONS_START + i] = header[i];
            }
            ROW_WHERE_OPTIONS_START++;
            foreach (Room Room in Game.CurrentRoom.AdjacentRooms)
            {
                for (int i = 0; i < Room.GetNameLength(); i++)
                {
                    Board.board[ROW_WHERE_OPTIONS_START, COLUMN_WHERE_OPTIONS_START + i] = Room.Name[i];
                }
                ROW_WHERE_OPTIONS_START++;
            }
        }

        public static void Quote()
        {
            int ROW_WHERE_QUOTE_STARTS = 14;
            int COLUMN_WHERE_QUOTE_STARTS = 1;
            string quote = Game.CurrentRoom.GetQuote();
            for (int i = 0; i < Game.CurrentRoom.GetQuoteLength(); i++)
            {
                Board.board[ROW_WHERE_QUOTE_STARTS, COLUMN_WHERE_QUOTE_STARTS + i] = quote[i];
            }
        }

        public static void Action()
        {
            int ROW_WHERE_ACTIONS_START = 5;
            int COLUMN_WHERE_ACTIONS_START = 2;
            for (int i = 0; i < Game.Actions.Length; i++)
            {
                for (int j = 0; j < Game.Actions[i].Length; j++)
                {
                    Board.board[ROW_WHERE_ACTIONS_START, COLUMN_WHERE_ACTIONS_START + j] = Game.Actions[i][j];
                }
                ROW_WHERE_ACTIONS_START++;
            }
        }

        public static void OneLineQuestionOrQuote(string questionOrQuote)
        {
            int ROW_WHERE_QUESITON_STARTS = 14;
            int COLUMN_WHERE_QUESTION_STARTS = 1;
            for (int i = 0; i < questionOrQuote.Length; i++)
            {
                Board.board[ROW_WHERE_QUESITON_STARTS, COLUMN_WHERE_QUESTION_STARTS + i] = questionOrQuote[i];
            }
        }

        public static void DeleteScene()
        {
            int ROW_SCENE_ENDS = 20;
            int COL_SCENCE_STARTS = 1;
            int COL_SCENCE_ENDS = 48;

            for (int ROW_SCENE_STARTS = 14; ROW_SCENE_STARTS < ROW_SCENE_ENDS; ROW_SCENE_STARTS++)
            {
                for (int col = 0; col < COL_SCENCE_ENDS; col++)
                {
                    Board.board[ROW_SCENE_STARTS, COL_SCENCE_STARTS + col] = ' ';
                }
            }
        }

        public static void SceneDescription()
        {
            int ROW_WHERE_SCENE_STARTS = 14;
            int COLUMN_WHERE_SCENE_STARTS = 2;
            int currentLetter = 0;

            for (int i = 0; i < Game.CurrentRoom.Description.Length; i++)
            {
                // * Asterisk represents a new line 
                //  If statement increases row, restarts the column, & currentLetter
                //  so that the description is rendered on the next line.
                if (Game.CurrentRoom.Description[i] == '*')
                {
                    i++;
                    ROW_WHERE_SCENE_STARTS++;
                    COLUMN_WHERE_SCENE_STARTS = 2;
                    currentLetter = 0;
                }
                Board.board[ROW_WHERE_SCENE_STARTS, COLUMN_WHERE_SCENE_STARTS + currentLetter] = Game.CurrentRoom.Description[i];
                currentLetter++;
            }
        }

        public static void DeleteLocation(char[,] board, Room currentRoom)
        {
            int ROW_WHERE_LOCATION_STARTS = 1;
            int COLUMN_WHERE_LOCATION_STARTS = 16;
            for (int i = 0; i < currentRoom.GetNameLength(); i++)
            {
                board[ROW_WHERE_LOCATION_STARTS, COLUMN_WHERE_LOCATION_STARTS + i] = ' ';
            }
        }

        public static void Location(char[,] board, Room currentRoom)
        {
            int ROW_WHERE_LOCATION_STARTS = 1;
            int COLUMN_WHERE_LOCATION_STARTS = 16;
            for (int i = 0; i < currentRoom.GetNameLength(); i++)
            {
                board[ROW_WHERE_LOCATION_STARTS, COLUMN_WHERE_LOCATION_STARTS + i] = currentRoom.Name[i];
            }
        }

        public static void AddItemToFoundItems(char[,] board, string foundItem)
        {
            int ROW_WHERE_ITEMS_START = 8;
            int COLUMN_WHERE_ITEMS_START = 50;
            int ROW_TO_INSERT_NEW_ITEM = ROW_WHERE_ITEMS_START + Game.Number_of_Items;
            for (int i = 0; i < foundItem.Length; i++)
            {
                board[ROW_TO_INSERT_NEW_ITEM, COLUMN_WHERE_ITEMS_START + i] = foundItem[i];
            }
        }

        public static void TypeByElement(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
                // Waits for user to press key to continue
                Console.ReadKey(true);
            }
        }
    }
}
