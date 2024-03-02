using Jujustu_API.Data;
using Jujustu_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jujustu_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Moves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Move>>> GetMoves()
        {
            return await _context.Moves.ToListAsync();
        }

        // GET: api/Moves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Move>> GetMove(int id)
        {
            var move = await _context.Moves.FindAsync(id);

            if (move == null)
            {
                return NotFound();
            }

            return move;
        }

        // PUT: api/Moves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMove(int id, Move move)
        {
            if (id != move.Id)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Moves
        [HttpPost]
        public async Task<ActionResult<Move>> PostMove(Move move)
        {
            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMove), new { id = move.Id }, move);
        }

        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMove(int id)
        {
            var move = await _context.Moves.FindAsync(id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Moves.Remove(move);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoveExists(int id)
        {
            return _context.Moves.Any(e => e.Id == id);
        }
    }
}