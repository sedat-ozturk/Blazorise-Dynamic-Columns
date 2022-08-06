using Listform_Manager.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Listform_Manager;

public abstract class Listform_ManagerComponentBase : AbpComponentBase
{
    protected Listform_ManagerComponentBase()
    {
        LocalizationResource = typeof(Listform_ManagerResource);
    }
}
