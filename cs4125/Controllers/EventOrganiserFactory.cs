using System;
using cs4125.Controllers.FactoryInterface;
using cs4125.models;
using cs4125;
using cs4215.models;

namespace cs4125.Controllers
{
    public class EventOrganiserFactory : IProfileFactory
    {
        public IProfile GetProfile(ProfileType profileType)
        {
            switch (profileType)
            {
                case ProfileType.EventOrganiser:
                    return new EventOrganiser();
                default:
                    throw new Exception("Invalid profile type");
            }

        }
    }
}