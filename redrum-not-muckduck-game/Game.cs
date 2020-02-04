﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Console = Colorful.Console;

namespace redrum_not_muckduck_game
{
    // This class controls the game logic
    // You can find the game loop, user turn loop, navigation logic, and sets the scene for the game
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
        public static HelpPage HelpPage = new HelpPage();
        public static int Number_of_Lives { get; set; } = 3;
        public static int Number_of_Items { get; set; } = 0;
        public static int Number_of_Rooms { get; set; } = 0;
        public static int Number_of_Names { get; set; } = 0; 
        public static bool IsGameOver = false;
        public static string[] Actions = new string[] { "- explore", "- talk to someone", "- leave the current room", "- quit playing" };
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
               "Oscar: \"I am going into the ceiling\"",
               true
               );
            Sales = new Room(
               "Sales",
               "Chaos ensues as the smoke thickens. " +
               "*Andy is frantically running in circles and " +
               "*knocks over his trash can, something makes " +
               "*a thud sound as it falls out.",
               "a random torch",
               "Andy: \"This would never happen at Cornell\"",
               true
               );
            Kitchen = new Room(
                "Kitchen",
                " ",
                "Oscar falling out of ceiling",
                "Phyllis: \"I saw Dwight came from the breakroom\"",
                false
                );
            Breakroom = new Room(
                "Breakroom",
                " ",
                "vending machine",
                "No one is here",
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
                "Kelly: \"Why does Dwight have a blow horn?\"",
                true
                );

            CurrentRoom = Accounting;

            Accounting.AdjacentRooms = new List<Room> { Sales };
            Sales.AdjacentRooms = new List<Room> { Reception, Accounting, Kitchen };
            Reception.AdjacentRooms = new List<Room> { Sales };
            Kitchen.AdjacentRooms = new List<Room> { Sales, Annex };
            Annex.AdjacentRooms = new List<Room> { Kitchen, Breakroom };
            Breakroom.AdjacentRooms = new List<Room> { Annex };
        }

        public void Play()
        {
            StartSetUp();
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
            Board.Render();
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
                    Board.AddNames("Andy"); 
                    TalkToPerson();
                    break;
                case "quit":
                    IsGameOver = !IsGameOver;
                    break;
                case "help":
                    Console.Clear();
                    HelpPage.Render();
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
        {          // adding visted room while updating current room 
            List<string> vistedRooms = new List<string>(); 
            foreach (Room Room in CurrentRoom.AdjacentRooms)
            {
                if (nextRoom == Room.GetNameToLowerCase())
                {
                    if (!vistedRooms.Contains(CurrentRoom.Name))
                    {
                        vistedRooms.Add(CurrentRoom.Name); 
                        Board.VistedRooms(CurrentRoom.Name);
                        Number_of_Rooms++;
                    }
                    CurrentRoom = Room;
                }
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
        }
    }
}
