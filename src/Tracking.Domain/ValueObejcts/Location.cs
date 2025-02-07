using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Tracking.ValueObejcts;

public class Location : ValueObject
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Latitude;
        yield return Longitude;
    }
}