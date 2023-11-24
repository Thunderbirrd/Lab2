using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Air;

internal sealed class Ship : AirTransport
{
    
    internal Ship(int distance)
    {
        Name = "Летучий корабль";
        Speed = 20;
        BoostCoefficient = (int)Math.Abs(Math.Sin(distance)) * 5;
    }
    
    internal override long Move(int distance) =>
        distance / (int)(Speed * BoostCoefficient + 6);
}