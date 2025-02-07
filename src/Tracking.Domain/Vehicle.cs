using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.ValueObejcts;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Tracking
{
    public class Vehicle: CreationAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
