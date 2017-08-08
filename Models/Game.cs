using System.Collections.Generic;
using System;

namespace PMNL.api.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int Buyinns { get; set; }

        public int Rebuys { get; set; }

        public decimal ValueTotal { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament {get;set;}

        public ICollection<GameResults> GamesResults { get; set; }

    }

}