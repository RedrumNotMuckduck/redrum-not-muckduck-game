using System;
using System.IO;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveHints
    {
        public char[,] HintsBoard { get; set; }
        public static string WorkingHintDirectory { get; set; }

        public static void Saved()
        {
            SaveHints SaveHints = new SaveHints
            {
                HintsBoard = HintPage.Hint_Page_Board,
            };

            File.WriteAllText(WorkingHintDirectory, JsonConvert.SerializeObject(SaveHints));
        }

        public static void Stored()
        {
            int ROW_WHERE_HINTS_PAGE_STARTS = 0;
            int COLUMN_WHERE_HINTS_PAGE_STARTS = 0;
            int hintsPageCurrentLetter = 0;

            var myJsonFile = File.ReadAllText(WorkingHintDirectory);

            myJsonFile = myJsonFile.Replace("{\"HintsBoard\":", string.Empty)
                .Replace("}", string.Empty)
                .Replace(",", string.Empty)
                .Replace("[", string.Empty)
                .Replace("\"", string.Empty)
                ;
            for (int i = 0; i < myJsonFile.Length - 2; i++)
            {
                if (myJsonFile[i] == ']')
                {
                    i++;
                    ROW_WHERE_HINTS_PAGE_STARTS++;
                    hintsPageCurrentLetter = 0;
                }

                HintPage.Hint_Page_Board[ROW_WHERE_HINTS_PAGE_STARTS, COLUMN_WHERE_HINTS_PAGE_STARTS + hintsPageCurrentLetter] = myJsonFile[i];
                hintsPageCurrentLetter++;
            }
        }

        public static void ResetHintsFile()
        {
            File.WriteAllText(WorkingHintDirectory, string.Empty);
        }

        public static void GetWorkingHintDirectory()
        {
            if (Game.Is_Windows)
            {
                WorkingHintDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "Hints.json");
            }
            else
            {
                WorkingHintDirectory = Environment.CurrentDirectory.Replace("bin/Debug/netcoreapp3.1", "Hints.json");
            }
        }
    }
}
