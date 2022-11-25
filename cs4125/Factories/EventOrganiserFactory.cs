using System;
using cs4125.models;
using cs4215.models;

namespace cs4125.FactoryInterface
{
    public class EventOrganiserFactory : IProfileFactory
    {
        public IProfile GetProfile(ProfileType profileType, string email, string password, string username)
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