using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1;
using FootballPlayerREST.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkPlayerID=397860

namespace FootballPlayerREST.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class FootballplayersController : ControllerBase
    {
        // GET: api/<FootballPlayerController>
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersController>
        [HttpGet]
        public IEnumerable<FootballPlayer> GetAll()
        {
            return _manager.GetAll();
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{PlayerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<FootballPlayer> GetByPlayerID(int PlayerID)
        {
            FootballPlayer footballPlayer = _manager.GetByPlayerID(PlayerID);
            if(footballPlayer == null) return NotFound("No Such FootballPlayer with PlayerID:"+PlayerID);
            return Ok(footballPlayer);
        }

        // POST api/<FootballPlaersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<FootballPlayer> Add([FromBody] FootballPlayer value)
        {
            //FootballPlayer FootballPlayer = new FootballPlayer(value);
            FootballPlayer footballPlayer = value;
            footballPlayer = _manager.Add(value);
            return Created("/"+footballPlayer.PlayerID,footballPlayer);
        }

        // PUT api/<FootballPlayersController>/5  - Opgaven bad ikke om PUT / Update
        //[HttpPut("{PlayerID}")]
        //public FootballPlayer Put(int PlayerID, [FromBody] FootballPlayer value)
        //{
        //    return _manager.Update(PlayerID, value);
        //} 

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{PlayerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<FootballPlayer> Delete(int PlayerID)
        {
            FootballPlayer footballPlayer = _manager.GetByPlayerID(PlayerID);
            if(footballPlayer == null) return NotFound("No Such FootballPlayer with PlayerID:"+PlayerID);
            return Ok(_manager.Delete(PlayerID));
            
        }
    }
}
