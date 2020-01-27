using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class Room
    {
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string ItemInRoom { get; set; }
        public string PersonInRoom { get; set; }

        public Room AdjacentRoom;

        public Room(string roomName, string description, string itemInRoom, string personInRoom)
        {
            RoomName = roomName; 
            Description = description;
            ItemInRoom = itemInRoom;
            PersonInRoom = personInRoom;
        }
    }
}
