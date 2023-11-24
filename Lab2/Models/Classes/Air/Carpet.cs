using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Air;

internal sealed class Carpet : AirTransport
{
    internal Carpet(int distance)
    {
        Name = "Ковёр-самолёт";
        Speed = 25;
        BoostCoefficient = (int)Math.Tan(distance) * 4;
    }
    
    internal override long Move(int distance) => 
        distance / (Speed * BoostCoefficient + 12);
}