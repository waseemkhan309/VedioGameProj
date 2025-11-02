using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using VedioGameAPI.Data;
using VedioGameAPI.Model;

namespace VedioGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VedioGameController : ControllerBase
    {
        private readonly VedioGameDbContext _context;

        public VedioGameController(VedioGameDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VedioGame>>> GetVedioGames()
        {
            return Ok( _context.VedioGames.ToListAsync() );
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VedioGame>> GetVedioGameById(int id)
        {
            var vedioGame = await _context.VedioGames.FindAsync(id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            return Ok(vedioGame);
        }

        [HttpPost]
        public async Task<ActionResult<VedioGame>> CreateVedioGame([FromBody] VedioGame vedioGame)
        {
            if (vedioGame == null)
            {
                return BadRequest();
            }

            
            _context.VedioGames.AddAsync(vedioGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVedioGameById), new { id = vedioGame.Id }, vedioGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVedioGame(int id, [FromBody] VedioGame updatedVedioGame)
        {
            var vedioGame = await _context.VedioGames.FindAsync( id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            vedioGame.Title = updatedVedioGame.Title;
            vedioGame.Platform = updatedVedioGame.Platform;
            vedioGame.Developer = updatedVedioGame.Developer;
            vedioGame.Publisher = updatedVedioGame.Publisher;
            
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVedioGame(int id)
        {
            var vedioGame = await _context.VedioGames.FindAsync(id);
            if (vedioGame == null)
            {
                return NotFound();
            }
            _context.VedioGames.Remove(vedioGame);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
