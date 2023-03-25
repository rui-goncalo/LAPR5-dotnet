using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Orders
{
    public interface IOrderRepository: IRepository<Order, Identifier>
    {
        Task<Order> GetByOrderIdAsync(string orderIdentifier);
    }
}