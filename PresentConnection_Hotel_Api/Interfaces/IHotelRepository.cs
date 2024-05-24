using PresentConnection_Hotel_Api.Models;

namespace PresentConnection_Hotel_Api.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync(string location);
        Task<Hotel> GetHotelByIdAsync(int id);
    }
}
