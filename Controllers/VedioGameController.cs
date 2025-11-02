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
    }
}
