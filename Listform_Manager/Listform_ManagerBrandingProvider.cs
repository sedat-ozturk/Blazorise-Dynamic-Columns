using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Listform_Manager;

[Dependency(ReplaceServices = true)]
public class Listform_ManagerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Listform_Manager";
}
