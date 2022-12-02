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
                Console.WriteLine($"User Logged in: {loggedInUser.Name}; Event Organiser\n\n");

                DateTime dt = new DateTime(2012, 12, 25, 10, 30, 50);

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
                profile.createEvent("Billie Eyelash", venue, dt2, 100.00);

                profile.createEvent("Lady GoGo", venue, dt2, 75.00);


                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Events available\n");
                Console.WriteLine(profile.getListEvents());

                Console.WriteLine("----------------------------------------------");


                UserFactory userA = new UserFactory();
                User userProfileA = (User)userA.GetProfile(ProfileType.User, "Wiki@gmail", "pass", "Wiki", dt);
                Console.WriteLine($"User Logged in: {userProfileA.Name}; User\n");

                UserFactory userB = new UserFactory();
                User userProfileB = (User)userB.GetProfile(ProfileType.User, "Sean@gmail", "pass", "Sean", dt);
                Console.WriteLine($"User Logged in: {userProfileB.Name}; User\n");


                userProfileA.initializeLists();
                userProfileA.addToCart(profile.getEvent(1), 'A', 1);

                userProfileB.initializeLists();
                userProfileB.addToCart(profile.getEvent(1), 'A', 2);

                userProfileA.payForTickets();
                userProfileB.payForTickets();
                userProfileA.makeBooking(profile.getEvent(1), 'A', 1);

                userProfileB.initializeLists();
                userProfileB.makeBooking(profile.getEvent(1), 'A', 2);


                Console.WriteLine("----------------------------------------------");

                Console.WriteLine(userProfileA.getBookings());
                Console.WriteLine(userProfileB.getBookings());

                Console.WriteLine("----------------------------------------------");
                profile.editEvent(1, "Name", "Billie Eyelid");

                userProfileA.refundTickets(userProfileA.Bookings[0], 'A');

                Console.WriteLine(userProfileA.getBookings());






            }
        }
    }
}
