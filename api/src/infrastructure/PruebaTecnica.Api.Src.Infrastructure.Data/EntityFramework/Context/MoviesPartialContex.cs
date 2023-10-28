using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Src.Infrastructure.Shared.Config;

namespace PruebaTecnica.Api.Src.Infrastructure.Data.EntityFramework.Context;

public partial class MoviesContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string dbConn = ConfigVariable.AZURE_CONNECTION ?? throw new Exception("No se encontró conexión a la Bd");

            optionsBuilder.UseSqlServer(dbConn ?? throw new Exception("DbConn is null"),
                sqlServerOptionsAction: SqlOptions =>
                {
                    SqlOptions.EnableRetryOnFailure();
                });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}