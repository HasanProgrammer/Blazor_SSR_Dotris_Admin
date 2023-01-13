using Karami.Domain.Commons.Enumerations;
using Karami.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Karami.Persistence.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    { 
        builder.HasKey(User => User.Id);

        builder.ToTable("Users");
        
        /*-----------------------------------------------------------*/
        
        builder.OwnsOne(User => User.FirstName)
               .Property(Name => Name.Value)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("FirstName");
        
        builder.OwnsOne(User => User.LastName)
               .Property(Name => Name.Value)
               .IsRequired()
               .HasMaxLength(80)
               .HasColumnName("LastName");
        
        builder.OwnsOne(User => User.Username)
               .Property(Name => Name.Value)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnName("Username");
        
        builder.OwnsOne(User => User.Password)
               .Property(Name => Name.Value)
               .IsRequired()
               .HasColumnName("Password");

        builder.Property(User => User.IsActive)
               .HasConversion(new EnumToNumberConverter<IsActive , int>())
               .IsRequired();

        /*-----------------------------------------------------------*/
        
        //Relations

        builder.HasMany(User => User.RoleUsers)
               .WithOne(RoleUser => RoleUser.User)
               .HasForeignKey(RoleUser => RoleUser.UserId);
        
        builder.HasMany(User => User.PermissionUsers)
               .WithOne(PermissionUser => PermissionUser.User)
               .HasForeignKey(PermissionUser => PermissionUser.UserId);
    }
}