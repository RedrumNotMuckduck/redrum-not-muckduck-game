using System.Collections.Generic;

namespace redrum_not_muckduck_game
{
    class Room
    {
        public string RoomName { get; set; }
        public string ItemInRoom { get; set; }
        public string PersonInRoom { get; set; }
        public List<Room> AdjacentRoom { get; set; }

        public Room(string roomName, string itemInRoom, string personInRoom)
        {
            RoomName = roomName; 
            ItemInRoom = itemInRoom;
            PersonInRoom = personInRoom;
        }
    }
}
