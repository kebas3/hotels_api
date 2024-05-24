using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentConnection_Hotel_Api.Data;
using PresentConnection_Hotel_Api.Interfaces;
using PresentConnection_Hotel_Api.Models;

namespace PresentConnection_Hotel_Api.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingContext _context;

        public HotelRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync(string? location = null)
        {
            if (string.IsNullOrEmpty(location))
            {
                return await _context.Hotels.ToListAsync();
            }

            return await _context.Hotels
                .Where(h => h.Location.ToLower().Contains(location.ToLower()))
                .ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
