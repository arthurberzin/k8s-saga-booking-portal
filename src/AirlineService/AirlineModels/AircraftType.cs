using System.ComponentModel;

namespace Airline.Models
{
    public enum AircraftType
    {
        [Description("Boeing 737")]
        Boeing737,
        [Description("Airbus A320")]
        AirbusA320,
        [Description("Embraer E190")]
        EmbraerE190,
        [Description("Bombardier CRJ900")]
        BombardierCRJ900,
        [Description("Boeing 747")]
        Boeing747,
        [Description("Airbus A380")]
        AirbusA380,

        // add more aircraft types as needed
    }
}