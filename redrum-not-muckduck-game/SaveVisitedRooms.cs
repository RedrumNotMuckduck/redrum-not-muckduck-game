using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveVisitedRooms
    {
        public string VisitedRooms { get; set; }
        public static string WorkingVisitedRoomsDirectory { get; set; }

        public static void Saved()
        {
            SaveVisitedRooms SavedRoomsLists = new SaveVisitedRooms
            {
                VisitedRooms = string.Join(",", Game.Visited_Rooms),
            };
            File.WriteAllText(WorkingVisitedRoomsDirectory, JsonConvert.SerializeObject(SavedRoomsLists));
        }

        public static void Stored()
        {
            var myVisitedRoomsFile = File.ReadAllText(WorkingVisitedRoomsDirectory);
            myVisitedRoomsFile = myVisitedRoomsFile
                .Replace("{\"VisitedRooms\":", string.Empty)
                .Replace("}", string.Empty)
                .Replace("\"", string.Empty);

            Game.Visited_Rooms = myVisitedRoomsFile.Split(',').ToList();
        }
        
        public static void GetWorkingVisitedRoomsDirectory()
        {
            if (Game.Is_Windows)
            {
                WorkingVisitedRoomsDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "VisitedRooms.json");
            }
            else
            {
                WorkingVisitedRoomsDirectory = Environment.CurrentDirectory.Replace("bin/Debug/netcoreapp3.1", "VisitedRooms.json");
            }
        }

        public static void ResetVisitedRoomsFile()
        {
            File.WriteAllText(WorkingVisitedRoomsDirectory, string.Empty);
        }
    }
}
