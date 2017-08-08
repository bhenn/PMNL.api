using Microsoft.EntityFrameworkCore;
using PMNL.api.Models;

namespace PMNL.api
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            : base(options) {}


        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentPlayer> TournamentsPlayers { get; set; }

    }

}
