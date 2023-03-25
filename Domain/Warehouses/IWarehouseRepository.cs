using DDDSample1.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDSample1.Domain.Warehouses
{
    public interface IWarehouseRepository: IRepository<Warehouse,Identifier>
    {
        Task<Warehouse> GetByWarehouseIdAsync(string warehouseIdentifier);
        Task<Warehouse> CheckActiveWarehouseByIdAsync(string warehouseIdentifier);

      //Task<List<WarehouseDto>> GetByIdsAsync(List<WarehouseId> ids);

    }
}