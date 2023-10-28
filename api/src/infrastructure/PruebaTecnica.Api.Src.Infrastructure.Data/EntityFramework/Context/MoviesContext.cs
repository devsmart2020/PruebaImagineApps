using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Src.Core.Domain.Entities;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.EntityFramework.Context;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }



    public virtual DbSet<MovieEntity> Movies { get; set; }



}
