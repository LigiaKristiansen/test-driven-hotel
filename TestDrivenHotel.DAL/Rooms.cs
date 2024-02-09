namespace TestDrivenHotel.DAL
{
    public static class Rooms
    {
        private static List<RoomModel> _rooms;

        static Rooms()
        {
            _rooms = new List<RoomModel> 
            {
                new RoomModel { RoomId = 1, RoomType = "Single", IsAvailable = true },
                new RoomModel { RoomId = 2, RoomType = "Double", IsAvailable = true },
                new RoomModel { RoomId = 3, RoomType = "Single", IsAvailable = true },
                new RoomModel { RoomId = 4, RoomType = "Double", IsAvailable = true },
                new RoomModel { RoomId = 5, RoomType = "Single", IsAvailable = true },
                new RoomModel { RoomId = 6, RoomType = "Double", IsAvailable = true },
                new RoomModel { RoomId = 7, RoomType = "Single", IsAvailable = true },
                new RoomModel { RoomId = 8, RoomType = "Double", IsAvailable = true },
                new RoomModel { RoomId = 9, RoomType = "Single", IsAvailable = true },
                new RoomModel { RoomId = 10, RoomType = "Double", IsAvailable = true }                
            };
           
        }

        public static List<RoomModel> GetAllRooms()
        {
            return _rooms;
        }

        public static RoomModel GetRoomById(int roomId)
        {
            return _rooms.Find(room => room.RoomId == roomId);
        }

        // Method to update room availability
        public static void UpdateRoomAvailability(int roomId, bool isAvailable)
        {
            var roomToUpdate = _rooms.Find(room => room.RoomId == roomId);
            if (roomToUpdate != null)
            {
                roomToUpdate.IsAvailable = isAvailable;
            }
        }
    }
}
