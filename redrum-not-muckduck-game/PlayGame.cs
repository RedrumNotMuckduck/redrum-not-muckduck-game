using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class PlayGame
    {
        public void StartGame()
        {
            Console.WriteLine("Welcome to the Office");

            Room currentRoom = SetUpRooms();

            string userChoice = "";

            while (userChoice != "q")
            {
                DescribeRoom(currentRoom);
                Console.WriteLine("> ");
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "leave":
                        if (currentRoom.AdjacentRoom != null)
                            currentRoom = currentRoom.AdjacentRoom;
                        break;
                    case "explore":
                        Console.WriteLine(currentRoom.ItemInRoom);
                        break;
                    case "talk":
                        Console.WriteLine(currentRoom.PersonInRoom);
                        break;

                    case "q":
                        Console.WriteLine("\nThanks for playing. Goodbye. ");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option: (explore, talk, leave, q)");
                        break;
                }
            }
        }

        static Room SetUpRooms()
        {
            Room accounting = new Room(
                "Accounting",
                "-Explore the room, Talk to the person, go to the adjacent room",
                "Angela's cat - Bandit",
                "Oscar - I am going to the ceiling"
                );

            Room sales = new Room(
                "Sales",
                "-Explore the room, Talk to the person, go the the adjacent room",
                "Random torch",
                "Andy - this would never happen at Cornell"
                );

            Room kitchen = new Room(
                "Kitchen",
                "- Explore, Talk, Leave the room",
                "Oscar falling out of ceiling",
                "Phlis - I saw Dwight came from the break room"
                );

            Room breakroom = new Room(
                "Breakroom",
                "- Explore, Talk, Leave the room",
                "You see a vending machine",
                "No one is here"
                );

            Room reception = new Room(
                "Reception",
                "- Explore, Talk, Leave the room",
                "nothing is here",
                "Pam - the door is locked"
                );
            Room theAnnex = new Room(
                "The Annex",
                "- Explore, Talk to someone, Leave the room",
                "Beet stained cigs, waring label- could cause fire",
                "Kelly - Why does Dwight have a blow horn?"
                );

            accounting.AdjacentRoom = sales;
            return accounting;
        }

        static void DescribeRoom(Room room)
        {
            Console.WriteLine();
            Console.WriteLine(room.RoomName);

            Console.WriteLine("".PadLeft(room.RoomName.Length), '-');
            Console.WriteLine(room.Description);
            Console.WriteLine("".PadLeft(room.RoomName.Length), '-');


        }
    }

}
