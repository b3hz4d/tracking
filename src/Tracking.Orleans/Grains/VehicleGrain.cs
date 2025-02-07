using System;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;
using Microsoft.Extensions.Logging;
using Tracking.ValueObjects;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tracking.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;

namespace Tracking.Grains
{
    public class VehicleGrain : Grain, IVehicleGrain
    {
        private readonly IRepository<Vehicle, Guid> _vehicleRepository;
        private readonly ILogger<VehicleGrain> _logger;
        private readonly TrackingDbContext _dbContext;
        private Vehicle _vehicle;
        private Location _currentLocation;
        private bool _hasLocationChanged;
        private readonly TimeSpan _updateInterval = TimeSpan.FromSeconds(5);
        private IDisposable _timer;

        public VehicleGrain(
            IRepository<Vehicle, Guid> vehicleRepository,
            ILogger<VehicleGrain> logger,
            TrackingDbContext dbContext)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
            _dbContext = dbContext;
        }

        public override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var vehicleId = this.GetPrimaryKey();
            _vehicle = await _vehicleRepository.FindAsync(vehicleId, true, cancellationToken: cancellationToken);

            if (_vehicle != null)
            {
                _currentLocation = _vehicle.Location;
            }

            // Start periodic updates
            _timer = RegisterTimer(
                SaveLocationToDatabase,
                null,
                _updateInterval,
                _updateInterval);

            await base.OnActivateAsync(cancellationToken);
        }

        public override async Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            
            // Save any pending changes before deactivation
            if (_hasLocationChanged)
            {
                await SaveLocationToDatabase(null);
            }

            await base.OnDeactivateAsync(reason, cancellationToken);
        }

        private async Task SaveLocationToDatabase(object _)
        {
            if (!_hasLocationChanged || _vehicle == null) return;

            try
            {
                // Get a fresh copy and update it
                var freshVehicle = await _dbContext.Vehicles
                    .Include(e => e.Location)
                    .FirstOrDefaultAsync(x => x.Id == _vehicle.Id);

                if (freshVehicle != null)
                {
                    freshVehicle.Location = _currentLocation;
                    await _dbContext.SaveChangesAsync();
                    
                    // Update our cached copy
                    _vehicle = freshVehicle;
                    _hasLocationChanged = false;
                    _logger.LogInformation("Updated location for vehicle {VehicleId} to {Location}", _vehicle.Id, _currentLocation);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save vehicle location to database");
            }
        }

        public Task UpdateLocationAsync(Location location)
        {
            if (_vehicle == null)
            {
                throw new Exception($"Vehicle with ID {this.GetPrimaryKey()} not found");
            }

            _currentLocation = location;
            _hasLocationChanged = true;
            _logger.LogInformation("Location update received for vehicle {VehicleId}: {Location}", _vehicle.Id, location);
            return Task.CompletedTask;
        }

        public Task<Location> GetLocationAsync()
        {
            if (_vehicle == null)
            {
                throw new Exception($"Vehicle with ID {this.GetPrimaryKey()} not found");
            }

            return Task.FromResult(_currentLocation ?? _vehicle.Location);
        }
    }
} 