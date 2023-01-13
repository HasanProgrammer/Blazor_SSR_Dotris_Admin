using Karami.Domain.RoleUser.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs;

public class RoleUserConfig : IEntityTypeConfiguration<RoleUser>
{
    public void Configure(EntityTypeBuilder<RoleUser> builder)
    {
        builder.ToTable("RoleUsers");
        
        builder.HasKey(RoleUser => RoleUser.Id);
        
        /*-----------------------------------------------------------*/
        
        //Relations
        
        builder.HasOne(RoleUser => RoleUser.User)
               .WithMany(User => User.RoleUsers)
               .HasForeignKey(RoleUser => RoleUser.UserId);
        
        builder.HasOne(RoleUser => RoleUser.Role)
               .WithMany(Role => Role.RoleUsers)
               .HasForeignKey(RoleUser => RoleUser.RoleId);
    }
}