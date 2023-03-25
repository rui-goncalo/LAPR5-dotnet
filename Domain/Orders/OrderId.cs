using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Orders
{
    public class OrderId : IValueObject
    {
        public string OrderIdentifier { get; set; }

        public OrderId()
        {
            this.OrderIdentifier = "";
        }

        public OrderId(string text)
        {
            this.OrderIdentifier = ValidateWarehouseIdentifier(text);
        }

        private string ValidateWarehouseIdentifier(string orderIdentifier)
        {
            if (orderIdentifier == null)
            {
                throw new NullReferenceException("The orderId can't be null.");
            }
            else
            {
                if (orderIdentifier.Length > 5)
                {
                    throw new BusinessRuleValidationException("The orderId can't have more than 5 characters.");
                }
            }

            return orderIdentifier;
        }

        public override string ToString()
        {
            return OrderIdentifier;
        }
    }
}