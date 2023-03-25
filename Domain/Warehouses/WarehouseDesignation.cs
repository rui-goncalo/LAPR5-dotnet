using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseDesignation : IValueObject
    {
        public String wh_designation{ get;  private set; }

        public bool Active{ get;  private set; }

        private WarehouseDesignation()
        {
            this.Active = true;
        }

        public WarehouseDesignation(String wh_designation)
        {
            if (wh_designation == null)
            throw new BusinessRuleValidationException("Designation can not be null");
            this.wh_designation = wh_designation;
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
                WarehouseDesignation e = (WarehouseDesignation)obj;
                return this.wh_designation.Equals(e.wh_designation);
            }
        }

        public override int GetHashCode()
        {
            return wh_designation.GetHashCode();
        }
    
        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
}