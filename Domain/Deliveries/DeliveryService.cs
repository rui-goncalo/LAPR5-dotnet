using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Mappers;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryRepository _repo;

        private readonly IWarehouseRepository _repoWare;

        public DeliveryService(IUnitOfWork unitOfWork, IDeliveryRepository repo, IWarehouseRepository repoWarehouses)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoWare = repoWarehouses;
        }

        public async Task<List<DeliveryDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<DeliveryDto> listDto = list.ConvertAll<DeliveryDto>(del => DeliveryMapper.domainToDTO(del));

            return listDto;
        }

        public async Task<DeliveryDto> GetByDeliveryIdAsync(string deliveryId)
        {
            var dl = await this._repo.GetByDeliveryIdAsync(deliveryId);
            
            if(dl == null)
                return null;

            return DeliveryMapper.domainToDTO(dl);
        }

        public async Task<DeliveryDto> AddAsync(CreatingDeliveryDto dto)    
        {
            await checkWarehouseIdAsync(dto.WarehouseId);
            var delivery = new Delivery(new DeliveryId(dto.DeliveryId), new WarehouseId(dto.WarehouseId) ,new DeliveryDate(dto.DeliveryDate),new Mass(dto.Mass),new Time(dto.LoadTime),new Time(dto.LoadTime));

            await this._repo.AddAsync(delivery);

            await this._unitOfWork.CommitAsync();

            return DeliveryMapper.domainToDTO(delivery);
        }

        public async Task<DeliveryDto> UpdateAsync(DeliveryDto dto)
        {
            //await checkWarehouseIdAsync(dto.WarehouseId);
            var delivery = await this._repo.GetByDeliveryIdAsync(dto.DeliveryId); 

            if (delivery == null)
                return null;   

            // change all fields
            delivery.ChangeDeliveryDate(new DeliveryDate(dto.DeliveryDate));
            delivery.ChangeMass(new Mass(dto.Mass));
            delivery.ChangeWarehouseId(new WarehouseId(dto.WarehouseId));
            delivery.ChangeLoadTime(new Time(dto.LoadTime));
            delivery.ChangeUnloadTime(new Time(dto.LoadTime));
            
            await this._unitOfWork.CommitAsync();

            return DeliveryMapper.domainToDTO(delivery);
        }

        public async Task<DeliveryDto> InactivateAsync(string id)
        {
            var delivery = await this._repo.GetByDeliveryIdAsync(id); 

            if (delivery == null)
                return null;   

            delivery.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return DeliveryMapper.domainToDTO(delivery);
        }

        public async Task<DeliveryDto> DeleteAsync(string id)
        {
            var delivery = await this._repo.GetByDeliveryIdAsync(id); 

            if (delivery == null)
                return null;   

            if (delivery.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active delivery.");
            
            this._repo.Remove(delivery);
            await this._unitOfWork.CommitAsync();

            return DeliveryMapper.domainToDTO(delivery);
        }

        private async Task checkWarehouseIdAsync(string warehouseId)
        {
           var warehouse = await _repoWare.GetByWarehouseIdAsync(warehouseId);
           if (warehouse == null)
                throw new BusinessRuleValidationException("Invalid Warehouse Id.");
        }
    }
}