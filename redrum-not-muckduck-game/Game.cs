using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

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
        public static Room CurrentRoom { get; set; }
        public Board Board = new Board();
        public Render Render = new Render(); 
        public static int NUMBER_OF_LIVES { get; set; } = 3;
        public static int NUMBER_OF_ITEMS { get; set; } = 0;
        private bool IsGameOver = false;
        public static string[] Actions = new string[] { "-explore", "-talk to someone", "-leave the current room", "-quit playing" };
        public static bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);


     
    public Game()
        {
            Accounting = new Room(
               "Accounting",
               "Angela's cat, Bandit",
               "Oscar: \"I am going into the ceiling\""
               );
            CurrentRoom = Accounting;
            Sales = new Room(
               "Sales",
               "a random torch",
               "Andy: \"This would never happen at Cornell\""
               );

            Kitchen = new Room(
                "Kitchen",
                "Oscar falling out of ceiling",
                "Phyllis: \"I saw Dwight came from the break room\""
                );

            Breakroom = new Room(
                "Breakroom",
                "vending machine",
                "No one is here"
                );

            Reception = new Room(
                "Reception",
                "nothing",
                "Pam: \"The door is locked\""
                );
            Annex = new Room(
                "Annex",
                "beet stained cigs",
                "Kelly: \"Why does Dwight have a blow horn?\""
                );

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
            WelcomePage.AcsiiArt();
            Board.UpdateCurrentPlayerLocation();
            Render.Action();
            Board.Render();
            Console.WriteLine("Welcome to the Office!");

            while (!IsGameOver)
            {
                UserTurn();
            }
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
                    NUMBER_OF_ITEMS++;
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
            Render.DeleteAdjacentRooms();
            Board.ClearCurrentRoom();
            UpdateCurrentRoom(nextRoom);
            Board.UpdateCurrentPlayerLocation();
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

        public void LoseALife()
        {
            int COLUMN_WHERE_HEARTS_START = 49;
            int ROW_WHERE_HEARTS_START = 2;
            int COLUMN_TO_DELETE_HEART_FROM = NUMBER_OF_LIVES + COLUMN_WHERE_HEARTS_START;
            Board.board[ROW_WHERE_HEARTS_START, COLUMN_TO_DELETE_HEART_FROM] = ' ';
            NUMBER_OF_LIVES -= NUMBER_OF_LIVES;
        }
    }
}
