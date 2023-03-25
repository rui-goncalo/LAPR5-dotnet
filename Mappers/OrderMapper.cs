using DDDSample1.Domain.Orders;

namespace DDDSample1.Mappers
{
    public class OrderMapper
    {
        public static OrderDto domainToDTO(Order or)
        {

            return new OrderDto { Id = or.Id.AsGuid(), OrderId = or.OrderId.OrderIdentifier, OrderDescription = or.Description.description };
        }

    }
}