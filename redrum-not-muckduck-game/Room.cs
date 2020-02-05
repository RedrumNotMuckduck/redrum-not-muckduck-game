using System.Collections.Generic;

namespace redrum_not_muckduck_game
{
    // This class creates new rooms for the game
    // Each room has a name, description, item, person, & adjacent rooms. 
    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemInRoom { get; set; }
        public string PersonInRoom { get; set; }
        public bool HasItem { get; set; }
        public List<Room> AdjacentRooms { get; set; }

        public Room(string roomName, string description, string itemInRoom, string personInRoom, bool hasItem)
        {
            Name = roomName;
            Description = description; 
            ItemInRoom = itemInRoom;
            PersonInRoom = personInRoom;
            HasItem = hasItem;
        }

        public string GetNameToLowerCase()
        {
            return Name.ToLower();
        }

        public int GetNameLength()
        {
            return Name.Length;
        }

        public string GetQuote()
        {
            return PersonInRoom;
        }

        public int GetQuoteLength()
        {
            return PersonInRoom.Length;
        }
    }
}
