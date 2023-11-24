using System;
using Lab2.Models.Abstracts;

namespace Lab2.Models.Classes.Air;

internal sealed class Broom : AirTransport
{
    
    internal Broom(int distance)
    {
        Name = "Метла";
        Speed = 15;
        BoostCoefficient = (int)Math.Abs(Math.Sin(distance)) * 5;
    }
    internal override long Move(int distance) =>
        distance / (Speed * BoostCoefficient + 4);
}