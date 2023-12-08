using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Configuration
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.ToTable("Meals", "dbo").HasKey(x => x.Id);
            builder.HasOne(_ => _.Restaurant).WithMany(_ => _.Meals).HasForeignKey(_ => _.RestaurantID);
        }
    }
}
