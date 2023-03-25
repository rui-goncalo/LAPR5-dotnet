using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class Warehouse : Entity<Identifier>, IAggregateRoot
    {

        public WarehouseId WarehouseId { get;  private set; }
        public WarehouseAddress WarehouseAddress { get;  private set; }

        public WarehouseDesignation WarehouseDesignation { get;  private set; }

        public WarehouseGeoCoord WarehouseGeoCoord { get;  private set; }
        public bool Active{ get;  private set; }

        public Warehouse()
        {
            this.Active = true;
        }

        public Warehouse(WarehouseId wh_id, WarehouseAddress wh_address, WarehouseDesignation wh_designation, WarehouseGeoCoord wh_geoCoord)
        {
            this.Id = new Identifier(Guid.NewGuid());
            this.WarehouseId = wh_id;
            this.WarehouseAddress = wh_address;
            this.WarehouseDesignation = wh_designation;
            this.WarehouseGeoCoord = wh_geoCoord;
            this.Active = true;
        }


        public void ChangeWarehouseAddress(WarehouseAddress wh_address)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the address of an inactive warehouse.");
            if (wh_address == null)
                throw new BusinessRuleValidationException("Every warehouse requires an address.");
            this.WarehouseAddress = wh_address;;
        }

        public void ChangeWarehouseGeoCoord(WarehouseGeoCoord wh_geoCoord)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the geo coordinates of an inactive warehouse.");
            if (wh_geoCoord == null)
                throw new BusinessRuleValidationException("Every warehouse requires geo coordinates.");
            this.WarehouseGeoCoord = wh_geoCoord;;
        }


        public void ChangeWarehouseDesignation(WarehouseDesignation wh_designation)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the designation of an inactive warehouse.");
            if (wh_designation == null)
                throw new BusinessRuleValidationException("Every warehouse requires designation.");
            this.WarehouseDesignation = wh_designation;;
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
                Warehouse u = (Warehouse)obj;
                return this.Id.Equals(u.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public void MarkAsInative()
        {
            this.Active = false;
        }

        public void MarkAsActive()
        {
            this.Active = true;
        }
    }
}