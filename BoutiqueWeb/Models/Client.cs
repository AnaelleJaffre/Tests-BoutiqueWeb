namespace BoutiqueWeb.Models;

public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Adresse { get; set; } = null!;
    public List<Commande> ListeCommandes { get; set; } = new List<Commande>();

    public Client() { }

    public Client(ClientDTO clientDTO)
    {
        Id = clientDTO.Id;
        Nom = clientDTO.Nom;
        Prenom = clientDTO.Prenom;
        Adresse = clientDTO.Adresse;
    }

    // [Test] Calculer le montant total que le client a dépensé sur l'application
    public decimal CalculerTotalDepense()
    {
        decimal total = 0;

        foreach (Commande commande in ListeCommandes)
        {
            total += commande.CalculerPrixTotal();
        }

        return total;
    }
}
