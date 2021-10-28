using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChessTournament.Models;
using ChessTournament.Service;

namespace ChessTournament.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        public TournamentController()
        {

        }

        [HttpGet]
        public ActionResult<List<Tournament>> GetAll() =>
            TournamentData.GetAll();


        [HttpGet("{name}")]
        public ActionResult<Tournament> Get(string name)
        {
            var tournament = TournamentData.Get(name);

            if(tournament == null)
                return NotFound();

            return tournament;
        }

        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {            
            TournamentData.Add(tournament);
            return CreatedAtAction(nameof(Create), new { name = tournament.Name }, tournament);
        }

        [HttpPut("{name}")]
        public IActionResult Update(string name,Tournament tournament)
        {
            if (name != tournament.Name)
                return BadRequest();

            var existingTournament =TournamentData.Get(name);
            if(existingTournament is null)
                return NotFound();

            TournamentData.Update(tournament);           

            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var tournament = TournamentData.Get(name);

            if (tournament is null)
                return NotFound();

            TournamentData.Delete(name);

            return NoContent();
        }
    }
}
