using System;
using System.Collections.Generic;
using System.Text;

namespace redrum_not_muckduck_game
{
    class Room
    {
        public string RoomName { get; set; }
        public string ItemInRoom { get; set; }
        public string PersonInRoom { get; set; }

        public List<Room> AdjacentRoom;

        public Room(string roomName, string itemInRoom, string personInRoom)
        {
            RoomName = roomName; 
            ItemInRoom = itemInRoom;
            PersonInRoom = personInRoom;
        }
    }
}
