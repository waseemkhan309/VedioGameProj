using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VedioGameAPI.Model;

namespace VedioGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VedioGameController : ControllerBase
    {
        static private List<VedioGame> vedioGames = new List<VedioGame> { 
            new VedioGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
            new VedioGame { Id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" }, 
            new VedioGame { Id = 3, Title = "Red Dead Redemption 2", Platform = "PlayStation 4, Xbox One, PC", Developer = "Rockstar Games", Publisher = "Rockstar Games" }
        };

        [HttpGet]
        public ActionResult<List<VedioGame>> GetVedioGames()
        {
            return Ok(vedioGames);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<VedioGame> GetVedioGameById(int id) {             
            var vedioGame = vedioGames.FirstOrDefault(vg => vg.Id == id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            return Ok(vedioGame);
        }

        [HttpPost]
        public ActionResult<VedioGame> CreateVedioGame([FromBody] VedioGame vedioGame) { 
            if(vedioGame == null)
            {
                return BadRequest();
            }

            vedioGame.Id = vedioGames.Max(vg => vg.Id) + 1;
            vedioGames.Add(vedioGame);
            return CreatedAtAction(nameof(GetVedioGameById), new { id = vedioGame.Id }, vedioGame); 
        }

        [HttpPut("{id}")]
        public ActionResult UpdateVedioGame(int id, [FromBody] VedioGame updatedVedioGame)
        {
            var vedioGame = vedioGames.FirstOrDefault(vg => vg.Id == id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            vedioGame.Title = updatedVedioGame.Title;
            vedioGame.Platform = updatedVedioGame.Platform;
            vedioGame.Developer = updatedVedioGame.Developer;
            vedioGame.Publisher = updatedVedioGame.Publisher;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVedioGame(int id)
        {
            var vedioGame = vedioGames.FirstOrDefault(vg => vg.Id == id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            vedioGames.Remove(vedioGame);
            return NoContent();
        }
}
