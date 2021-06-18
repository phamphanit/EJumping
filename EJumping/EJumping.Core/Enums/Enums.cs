using System;
using System.ComponentModel;

namespace EJumping.Core.Enums
{
    public enum ShowLogLevel
    {
        Default = 0,
        Production = 1,
        Stacktrace = 2
    }

    [Flags]
    public enum RoleType
    {
        General = 1,
        Country = 2,
        Client = 4
    }

    public enum PermissionType
    {
        Create = 0,
        Update = 1,
        Read = 2,
        Delete = 3,
        Approve = 4
    }

    public enum EntityScope
    {
        General = 0,
        Country = 1,
        Client = 2
    }

    public enum InitialType
    {
        Custom = 0,
        Standard = 1
    }

    public enum RoleLevel
    {
        [Description("Level 1")]
        Level1 = 0,

        [Description("Level 2")]
        Level2 = 1,

        [Description("Level 3")]
        Level3 = 2,

        [Description("Level 4")]
        Level4 = 3
    }

}
