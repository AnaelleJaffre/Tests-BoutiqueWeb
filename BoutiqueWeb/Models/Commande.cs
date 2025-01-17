using System.Runtime.InteropServices;

namespace BoutiqueWeb.Models;

public class Commande
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ProduitId { get; set; }
    public int Quantite { get; set; }
    public DateOnly Date { get; set; }
    public Client Client { get; set; } = null!;
    public Produit Produit { get; set; } = null!;

    public Commande() { }

    public Commande(CommandeDTO commandeDTO)
    {
        Id = commandeDTO.Id;
        ClientId = commandeDTO.Client_id;
        ProduitId = commandeDTO.Produit_id;
        Quantite = commandeDTO.Quantite;
        Date = commandeDTO.Date;
    }

    // [Tests] Calcul du prix total
    public decimal CalculerPrixTotal()
    {
        return Produit.Prix * Quantite;
    }
}
