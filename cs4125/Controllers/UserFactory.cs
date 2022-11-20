using System;
using cs4125.Controllers.FactoryInterface;
using cs4125.models;
using cs4125.Models;
using cs4215.models;


namespace cs4125.Controllers
{
	public class UserFactory : IProfileFactory
	{
		public IProfile GetProfile(ProfileType profileType)
		{
			switch (profileType)
			{
				case ProfileType.User:
					return new User();
				case ProfileType.PremiumUser:
					return new PremiumUser();
				default:
					throw new Exception("Invalid profile type");
			}

		}
	}
}
