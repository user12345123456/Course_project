using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "dbo").HasKey(x => x.ID);
            builder.HasOne(_ => _.User).WithMany(_ => _.Orders).HasForeignKey(_ => _.UserID);
            builder.HasOne(_ => _.Restaurant).WithMany(_ => _.Orders).HasForeignKey(_ => _.RestaurantID);
            // builder.HasOne(_ => _.Meal).WithMany(_ => _.Orders).HasForeignKey(_ => _.MealID);
        }
    }
}
