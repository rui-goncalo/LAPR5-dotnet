using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Mappers;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _repo;

        public WarehouseService(IUnitOfWork unitOfWork, IWarehouseRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<WarehouseDto> listDto = list.ConvertAll<WarehouseDto>(wh => WarehouseMapper.domainToDTO(wh));

            return listDto;
        }

        public async Task<WarehouseDto> GetByWarehouseIdAsync(string warehouseId)
        {
            var wh = await this._repo.GetByWarehouseIdAsync(warehouseId);
            
            if(wh == null)
                return null;

            return WarehouseMapper.domainToDTO(wh);
        }

        public async Task<WarehouseDto> AddAsync(CreatingWarehouseDto dto)
        {
            var warehouse = new Warehouse(new WarehouseId(dto.WarehouseId),new WarehouseAddress(dto.WarehouseAddress),new WarehouseDesignation(dto.WarehouseDesignation),new WarehouseGeoCoord(dto.WarehouseGeoCoord));

            await this._repo.AddAsync(warehouse);

            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

        public async Task<WarehouseDto> UpdateAsync(WarehouseDto dto)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(dto.WarehouseId); 

            if (warehouse == null)
                return null;   

            // change all fields
            warehouse.ChangeWarehouseAddress(new WarehouseAddress(dto.WarehouseAddress));
            warehouse.ChangeWarehouseDesignation(new WarehouseDesignation(dto.WarehouseDesignation));
            warehouse.ChangeWarehouseGeoCoord(new WarehouseGeoCoord(dto.WarehouseGeoCoord));
            
            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

        public async Task<WarehouseDto> InactivateAsync(string warehouseId)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseId); 

            if (warehouse == null)
                return null;   

            warehouse.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

        public async Task<WarehouseDto> ActivateAsync(string warehouseId)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseId); 

            if (warehouse == null)
                return null;   

            warehouse.MarkAsActive();
            
            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

        public async Task<WarehouseDto> CheckActivateAsync(string warehouseId)
        {
            var warehouse = await this._repo.CheckActiveWarehouseByIdAsync(warehouseId); 

            if (warehouse == null)
                return null;   

            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

        public async Task<WarehouseDto> DeleteAsync(string warehouseId)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseId); 

            if (warehouse == null)
                return null;   

            if (warehouse.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active warehouse.");
            
            this._repo.Remove(warehouse);
            await this._unitOfWork.CommitAsync();

            return WarehouseMapper.domainToDTO(warehouse);
        }

    }
}