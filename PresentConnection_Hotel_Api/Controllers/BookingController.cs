using Microsoft.AspNetCore.Mvc;
using PresentConnection_Hotel_Api.Interfaces;
using PresentConnection_Hotel_Api.Models;
using PresentConnection_Hotel_Api.Models.DTOs;

namespace PresentConnection_Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHotelRepository _hotelRepository;

        public BookingController(IBookingRepository bookingService, IHotelRepository hotelRepository)
        {
            _bookingRepository = bookingService;
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingRepository.GetBookingsAsync();
            return Ok(bookings);
        }


        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(CreateBookingDTO booking)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(booking.HotelId);

            var newBooking = new Booking
            {
                Hotel = hotel,
                RoomType = booking.RoomType,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                BreakfastIncluded = booking.BreakfastIncluded,
                Guests = booking.Guests,
            };

            await _bookingRepository.CreateBookingAsync(newBooking);
            return Ok(newBooking);
        }

    }
}
