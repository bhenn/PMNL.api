using System.Collections.Generic;

namespace PMNL.api.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<TournamentPlayer> TournamentPlayers { get; set; }
        
    }

}