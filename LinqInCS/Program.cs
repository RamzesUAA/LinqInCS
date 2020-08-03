using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInCS
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {

            var listOfFootballers1 = new List<Footballer>();
            var KarpatyLviv = new FootballTeam("Karpaty Lviv", listOfFootballers1, "Roman Gnativ");
            for (int i = 0; i < 11; i++)
            {
                listOfFootballers1.Add(new Footballer()
                {
                    numberOfPlayer = i,
                    Name = $"Player {i}",
                    Year = rnd.Next(1991, 2002),
                    FootballTeam = KarpatyLviv
                });
            }

            var top5TheMostYoungestPlayers = (from player in KarpatyLviv.Command
                                              select player).OrderByDescending(player => player.Year).Take(5);
            Console.WriteLine("Top 5 the most yongest players:");

            foreach (var player in top5TheMostYoungestPlayers)
            {
                Console.WriteLine($"Name: {player.Name} Year: {player.Year} NameOfClub: {player.FootballTeam.NameOfClub}");
            }
            Console.WriteLine();


            var minYear = KarpatyLviv.Command.Min(player => player.Year);
            var theMostOlderPlayers = from player in KarpatyLviv.Command
                                      where player.Year.Equals(minYear)
                                      select player;

            Console.WriteLine("The most older player:");

            foreach (var player in theMostOlderPlayers)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine();

            var playersWithTheSameYears = KarpatyLviv.Command.OrderByDescending(player => player.Year).GroupBy(player => player.Year);
            foreach (var group in playersWithTheSameYears)
            {
                Console.WriteLine($"Year: {group.Key}");
                foreach (var player in group)
                {
                    Console.WriteLine($"\t{player}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Reversed list of players:");
            KarpatyLviv.Command.Reverse();
            foreach (var player in KarpatyLviv.Command)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine();

            Console.WriteLine(KarpatyLviv.Command.All(player => player.Name.StartsWith("T"))); // false
            Console.WriteLine(KarpatyLviv.Command.All(player => player.Name.StartsWith("P"))); // true
            Console.WriteLine(KarpatyLviv.Command.Any(player => player.Year == 2000));


            var listOfFootballers2 = new List<Footballer>();
            FootballTeam ShakhtarDonetsk = new FootballTeam("Shakhtar Donetsk", listOfFootballers2, "Luis Castro");

            for (int i = 0; i < 11; i++)
            {
                listOfFootballers2.Add(new Footballer()
                {
                    numberOfPlayer = i + 5,
                    Name = $"Player {i + 5}",
                    Year = rnd.Next(1991, 2002),
                    FootballTeam = ShakhtarDonetsk
                });
            }


            Console.WriteLine("Union of two commands:");
            var union = ShakhtarDonetsk.Command.Union(KarpatyLviv.Command);
            foreach (var player in union)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine();

            Console.WriteLine("Intersect of two commands:");
            var intersect = ShakhtarDonetsk.Command.Intersect(KarpatyLviv.Command);
            foreach (var player in intersect)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine();

            var sumOfYear = ShakhtarDonetsk.Command.Sum(p => p.Year);
            Console.WriteLine("Sum of years of whole Shakhtar team: ");
            Console.WriteLine(sumOfYear);


            var elementAt = ShakhtarDonetsk.Command.ElementAt(4);
            Console.WriteLine(elementAt);


            var last = ShakhtarDonetsk.Command.LastOrDefault();
            var first = KarpatyLviv.Command.First(p => p.Year > 1995);

        }
    }
}
