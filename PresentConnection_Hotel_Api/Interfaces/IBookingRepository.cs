using PresentConnection_Hotel_Api.Models;
using PresentConnection_Hotel_Api.Models.DTOs;

namespace PresentConnection_Hotel_Api.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<GetBookingDTO>> GetBookingsAsync();
        Task<Booking> CreateBookingAsync(Booking booking);
    }
}
