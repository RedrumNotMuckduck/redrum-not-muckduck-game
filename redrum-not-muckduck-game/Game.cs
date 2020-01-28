using System;
using System.Collections.Generic;
using System.Text;

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
        public static int NUMBER_OF_LIVES { get; set; } = 3;
        private bool IsGameOver = false; 

        public Game()
        {
            Accounting = new Room(
               "Accounting",
               "Angela's cat, Bandit",
               "Oscar: I am going into the ceiling"
               );
            CurrentRoom = Accounting;
            Sales = new Room(
               "Sales",
               "a random torch",
               "Andy: This would never happen at Cornell"
               );

            Kitchen = new Room(
                "Kitchen",
                "Oscar falling out of ceiling",
                "Phyllis: I saw Dwight came from the break room"
                );

            Breakroom = new Room(
                "Breakroom",
                "nothing but you see the vending machine.",
                "No one is here"
                );

            Reception = new Room(
                "Reception",
                "nothing",
                "Pam: the door is locked"
                );
            Annex = new Room(
                "The Annex",
                "beet stained cigs, warning label 'could cause fire'",
                "Kelly: Why does Dwight have a blow horn?"
                );

            Accounting.AdjacentRoom = new List<Room> { Sales };
            Sales.AdjacentRoom = new List<Room> { Reception, Accounting, Kitchen };
            Reception.AdjacentRoom = new List<Room> { Sales };
            Kitchen.AdjacentRoom = new List<Room> { Sales, Annex };
            Annex.AdjacentRoom = new List<Room> { Kitchen, Breakroom };
            Breakroom.AdjacentRoom = new List<Room> { Annex };
        }

        public void PlayGame()
        {
            Board.AddItemToFoundItems();
            Board.UpdateCurrentPlayerLocation("Melissa");
            Board.Render();

            Console.WriteLine("Welcome to the Office");

            while (!IsGameOver)
            {
                UserTurn();
            }
        }

        private void UserTurn()
        {
            string userChoice = "";
            Console.WriteLine("You can explore, talk to someone, leave the current room, or quit playing");
            Console.WriteLine("> ");
            userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (userChoice)
            {
                case "leave":
                    LeaveTheRoom();
                    break;
                case "explore":
                    Console.WriteLine($"You found: {CurrentRoom.ItemInRoom}");
                    break;
                case "talk":
                    Console.WriteLine(CurrentRoom.PersonInRoom);
                    break;
                case "quit":
                    IsGameOver = !IsGameOver; 
                    Console.WriteLine("\nThanks for playing. Goodbye. ");
                    break;
                default:
                    Console.WriteLine("Please enter a valid option: (explore, talk, leave, quit)");
                    break;
            }
        }

        private void LeaveTheRoom()
        {
            Console.Write("You have the choice to go to: ");
            for (int i = 0; i < CurrentRoom.AdjacentRoom.Count; i++)
            {
                Console.Write($"{CurrentRoom.AdjacentRoom[i].RoomName} ");
            }
            // TODO: error handling for user input 
            string nextRoom = Console.ReadLine().ToLower();
            UpdateCurrentRoom(nextRoom);
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
            int ROW = 2;
            int COLUMN = NUMBER_OF_LIVES + COLUMN_WHERE_HEARTS_START;
            Board.board[ROW, COLUMN] = ' ';
            NUMBER_OF_LIVES -= NUMBER_OF_LIVES;
        }
    }
}
