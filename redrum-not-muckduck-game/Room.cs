using System.Collections.Generic;

namespace redrum_not_muckduck_game
{
    class Room
    {
        public string Name { get; set; }
        public string ItemInRoom { get; set; }
        public string PersonInRoom { get; set; }
        public bool HasItem { get; set; }
        public List<Room> AdjacentRoom { get; set; }

        public Room(string roomName, string itemInRoom, string personInRoom, bool hasItem)
        {
            Name = roomName; 
            ItemInRoom = itemInRoom;
            PersonInRoom = personInRoom;
            HasItem = hasItem;
        }
    }
}
