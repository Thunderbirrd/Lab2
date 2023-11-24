using System.Collections.Generic;
using Lab2.Models.Abstracts;
using Lab2.Models.Classes.Air;
using Lab2.Models.Classes.Ground;

namespace Lab2.Models;

internal static class Initializer
{
    internal static List<AirTransport> InitAirTransport(int distance) => new()
    {
        new Stupa(distance),
        new Ship(distance),
        new Carpet(distance),
        new Broom(distance),
    };
    internal static List<GroundTransport> InitGroundTransport() => new()
    {
        new Boots(),
        new Centaur(),
        new PumpkinCoach(),
        new ChickenLegsHouse(),
        
    };
}