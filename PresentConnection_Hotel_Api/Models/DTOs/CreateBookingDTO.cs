namespace PresentConnection_Hotel_Api.Models.DTOs
{
    public class CreateBookingDTO
    {
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public bool BreakfastIncluded { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Guests { get; set; }
    }
}
