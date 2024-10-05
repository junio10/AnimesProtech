using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Director> Directors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
