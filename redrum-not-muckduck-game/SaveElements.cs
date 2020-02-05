using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace redrum_not_muckduck_game
{
    class SaveElements
    {
        public static string WorkingElementDirectory { get; set; }

        public static void Saved()
        {
            SavedElements SavedElements = new SavedElements 
            {
                AccountingItem = Game.Accounting.HasItem.ToString(),
                SalesItem = Game.Sales.HasItem.ToString(),
                AnnexItem = Game.Annex.HasItem.ToString(),
                TheCurrentRoom = Game.CurrentRoom.Name,
                NumberofItems = Game.Number_of_Items,
                NumberofLives = Game.Number_of_Lives,
            };
            
            File.WriteAllText(WorkingElementDirectory, JsonConvert.SerializeObject(SavedElements));
        }

        public static void StoredElements()
        { 
            var myJsonFile = File.ReadAllText(WorkingElementDirectory);
            myJsonFile = myJsonFile.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty);

            Console.WriteLine(myJsonFile);

            var dict = myJsonFile.Split(',')
              .Select(s => s.Split(':'))
              .ToDictionary(a => a[0].Trim(), a => a[1].Trim());

            Game.Accounting.HasItem = Convert.ToBoolean(dict["AccountingItem"]);
            Game.Sales.HasItem = Convert.ToBoolean(dict["SalesItem"]);
            Game.Annex.HasItem = Convert.ToBoolean(dict["AnnexItem"]);
            Game.CurrentRoom.Name = dict["TheCurrentRoom"];
            Game.Number_of_Items = Int32.Parse(dict["NumberofItems"]);
            Game.Number_of_Lives = Int32.Parse(dict["NumberofLives"]);

            UpdateRoom();
        }

        public static void UpdateRoom()
        {
            foreach (Room room in Game.AllRooms)
            {
                if(Game.CurrentRoom.Name == room.Name)
                {
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
            WorkingElementDirectory = Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp3.1", "Elements.json");
        }
    }

    class SavedElements
    {
        public string AccountingItem { get; set; }
        public string SalesItem { get; set; }
        public string AnnexItem { get; set; }
        public string TheCurrentRoom { get; set; }
        public int NumberofItems { get; set; }
        public int NumberofLives { get; set; }
    }
}
