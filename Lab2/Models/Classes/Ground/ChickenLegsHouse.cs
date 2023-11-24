using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Ground;

internal sealed class ChickenLegsHouse : GroundTransport
{
    internal ChickenLegsHouse()
    {
        Name = "Избушка на курьих ножках";
        Speed = 20;
        RideTimeBeforeRest = 15;
        RestTimeConst = 4;
    }
    
    internal override long Move(int distance)
    {
        var stopsCount = distance / Speed / RideTimeBeforeRest;
        var totalRestTime = 0;

        for (var i = 1; i <= stopsCount; i++)
        {
            totalRestTime += RestTimeConst * (int)Math.Sqrt(i * 5 + 3);
        }

        var rideTime = distance / Speed;
        var totalTime = rideTime + totalRestTime;

        return totalTime;
    }
}