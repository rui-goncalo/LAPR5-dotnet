using System;
using DDDSample1.Domain.Deliveries;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }
        public string DeliveryId { get;  set; }
        public string WarehouseId { get;  set; }
        public string DeliveryDate { get;  set; }
        public string Mass { get;  set; }
        public string LoadTime { get;  set; }
        public string UnloadTime { get;  set; }

    }
}