namespace Listform_Manager.Permissions
{
    public class Listform_ManagerPermissions
    {
        public const string GroupName = "Lists";

        public static class Product
        {
            public const string Products = GroupName + ".Products";
            public const string Create = Products + ".Create";
            public const string Edit = Products + ".Edit";
            public const string Delete = Products + ".Delete";
        }

        public static class Formlist
        {
            public const string Formlists = GroupName + ".Formlists";
            public const string Create = Formlists + ".Create";
            public const string Edit = Formlists + ".Edit";
            public const string Delete = Formlists + ".Delete";
        }

        public static class Book
        {
            public const string Books = GroupName + ".Books";
            public const string Create = Books + ".Create";
            public const string Edit = Books + ".Edit";
            public const string Delete = Books + ".Delete";
        }
    }
}