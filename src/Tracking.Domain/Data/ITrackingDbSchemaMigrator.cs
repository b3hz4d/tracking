using System.Threading.Tasks;

namespace Tracking.Data;

public interface ITrackingDbSchemaMigrator
{
    Task MigrateAsync();
}
