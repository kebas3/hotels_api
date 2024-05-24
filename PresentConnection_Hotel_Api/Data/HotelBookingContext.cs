using PresentConnection_Hotel_Api.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace PresentConnection_Hotel_Api.Data
{
    public class HotelBookingContext : DbContext
    {
        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "The Peninsula Paris", Location = "Paris, France", ImageUrl = "https://www.peninsula.com/en/-/media/news-room/about-us/pr-company-profile.png?mw=905&hash=D2F2A2130F77BE2876FB195243EBAB2A" },
                new Hotel { Id = 2, Name = "Steigenberger Frankfurter Hof", Location = "Frankfurt am Main, Germany", ImageUrl = "https://www.luxurylink.com/images/sho_59dfdf4a/7592_550-1280/image-7592_550.jpg?filtered=1" },
                new Hotel { Id = 3, Name = "Sol Principe", Location = "Torremolinos, Spain", ImageUrl = "https://bynder.onthebeach.co.uk/cdn-cgi/image/width=640,quality=70,fit=cover,format=auto/m/7fd33f013028b8ac/original/Sol-Principe.jpg" },
                new Hotel { Id = 4, Name = "Holiday Inn", Location = "Vilnius, Lithuania", ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/337072888.jpg?k=8f72385b9726da7a3efa643cfe6ea929b37829c7d4fe12b0f148825facb97c75&o=&hp=1" },
                new Hotel { Id = 5, Name = "VICTORIA Hotel", Location = "Kaunas, Lithuania", ImageUrl = "https://www.hotelscombined.com/himg/ed/ef/24/expediav2-317858-beb6e4-910033.jpg" },
                new Hotel { Id = 6, Name = "Radisson Blu", Location = "Riga, Latvia", ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/399173468.jpg?k=c4837a1ada2737131363e3efa4e35cead450dd43420ed76a1ee6ccc02e4dbedc&o=&hp=1" }
                );
        }
    }
}
