using System;
using cs4125.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace cs4125.FactoryInterface
{
    public class UserFactory : IProfileFactory
    {
        public Profile GetProfile(ProfileType profileType, string email, string password, string username)
        {
            switch (profileType)
            {
                case ProfileType.User:
                    User U = new User();
                    U.Email = email;
                    U.Name = username;
                    return U;
                case ProfileType.PremiumUser:
                    PremiumUser Pu = new PremiumUser();
                    Pu.Email = email;
                    Pu.Name = username;
                    return Pu;
                default:
                    throw new Exception("Invalid profile type");
            }

        }
    }
}
