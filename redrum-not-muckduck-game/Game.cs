using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Console = Colorful.Console;

namespace redrum_not_muckduck_game
{
    // This class controls the game logic
    // You can find the game loop, user turn loop, navigation logic, and sets the scene for the game
    class Game
    {
        public static Room Accounting { get; set; }
        public static Room Sales { get; set; }
        public static Room Kitchen { get; set; }
        public static Room Breakroom { get; set; }
        public static Room Reception { get; set; }
        public static Room Annex { get; set; }
        public static Room Exit { get; set; }
        public static Room CurrentRoom { get; set; }
        public static List<Room> List_Of_All_Roooms { get; set; }
        public static int Number_of_Lives { get; set; } = 3;
        public static int Number_of_Items { get; set; } = 0;
        public static int Number_of_Rooms { get; set; } = 0;
        public static int Number_of_Names { get; set; } = 0;
        public static bool Is_Game_Over { get; set; } = false;
        public static List<string> Collected_Hints { get; set; } = new List<string>();
        public static List<string> Visited_Rooms { get; set; } = new List<string>();

        //Instances of all "pages/scences" within the game
        public static Board Board = new Board();
        public static HelpPage HelpPage = new HelpPage();
        public static HintPage HintPage = new HintPage();
        //Checks OS of user
        public static readonly bool Is_Windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public Game()
        {
            Accounting = new Room(
               "Accounting",
               "Your desk is covered in M&Ms.  " +
               "*Oscar is trying to find an exit.  " +
               "*Out of the corner of your eye, you " +
               "*see a drawer slowly open. ",
               "Angela's cat, Bandit",
               "Oscar: \'I am going into the ceiling\'",
               true
               );
            Sales = new Room(
               "Sales",
               "Chaos ensues as the smoke thickens. " +
               "*Andy is frantically running in circles and " +
               "*knocks over his trash can, something makes " +
               "*a thud sound as it falls out.",
               "a random torch",
               "Andy: \'This would never happen at Cornell\'",
               true
               );
            Kitchen = new Room(
                "Kitchen",
                " ",
                "Oscar falling out of ceiling",
                "Phyllis: \'I saw Dwight came from the breakroom\'",
                false
                );
            Breakroom = new Room(
                "Breakroom",
                " ",
                "vending machine",
                "No one is in the breakroom",
                false
                );
            Reception = new Room(
                "Reception",
                " ",
                "no item",
                "Michael: \"Would you like to solve the puzzle?\"",
                false
                );
            Annex = new Room(
                "Annex",
                " ",
                "beet stained cigs",
                "Kelly: \'Why does Dwight have a blow horn?\'",
                true
                );

            CurrentRoom = Accounting;

            Accounting.AdjacentRooms = new List<Room> { Sales };
            Sales.AdjacentRooms = new List<Room> { Reception, Accounting, Kitchen };
            Reception.AdjacentRooms = new List<Room> { Sales };
            Kitchen.AdjacentRooms = new List<Room> { Sales, Annex };
            Annex.AdjacentRooms = new List<Room> { Kitchen, Breakroom };
            Breakroom.AdjacentRooms = new List<Room> { Annex };
            List_Of_All_Roooms = new List<Room> { Accounting, Sales, Reception, Kitchen, Annex, Breakroom };
        }

        public void Play()
        {
            CheckForSavedData();
            Board.Render();
            while (!Is_Game_Over)
            {
                UserTurn();
            }
            EndOfGame();
        }

        public void CheckForSavedData()
        {
            //Find the files where the data is being stored
            SaveVisitedRooms.GetWorkingVisitedRoomsDirectory();
            SaveHintQuotes.GetWorkingHintQuotesDirectory();
            SaveWholeBoard.GetWorkingBoardDirectory();
            SaveElements.GetWorkingElementDirectory();
            SaveHints.GetWorkingHintDirectory();

            //If there is saved data - load it
            if (new FileInfo(SaveWholeBoard.WorkingBoardDirectory).Length != 0)
            {
                SaveVisitedRooms.Stored();
                SaveHintQuotes.Stored();
                SaveHints.Stored();
                SaveWholeBoard.Stored();
                SaveElements.StoredElements();
            }
            else //Otherwise - setup a new game
            {
                StartSetUp();
            }
        }

        private void StartSetUp()
        {
            if (Is_Windows) { Sound.PlaySound("Theme.mp4", 1000); } //If device is windows - play music
            //WelcomePage.AcsiiArt();
            //WelcomePage.StoryIntro();
            Render.Location(CurrentRoom);
            Render.Action();
            Render.SceneDescription();
        }

