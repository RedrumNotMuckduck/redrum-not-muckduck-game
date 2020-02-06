using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveElements
    {
        public string AccountingItem { get; set; }
        public string SalesItem { get; set; }
        public string AnnexItem { get; set; }
        public string TheCurrentRoom { get; set; }
        public int NumberofVisitedRooms { get; set; }
        public int NumberofItems { get; set; }
        public int NumberofLives { get; set; }
        public int NumberofHints { get; set; }
        public static string WorkingElementDirectory { get; set; }

        public static void Saved()
        {
            SaveElements SaveElements = new SaveElements
            {
                AccountingItem = Game.Accounting.HasItem.ToString(),
                SalesItem = Game.Sales.HasItem.ToString(),
                AnnexItem = Game.Annex.HasItem.ToString(),
                TheCurrentRoom = Game.CurrentRoom.Name,
                NumberofVisitedRooms = Game.Number_of_Rooms,
                NumberofItems = Game.Number_of_Items,
                NumberofLives = Game.Number_of_Lives,
                NumberofHints = Game.hintList.Count(),
            };
            
            File.WriteAllText(WorkingElementDirectory, JsonConvert.SerializeObject(SaveElements));
        }

        public static void StoredElements()
        { 
            var myJsonFile = File.ReadAllText(WorkingElementDirectory);
            myJsonFile = myJsonFile.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty);

            var dict = myJsonFile.Split(',')
              .Select(s => s.Split(':'))
              .ToDictionary(a => a[0].Trim(), a => a[1].Trim());

            Game.Accounting.HasItem = Convert.ToBoolean(dict["AccountingItem"]);
            Game.Sales.HasItem = Convert.ToBoolean(dict["SalesItem"]);
            Game.Annex.HasItem = Convert.ToBoolean(dict["AnnexItem"]);
            Game.CurrentRoom.Name = dict["TheCurrentRoom"];
            Game.Number_of_Rooms = Int32.Parse(dict["NumberofVisitedRooms"]);
            Game.Number_of_Items = Int32.Parse(dict["NumberofItems"]);
            Game.Number_of_Lives = Int32.Parse(dict["NumberofLives"]);
            Hints.SavedHints = Int32.Parse(dict["NumberofHints"]);

            UpdateRoom();
        }

        public static void UpdateRoom()
        {
            foreach (Room room in Game.List_Of_All_Roooms)
            {
                if(Game.CurrentRoom.Name == room.Name)
                {
                    Game.CurrentRoom.Name = "Accounting";
                    Game.CurrentRoom = room;
                }
            }
        } 

        public static void ResetElementsFile()
        {
            File.WriteAllText(WorkingElementDirectory, string.Empty);
        }

        public static void GetWorkingElementDirectory()
        {
            if (Game.Is_Windows)
            {
                WorkingElementDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "Elements.json");
            }
            else
            {
                WorkingElementDirectory = Environment.CurrentDirectory.Replace("bin/Debug/netcoreapp3.1", "Elements.json");
            }
        }
    }
}
