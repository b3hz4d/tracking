using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.ValueObjects;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Tracking
{
    public class Person: CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location Location { get; set; }
    }
}
