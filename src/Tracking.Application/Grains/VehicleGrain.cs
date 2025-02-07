using System;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Tracking.ValueObejcts;
using Volo.Abp.Domain.Repositories;

namespace Tracking.Grains
{
    public class VehicleGrain : Grain, IVehicleGrain
    {
        private readonly IRepository<Vehicle, Guid> _vehicleRepository;
        private Vehicle _vehicle;

        public VehicleGrain(IRepository<Vehicle, Guid> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var vehicleId = this.GetPrimaryKey();
            _vehicle = await _vehicleRepository.FindAsync(vehicleId);
            await base.OnActivateAsync(cancellationToken);
        }

        public async Task UpdateLocationAsync(Location location)
        {
            if (_vehicle == null)
            {
                throw new Exception($"Vehicle with ID {this.GetPrimaryKey()} not found");
            }

            _vehicle.Location = location;
            await _vehicleRepository.UpdateAsync(_vehicle);
        }

        public Task<Location> GetLocationAsync()
        {
            if (_vehicle == null)
            {
                throw new Exception($"Vehicle with ID {this.GetPrimaryKey()} not found");
            }

            return Task.FromResult(_vehicle.Location);
        }
    }
} 