        private void UserTurn()
        {
            Console.Write("> ");
            string userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (userChoice)
            {
                case "leave":
                    LeaveTheRoom();
                    break;
                case "explore":
                    CheckIfItemHasBeenFound();
                    break;
                case "talk":
                    TalkToPerson();
                    break;
                case "quit":
                    Is_Game_Over = !Is_Game_Over;
                    break;
                case "save":
                    SaveTheGame();
                    break;
                case "help":
                    HelpPage.Render();
                    break;
                case "hint":
                    HintPage.Render();
                    break;
                default:
                    Board.Render();
                    Console.WriteLine("Please enter a valid option: (explore, talk, leave, quit)");
                    break;
            }
        }

        private void LeaveTheRoom()
        {
            Delete.Scene();
            Render.AdjacentRooms();
            Board.Render();
            AskUserWhereToGo();
        }

        private void AskUserWhereToGo()
        {
            Console.Write("> ");
            string nextRoom = Console.ReadLine().ToLower();
            UpdateCurrentRoom(nextRoom);
            Board.Render();
        }

        private void CheckIfItemHasBeenFound()
        {
            Delete.Scene();
            if (CurrentRoom.HasItem)
            {
                Render.OneLineQuestionOrQuote($"You found: {CurrentRoom.ItemInRoom}");
                Render.ItemToFoundItems(CurrentRoom.ItemInRoom);
                CurrentRoom.HasItem = !CurrentRoom.HasItem;
                Number_of_Items++;
            }
            else
            {
                Render.OneLineQuestionOrQuote("Nothing left to explore");
            }
            Board.Render();
        }

        private void TalkToPerson()
        {
            Delete.Scene();
            Render.Quote();
            AddQuoteToHintPage();
            CheckIfTalkingToMichael();
            Board.Render();
        }

        private void AddQuoteToHintPage()
        {
            //Check if quote has been added to hint page
            //Unless we're in Reception - because talking to Michael is to end the game not to get a hint
            if (!Collected_Hints.Contains(CurrentRoom.GetQuote()) && CurrentRoom.Name != "Reception")
            {
                Collected_Hints.Add(CurrentRoom.GetQuote());
                HintPage.DisplayHints(CurrentRoom.GetQuote());
            }
        }

        private void CheckIfTalkingToMichael()
        {
            if (CurrentRoom.Name == "Reception")
            {
                Board.Render();
                bool userWantsToSolve = Solution.AskToSolvePuzzle();
                if (userWantsToSolve)
                {
                    //If the user would like to solve the puzzle - check their answers
                    Is_Game_Over = Solution.CheckSolution();
                    CheckHealth();
                }
                else
                {
                    //Otherwise - Tell them to come back when they are ready
                    Delete.Scene();
                    Render.OneLineQuestionOrQuote("Michael: \"Ok, come back when you are ready\"");
                }
            }
        }

        private void UpdateCurrentRoom(string nextRoom)
        {
            Delete.Scene();
            Delete.Location(CurrentRoom);
            //Loop through adjacent rooms to see which one the user selected
            foreach (Room Room in CurrentRoom.AdjacentRooms)
            {
                if (nextRoom == Room.GetNameToLowerCase())
                {
                    CheckIfVistedRoom(CurrentRoom.Name); //Check if user has been to this room
                    CurrentRoom = Room; //Update the current room
                }
            }
            Render.Location(CurrentRoom);
            Render.SceneDescription();
        }

        private void CheckIfVistedRoom(string roomName)
        {
            if (!Visited_Rooms.Contains(roomName))
            {
                Visited_Rooms.Add(roomName); //Add room to list of seen rooms
                Render.VistedRooms(roomName); //Render to the board
                Number_of_Rooms++;
            }
        }

        private void SaveTheGame()
        {
             Console.Clear();
             SaveVisitedRooms.Saved();
             SaveHintQuotes.Saved();
             SaveElements.Saved();
             SaveWholeBoard.Saved();
             Console.WriteLine("You game has been saved, Seen you soon.");
        }

        private void CheckHealth()
        {
            if (Number_of_Lives == 0)
            {
                Is_Game_Over = true;
            }
        }

        private void EndOfGame()
        {
            if (Number_of_Lives == 0) { EndPage.LoseScene(); }
            else { EndPage.WinScene(); }
            EndPage.ThankYouAsciiArt();
            SaveHintQuotes.ResetHintQuotesFile();
            SaveVisitedRooms.ResetVisitedRoomsFile();
            SaveHints.ResetHintsFile();
            SaveWholeBoard.ResetBoardFile();
            SaveElements.ResetElementsFile();
        }
    }
}
