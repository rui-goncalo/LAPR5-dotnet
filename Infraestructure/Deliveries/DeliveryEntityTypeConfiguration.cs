using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Deliveries;

namespace DDDSample1.Infrastructure.Deliveries
{
    internal class DeliveryEntityTypeConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Deliveries", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b.DeliveryId);
            builder.OwnsOne(b => b.DeliveryDate);
            builder.OwnsOne(b => b.Mass);
            builder.OwnsOne(b => b.WarehouseId);
            builder.OwnsOne(b => b.LoadTime);
            builder.OwnsOne(b => b.UnloadTime);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}