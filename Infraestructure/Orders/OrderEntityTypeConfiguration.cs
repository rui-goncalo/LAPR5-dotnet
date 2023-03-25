using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Orders;

namespace DDDSample1.Infrastructure.Orders
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.ToTable("Orders", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.OrderId);
            builder.OwnsOne(b => b.Description);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}