using Karami.Domain.Commons.ValueObjects;
using Karami.Domain.Permission.Entities;
using Karami.Domain.Role.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Karami.Persistence.Configs;

public class PermissionConfig : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(Permission => Permission.Id);

        builder.ToTable("Permissions");
        
        /*-----------------------------------------------------------*/

        builder.OwnsOne(Permission => Permission.Name)
               .Property(Name => Name.Value)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("Name");
        
        /*builder.Property(Permission => Permission.Name)
               .HasConversion(Name => Name.Value , Value => new Name(Value))
               .IsRequired()
               .HasMaxLength(100);
        
        builder.Property(Permission => Permission.CreatedAt)
               .HasConversion(CreatedAt => JsonConvert.SerializeObject(CreatedAt) , Value => JsonConvert.DeserializeObject<CreatedAt>(Value))
               .IsRequired();
        
        builder.Property(Permission => Permission.UpdatedAt)
               .HasConversion(UpdatedAt => JsonConvert.SerializeObject(UpdatedAt) , Value => JsonConvert.DeserializeObject<UpdatedAt>(Value))
               .IsRequired();*/

        /*-----------------------------------------------------------*/

        builder.HasOne(Permission => Permission.Role)
               .WithMany(Role => Role.Permissions)
               .HasForeignKey(Permission => Permission.RoleId);

        builder.HasMany(Permission => Permission.PermissionUsers)
               .WithOne(PermissionUser => PermissionUser.Permission)
               .HasForeignKey(PermissionUser => PermissionUser.PermissionId);
    }
}