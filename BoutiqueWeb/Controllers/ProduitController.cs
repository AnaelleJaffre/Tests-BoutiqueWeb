using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoutiqueWeb.Models;
using BoutiqueWeb.Data;

namespace ApiProduit.Controllers;

[ApiController]
[Route("api/produit")]
public class ProduitController : ControllerBase
{
    private readonly BoutiqueWebContext _context;

    public ProduitController(BoutiqueWebContext context)
    {
        _context = context;
    }

    // GET: api/produit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProduitDTO>>> GetProduits()
    {
        // Get produits and related lists
        var produits = _context.Produits.Select(x => new ProduitDTO(x));
        return await produits.ToListAsync();
    }

    // GET: api/produit/2
    [HttpGet("{id}")]
    public async Task<ActionResult<ProduitDTO>> GetProduit(int id)
    {
        // Find produit and related list
        // SingleAsync() throws an exception if no produit is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var produit = await _context.Produits.SingleOrDefaultAsync(t => t.Id == id);

        if (produit == null)
            return NotFound();

        return new ProduitDTO(produit);
    }

    // POST: api/Produit
    [HttpPost]
    public async Task<ActionResult<Produit>> PostProduit(ProduitDTO produitDTO)
    {
        Produit produit = new(produitDTO);

        _context.Produits.Add(produit);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduit), new { id = produit.Id }, new ProduitDTO(produit));
    }

    // PUT: api/produit/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduit(int id, ProduitDTO produitDTO)
    {
        if (id != produitDTO.Id)
        {
            return BadRequest();
        }

        Produit produit = new(produitDTO);

        _context.Entry(produit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Produits.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/produit/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduitItem(int id)
    {
        var produit = await _context.Produits.FindAsync(id);

        if (produit == null)
            return NotFound();

        _context.Produits.Remove(produit);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}