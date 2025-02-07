using Orleans;
using System;
using System.Collections.Generic;

namespace Tracking.ValueObjects;

[GenerateSerializer]
public class Location : IEquatable<Location>
{
    [Id(0)]
    public double Latitude { get; set; }
    
    [Id(1)]
    public double Longitude { get; set; }

    public Location() { } // Required for Orleans serialization

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Location)obj);
    }

    public bool Equals(Location other)
    {
        if (other is null) return false;
        return Latitude.Equals(other.Latitude) && 
               Longitude.Equals(other.Longitude);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longitude);
    }

    public static bool operator ==(Location left, Location right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Location left, Location right)
    {
        return !(left == right);
    }
}