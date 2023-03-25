using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Deliveries
{
    public class DeliveryRepository : BaseRepository<Delivery, Identifier>, IDeliveryRepository
    {
        private readonly DDDSample1DbContext _context;
        public DeliveryRepository(DDDSample1DbContext context):base(context.Deliveries)
        {
           _context = context;
        }

        public async Task<Delivery> GetByDeliveryIdAsync(string deliveryIdentifier)
        {
            return await _context.Deliveries
                .Where(x => deliveryIdentifier.Equals(x.DeliveryId.DeliveryIdentifier) && x.Active)
                .FirstOrDefaultAsync();

        }
    }
}