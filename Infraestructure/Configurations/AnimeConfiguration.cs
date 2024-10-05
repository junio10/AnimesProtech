using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("Animes");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(a => a.Name).IsUnique();

        builder.Property(a => a.Summary).IsRequired().HasMaxLength(500);

        builder.Property(a => a.DirectorId).IsRequired();

        builder.HasOne(a => a.Director)
            .WithMany(d => d.Animes)
            .HasForeignKey(a => a.DirectorId);

        //builder.HasData(new Anime
        //{
        //    Id = 1,
        //    Name = "Wolf Children",
        //    Summary = "Wolf Children is a 2012 Japanese anime film directed and co-written by Mamoru Hosoda.",
        //    DirectorId = 1
        //},
        //new Anime
        //{
        //    Id = 2,
        //    Name = "Your Name",
        //    Summary = "Your Name is a 2016 romantic fantasy anime film directed by Makoto Shinkai, featuring a story of body-swapping and star-crossed lovers.",
        //    DirectorId = 2
        //},
        //new Anime
        //{
        //    Id = 3,
        //    Name = "Attack on Titan",
        //    Summary = "Attack on Titan is a dark fantasy anime series based on the manga of the same name, focusing on humanity's struggle against giant humanoid creatures.",
        //    DirectorId = 3
        //},
        //new Anime
        //{
        //    Id = 4,
        //    Name = "My Hero Academia",
        //    Summary = "My Hero Academia is a superhero anime series that follows a boy born without superpowers in a world where they are the norm, and his quest to become a hero.",
        //    DirectorId = 4
        //},
        //new Anime
        //{
        //    Id = 5,
        //    Name = "Spirited Away",
        //    Summary = "Spirited Away is a 2001 animated fantasy film directed by Hayao Miyazaki, telling the story of a young girl navigating a world of spirits and gods.",
        //    DirectorId = 5
        //}
        //);
    }
}
