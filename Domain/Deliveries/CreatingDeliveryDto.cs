namespace DDDSample1.Domain.Deliveries
{
    public class CreatingDeliveryDto
    {
        public string DeliveryId { get;  set; }
        public string WarehouseId { get;  set; }
        public string DeliveryDate { get;  set; }
        public string Mass { get;  set; }
        public string LoadTime { get;  set; }
        public string UnloadTime { get;  set; }

    }
}