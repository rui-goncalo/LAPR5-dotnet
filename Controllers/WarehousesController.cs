using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;


namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehouseService _service;

        public WarehousesController(WarehouseService service)
        {
            _service = service;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Warehouses/ByIdentifier/id
        [HttpGet("ByIdentifier/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDto>> GetByWarehouseId(string warehouseIdentifier)
        {
            var warehouse = await _service.GetByWarehouseIdAsync(warehouseIdentifier);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // POST: api/Warehouses
        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> Create(CreatingWarehouseDto dto)
        {
            var list = await _service.GetAllAsync();
            foreach (var warehouseDto in list)
            {
                if (warehouseDto.WarehouseId.Equals(dto.WarehouseId))
                {
                    return BadRequest(new { Message = "This warehouse identifier already exists try another one." });
                }
            }
            try
            {
                var warehouse = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetByWarehouseId), new { id = warehouse.Id },warehouse);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        
        // PUT: api/Warehouses/id
        [HttpPut("{id}")]
        public async Task<ActionResult<WarehouseDto>> Update(string id, WarehouseDto dto)
        {
        
            if (id != dto.WarehouseId)
            {
                return BadRequest();
            }

            try
            {
                var wh = await _service.UpdateAsync(dto);
                
                if (wh == null)
                {
                    return NotFound();
                }
                return Ok(wh);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Warehouses/inactivate/id
        [HttpPut("inactivate/{id}")]
        public async Task<ActionResult<WarehouseDto>> SoftDelete(string id)
        {
            var wh = await _service.InactivateAsync(id);

            if (wh == null)
            {
                return NotFound();
            }

            return Ok(wh);
        }

        // Activate: api/Warehouses/activate/id
        [HttpPut("activate/{id}")]
        public async Task<ActionResult<WarehouseDto>> Activate(string id)
        {
            var wh = await _service.ActivateAsync(id);

            if (wh == null)
            {
                return NotFound();
            }

            return Ok(wh);
        }

        // GET: api/Warehouses/checkactivated/id
        [HttpGet("checkactivated/{id}")]
        public async Task<ActionResult<bool>> CheckActivated(string id)
        {
            var warehouse = await _service.CheckActivateAsync(id);

            if (warehouse == null)
            {
                return false;
            }

            return true;
        }
        
        // DELETE: api/Warehouses/id/hard
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<WarehouseDto>> HardDelete(string id)
        {
            try
            {
                var wh = await _service.DeleteAsync(id);

                if (wh == null)
                {
                    return NotFound();
                }

                return Ok(wh);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}