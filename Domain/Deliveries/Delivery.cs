using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Deliveries
{
    public class Delivery : Entity<Identifier>, IAggregateRoot
    {
        public DeliveryId DeliveryId { get;  set; }
        public DeliveryDate DeliveryDate { get;  private set; }

        public Mass Mass { get;  private set; }

        public WarehouseId WarehouseId { get;  private set; }

        public Time LoadTime { get;  private set; }

        public Time UnloadTime { get;  private set; }

        public bool Active{ get;  private set; }

        public Delivery()
        {
            this.Active = true;
        }

        public Delivery(DeliveryId deliveryId,WarehouseId warehouseId, DeliveryDate deliveryDate, Mass mass, Time loadTime, Time unloadTime)
        {
            this.Id = new Identifier(Guid.NewGuid());
            this.DeliveryId = deliveryId;
            this.WarehouseId = warehouseId;
            this.DeliveryDate = deliveryDate;
            this.Mass = mass;
            this.LoadTime = loadTime;
            this.UnloadTime = unloadTime;
            this.Active = true;
        }

        public void ChangeDeliveryDate(DeliveryDate date)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the date to an inactive delivery.");
            this.DeliveryDate = date;
        }

        public void ChangeMass(Mass mass)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the mass to an inactive delivery.");
            this.Mass = mass;
        }

        public void ChangeWarehouseId(WarehouseId warehouseId)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the warehouse of an inactive delivery.");
            if (warehouseId == null)
                throw new BusinessRuleValidationException("Every delivery requires a warehouse.");
            this.WarehouseId = warehouseId;;
        }

        public void ChangeLoadTime(Time loadTime)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the load time to an inactive delivery.");
            this.LoadTime = loadTime;
        }

        public void ChangeUnloadTime(Time unloadTime)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the unload time to an inactive delivery.");
            this.UnloadTime = unloadTime;
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Delivery u = (Delivery)obj;
                return this.Id.Equals(u.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}