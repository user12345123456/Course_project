using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakazObedov1.Entities;

namespace ZakazObedov1.DataAccess.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants", "dbo").HasKey(x => x.Id);
            builder.HasMany(_ => _.Orders).WithOne(_ => _.Restaurant).HasForeignKey(_ => _.RestaurantID);
            builder.HasMany(_ => _.Meals).WithOne(_ => _.Restaurant).HasForeignKey(_ => _.RestaurantID);
        }
    }
}
