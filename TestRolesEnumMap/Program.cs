using System;
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
			var something = Enum.GetValues(typeof(EnumAllUsers))
				.Cast<EnumAllUsers>()
				.Select(r => Enum.GetName(r.GetType(), r));

			Console.WriteLine(string.Join(", ", something));

			//OR CTRL+F5 ;-)
			Console.ReadLine();
		}
	}
}
