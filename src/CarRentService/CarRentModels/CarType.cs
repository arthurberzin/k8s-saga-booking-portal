using System.ComponentModel;

namespace CarRent.Models
{
    public enum CarType
    {
        [Description("Small")]
        Small = 0,
        [Description("Medium")]
        Medium = 1,
        [Description("Estate")]
        Estate = 2,
        [Description("SUV")]
        SUV = 3,
    }
}