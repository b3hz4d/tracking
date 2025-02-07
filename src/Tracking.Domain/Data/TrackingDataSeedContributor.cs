using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Microsoft.Extensions.Logging;
using System.Linq;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tracking.Data;

public class TrackingDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IPermissionManager _permissionManager;
    private readonly IIdentityRoleRepository _roleRepository;
    private readonly IIdentityUserRepository _userRepository;
    private readonly ILogger<TrackingDataSeedContributor> _logger;
    private readonly IPermissionGrantRepository _permissionGrantRepository;

    public TrackingDataSeedContributor(
        IPermissionManager permissionManager,
        IIdentityRoleRepository roleRepository,
        IIdentityUserRepository userRepository,
        ILogger<TrackingDataSeedContributor> logger,
        IPermissionGrantRepository permissionGrantRepository)
    {
        _permissionManager = permissionManager;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _logger = logger;
        _permissionGrantRepository = permissionGrantRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Log existing permissions
        var existingGrants = await _permissionGrantRepository.GetListAsync();
        _logger.LogInformation($"Current permission grants count: {existingGrants.Count}");
        foreach (var grant in existingGrants)
        {
            _logger.LogInformation($"Permission: {grant.Name}, Provider: {grant.ProviderName}, Key: {grant.ProviderKey}");
        }

        // Grant permissions to admin role
        var adminRole = await _roleRepository.FindByNormalizedNameAsync("ADMIN");
        if (adminRole != null)
        {
            _logger.LogInformation($"Found admin role: {adminRole.Name}");

            // Grant Vehicle permissions for admin role
            await _permissionManager.SetAsync("Tracking.Vehicle", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Create", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Update", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Delete", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Read", "R", adminRole.Name, true);

            // Grant Person permissions for admin role
            await _permissionManager.SetAsync("Tracking.Person", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Person.Create", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Person.Update", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Person.Delete", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Person.Read", "R", adminRole.Name, true);

            // Grant Product permissions for admin role
            await _permissionManager.SetAsync("Tracking.Product", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Product.Create", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Product.Update", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Product.Delete", "R", adminRole.Name, true);
            await _permissionManager.SetAsync("Tracking.Product.Read", "R", adminRole.Name, true);
        }
        else
        {
            _logger.LogWarning("Admin role not found!");
        }

        // Grant permissions to all users
        var users = await _userRepository.GetListAsync();
        _logger.LogInformation($"Found {users.Count} users to grant permissions to");
        
        foreach (var user in users)
        {
            _logger.LogInformation($"Granting permissions to user: {user.UserName} ({user.Id})");

            // Grant Vehicle permissions for user
            await _permissionManager.SetAsync("Tracking.Vehicle", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Create", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Update", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Delete", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Vehicle.Read", "U", user.Id.ToString(), true);

            // Grant Person permissions for user
            await _permissionManager.SetAsync("Tracking.Person", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Person.Create", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Person.Update", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Person.Delete", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Person.Read", "U", user.Id.ToString(), true);

            // Grant Product permissions for user
            await _permissionManager.SetAsync("Tracking.Product", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Product.Create", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Product.Update", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Product.Delete", "U", user.Id.ToString(), true);
            await _permissionManager.SetAsync("Tracking.Product.Read", "U", user.Id.ToString(), true);
        }

        // Log final permissions
        var finalGrants = await _permissionGrantRepository.GetListAsync();
        _logger.LogInformation($"Final permission grants count: {finalGrants.Count}");
        foreach (var grant in finalGrants)
        {
            _logger.LogInformation($"Permission: {grant.Name}, Provider: {grant.ProviderName}, Key: {grant.ProviderKey}");
        }
    }
} 