namespace cs4125.Models
{
    public class PriceCalculator
    {
        public PriceCalculator() { }
        public double calculate(User cust, Event ev, Ticket t)
        {
            double result = t.BasePrice;
            result *= applyPremium(t);
            result *= (1 - getDiscounts(cust, ev));

            return result;
            
        }

        private double getDiscounts(User cust, Event ev)
        {
            double result = 0;
            foreach (var d in ev.Discounts)
            {
                result += d.getDiscount(cust, ev);
            }
            return result;
        }

        private double applyPremium(Ticket t)
        {
            return t.Seat.Block.Premium;
        }
    }
}
