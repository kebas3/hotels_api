using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentConnection_Hotel_Api.Controllers;
using PresentConnection_Hotel_Api.Interfaces;
using PresentConnection_Hotel_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PresentConnection_Hotel_Api.Controllers.Tests
{
    public class HotelControllerTests
    {
        private readonly Mock<IHotelRepository> _mockHotelRepository;
        private readonly HotelController _controller;

        public HotelControllerTests()
        {
            _mockHotelRepository = new Mock<IHotelRepository>();
            _controller = new HotelController(_mockHotelRepository.Object);
        }

        [Fact]
        public async Task GetHotels_WithLocation_ReturnsOkWithHotels()
        {
            var location = "New York";
            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, Name = "Hotel A", Location = "New York" },
                new Hotel { Id = 2, Name = "Hotel B", Location = "New York" }
            };
            _mockHotelRepository.Setup(repo => repo.GetHotelsAsync(location)).ReturnsAsync(hotels);

            var result = await _controller.GetHotels(location);

            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var returnedHotels = Xunit.Assert.IsAssignableFrom<IEnumerable<Hotel>>(okResult.Value);
            returnedHotels.Should().BeEquivalentTo(hotels);
        }

        [Fact]
        public async Task GetHotel_WithValidId_ReturnsOkWithHotel()
        {
            var hotelId = 1;
            var hotel = new Hotel { Id = hotelId, Name = "Hotel A", Location = "Paris" };
            _mockHotelRepository.Setup(repo => repo.GetHotelByIdAsync(hotelId)).ReturnsAsync(hotel);

            var result = await _controller.GetHotel(hotelId);

            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var returnedHotel = Xunit.Assert.IsAssignableFrom<Hotel>(okResult.Value);
            returnedHotel.Should().BeEquivalentTo(hotel);
        }

        [Fact]
        public async Task GetHotel_WithInvalidId_ReturnsNotFound()
        {
            var hotelId = 99;
            _mockHotelRepository.Setup(repo => repo.GetHotelByIdAsync(hotelId)).ReturnsAsync((Hotel)null);

            var result = await _controller.GetHotel(hotelId);

            Xunit.Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
