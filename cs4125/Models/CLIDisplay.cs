using cs4125.FactoryInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Xml.Linq;

namespace cs4125.Models
{
    public class CLIDisplay
    {
        public CLIDisplay()
        {
            LoggedInUser user = LoggedInUser.GetInstance("", "", "", "", false);
            if (user != null)
            {
                LoggedInUser loggedInUser = LoggedInUser.GetInstance("", "", "");

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Checking if information is taken from factory method");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"User Logged in: {loggedInUser.Name}; Event Organiser\n\n");

                DateTime dt = new DateTime(2012, 12, 25, 10, 30, 50);
                DateTime bd = new DateTime(1990, 12, 25, 10, 30, 50);

                EventOrganiserFactory userF = new EventOrganiserFactory();
                EventOrganiser profile = (EventOrganiser)userF.GetProfile(ProfileType.EventOrganiser, loggedInUser.Email, loggedInUser.Password, loggedInUser.Name, dt);

                DateTime dt2 = new DateTime(2015, 12, 31);
                Venue venue = new Venue(0001, "3 arena", "somewhere in Dublin");

                char ch = 'A';
                for (int i = 0; i < 10; i++)
                {

                    Block b = new Block(ch, 50, 75.00);
                    ch++;
                    venue.addBlock(b);
                }

                profile.initializeEventList();

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Checking if event are being created");
                Console.WriteLine("----------------------------------------------");

                profile.createEvent("Billie Eyelash", venue, dt2, 100.00);
                profile.createEvent("Lady GoGo", venue, dt2, 75.00);

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Events avaiblable -- confirms events are created\n");
                Console.WriteLine(profile.getListEvents());
                Console.WriteLine("----------------------------------------------");



                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Create new users");
                Console.WriteLine("----------------------------------------------");
                UserFactory userA = new UserFactory();
                User userProfileA = (User)userA.GetProfile(ProfileType.User, "Wiki@gmail", "pass", "Wiki", bd);
                userProfileA.initializeLists();
                Console.WriteLine($"User Logged in: {userProfileA.Name}; User\n");

                UserFactory userB = new UserFactory();
                User userProfileB = (User)userB.GetProfile(ProfileType.User, "Sean@gmail", "pass", "Sean", bd);
                userProfileB.initializeLists();
                Console.WriteLine($"User Logged in: {userProfileB.Name}; User\n");



                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Checking can user book tickets");
                Console.WriteLine("----------------------------------------------");
                bool eligable = userProfileA.isEligable(profile.getEvent(1), 1);
                if (eligable == true)
                {
                    userProfileA.addToCart(profile.getEvent(1), 'A', 1);
                    userProfileA.payForTickets();
                }

                bool eligable2 = userProfileA.isEligable(profile.getEvent(2), 1);
                if (eligable2 == true)
                {
                    userProfileA.addToCart(profile.getEvent(2), 'A', 1);
                    userProfileA.payForTickets();
                }

                bool eligableB = userProfileB.isEligable(profile.getEvent(1), 1);
                if (eligableB == true)
                {
                    userProfileB.addToCart(profile.getEvent(1), 'A', 2);
                    userProfileB.payForTickets();
                }

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"{userProfileA.Name} bookings -- confirms booking works");
                Console.WriteLine("----------------------------------------------");

                Console.WriteLine(userProfileA.getBookings());

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"{userProfileB.Name} bookings -- confirms booking works");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(userProfileB.getBookings());

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Editing an event -- notifies user who booked (observer)");
                Console.WriteLine("----------------------------------------------");
                profile.editEvent(1, "Name", "Billie Eyelid");

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Checking if refunds work");
                Console.WriteLine("----------------------------------------------");
                userProfileA.refundTickets(userProfileA.Bookings[0], 'A');
                Console.WriteLine($"{userProfileA.Name} bookings -- confirms refund works");
                Console.WriteLine(userProfileA.getBookings());

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Checking if booking without suffiecient funds doesn't work (facade design)");
                Console.WriteLine("----------------------------------------------");
                bool eligableB2 = userProfileB.isEligable(profile.getEvent(2), 1);
                if (eligableB2 == true)
                {
                    userProfileB.addToCart(profile.getEvent(1), 'A', 7);
                    userProfileB.payForTickets();
                }



            }
        }
    }
}
