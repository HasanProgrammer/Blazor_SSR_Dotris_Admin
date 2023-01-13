using Karami.Domain.Commons.Enumerations;
using Karami.Domain.Event.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Karami.Persistence.Configs;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(Event => Event.Id);
        
        /*-----------------------------------------------------------*/
        
        builder.OwnsOne(Event => Event.CreatedAt, CreatedAt => {
            CreatedAt.Property(vo => vo.EnglishDate).IsRequired().HasColumnName("CreatedAt_EnglishDate");
            CreatedAt.Property(vo => vo.PersianDate).IsRequired().HasColumnName("CreatedAt_PersianDate");
        });
        
        builder.OwnsOne(Event => Event.UpdatedAt, CreatedAt => {
            CreatedAt.Property(vo => vo.EnglishDate).IsRequired().HasColumnName("UpdatedAt_EnglishDate");
            CreatedAt.Property(vo => vo.PersianDate).IsRequired().HasColumnName("UpdatedAt_PersianDate");
        });

        builder.Property(Event => Event.IsActive)
            .HasConversion(new EnumToNumberConverter<IsActive , int>())
            .IsRequired();
    }
}