namespace cs4125.Models
{
    /// <summary>
    /// Interface abstracting a discount campaign for an event.
    /// </summary>
    public interface IDiscount
    {
        abstract double getDiscount(User cust, Event ev);
    }

    /// <summary>
    /// Class <c>AgeDiscount</c> models a discount based on a specified age limit. If the customer's age is above the limit, the discount is applied.
    /// </summary>
    public class AgeDiscount : IDiscount {
        protected int ageLimit;
        protected double discount;
        public AgeDiscount(int ageLimit, double discount)
        {
            this.ageLimit = ageLimit;
            this.discount = discount;
        }

        public double getDiscount(User cust, Event ev)
        {
            if(cust.getAge() >= ageLimit)
            {
                return discount;
            }
            return 0.0;
        }
    }

    /// <summary>
    /// Class <c>FirstTicketsDiscount</c> models a discount based on the first N tickets for an event. If the purchased is within the limit, the discount is applied.
    /// </summary>
    public class FirstTicketsDiscount : IDiscount{
        protected int ticketLimit;
        protected double discount;

        public FirstTicketsDiscount(int ticketLimit, double discount)
        {
            this.ticketLimit = ticketLimit; 
            this.discount = discount;
        }

        public double getDiscount(User cust, Event ev)
        {
            if(ev.RemainingTickets > ev.Tickets.Count - ticketLimit) { 
                return discount; 
            }

            return 0.0;
        }
    }
}
