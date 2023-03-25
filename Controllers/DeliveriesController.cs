using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveryService _service;

        public DeliveriesController(DeliveryService service)
        {
            _service = service;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Deliveries/ByIdentifier/id
        [HttpGet("ByIdentifier/{deliveryIdentifier}")]
        public async Task<ActionResult<DeliveryDto>> GetByDeliveryId(string deliveryIdentifier)
        {
            var del = await _service.GetByDeliveryIdAsync(deliveryIdentifier);

            if (del == null)
            {
                return NotFound();
            }

            return del;
        }

        // POST: api/Deliveries
        [HttpPost]
        public async Task<ActionResult<DeliveryDto>> Create(CreatingDeliveryDto dto)
        {
            var list = await _service.GetAllAsync();
            foreach (var deliveryDto in list)
            {
                if (deliveryDto.DeliveryId.Equals(dto.DeliveryId))
                {
                    return BadRequest(new { Message = "This delivery identifier already exists try another one." });
                }
            }
            try
            {
                var delivery = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetByDeliveryId), new { id = delivery.Id },delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        
        // PUT: api/Deliveries/id
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryDto>> Update(string id, DeliveryDto dto)
        {
            if (id != dto.DeliveryId)
            {
                return BadRequest();
            }

            try
            {
                var del = await _service.UpdateAsync(dto);
                
                if (del == null)
                {
                    return NotFound();
                }
                return Ok(del);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Deliveries/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryDto>> SoftDelete(string id)
        {
            var del = await _service.InactivateAsync(id);

            if (del == null)
            {
                return NotFound();
            }

            return Ok(del);
        }
        
        // DELETE: api/Deliveries/id
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<DeliveryDto>> HardDelete(string id)
        {
            try
            {
                var del = await _service.DeleteAsync(id);

                if (del == null)
                {
                    return NotFound();
                }

                return Ok(del);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}