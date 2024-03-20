using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentesConsole.Data;
using VentesConsole.Models;

namespace VentesConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleModelsController : ControllerBase
    {
        private readonly VentesConsoleContext _context;

        public ConsoleModelsController(VentesConsoleContext context)
        {
            _context = context;
        }

        // GET: api/ConsoleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsoleModel>>> GetConsoleModel()
        {
            return await _context.ConsoleModel.ToListAsync();
        }

        // GET: api/ConsoleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsoleModel>> GetConsoleModel(int id)
        {
            var consoleModel = await _context.ConsoleModel.FindAsync(id);

           if (consoleModel == null)
            {
                return NotFound();
            }

            return consoleModel;
        }

        // PUT: api/ConsoleModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsoleModel(int id, ConsoleModel consoleModel)
        {
            if (id != consoleModel.ConsoleId)
            {
                return BadRequest();
            }

            _context.Entry(consoleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleModelExists(id))
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

        // POST: api/ConsoleModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsoleModel>> PostConsoleModel(ConsoleModel consoleModel)
        {
            _context.ConsoleModel.Add(consoleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsoleModel", new { id = consoleModel.ConsoleId }, consoleModel);
        }

        // DELETE: api/ConsoleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsoleModel(int id)
        {
            var consoleModel = await _context.ConsoleModel.FindAsync(id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            _context.ConsoleModel.Remove(consoleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsoleModelExists(int id)
        {
            return _context.ConsoleModel.Any(e => e.ConsoleId == id);
        }
    }
}
