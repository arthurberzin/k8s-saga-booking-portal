using System.ComponentModel;

namespace CarRent.Models
{
    public enum TransmissionType
    {
        [Description("Manual")]
        Manual = 0,
        [Description("Automatic")]
        Automatic =1
    }
}