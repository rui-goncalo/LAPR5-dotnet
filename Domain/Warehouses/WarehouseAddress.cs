using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseAddress : IValueObject
    {
        public String wh_address{ get;  private set; }

        public bool Active{ get;  private set; }

        private WarehouseAddress()
        {
            this.Active = true;
        }

        public WarehouseAddress(String wh_address)
        {
            if (wh_address == null)
            throw new BusinessRuleValidationException("Address can not be null");
            this.wh_address = wh_address;
            this.Active = true;
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
                WarehouseAddress e = (WarehouseAddress)obj;
                return this.wh_address.Equals(e.wh_address);
            }
        }

        public override int GetHashCode()
        {
            return wh_address.GetHashCode();
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
}