using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryId : IValueObject 
    {
        
        public string DeliveryIdentifier { get; set; }

        public DeliveryId()
        {
            this.DeliveryIdentifier = "";
        }

        public DeliveryId(string text)
        {
            this.DeliveryIdentifier = ValidateDeliveryId(text);
        }

        private string ValidateDeliveryId(string deliveryIdentifier)
        {
            if (deliveryIdentifier == null)
            {
                throw new NullReferenceException("The deliveryId can't be null.");
            }
            else
            {
                if (deliveryIdentifier.Length > 5)
                {
                    throw new BusinessRuleValidationException("The deliveryId can't have more than 5 characters.");
                }
            }

            return deliveryIdentifier;
        }

        public override string ToString()
        {
            return DeliveryIdentifier;
        }
    }
}