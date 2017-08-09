
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PMNL.api.Controllers
{
    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {

        private Contexto db;
        
        public TournamentsController(Contexto cn){
            db = cn;
        }

        [HttpGet]
        public IActionResult Get(){
            var tournaments = db.Tournaments
            .Include(x => x.Games)
                .ThenInclude(gs => gs.GamesResults)
                .ThenInclude(p => p.TournamentPlayer)
                .ThenInclude(p => p.Player)
            .Include(x => x.TournamentPlayers)
                .ThenInclude(p => p.Player)
            .ToList().OrderByDescending(o => o.Id)
            .Select(x => new {
                id = x.Id,
                description = x.Description,
                tournamentPlayers = x.TournamentPlayers.Select(t => new {
                    t.Id,
                    t.Player.Name,
                    t.Points,
                    t.Wins
                }).OrderByDescending(o => o.Points),
                games = x.Games.OrderByDescending(o => o.Id).Select( y => new {
                    y.Id,
                    y.Description,
                    y.Date,
                    y.Rebuys,
                    y.ValueTotal,
                    GamesResults = y.GamesResults.Select(p => new {p.Order, p.TournamentPlayer.Player.Name, p.Points}).OrderBy(o => o.Order)
                })
            });
            return Ok(tournaments);
        } 
    }
}
