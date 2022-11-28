using System;
using cs4125.Models;

namespace cs4125.FactoryInterface
{
    public class EventOrganiserFactory : IProfileFactory
    {
        public Profile GetProfile(ProfileType profileType, string email, string password, string username, DateTime date)
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