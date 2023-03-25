using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Orders
{
    public class Order: Entity<Identifier>, IAggregateRoot
    {

        public OrderId OrderId{ get; private set; }
        public OrderDescription Description { get; private set; }

        public bool Active { get; private set; }

        public Order() {
            this.Active = true;
        }

        public Order(OrderId orderId, OrderDescription description) {
            this.Id = new Identifier(Guid.NewGuid());
            this.OrderId = orderId;
            this.Description = description;
            this.Active = true;
        }

        public void ChangeDescription(OrderDescription description)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the description to an inactive family.");
            this.Description = description;
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
                Order u = (Order)obj;
                return this.Id.Equals(u.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}