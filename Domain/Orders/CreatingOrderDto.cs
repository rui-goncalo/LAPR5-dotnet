using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Orders
{
    public class CreatingOrderDto
    {
        public string OrderId { get;  set; }
        public string OrderDescription { get; set; }

    }
}