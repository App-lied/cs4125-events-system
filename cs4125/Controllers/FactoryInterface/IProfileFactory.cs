using cs4125.models;
using cs4215.models;

namespace cs4125.Controllers.FactoryInterface
{
    public interface IProfileFactory
    {
        IProfile GetProfile(ProfileType profileType);

    }
}
