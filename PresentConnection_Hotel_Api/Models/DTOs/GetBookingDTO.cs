namespace PresentConnection_Hotel_Api.Models.DTOs
{
    public class GetBookingDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? RoomType { get; set; }
        public bool BreakfastIncluded { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }
        public int Guests { get; set; }
        public string? HotelName { get; set; }
        public string? HotelLocation { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
