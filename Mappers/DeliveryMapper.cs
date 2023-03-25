using DDDSample1.Domain.Deliveries;

namespace DDDSample1.Mappers
{
    public class DeliveryMapper
    {
        public static DeliveryDto domainToDTO(Delivery dl)
        {

            return new DeliveryDto { Id = dl.Id.AsGuid(), DeliveryId = dl.DeliveryId.DeliveryIdentifier, WarehouseId = dl.WarehouseId.WarehouseIdentifier ,DeliveryDate = dl.DeliveryDate.DelDate , Mass =dl.Mass.Mass1, LoadTime = dl.LoadTime.Time1, UnloadTime = dl.UnloadTime.Time1};
        }

    }
}