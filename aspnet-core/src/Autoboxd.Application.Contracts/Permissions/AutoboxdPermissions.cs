namespace Autoboxd.Permissions
{
    public static class AutoboxdPermissions
    {
        public const string GroupName = "Autoboxd";

        public static class Items
        {
            public const string Default = GroupName + ".Items";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}