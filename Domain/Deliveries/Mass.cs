using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Deliveries
{
    public class Mass : IValueObject
    {

        public string Mass1{ get;  private set; }
        public bool Active { get;  private set; }

        private Mass()
        {
            this.Active = true;
        }


        public Mass(string mass1)
        {
            if (Verify(mass1))
            {
                this.Mass1 = mass1;
            }
            else
            {
                throw new BusinessRuleValidationException("Mass can not be higher than 4300kg.");
            }
        }

        private bool Verify(string mass1)
        {
            return massValidate(mass1);
        }

        public static bool massValidate(string mass1)
        {
            if (mass1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                Mass e = (Mass)obj;
                return this.Mass1.Equals(e.Mass1);
            }
        }

        public override int GetHashCode()
        {
            return Mass1.GetHashCode();
        }
        public void MarkAsInative()
        {
            this.Active = false;
        }
    }

}