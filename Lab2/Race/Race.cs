using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Models.Abstracts;

namespace Lab2.Race;

public class Race
{
    private readonly List<Transport> _participants;
    private readonly int _distance;
    private string _winner;

    internal Race(IEnumerable<Transport> participants, int distance)
    {
        _distance = distance;
        _participants = new List<Transport>(participants);
    }

    internal void StartRace()
    {
        Console.WriteLine("Время участников:");
        var raceResult = _participants.OrderBy(participant =>
        {
            var timeResult = participant.Move(_distance);
            var timeSpan = TimeSpan.FromSeconds(timeResult);
            Console.WriteLine($"{participant.Name}: {timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}");
            return timeResult;
        });

        _winner = raceResult.First().Name;
        Console.WriteLine();
        Console.WriteLine($"Победитель: {_winner}!");
    }
}