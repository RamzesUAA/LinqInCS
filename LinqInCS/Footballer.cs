using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInCS
{
    class Footballer
    {
        public int numberOfPlayer;
        public string Name { get; set; }
        public int Year { get; set; }

        public FootballTeam FootballTeam;

        public override string ToString()
        {
            return $"Name: {Name} Year: {Year} NameOfClub: {FootballTeam.NameOfClub}";
        }
    }
}