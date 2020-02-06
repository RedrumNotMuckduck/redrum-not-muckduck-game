using System.Collections.Generic;
using NUnit.Framework;
using Room = redrum_not_muckduck_game.Room;

namespace UnitTests
{
    [TestFixture]
    public class RoomTest
    {
        private string Name = "Classroom1";
        private string Description = "TLG Learning Center";
        private string ItemInRoom = "Computers";
        private string PersonInRoom = "Renni: \"Good Morning\"";
        private bool HasItem = false;
        private List<Room> AdjacentRooms;
        private Room RoomToTest;
        private Room AdjacentRoomToTest;

        [SetUp] //Creates the room to be used in tests
        public void Setup()
        {
            RoomToTest = new Room(Name, Description, ItemInRoom, PersonInRoom, HasItem);
            RoomToTest.AdjacentRooms = new List<Room> { AdjacentRoomToTest };
        }

        [Test]
        public void RoomShouldHaveAName()
        {
            Assert.AreEqual(RoomToTest.Name, Name); ;
        }

        [Test]
        public void RoomShouldHaveADescription()
        {
            Assert.AreEqual(RoomToTest.Description, Description);
        }

        [Test]
        public void RoomsCanHaveAnItem()
        {
            Assert.AreEqual(RoomToTest.ItemInRoom, ItemInRoom);
        }

        [Test]
        public void RoomsCanHavePeopleInThem()
        {
            Assert.AreEqual(RoomToTest.PersonInRoom, PersonInRoom);
        }

        [Test]
        public void RoomsKnowIfTheyHaveAnItem()
        {
            Assert.AreEqual(RoomToTest.HasItem, HasItem);
        }
    }
}