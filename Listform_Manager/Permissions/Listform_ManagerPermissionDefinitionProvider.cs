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

            var productPermission = listsGroup.AddPermission(Listform_ManagerPermissions.Product.Products, L("Permission:Lists:Products"));
            productPermission.AddChild(Listform_ManagerPermissions.Product.Create, L("Permission:Lists:Products.Create"));
            productPermission.AddChild(Listform_ManagerPermissions.Product.Edit, L("Permission:Lists:Products.Edit"));
            productPermission.AddChild(Listform_ManagerPermissions.Product.Delete, L("Permission:Lists:Products.Delete"));

            var formlistPermission = listsGroup.AddPermission(Listform_ManagerPermissions.Formlist.Formlists, L("Permission:Lists:Formlists"));
            formlistPermission.AddChild(Listform_ManagerPermissions.Formlist.Create, L("Permission:Lists:Formlists.Create"));
            formlistPermission.AddChild(Listform_ManagerPermissions.Formlist.Edit, L("Permission:Lists:Formlists.Edit"));
            formlistPermission.AddChild(Listform_ManagerPermissions.Formlist.Delete, L("Permission:Lists:Formlists.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Listform_ManagerResource>(name);
        }
    }
}
