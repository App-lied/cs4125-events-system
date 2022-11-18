namespace cs4125.Models
{
    public interface IDiscount
    {
        abstract double getDiscount(User cust, Event ev);
    }
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
            if(cust.getAge() > ageLimit)
            {
                return discount;
            }
            return 0.0;
        }
    }

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
            return 0.0;
        }
    }
}
