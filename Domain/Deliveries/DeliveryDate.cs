using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Deliveries
{
    public class DeliveryDate : IValueObject
    {

        public String DelDate{ get;  private set; }

        public bool Active { get;  private set; }

        private DeliveryDate()
        {
            this.Active = true;
        }

        public DeliveryDate(string dDate)
        {
            if (Verify(dDate))
            {
                this.DelDate = dDate;
            }
            else
            {
                throw new BusinessRuleValidationException("Delivery Date is invalid");
            }
        }

        private bool Verify(string deliveryDate)
        {
            return dateValidate(deliveryDate);
        }

        public static bool dateValidate(string deliveryDate)
        {

            DateTime dt;
            if (DateTime.TryParse(deliveryDate, out dt) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void MarkAsInative()
        {
            this.Active = false;
        }
    }

}