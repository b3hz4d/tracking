using System.Threading.Tasks;
using Orleans;
using Tracking.ValueObjects;

namespace Tracking.Grains
{
    public interface IVehicleGrain : IGrainWithGuidKey
    {
        Task UpdateLocationAsync(Location location);
        Task<Location> GetLocationAsync();
    }
} 