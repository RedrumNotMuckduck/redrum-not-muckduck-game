using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class Game
    {
        public Room accounting { get; set; }
        public Room sales { get; set; }
        public Room kitchen { get; set; }
        public Room breakroom { get; set; }
        public Room reception { get; set; }
        public Room annex { get; set; }
        public static Room currentRoom { get; set; }
        public static int NUMBER_OF_LIVES { get; set; } = 3;

        public Game()
        {
            accounting = new Room(
               "Accounting",
               "Angela's cat, Bandit",
               "Oscar: I am going into the ceiling"
               );
            currentRoom = accounting;
            sales = new Room(
               "Sales",
               "a random torch",
               "Andy: This would never happen at Cornell"
               );

            kitchen = new Room(
                "Kitchen",
                "Oscar falling out of ceiling",
                "Phyllis: I saw Dwight came from the break room"
                );

            breakroom = new Room(
                "Breakroom",
                "nothing but you see the vending machine.",
                "No one is here"
                );

            reception = new Room(
                "Reception",
                "nothing",
                "Pam: the door is locked"
                );
            annex = new Room(
                "The Annex",
                "beet stained cigs, warning label 'could cause fire'",
                "Kelly: Why does Dwight have a blow horn?"
                );

            accounting.AdjacentRoom = new List<Room> { sales };
            sales.AdjacentRoom = new List<Room> { reception, accounting, kitchen };
            reception.AdjacentRoom = new List<Room> { sales };
            kitchen.AdjacentRoom = new List<Room> { sales, annex };
            annex.AdjacentRoom = new List<Room> { kitchen, breakroom };
            breakroom.AdjacentRoom = new List<Room> { annex };
        }

        public void PlayGame()
        {
            Board current = new Board();
            current.AddItemToFoundItems();
            current.UpdateCurrentPlayerLocation("Melissa");
            current.Render();

            Console.WriteLine("Welcome to the Office");

            while (!EndGame())
            {
                UserTurn();
            }
        }

        private bool EndGame()
        {
            return false;
        }

        private void UserTurn()
        {
            string userChoice = "";
            Console.WriteLine("> ");
            userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();

            switch (userChoice)
            {
                case "leave":
                    LeaveTheRoom();
                    break;
                case "explore":
                    Console.WriteLine(currentRoom.ItemInRoom);
                    break;
                case "talk":
                    Console.WriteLine(currentRoom.PersonInRoom);
                    break;
                case "q":
                    EndGame();
                    Console.WriteLine("\nThanks for playing. Goodbye. ");
                    break;
                default:
                    Console.WriteLine("Please enter a valid option: (explore, talk, leave, q)");
                    break;
            }
        }

        private void LeaveTheRoom()
        {
            string nextRoom = "";
            Console.Write("You have the choice to go to: ");
            for (int i = 0; i < currentRoom.AdjacentRoom.Count; i++)
            {
                Console.Write($"{currentRoom.AdjacentRoom[i].RoomName} ");
            }

            nextRoom = Console.ReadLine().ToLower();
            UpdateCurrentRoom(nextRoom);
        }

        private void UpdateCurrentRoom(string nextRoom) 
        {
            for (int i = 0; i < currentRoom.AdjacentRoom.Count; i++)
            {
                if (nextRoom == currentRoom.AdjacentRoom[i].RoomName.ToLower())
                {
                    currentRoom = currentRoom.AdjacentRoom[i];
                }
            }
        }
    }
}
