using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentConnection_Hotel_Api.Interfaces;
using PresentConnection_Hotel_Api.Models;

namespace PresentConnection_Hotel_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepo)
        {
            _hotelRepository = hotelRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels(string? location)
        {
            var hotels = await _hotelRepository.GetHotelsAsync(location);
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }
    }
}
