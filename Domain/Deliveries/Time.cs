using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Deliveries
{
    public class Time : IValueObject
    {

        public string Time1{ get;  private set; }

       public bool Active { get;  private set; }

        private Time()
        {
            this.Active = true;
        }

        public Time(string time)
        {
            if (Verify(time))
            {
                this.Time1 = time;
            }
            else
            {
                throw new BusinessRuleValidationException("Time has to be higher than 0 minutes.");
            }
        }

        private bool Verify(string time)
        {
            return timeValidate(time);
        }

        public static bool timeValidate(string time)
        {

            if (time != null)
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
                Time e = (Time)obj;
                return this.Time1.Equals(e.Time1);
            }
        }

        public override int GetHashCode()
        {
            return Time1.GetHashCode();
        }

        public void MarkAsInative()
        {
            this.Active = false;
        }
    }

}