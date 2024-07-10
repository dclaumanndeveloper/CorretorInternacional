using CorretorInternacional.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace CorretorInternacional.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        // ... outras entidades
    }
}
