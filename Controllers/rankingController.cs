using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace PMNL.api.Controllers
{
    [Route("api/[controller]")]
    public class RankingController : Controller
    {

        // private Contexto db = new Contexto();
        private Contexto db;
        
        public RankingController(Contexto cn){
            db = cn;
        }

        [HttpGet]
        public IActionResult Get(){
            var ranking = db.Tournaments
                            .Include(x => x.TournamentPlayers)
                                .ThenInclude(p => p.Player)
                            .Select(x => new {
                                x.Description,
                                x.Id,
                                TournamentPlayers = x.TournamentPlayers.Select( p => new {
                                    p.Player.Name,
                                    p.Points,
                                    p.Wins
                                }).OrderByDescending(o => o.Points)
                            }
                            )
                            .ToList().OrderByDescending(o => o.Id);

            return Ok(ranking);
        } 
    }
}
