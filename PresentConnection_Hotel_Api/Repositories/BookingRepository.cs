using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentConnection_Hotel_Api.Data;
using PresentConnection_Hotel_Api.Interfaces;
using PresentConnection_Hotel_Api.Models;
using PresentConnection_Hotel_Api.Models.DTOs;

namespace PresentConnection_Hotel_Api.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingContext _context;

        public BookingRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetBookingDTO>> GetBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Hotel)
                .Select(b => new GetBookingDTO
                {
                    Id = b.Id,
                    HotelId = b.HotelId,
                    HotelName = b.Hotel.Name,
                    RoomType = b.RoomType.ToString(),
                    CheckInDate = b.CheckInDate.ToShortDateString(),
                    CheckOutDate = b.CheckOutDate.ToShortDateString(),
                    BreakfastIncluded = b.BreakfastIncluded,
                    TotalPrice = b.TotalPrice,
                    Guests = b.Guests
                })
                .ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            var roomRate = (int)booking.RoomType;
            var days = (booking.CheckOutDate - booking.CheckInDate).Days;
            var breakfastCost = booking.BreakfastIncluded ? 15 * days * booking.Guests : 0;

            booking.TotalPrice = roomRate * days + 20 + breakfastCost;

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking;
        }
    }
}
