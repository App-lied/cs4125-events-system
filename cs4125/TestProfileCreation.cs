using cs4125.Controllers;
using cs4125.FactoryInterface;
using cs4125.Models;

namespace cs4125
{
    public class TestProfileCreation
    {
        static void Main(string[] args)
        {
            IProfileFactory profileFactory = new UserFactory();
            //Profile profile = profileFactory.GetProfile(ProfileType.User, "", "", "", );

            //profile.GetProfile();

            Console.ReadKey();
        }

    }
}
