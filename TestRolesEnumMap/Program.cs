using System;
using System.Collections.Generic;
using System.Linq;

namespace TestRolesEnumMap
{
	class Program
	{
		public enum EnumAllUsers
		{
			AdminGroup,
			CostingsTeamManagerGroup,
			CostingsTeamUserGroup,
			ReadOnlyUserGroup,
			MaterialTeamUserGroup
		}

		public enum EnumSomeUsers
		{
			AdminGroup,
			CostingsTeamManagerGroup
		}

		public enum EnumSomeOtherUsers
		{
			AdminGroup,
			MaterialTeamUserGroup
		}

		public enum EnumSomeMoreUsers
		{
			CostingsTeamUserGroup,
			ReadOnlyUserGroup,
		}

		public static class AccessPermissions
		{
			public const string AdminGroup = @"roleNameAdmin";
			public const string CostingsTeamManagerGroup = @"roleNameCostingsTeamManager";
			public const string CostingsTeamUserGroup = @"roleNameCostingsTeamUser";
			public const string ReadOnlyUserGroup = @"roleNameReadOnlyUser";
			public const string MaterialTeamUserGroup = @"roleNameMaterialteamUser";
		}

		static void Main()
		{
			//var something = ListOfRoleNames2();
			Console.WriteLine(string.Join(", ", ListOfUserGroups()));
			Console.WriteLine(string.Join(", ", ListOfRoleNames()));
			Console.WriteLine(string.Join(", ", ListOfSomeUsersRoleNames(typeof(EnumSomeUsers))));
			Console.WriteLine(string.Join(", ", ListOfSomeUsersRoleNames(typeof(EnumSomeOtherUsers))));
			Console.WriteLine(string.Join(", ", ListOfSomeUsersRoleNames(typeof(EnumSomeMoreUsers))));

			//OR CTRL+F5 ;-)
			Console.ReadLine();
		}

		private static IEnumerable<string> ListOfUserGroups()
		{
			return Enum.GetValues(typeof(EnumAllUsers))
				.Cast<EnumAllUsers>()
				.Select(r => Enum.GetName(r.GetType(), r));
		}

		private static IEnumerable<string> ListOfRoleNames()
		{
			return Enum.GetValues(typeof(EnumAllUsers))
				.Cast<EnumAllUsers>()
				.Select(ToFriendlyString).ToList();
		}

		private static IEnumerable<string> ListOfSomeUsersRoleNames(Type userGroup)
		{
			var userGroupNames = Enum.GetNames(userGroup);

			//As a ForEach
			//foreach (EnumAllUsers enumAllUser in Enum.GetValues(typeof(EnumAllUsers)))
			//{
			//	var bob = enumAllUser.ToString();
			//	if (userGroupNames.Contains(bob))
			//	{
			//		foo.Add(ToFriendlyString(enumAllUser));
			//	}

			//}

			return (from EnumAllUsers enumAllUser
					in Enum.GetValues(typeof(EnumAllUsers))
					let bob = enumAllUser.ToString()
					where userGroupNames.Contains(bob)
					select ToFriendlyString(enumAllUser)).ToList();
		}

		public static string ToFriendlyString(EnumAllUsers me)
		{
			switch (me)
			{
				case EnumAllUsers.AdminGroup:
					return AccessPermissions.AdminGroup;
				case EnumAllUsers.CostingsTeamUserGroup:
					return AccessPermissions.CostingsTeamUserGroup;
				case EnumAllUsers.CostingsTeamManagerGroup:
					return AccessPermissions.CostingsTeamManagerGroup;
				case EnumAllUsers.MaterialTeamUserGroup:
					return AccessPermissions.MaterialTeamUserGroup;
				case EnumAllUsers.ReadOnlyUserGroup:
					return AccessPermissions.ReadOnlyUserGroup;
				default:
					return string.Empty;
			}
		}
	}
}
