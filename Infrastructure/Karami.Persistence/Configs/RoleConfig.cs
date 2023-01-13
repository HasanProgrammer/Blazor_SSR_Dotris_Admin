using Karami.Domain.Role.Entities;
using Karami.Domain.Role.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(Role => Role.Id);
        
        /*-----------------------------------------------------------*/
        
        builder.OwnsOne(Role => Role.Name)
            .Property(Name => Name.Value)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name");
        
        /*-----------------------------------------------------------*/
        
        //Relations
        
        builder.HasMany(Role => Role.RoleUsers)
            .WithOne(RoleUser => RoleUser.Role)
            .HasForeignKey(RoleUser => RoleUser.RoleId);
        
        builder.HasMany(Role => Role.Permissions)
            .WithOne(Permissions => Permissions.Role)
            .HasForeignKey(Permissions => Permissions.RoleId);
    }
}