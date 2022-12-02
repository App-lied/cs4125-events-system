namespace cs4125.Models
{
    public class Payment
    {

        public Payment() { }

        /// <summary>
        /// Adds points to a user.
        /// </summary>
        /// <param name="user">The user preforming the transaction.</param>
        /// <param name="points">Amount being added to the account.</param>
        public double topUpPoints(Profile user, int points)
        {
            return user.Points += points;
        }

        /// <summary>
        /// Returns whether the transaction was successful and the amount paid.
        /// </summary>
        /// <param name="user">The user preforming the transaction.</param>
        /// <param name="inCart">The number of tickets.</param>
        /// <param name="ev">The event.</param>
        public Tuple<bool, double> makePayemnt(Profile user, List<Ticket> inCart, Event ev)
        {
            double total = 0;


            foreach (Ticket t in inCart)
            {
                //PriceCalculator newPrice = new PriceCalculator();
                //total += newPrice.calculate(user, ev, t);
                total += t.BasePrice;
            }
            if (total <= user.Points)
            {
                Console.WriteLine($"Payment Successful");
                return Tuple.Create(true, total);
            }
            else
            {
                Console.WriteLine($"Insufficient Funds");
                return Tuple.Create(false, 0.0);
            }

            
        }

        /// <summary>
        /// Adds points back to a user.
        /// </summary>
        /// <param name="user">The user preforming the transaction.</param>
        /// <param name="paid">Amount being added to the account.</param>
        public void refundPayemnt(Profile user, double paid)
        {

            user.Points += (int)paid;
            Console.WriteLine($"Hello {user.Name}, you have been refunded {paid} due to the cancellation of the event");

        }

        /// <summary>
        /// Refunds all users that purchased a ticket for an event.
        /// </summary>
        /// <param name="bookings">All users bookings.</param>
        public void RefundAll(List<Booking> bookings)
        {
            foreach (Booking b in bookings)
            {
                b.User.Points += (int)b.Paid;
                Console.WriteLine($"Hello {b.User.Name}, you have been refunded {b.Paid} due to the cancellation of the event");
            }
        }

    }

}