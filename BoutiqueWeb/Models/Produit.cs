namespace BoutiqueWeb.Models;

public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public int Prix { get; set; }
    public ProduitType Type { get; set; }

    public Produit() { }

    public Produit(ProduitDTO produitDTO)
    {
        Id = produitDTO.Id;
        Nom = produitDTO.Nom;
        Prix = produitDTO.Prix;
        Type = (ProduitType)Enum.Parse(typeof(ProduitType), produitDTO.Type, true);
    }

    // [Tests] Calcul du nombre de clients ayant acheté un même produit
    public int CalculerNombreClients(List<Commande> commandes)
    {
        var clientsAcheteurs = commandes
            .Where(c => c.ProduitId == this.Id) // Filtrer les commandes par produit
            .Select(c => c.ClientId) // Extraire les identifiants des clients
            .Distinct() // Garder seulement les clients uniques
            .Count(); // Compter le nombre de clients

        return clientsAcheteurs;
    }
}
