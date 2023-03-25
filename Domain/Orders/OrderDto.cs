using System;
using DDDSample1.Domain.Orders;

namespace DDDSample1.Domain.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string OrderId { get;  set; }
        public string OrderDescription { get; set; }

    }
}