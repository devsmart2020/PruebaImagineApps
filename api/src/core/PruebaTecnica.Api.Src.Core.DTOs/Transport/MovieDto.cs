using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Api.Src.Core.DTOs.Transport
{
    public sealed class MovieDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required]
        public string Genre { get; set; } = null!;
        public decimal Score { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Image { get; set; } = null!;
        public string TrailerUrl { get; set; } = null!;

    }
}
