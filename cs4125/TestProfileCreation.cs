using cs4125.Controllers;
using cs4125.Controllers.FactoryInterface;
using cs4125.models;
using cs4215.models;

namespace cs4125
{
    public class TestProfileCreation
    {
        static void Main(string[] args)
        {
            IProfileFactory profileFactory = new UserFactory();
            IProfile profile = profileFactory.GetProfile(ProfileType.User);

            profile.GetProfile();

            Console.ReadKey();
        }

    }
}
