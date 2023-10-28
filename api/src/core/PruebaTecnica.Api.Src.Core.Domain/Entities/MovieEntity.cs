using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Api.Src.Core.Domain.Entities
{
    [Table("Movies")]
    public partial class MovieEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual string Genre { get; set; } = null!;
        public virtual decimal Score { get; set; }
        public virtual DateTime LaunchDate { get; set; }
        public virtual string Image { get; set; } = null!;
        public virtual string TrailerUrl { get; set; } = null!;

    }
}
