using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using Console = Colorful.Console;


namespace redrum_not_muckduck_game
{
    class Game
    {
        public Room Accounting { get; set; }
        public Room Sales { get; set; }
        public Room Kitchen { get; set; }
        public Room Breakroom { get; set; }
        public Room Reception { get; set; }
        public Room Annex { get; set; }
        public Room Exit { get; set; }
        public static Room CurrentRoom { get; set; }
        public static Board Board = new Board();
        public static Render Render = new Render();
        public static Solution Solution = new Solution();
        public static int Number_of_Lives { get; set; } = 3;
        public static int Number_of_Items { get; set; } = 0;
        public static bool IsGameOver = false;
        public static string[] Actions = new string[] { "-explore", "-talk to someone", "-leave the current room", "-quit playing" };
        public static bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public Game()
        {
            Accounting = new Room(
               "Accounting",
               "Your desk is covered in M&Ms.  " +
               "*Oscar is trying to find an exit.  " +
               "*Out of the corner of your eye, you " +
               "*see a drawer slowly open. ",
               "Angela's cat, Bandit",
               "Oscar: \"I am going into the ceiling\""
               );
            Sales = new Room(
               "Sales",
               "Chaos ensues as the smoke thickens. " +
               "Andy is frantically running in circles and knocks over his " +
               "trash can, something makes a thud sound as it falls out.",
               "a random torch",
               "Andy: \"This would never happen at Cornell\""
               );
            Kitchen = new Room(
                "Kitchen",
                " ",
                "Oscar falling out of ceiling",
                "Phyllis: \"I saw Dwight came from the break room\""
                );
            Breakroom = new Room(
                "Breakroom",
                " ",
                "vending machine",
                "No one is here"
                );
            Reception = new Room(
                "Reception",
                " ",
                "nothing",
                "Pam: \"The door is locked\""
                );
            Annex = new Room(
                "Annex",
                " ",
                "beet stained cigs",
                "Kelly: \"Why does Dwight have a blow horn?\""
                );

            CurrentRoom = Accounting;

            Accounting.AdjacentRoom = new List<Room> { Sales };
            Sales.AdjacentRoom = new List<Room> { Reception, Accounting, Kitchen };
            Reception.AdjacentRoom = new List<Room> { Sales };
            Kitchen.AdjacentRoom = new List<Room> { Sales, Annex };
            Annex.AdjacentRoom = new List<Room> { Kitchen, Breakroom };
            Breakroom.AdjacentRoom = new List<Room> { Annex };
        }

        public void Play()
        {
            if (IsWindows) { Sound.PlaySound("Theme.mp4", 1000); }
            //WelcomePage.AcsiiArt();
            Board.UpdateCurrentPlayerLocation();
            Render.Action();
            Render.SceneDescription();
            Board.Render();
            Console.WriteLine("Welcome to the Office!");

            while (!IsGameOver)
            {
                UserTurn();
            }
            WelcomePage.EndScene();
        }

        private void UserTurn()
        {
            Console.Write("> ");
            string userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (userChoice)
            {
                case "leave":
                    Render.DeleteQuote();
                    LeaveTheRoom();
                    Board.Render();
                    break;
                case "explore":
                    Render.DeleteAdjacentRooms();
                    Render.DeleteQuote();
                    Board.Render();
                    Console.WriteLine($"You found: {CurrentRoom.ItemInRoom}");
                    Number_of_Items++;
                    //TODO: add function to handle when nothing is in the room/when item is already found
                    Board.AddItemToFoundItems(CurrentRoom.ItemInRoom);
                    Board.Render();
                    break;
                case "talk":
                    Render.DeleteAdjacentRooms();
                    Render.DeleteQuote();
                    Render.Quote();
                    Board.Render();
                    break;
                case "quit":
                    IsGameOver = !IsGameOver;
                    Console.Clear();
                    Console.WriteLine("\nThanks for playing. Goodbye. ");
                    break;
                case "help":
                    Console.WriteLine("In order to escape you must find WHO started the fire, WHAT started the fire, \n" +
                     "& WHERE the fire was started. After gathering as much information \n" +
                     "possible head to the reception area to show Michael what you have found.\n" +
                     "Your options for naviagting in the rooms are: (explore, talk, leave, quit)", Color.Red);
                    break;
                default:
                    Board.Render();
                    Console.WriteLine("Please enter a valid option: (explore, talk, leave, quit)");
                    break;
            }
        }

        private void LeaveTheRoom()
        {
            if (CurrentRoom.RoomName == "Reception")
            {
                Solution.CheckSolution();
            }
            else
            {
                Render.AdjacentRooms();
                Board.Render();
                Console.Write("> ");
                // TODO: error handling for user input 
                string nextRoom = Console.ReadLine().ToLower();
                Render.DeleteAdjacentRooms();
                Board.ClearCurrentRoom();
                UpdateCurrentRoom(nextRoom);
                Board.UpdateCurrentPlayerLocation();
            }
        }

        private void UpdateCurrentRoom(string nextRoom)
        {
            for (int i = 0; i < CurrentRoom.AdjacentRoom.Count; i++)
            {
                if (nextRoom == CurrentRoom.AdjacentRoom[i].RoomName.ToLower())
                {
                    CurrentRoom = CurrentRoom.AdjacentRoom[i];
                }
            }
        }
    }
}
