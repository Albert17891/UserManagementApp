using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Core.Entities;

namespace UserManagement.Infastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasOne(u => u.UserProfile)
               .WithOne(up => up.User)
               .HasForeignKey<UserProfile>(up => up.Id);
    }
}
