using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(d => d.Name).IsUnique();

        //builder.HasData(
        //        new Director { Id = 1, Name = "Mamoru Hosoda" },
        //        new Director { Id = 2, Name = "Makoto Shinkai" },
        //        new Director { Id = 3, Name = "Hiroshi Kojima" },
        //        new Director { Id = 4, Name = "Yoshiyuki Tomino" },
        //        new Director { Id = 5, Name = "Hayao Miyazaki" }
        //  );
    }
}
