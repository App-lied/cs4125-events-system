using System;
using cs4125.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace cs4125.FactoryInterface
{
    public class UserFactory : IProfileFactory
    {
        public Profile GetProfile(ProfileType profileType, string email, string password, string username, DateTime date)
        {
            switch (profileType)
            {
                case ProfileType.User:
                    User U = new User();
                    U.Email = email;
                    U.Name = username;
                    U.Password = password;
                    U.DateOfBirth= date;
                    return U;
                case ProfileType.PremiumUser:
                    PremiumUser Pu = new PremiumUser();
                    Pu.Email = email;
                    Pu.Name = username;
                    Pu.Password = password;
                    Pu.DateOfBirth= date;
                    return Pu;
                default:
                    throw new Exception("Invalid profile type");
            }

        }
    }
}
