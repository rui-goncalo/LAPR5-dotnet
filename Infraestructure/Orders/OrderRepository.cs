using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Orders;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Orders
{
    public class OrderRepository : BaseRepository<Order,Identifier>, IOrderRepository
    {
        private readonly DDDSample1DbContext _context;
        public OrderRepository(DDDSample1DbContext context):base(context.Orders)
        {
           _context = context;
        }
        public async Task<Order> GetByOrderIdAsync(string orderIdentifier)
        {
            return await _context.Orders.Where(x => orderIdentifier.Equals(x.OrderId.OrderIdentifier) && x.Active).FirstOrDefaultAsync();

        }
    }
}