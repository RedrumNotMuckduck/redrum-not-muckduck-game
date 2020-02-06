using System;
using System.Collections.Generic;
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
        public static List<Room> AllRooms{ get; set; }
        public static Board Board = new Board();
        public static HelpPage HelpPage = new HelpPage();
        public static Hints Hints = new Hints(); 
        public static int Number_of_Lives { get; set; } = 3;
        public static int Number_of_Items { get; set; } = 0;
        public static int Number_of_Rooms { get; set; } = 0;
        public static int Number_of_Names { get; set; } = 0; 
        public static bool IsGameOver = false;
        public static string[] Actions = new string[] { "- explore", "- talk to someone", "- leave the current room", "- quit playing" };
        public static bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static List<string> hintList = new List<string>();
        public static List<string> vistedRooms = new List<string>();

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
            AllRooms = new List<Room> { Accounting, Sales, Reception, Kitchen, Annex, Breakroom };
        }

        public void Play(bool isNewGame)
        {
            if (isNewGame) { StartSetUp(); }
            Board.Render();
            while (!IsGameOver)
            {
                UserTurn();
            }
            EndOfGame();
        }

        private void StartSetUp()
        {
            if (IsWindows) { Sound.PlaySound("Theme.mp4", 1000); } //If device is windows - play music
            //WelcomePage.AcsiiArt();
            //WelcomePage.StoryIntro();
            Render.Location(Board.board, CurrentRoom);
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
                    Render.DeleteScene();
                    LeaveTheRoom();
                    Render.SceneDescription();
                    Board.Render();
                    break;
                case "explore":
                    Render.DeleteScene();
                    Board.Render();
                    CheckIfItemHasBeenFound();
                    Board.Render();
                    break;
                case "talk":
                    TalkToPerson();
                    break;
                case "quit":
                    IsGameOver = !IsGameOver;
                    break;
                case "save":
                    Console.Clear();
                    SaveVisitedRooms.Saved();
                    SaveHintQuotes.Saved();
                    SaveElements.Saved();
                    SaveWholeBoard.Saved();
                    Console.WriteLine("You game has been saved, Seen you soon.");
                    break;
                case "help":
                    Console.Clear();
                    HelpPage.Render();
                    break;
                case "hint":
                    Console.Clear();
                    Hints.Render();
                    break;
                default:
                    Board.Render();
                    Console.WriteLine("Please enter a valid option: (explore, talk, leave, quit)");
                    break;
            }
        }

        private void LeaveTheRoom()
        {
            Render.AdjacentRooms();
            Board.Render();
            Console.Write("> ");
            // TODO: error handling for user input 
            string nextRoom = Console.ReadLine().ToLower();
            Render.DeleteScene();
            Render.DeleteLocation(Board.board, CurrentRoom);
            UpdateCurrentRoom(nextRoom);
            Render.Location(Board.board, CurrentRoom);
        }

        private void TalkToPerson()
        {
            Render.DeleteScene();
            Render.Quote();
            //Adding hint to hint list after talking to people
            if (!hintList.Contains(CurrentRoom.GetQuote()) && CurrentRoom.Name != "Reception")
            {
                hintList.Add(CurrentRoom.GetQuote());
                Hints.DisplayHints(CurrentRoom.GetQuote()); 
            }

            Board.Render();
            if (CurrentRoom.Name == "Reception")
            {
                bool userWantsToSolve = Solution.AskToSolvePuzzle();
                if (userWantsToSolve)
                {
                    //If the user would like to solve the puzzle - check their answers
                    IsGameOver = Solution.CheckSolution();
                    CheckHealth();
                }
                else
                {
                    //Otherwise - Tell them to come back when they are ready
                    Render.DeleteScene();
                    Render.OneLineQuestionOrQuote("Michael: \"Ok, come back when you are ready\"");
                    Board.Render();
                }
            }
        }

        private void CheckHealth()
        {
            if (Number_of_Lives == 0)
            {
                IsGameOver = true;
            }
        }

        private void UpdateCurrentRoom(string nextRoom)
        {   // adding visted room while updating current room 
           
            foreach (Room Room in CurrentRoom.AdjacentRooms)
            {
                if (nextRoom == Room.GetNameToLowerCase())
                {
                    CheckIfVistedRoom(CurrentRoom.Name); 
                    CurrentRoom = Room;
                }
            }
        }

        private void CheckIfVistedRoom(string roomName)
        {
            if (!vistedRooms.Contains(roomName))
            {
                vistedRooms.Add(roomName);
                Board.VistedRooms(roomName);
                Number_of_Rooms++;
            }
        }


        private void CheckIfItemHasBeenFound()
        {
            if (CurrentRoom.HasItem)
            {
                Render.OneLineQuestionOrQuote($"You found: {CurrentRoom.ItemInRoom}");
                Render.AddItemToFoundItems(Board.board, CurrentRoom.ItemInRoom);
                CurrentRoom.HasItem = !CurrentRoom.HasItem;
                Number_of_Items++;
            }
            else
            {
                Render.OneLineQuestionOrQuote("Nothing left to explore");
            }
        }

        private void EndOfGame()
        {
            if (Number_of_Lives == 0) { EndPage.LoseScene(); }
            else { EndPage.WinScene(); }
            EndPage.ThankYouAsciiArt();
            SaveHints.ResetHintsFile();
            SaveWholeBoard.ResetBoardFile();
            SaveElements.ResetElementsFile();
        }
    }
}
