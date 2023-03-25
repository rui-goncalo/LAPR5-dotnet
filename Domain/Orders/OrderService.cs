using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Mappers;

namespace DDDSample1.Domain.Orders
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _repo;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<OrderDto> listDto = list.ConvertAll<OrderDto>(ord => OrderMapper.domainToDTO(ord));

            return listDto;
        }

        public async Task<OrderDto> GetByOrderIdAsync(string orderId)
        {
            var ord = await this._repo.GetByOrderIdAsync(orderId);
            
            if(ord == null)
                return null;

            return OrderMapper.domainToDTO(ord);
        }

        public async Task<OrderDto> AddAsync(CreatingOrderDto dto)
        {
            var order = new Order(new OrderId(dto.OrderId),new OrderDescription(dto.OrderDescription));

            await this._repo.AddAsync(order);

            await this._unitOfWork.CommitAsync();

            return OrderMapper.domainToDTO(order);
        }

        public async Task<OrderDto> UpdateAsync(OrderDto dto)
        {
            var order = await this._repo.GetByOrderIdAsync(dto.OrderId); 

            if (order == null)
                return null;   

            // change all field
            order.ChangeDescription(new OrderDescription(dto.OrderDescription));
            
            await this._unitOfWork.CommitAsync();

            return OrderMapper.domainToDTO(order);
        }

        public async Task<OrderDto> InactivateAsync(string orderId)
        {
            var order = await this._repo.GetByOrderIdAsync(orderId); 

            if (order == null)
                return null;   

            // change all fields
            order.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return OrderMapper.domainToDTO(order);
        }

         public async Task<OrderDto> DeleteAsync(string orderId)
        {
            var order = await this._repo.GetByOrderIdAsync(orderId); 

            if (order == null)
                return null;   

            if (order.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active order.");
            
            this._repo.Remove(order);
            await this._unitOfWork.CommitAsync();

            return OrderMapper.domainToDTO(order);
        }
    }
}