using Listform_Manager.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Listform_Manager.Permissions
{
    public class Listform_ManagerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var listsGroup = context.AddGroup(Listform_ManagerPermissions.GroupName, L("Permission:Lists"));

            var booksPermission = listsGroup.AddPermission(Listform_ManagerPermissions.Lists.Default, L("Permission:Lists:Products"));
            booksPermission.AddChild(Listform_ManagerPermissions.Lists.Create, L("Permission:Lists:Products.Create"));
            booksPermission.AddChild(Listform_ManagerPermissions.Lists.Edit, L("Permission:Lists:Products.Edit"));
            booksPermission.AddChild(Listform_ManagerPermissions.Lists.Delete, L("Permission:Lists:Products.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Listform_ManagerResource>(name);
        }
    }
}
