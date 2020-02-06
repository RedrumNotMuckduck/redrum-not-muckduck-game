using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveWholeBoard
    {
        public static string WorkingBoardDirectory { get; set; }

        public static void Saved()
        {
            SavedBoard savedBoard = new SavedBoard
            {
                TheBoard = Board.board,
            };

            File.WriteAllText(WorkingBoardDirectory, JsonConvert.SerializeObject(savedBoard));
        }

        public static void Stored()
        {
            int ROW_WHERE_STORED_BOARD_STARTS = 0;
            int COLUMN_WHERE_STORED_BOARD_STARTS = 0;
            int storedBoardCurrentLetter = 0;

            var myJsonFile = File.ReadAllText(WorkingBoardDirectory);

            myJsonFile = myJsonFile.Replace("{\"TheBoard\":", string.Empty)
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace(",", string.Empty)
                .Replace("\"", string.Empty)
                .Replace("[", string.Empty)
                ;
            for (int i = 0; i < myJsonFile.Length-2; i++)
            {
                if (myJsonFile[i] == ']')
                {
                    i++;
                    ROW_WHERE_STORED_BOARD_STARTS++;
                    storedBoardCurrentLetter = 0;
                }

                Board.board[ROW_WHERE_STORED_BOARD_STARTS, COLUMN_WHERE_STORED_BOARD_STARTS + storedBoardCurrentLetter] = myJsonFile[i];
                storedBoardCurrentLetter++;
            }
        }

        public static void ResetBoardFile()
        {
            File.WriteAllText(WorkingBoardDirectory, string.Empty);
        }

        public static void GetWorkingBoardDirectory()
        {
            if (Game.IsWindows)
            {
                WorkingBoardDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "Board.json");
            }
            else
            {
                WorkingBoardDirectory = Environment.CurrentDirectory.Replace("bin/Debug/netcoreapp3.1", "Board.json");
            }
        }
    }

    class SavedBoard
    {
        public char[,] TheBoard { get; set; }
    }
}
