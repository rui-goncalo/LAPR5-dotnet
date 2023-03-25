using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Orders
{
    public class OrderDescription : IValueObject
    {
        public String description{ get;  private set; }

        public bool Active { get;  private set; }

        private OrderDescription()
        {
            this.Active = true;
        }

        public OrderDescription(String description)
        {
            if (description == null)
             throw new BusinessRuleValidationException("Description can not be null");
            this.description = description;
            this.Active = true;
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
                OrderDescription e = (OrderDescription)obj;
                return this.description.Equals(e.description);
            }
        }

        public override int GetHashCode()
        {
            return description.GetHashCode();
        }
    }
}