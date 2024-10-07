using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class ProtechAnimesContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Director> Directors { get; set; }
        public ProtechAnimesContext(DbContextOptions<ProtechAnimesContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimeConfiguration).Assembly);
        }

    }
}
