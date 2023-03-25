using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseGeoCoord : IValueObject
    {
        public String wh_geoCoords{ get;  private set; }

        public bool Active{ get;  private set; }

        private WarehouseGeoCoord()
        {
            this.Active = true;
        }

        public WarehouseGeoCoord(String wh_geoCoords)
        {
            //if (wh_geoCoords == null)
              //  throw new BusinessRuleValidationException("Geo Coordinates can not be null");
            this.wh_geoCoords = wh_geoCoords;
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
                WarehouseGeoCoord e = (WarehouseGeoCoord)obj;
                return this.wh_geoCoords.Equals(e.wh_geoCoords);
            }
        }

        public override int GetHashCode()
        {
            return wh_geoCoords.GetHashCode();
        }
    
        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
}