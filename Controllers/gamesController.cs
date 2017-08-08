
using PMNL.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace PMNL.api.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {

        // private Contexto db = new Contexto();
        private Contexto db;
        
        public GamesController(Contexto cn){
            db = cn;
        }

        [HttpGet]
        public IActionResult Get(){
            var games = db.Games
            .Include(x => x.Tournament)
            .Include(x => x.GamesResults)
                .ThenInclude(c => c.TournamentPlayer)
                .ThenInclude(p => p.Player)
            .ToList()
            .Select( x => new {
                id = x.Id,
                description = x.Description,
                date = x.Date, 
                buyinns = x.Buyinns,
                rebuys = x.Rebuys,
                valueTotal = x.ValueTotal,
                tournament = x.Tournament,
                gamesResults = x.GamesResults.Select(p => new {p.Order, p.TournamentPlayer.Player.Name, p.Points}).OrderBy(o => o.Order),
            });

            return Ok(games);

        }        

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Game game)
        {
            game.Date = DateTime.Now;

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            int nrJogadores = game.GamesResults.Count();
            TournamentPlayer playerAlter;

            foreach (var item in game.GamesResults)
            {
                item.Points = getPoints(nrJogadores, item.Order);

                playerAlter = db.TournamentsPlayers.SingleOrDefault(x => x.Id == item.TournamentPlayerId);
                playerAlter.Points += item.Points;

                if (item.Order == 1){
                    playerAlter.Wins ++;
                }

                db.Update(playerAlter);

                playerAlter = null;
            }

            db.Games.Add(game);
            db.SaveChanges();

            return Ok();            

        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            var game = db.Games.Single(t => t.Id == id);

            db.Games.Remove(game);
            db.SaveChanges();
        }

        private int getPoints(int nrJogadores, int posicao) {
            int[][] pontuacao = new int[][]{
                new int[5]{11,7,4,2,1}, //0
                new int[6]{14,9,6,4,2,1}, //1
                new int[7]{17,11,8,5,3,2,1}, //2
                new int[8]{19,13,9,6,4,3,2,1}, //3
                new int[9]{21,15,10,7,5,4,3,2,1}, //4
                new int[10]{23,16,11,8,6,5,4,3,2,1}, //5
                new int[11]{24,17,12,9,7,6,5,4,3,2,1}, //6
                new int[12]{25,18,13,10,8,7,6,5,4,3,2,1} //7
            };

            return pontuacao[nrJogadores - 5][posicao - 1];

        }

       
    }
}
