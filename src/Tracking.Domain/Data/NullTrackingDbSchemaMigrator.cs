using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Tracking.Data;

/* This is used if database provider does't define
 * ITrackingDbSchemaMigrator implementation.
 */
public class NullTrackingDbSchemaMigrator : ITrackingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
