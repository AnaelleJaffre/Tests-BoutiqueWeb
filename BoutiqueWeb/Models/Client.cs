namespace BoutiqueWeb.Models;

public class Client
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Adresse { get; set; } = null!;
    public List<Commande> ListeCommandes { get; set; } = null!;

    public Client() { }

    public Client(ClientDTO clientDTO) {
        Id = clientDTO.Id;
        Nom = clientDTO.Nom;
        Prenom = clientDTO.Prenom;
        Adresse = clientDTO.Adresse;
    }
}