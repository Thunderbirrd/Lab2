using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Ground;

internal sealed class PumpkinCoach : GroundTransport
{
    internal PumpkinCoach()
    {
        Name = "Карета-тыква";
        Speed = 15;
        RideTimeBeforeRest = 30;
        RestTimeConst = 1;
    }
    
    internal override long Move(int distance)
    {
        var stopsCount = distance / Speed / RideTimeBeforeRest;
        var totalRestTime = 0;

        for (var i = 1; i <= stopsCount; i++)
        {
            totalRestTime += RestTimeConst * i * (int)Math.Log(i) + 1;
        }

        var rideTime = distance / Speed;
        var totalTime = rideTime + totalRestTime;

        return totalTime;
    }
}