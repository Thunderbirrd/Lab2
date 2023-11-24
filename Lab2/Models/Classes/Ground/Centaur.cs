using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Ground;

internal sealed class Centaur : GroundTransport
{
    internal Centaur()
    {
        Name = "Кентавр";
        Speed = 20;
        RideTimeBeforeRest = 25;
        RestTimeConst = 8;
    }
    
    internal override long Move(int distance)
    {
        var stopsCount = distance / Speed / RideTimeBeforeRest;
        var totalRestTime = 0;

        for (var i = 1; i <= stopsCount; i++)
        {
            totalRestTime += RestTimeConst * i * (int)Math.Abs(Math.Tan(i) * 2);
        }

        var rideTime = distance / Speed;
        var totalTime = rideTime + totalRestTime;

        return totalTime;
    }
}