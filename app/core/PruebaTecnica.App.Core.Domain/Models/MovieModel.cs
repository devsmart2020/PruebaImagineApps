using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.App.Core.Domain.Models
{
    public sealed class MovieModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public decimal Score { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
