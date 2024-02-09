namespace TestDrivenHotel.BLL
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string GuestName { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        

        public Booking(string guestName, int roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            GuestName = guestName;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            
        }
    }
}

