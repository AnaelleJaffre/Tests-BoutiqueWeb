namespace BoutiqueWeb.Models;

public class CommandeDTO
{
    public int Id { get; set; }
    public int Client_id { get; set; }
    public int Produit_id { get; set; }
    public int Quantite { get; set; }
    public string Date { get; set; } = null!;

    public CommandeDTO() { }

    public CommandeDTO(Commande commande) {
        Id = commande.Id;
        Client_id = commande.ClientId;
        Produit_id = commande.ProduitId;
        Quantite = commande.Quantite;
        Date = commande.Date;
    }

}
