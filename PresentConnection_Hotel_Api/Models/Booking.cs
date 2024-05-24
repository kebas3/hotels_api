namespace PresentConnection_Hotel_Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool BreakfastIncluded { get; set; }
        public decimal TotalPrice { get; set; }
        public int Guests { get; set; }
    }
}
