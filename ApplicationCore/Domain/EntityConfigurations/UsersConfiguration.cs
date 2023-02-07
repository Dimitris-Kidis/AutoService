


using ApplicationCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationCore.Domain.EntityConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.ClientConsultation).WithOne(b => b.Client).HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MasterConsultation).WithOne(b => b.Master).HasPrincipalKey(x => x.Id)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ClientMessage).WithOne(b => b.Client).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.Sender)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MasterMessage).WithOne(b => b.Master).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.Receiver)
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
