using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Listform_Manager.Data;

public class Listform_ManagerEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public Listform_ManagerEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the Listform_ManagerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Listform_ManagerDbContext>()
            .Database
            .MigrateAsync();
    }
}
