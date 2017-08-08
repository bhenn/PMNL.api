namespace PMNL.api.Models
{
    public class GameResults
    {
        
        public int Id { get; set; }

        public int GameId { get; set; }
        public int TournamentPlayerId { get; set; }

        public int Order { get; set; }
        public int Points { get; set; }
        public int Rebuys { get; set; }

        public TournamentPlayer TournamentPlayer { get; set; }
        public Game Game { get; set; }
        
        
    }
}