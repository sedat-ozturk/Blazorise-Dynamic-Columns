namespace Listform_Manager.Permissions
{
    public class Listform_ManagerPermissions
    {
        public const string GroupName = "Lists";

        public static class Lists
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
