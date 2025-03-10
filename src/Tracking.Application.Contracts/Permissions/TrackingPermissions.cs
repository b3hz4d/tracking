﻿namespace Tracking.Permissions;

public static class TrackingPermissions
{
    public const string GroupName = "Tracking";

    public static class Vehicle
    {
        public const string Default = GroupName + ".Vehicle";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Read = Default + ".Read";
    }

    public static class Person
    {
        public const string Default = GroupName + ".Person";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Read = Default + ".Read";
    }

    public static class Product
    {
        public const string Default = GroupName + ".Product";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Read = Default + ".Read";
    }

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
