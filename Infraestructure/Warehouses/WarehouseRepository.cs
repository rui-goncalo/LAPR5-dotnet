using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Warehouses
{
    public class WarehouseRepository : BaseRepository<Warehouse, Identifier>,IWarehouseRepository
    {
        private readonly DDDSample1DbContext _context;
        public WarehouseRepository(DDDSample1DbContext context):base(context.Warehouses)
        {
            _context = context;
        }

        public async Task<Warehouse> GetByWarehouseIdAsync(string warehouseIdentifier)
        {
            return await _context.Warehouses.Where(x => warehouseIdentifier.Equals(x.WarehouseId.WarehouseIdentifier) ).FirstOrDefaultAsync();

        }

        public async Task<Warehouse> CheckActiveWarehouseByIdAsync(string warehouseIdentifier)
        {
            return await _context.Warehouses.Where(x => warehouseIdentifier.Equals(x.WarehouseId.WarehouseIdentifier) && x.Active).FirstOrDefaultAsync();

        }
    }
}