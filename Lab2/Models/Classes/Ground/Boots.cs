using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Ground;

internal sealed class Boots : GroundTransport
{
    internal Boots()
    {
        Name = "Сапоги-скороходы";
        Speed = 10;
        RideTimeBeforeRest = 50;
        RestTimeConst = 3;
    }
    
    internal override long Move(int distance)
    {
        var stopsCount = distance / Speed / RideTimeBeforeRest;
        var totalRestTime = 0;

        for (var i = 1; i <= stopsCount; i++)
        {
            totalRestTime += RestTimeConst * (int)Math.Log(i) + 1;
        }

        var rideTime = distance / Speed;
        var totalTime = rideTime + totalRestTime;

        return totalTime;
    }
}