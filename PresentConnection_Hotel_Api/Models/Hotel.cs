using System.ComponentModel.DataAnnotations;

namespace PresentConnection_Hotel_Api.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

    }
}
