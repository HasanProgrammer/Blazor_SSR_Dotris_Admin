using Karami.Domain.Permission.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs;

public class PermissionUserConfig : IEntityTypeConfiguration<PermissionUser>
{
    public void Configure(EntityTypeBuilder<PermissionUser> builder)
    {
        builder.ToTable("PermissionUsers");
        
        builder.HasKey(PermissionUser => PermissionUser.Id);
        
        /*-----------------------------------------------------------*/
        
        builder.HasOne(PermissionUser => PermissionUser.Permission)
            .WithMany(Permission => Permission.PermissionUsers)
            .HasForeignKey(PermissionUser => PermissionUser.PermissionId);
        
        builder.HasOne(PermissionUser => PermissionUser.User)
            .WithMany(User => User.PermissionUsers)
            .HasForeignKey(PermissionUser => PermissionUser.UserId);
    }
}