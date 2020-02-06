using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveHintQuotes
    {
        public string SeenHints { get; set; }
        public static string WorkingHintQuotesDirectory { get; set; }

        public static void Saved()
        {
            SaveHintQuotes SavedHintsLists = new SaveHintQuotes
            {
                SeenHints = string.Join(",", Game.Collected_Hints),
            };
            File.WriteAllText(WorkingHintQuotesDirectory, JsonConvert.SerializeObject(SavedHintsLists));
        }

        public static void Stored()
        {
            var myHintQuotesFile = File.ReadAllText(WorkingHintQuotesDirectory);
            myHintQuotesFile = myHintQuotesFile
                .Replace("{\"SeenHints\":", string.Empty)
                .Replace("}", string.Empty)
                .Replace("\"", string.Empty);

            Game.Collected_Hints = myHintQuotesFile.Split(',').ToList();
            AddHintsToBoard();
        }

        public static void AddHintsToBoard()
        {
            foreach (string hint in Game.Collected_Hints)
            {
                Game.HintPage.DisplayHints(hint);
            }
        }

        public static void GetWorkingHintQuotesDirectory()
        {
            if (Game.Is_Windows)
            {
                WorkingHintQuotesDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "HintQuotes.json");
            }
            else
            {
                WorkingHintQuotesDirectory = Environment.CurrentDirectory.Replace("bin/Debug/netcoreapp3.1", "HintQuotes.json");
            }
        }

        public static void ResetHintQuotesFile()
        {
            File.WriteAllText(WorkingHintQuotesDirectory, string.Empty);
        }
    }
}