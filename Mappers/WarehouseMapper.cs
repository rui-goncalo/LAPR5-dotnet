using DDDSample1.Domain.Warehouses;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Mappers
{
    public class WarehouseMapper
    {
        public static WarehouseDto domainToDTO(Warehouse wh)
        {

            return new WarehouseDto { Id = wh.Id.AsGuid(), WarehouseId = wh.WarehouseId.WarehouseIdentifier, WarehouseAddress = wh.WarehouseAddress.wh_address, WarehouseDesignation = wh.WarehouseDesignation.wh_designation, WarehouseGeoCoord = wh.WarehouseGeoCoord.wh_geoCoords };
        }

    }
}