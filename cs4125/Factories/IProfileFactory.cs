using cs4125.Models;

namespace cs4125.FactoryInterface
{
    public interface IProfileFactory
    {
        Profile GetProfile(ProfileType profileType, string email, string password, string username, DateTime date);

    }
}
