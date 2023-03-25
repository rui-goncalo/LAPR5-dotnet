using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Orders;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Orders/ByIdentifier/id
        [HttpGet("ByIdentifier/{orderIdentifier}")]
        public async Task<ActionResult<OrderDto>> GetByOrderId(string orderIdentifier)
        {
            var ord = await _service.GetByOrderIdAsync(orderIdentifier);

            if (ord == null)
            {
                return NotFound();
            }

            return ord;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(CreatingOrderDto dto)
        {
            var list = await _service.GetAllAsync();
            foreach (var orderDto in list)
            {
                if (orderDto.OrderId.Equals(dto.OrderId))
                {
                    return BadRequest(new { Message = "This order identifier already exists try another one." });
                }
            }
            try
            {
                var order = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetByOrderId), new { id = order.Id },order);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        
        // PUT: api/Orders/id
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> Update(string id, OrderDto dto)
        {
            if (id != dto.OrderId)
            {
                return BadRequest();
            }

            try
            {
                var ord = await _service.UpdateAsync(dto);
                
                if (ord == null)
                {
                    return NotFound();
                }
                return Ok(ord);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Orders/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDto>> SoftDelete(string id)
        {
            var ord = await _service.InactivateAsync(id);

            if (ord == null)
            {
                return NotFound();
            }

            return Ok(ord);
        }
        
        // DELETE: api/Orders/id
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<OrderDto>> HardDelete(string id)
        {
            try
            {
                var ord = await _service.DeleteAsync(id);

                if (ord == null)
                {
                    return NotFound();
                }

                return Ok(ord);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}