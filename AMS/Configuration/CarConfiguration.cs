using AMS.Models;
using Microsoft.EntityFrameworkCore;

namespace AMS.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
    {
       builder.ToTable(nameof(Car));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(128);
        builder.Property(x=>x.Model).HasMaxLength(128); 
        builder.Property(x=>x.Milece).HasMaxLength(50); 
    }
}
