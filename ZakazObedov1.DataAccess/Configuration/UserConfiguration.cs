using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Orders).WithOne(_ => _.User).HasForeignKey(_ => _.UserID);
        }
    }
}
