using BoutiqueWeb.Data;
using BoutiqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestion.Controllers;

[ApiController]
[Route("api/gestion/client")]
public class GestionController : ControllerBase
{
    private readonly BoutiqueWebContext _context;

    public GestionController(BoutiqueWebContext context)
    {
        _context = context;
    }

    // GET: api/gestion/client
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetGestionClients()
    {
        // Get clients and related lists
        // Task<ActionResult<IEnumerable<ClientDTO>>> GetClients();
        // var clients = _context.Produits.Select(x => new ClientDTO());
        var clients = _context.Clients;
        foreach (var c in clients)
        {
            // c.ListeCommandes = _context.Commandes;
        }
        return await clients.ToListAsync();
    }

    // // GET: api/client/2 -> pas utiliser ici mais potentiellement utile
    // [HttpGet("{id}")]
    // public async Task<ActionResult<ProduitDTO>> GetProduit(int id)
    // {
    //     // Find client and related list
    //     // SingleAsync() throws an exception if no client is found (which is possible, depending on id)
    //     // SingleOrDefaultAsync() is a safer choice here
    //     var client = await _context.Produits.SingleOrDefaultAsync(t => t.Id == id);

    //     if (client == null)
    //         return NotFound();

    //     return new ProduitDTO(client);
    // }
}
