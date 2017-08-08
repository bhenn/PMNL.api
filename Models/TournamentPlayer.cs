namespace PMNL.api.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }
        public int PlayerId { get; set; }


        public int Wins { get; set; }
        public int Points { get; set; }


        public Player Player { get; set; }
        public Tournament Tournament { get; set; }

    }

}