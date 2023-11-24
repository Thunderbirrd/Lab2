using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Air;

internal sealed class Stupa : AirTransport
{
    public Stupa(int distance)
    {
        Name = "Ступа Бабы Яги";
        Speed = 10;
        BoostCoefficient = (int)Math.Log(distance);
    }
    
    internal override long Move(int distance) => 
        distance / (Speed * BoostCoefficient / 10);
}