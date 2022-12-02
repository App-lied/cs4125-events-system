namespace cs4125.Models
{
    public class Payment
    {

        public Payment() { }

        public double topUpPoints(Profile user, int points)
        {
            return user.Points += points;
        }

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

            Console.WriteLine($"Error Occured");
            return Tuple.Create(false, 0.0);
        }

        public void refundPayemnt(Profile user, double paid)
        {

            user.Points += (int)paid;
            Console.WriteLine($"Hello {user.Name}, you have been refunded {paid} due to the cancellation of the event");

        }



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