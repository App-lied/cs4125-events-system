namespace cs4125.Models
{
    public class PriceCalculator
    {
        /// <summary>
        /// Gets the price of an event.
        /// </summary>
        public PriceCalculator() { }
        public double calculate(User cust, Event ev, Ticket t)
        {
            double result = t.BasePrice;
            result *= applyPremium(t);
            result *= (1 - getDiscounts(cust, ev));

            return result;
            
        }

        /// <summary>
        /// Gets the discount of the event.
        /// </summary>
        /// <param name="cust">The customer.</param>
        /// <param name="ev">The event.</param>
        private double getDiscounts(User cust, Event ev)
        {
            double result = 0;
            foreach (var d in ev.Discounts)
            {
                result += d.getDiscount(cust, ev);
            }
            return result;
        }

        /// <summary>
        /// Returns the premium.
        /// </summary>
        /// <param name="t">The ticket.</param>
        private double applyPremium(Ticket t)
        {
            return t.Seat.Block.Premium;
        }
    }
}
