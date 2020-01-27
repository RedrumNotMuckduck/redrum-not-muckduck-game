using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class Room
    {
        public string RoomName;
        public string Description;
        public string ItemInRoom;
        public string PersonInRoom;

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
