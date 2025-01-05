using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueWeb.Models;
using BoutiqueWeb.Data;

namespace ApiClient.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly BoutiqueWebContext _context;

    public ClientController(BoutiqueWebContext context)
    {
        _context = context;
    }

    // GET: api/client
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
    {
        // Get clients and related lists
        var clients = _context.Clients.Select(x => new ClientDTO(x));
        return await clients.ToListAsync();
    }

    // GET: api/client/2
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> GetClient(int id)
    {
        // Find client and related list
        // SingleAsync() throws an exception if no client is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var client = await _context.Clients.SingleOrDefaultAsync(t => t.Id == id);

        if (client == null)
            return NotFound();

        return new ClientDTO(client);
    }

    // POST: api/Client
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(ClientDTO clientDTO)
    {
        Client client = new(clientDTO);

        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, new ClientDTO(client));
    }

    // PUT: api/client/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, ClientDTO clientDTO)
    {
        if (id != clientDTO.Id)
        {
            return BadRequest();
        }

        Client client = new(clientDTO);

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Clients.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/client/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClientItem(int id)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
            return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}