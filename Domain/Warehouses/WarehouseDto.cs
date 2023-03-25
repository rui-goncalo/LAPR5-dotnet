using System;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseDto
    {
        public Guid Id { get; set; }
        public string WarehouseId { get;  set; }
        public string WarehouseAddress { get;  set; }

        public string WarehouseDesignation { get;  set; }

        public string WarehouseGeoCoord { get;  set; } 

    }
}