using System;
using System.Collections.Generic;
using System.Linq;
using TestDrivenHotel.DAL;

namespace TestDrivenHotel.BLL
{
    public class HotelRepository
    {
        public List<RoomModel> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate, string roomType = null)
        {
            var allRooms = Rooms.GetAllRooms();
            var availableRooms = allRooms.Where(room => room.IsAvailable &&
                                                        (roomType == null || room.RoomType == roomType)).ToList();
            
            var bookedRoomIds = GetBookedRoomIds(checkInDate, checkOutDate);
            availableRooms = availableRooms.Where(room => !bookedRoomIds.Contains(room.RoomId)).ToList();

            return availableRooms;
        }
        public bool BookRoom(Booking booking)
        {
            var availableRooms = GetAvailableRooms(booking.CheckInDate, booking.CheckOutDate);
            var roomToBook = availableRooms.FirstOrDefault(room => room.RoomId == booking.RoomId);

            if (roomToBook != null)
            {
                roomToBook.IsAvailable = false;
                // Additional logic to save booking details if needed
                return true;
            }
            return false;
        }

        // Helper method to get room ids that are booked within a specific date range
        private List<int> GetBookedRoomIds(DateTime checkInDate, DateTime checkOutDate)
        {
            // Logic to fetch booked room ids within the specified date range
            // For simplicity, returning an empty list
            return new List<int>();
        }
    }
}
