using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Models;
using Lab2.Models.Abstracts;
using Lab2.Race;

namespace Lab2;

public static class RaceSimulator
{
    internal static void Run()
    {
        Console.WriteLine("Приветсвуем вас в симуляторе гонок!");
        var raceType = GetRaceType();
        var distance = GetDistance();

        var participant = raceType switch
        {
            1 => PrepareToStartGroundRace(),
            2 => PrepareStartAirRace(distance),
            3 => PrepareStartMixedRace(distance),
            _ => throw new ArgumentException("Неправильный тип гонки!")
        };

        var race = new Race.Race(participant, distance);
        race.StartRace();
        race.HandleResult();
    }
    
    private static int GetRaceType()
    {
        int raceType;
        bool isValid;

        do
        {
            Console.WriteLine("Выберите тип гонки:\n1) Наземная\n2) Воздушная\n3) Смешанная");
            isValid = int.TryParse(Console.ReadLine(), out raceType);
            if (Enum.IsDefined(typeof(RaceTypes), raceType) && isValid) continue;
            isValid = false;
            Console.WriteLine("Неправильный тип гонки!");
        } while (!isValid);

        return raceType;
    }

    private static int GetDistance()
    {
        int distance;
        bool isValid;

        do
        {
            Console.WriteLine("Установите дистанцию гонки:");
            isValid = int.TryParse(Console.ReadLine(), out distance);
            if (!isValid)
            {
                Console.WriteLine("Неправильная дистанция!");
            }
        } while (!isValid);
        return distance;
    }
    
    private static IEnumerable<Transport> PrepareToStartGroundRace() => 
        PrepareToStartRace(Initializer.InitGroundTransport().Cast<Transport>());
    
    private static IEnumerable<Transport> PrepareStartAirRace(int distance) =>
        PrepareToStartRace(Initializer.InitAirTransport(distance).Cast<Transport>());
    
    private static IEnumerable<Transport> PrepareStartMixedRace(int distance) =>
        PrepareToStartRace(
            Initializer.InitGroundTransport().Cast<Transport>()
                .Concat(Initializer.InitAirTransport(distance).Cast<Transport>())
        );

    private static IEnumerable<T> PrepareToStartRace<T>(IEnumerable<T> allParticipants) where T : Transport
    {
        var participants = new List<T>();
        var availableTransport = allParticipants.ToList();

        while (true)
        {
            availableTransport = availableTransport
                .Except(participants)
                .ToList();

            bool isValid;
            do
            {
                DisplayAvailableTransport((IList<Transport>)availableTransport);

                Console.WriteLine("Введите соответсвующий номер, чтобы добавить участника в гонку:");
                var input = Console.ReadLine();
                if (input?.ToLower() is "старт")
                {
                    if (participants.Count is not 0)
                    {
                        return participants;
                    }
                    Console.WriteLine("В гонку не добавлены участники!");
                    isValid = false;
                    continue;
                }

                isValid = int.TryParse(input, out var index);
                if (isValid && index <= availableTransport.Count)
                {
                    participants.Add(availableTransport[index - 1]);
                    availableTransport.RemoveAt(index - 1);
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("Неправильный номер участника!");
                }

                if (availableTransport.Count is 0)
                {
                    return participants;
                }
            } while (!isValid);
        }
    }
    
    private static void DisplayAvailableTransport(IList<Transport> participants)
    {
        Console.WriteLine();
        Console.WriteLine("Доступные участники гонки:");
        for (var i = 0; i < participants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {participants[i].Name}");
        }

        Console.WriteLine("Для старта гонки введите: старт");
        Console.WriteLine();
    }
}