using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueWeb.Models;
using BoutiqueWeb.Data;

namespace ApiCommande.Controllers;

[ApiController]
[Route("api/commande")]
public class CommandeController : ControllerBase
{
    private readonly BoutiqueWebContext _context;

    public CommandeController(BoutiqueWebContext context)
    {
        _context = context;
    }

    // GET: api/commande
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommandeDTO>>> GetCommandes()
    {
        // Get commandes and related lists
        var commandes = _context.Commandes.Select(x => new CommandeDTO(x));
        return await commandes.ToListAsync();
    }


    // GET: api/commande/2
    [HttpGet("{id}")]
    public async Task<ActionResult<CommandeDTO>> GetCommande(int id)
    {
        // Find commande and related list
        // SingleAsync() throws an exception if no commande is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var commande = await _context.Commandes.SingleOrDefaultAsync(t => t.Id == id);

        if (commande == null)
            return NotFound();

        return new CommandeDTO(commande);
    }

    // POST: api/Commande
    [HttpPost]
    public async Task<ActionResult<Commande>> PostCommande(CommandeDTO commandeDTO)
    {
        Commande commande = new(commandeDTO);

        _context.Commandes.Add(commande);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCommande), new { id = commande.Id }, new CommandeDTO(commande));
    }

    // PUT: api/commande/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommande(int id, CommandeDTO commandeDTO)
    {
        if (id != commandeDTO.Id)
        {
            return BadRequest();
        }

        Commande commande = new(commandeDTO);

        _context.Entry(commande).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Commandes.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/commande/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommandeItem(int id)
    {
        var commande = await _context.Commandes.FindAsync(id);

        if (commande == null)
            return NotFound();

        _context.Commandes.Remove(commande);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}