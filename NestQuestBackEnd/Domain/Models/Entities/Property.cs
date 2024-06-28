using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestQuestBackEnd.Domain.Models.Entities
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        public string Amenities { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string? ImageUrl { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public bool Verified { get; set; }

        public string? zipcode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; } = null;
        public Boolean? Furnished { get; set; }
    }
}
