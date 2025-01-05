namespace BoutiqueWeb.Models;

public class ClientDTO
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Adresse { get; set; } = null!;

    public ClientDTO() { }

    public ClientDTO(Client client)
    {
        Id = client.Id;
        Nom = client.Nom;
        Prenom = client.Prenom;
        Adresse = client.Adresse;
    }
}
