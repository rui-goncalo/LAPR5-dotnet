using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseId : IValueObject
    {
        public string WarehouseIdentifier { get; set; }

        public WarehouseId()
        {
            this.WarehouseIdentifier = "";
        }

        public WarehouseId(string text)
        {
            this.WarehouseIdentifier = ValidateWarehouseIdentifier(text);
        }

        private string ValidateWarehouseIdentifier(string warehouseIdentifier)
        {
            if (warehouseIdentifier == null)
            {
                throw new NullReferenceException("The warehouseId can't be null.");
            }
            else
            {
                if (warehouseIdentifier.Length > 5)
                {
                    throw new BusinessRuleValidationException("The warehouseId can't have more than 5 characters.");
                }
            }

            return warehouseIdentifier;
        }

        public override string ToString()
        {
            return WarehouseIdentifier;
        }
    }
}