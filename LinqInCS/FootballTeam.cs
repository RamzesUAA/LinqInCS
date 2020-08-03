using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInCS
{
    class FootballTeam
    {
        public FootballTeam(string ClubName, List<Footballer> command, string nameOfTrainer)
        {
            NameOfClub = ClubName;
            Command = command;
            Trainer = nameOfTrainer;
        }
        public string NameOfClub { get; set; }
        public List<Footballer> Command { get; set; }
        public string Trainer { get; set; }

    }
}